using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class TestServer: IDisposable
    {
        private Process _process;

        public HttpClient Client { get; private set; }


        public void StartProcess()
        {
            var portPhrase = "port: ";
            var nodeModules = FindNodeModulesDirectory();
            var wiremock = Path.Combine(nodeModules, "wiremock", "jdeploy-bundle");
            var wiremockJar = Directory.GetFiles(wiremock, "*.jar").Single();
            var root = Path.Combine(nodeModules, "@autorest", "test-server");

            var processStartInfo = new ProcessStartInfo("java", $"-jar {wiremockJar} --root-dir {root} --port 0");
            // Use random port
            processStartInfo.Environment["PORT"] = "0";
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;

            _process = Process.Start(processStartInfo);
            ProcessTracker.Add(_process);
            while (!_process.HasExited)
            {
                var s = _process.StandardOutput.ReadLine();
                if (s?.StartsWith(portPhrase) == true)
                {
                    Client = new HttpClient()
                    { 
                        BaseAddress = new Uri($"http://localhost:{s.Substring(portPhrase.Length).Trim()}")
                    };
                    return;
                }
            }

            if (Client == null)
            {
                throw new InvalidOperationException($"Unable to detect server port {_process.StandardOutput.ReadToEnd()} {_process.StandardError.ReadToEnd()}");
            }

        }

        private string FindNodeModulesDirectory()
        {
            var assemblyFile = new DirectoryInfo(typeof(TestServer).Assembly.Location);
            var directory = assemblyFile.Parent;
            
            do
            {
                var testServerDirectory = Path.Combine(directory.FullName, "node_modules");
                if (Directory.Exists(testServerDirectory))
                {
                    return testServerDirectory;
                }

                directory = directory.Parent;
            } while (directory != null);

            throw new InvalidOperationException($"Cannot find 'node_modules' in parent directories of {typeof(TestServer).Assembly.Location}.");
        }

        public async Task<string[]> GetUnmatchedRequests()
        {
            var coverageString = await Client.GetStringAsync("/__admin/requests/unmatched");
            var coverageDocument = JsonDocument.Parse(coverageString);

            return coverageDocument.RootElement.GetProperty("requests").EnumerateArray().Select(request => request.ToString()).ToArray();
        }

        public async Task ResetAsync()
        {
            var response = await Client.PostAsync("/__admin/requests/reset", new ByteArrayContent(Array.Empty<byte>()));
            response.EnsureSuccessStatusCode();
        }

        public async Task<string[]> GetMatchedStubs()
        {
            var coverageString = await Client.GetStringAsync("/__admin/requests/");
            var coverageDocument = JsonDocument.Parse(coverageString);

            List<string> results = new List<string>();
            foreach (var request in coverageDocument.RootElement.GetProperty("requests").EnumerateArray())
            {
                var mapping = request.GetProperty("stubMapping");
                if (mapping.TryGetProperty("name", out var mappingName))
                {
                    results.Add(mappingName.GetString());
                }
            }

            return results.ToArray();
        }

        public void Stop()
        {
            _process.Kill(true);
        }

        public void Dispose()
        {
            Stop();

            _process?.Dispose();
            Client?.Dispose();
        }

        // Uses Windows Job Objects to ensure external processes are killed if the current process is terminated non-gracefully.
        internal static class ProcessTracker
        {
            private static readonly IntPtr _jobHandle;

            static ProcessTracker()
            {
                // Requires Win8 or later
                if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || Environment.OSVersion.Version < new Version(6, 2))
                {
                    return;
                }

                // Job name is optional but helps with diagnostics.  Job name must be unique if non-null.
                _jobHandle = CreateJobObject(IntPtr.Zero, name: $"ProcessTracker{Process.GetCurrentProcess().Id}");

                var extendedInfo = new JOBOBJECT_EXTENDED_LIMIT_INFORMATION
                {
                    BasicLimitInformation = new JOBOBJECT_BASIC_LIMIT_INFORMATION
                    {
                        LimitFlags = JOBOBJECTLIMIT.JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE
                    }
                };

                var length = Marshal.SizeOf(typeof(JOBOBJECT_EXTENDED_LIMIT_INFORMATION));
                var extendedInfoPtr = Marshal.AllocHGlobal(length);
                try
                {
                    Marshal.StructureToPtr(extendedInfo, extendedInfoPtr, false);

                    if (!SetInformationJobObject(_jobHandle, JobObjectInfoType.ExtendedLimitInformation,
                        extendedInfoPtr, (uint)length))
                    {
                        throw new Win32Exception();
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(extendedInfoPtr);
                }
            }

            public static void Add(Process process)
            {
                if (_jobHandle != IntPtr.Zero)
                {
                    var success = AssignProcessToJobObject(_jobHandle, process.Handle);
                    if (!success && !process.HasExited)
                    {
                        throw new Win32Exception();
                    }
                }
            }

            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            static extern IntPtr CreateJobObject(IntPtr lpJobAttributes, string name);

            [DllImport("kernel32.dll")]
            static extern bool SetInformationJobObject(IntPtr job, JobObjectInfoType infoType,
                IntPtr lpJobObjectInfo, uint cbJobObjectInfoLength);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool AssignProcessToJobObject(IntPtr job, IntPtr process);

            private enum JobObjectInfoType
            {
                AssociateCompletionPortInformation = 7,
                BasicLimitInformation = 2,
                BasicUIRestrictions = 4,
                EndOfJobTimeInformation = 6,
                ExtendedLimitInformation = 9,
                SecurityLimitInformation = 5,
                GroupInformation = 11
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct JOBOBJECT_BASIC_LIMIT_INFORMATION
            {
                public Int64 PerProcessUserTimeLimit;
                public Int64 PerJobUserTimeLimit;
                public JOBOBJECTLIMIT LimitFlags;
                public UIntPtr MinimumWorkingSetSize;
                public UIntPtr MaximumWorkingSetSize;
                public UInt32 ActiveProcessLimit;
                public Int64 Affinity;
                public UInt32 PriorityClass;
                public UInt32 SchedulingClass;
            }

            [Flags]
            private enum JOBOBJECTLIMIT : uint
            {
                JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE = 0x2000
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct IO_COUNTERS
            {
                public UInt64 ReadOperationCount;
                public UInt64 WriteOperationCount;
                public UInt64 OtherOperationCount;
                public UInt64 ReadTransferCount;
                public UInt64 WriteTransferCount;
                public UInt64 OtherTransferCount;
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct JOBOBJECT_EXTENDED_LIMIT_INFORMATION
            {
                public JOBOBJECT_BASIC_LIMIT_INFORMATION BasicLimitInformation;
                public IO_COUNTERS IoInfo;
                public UIntPtr ProcessMemoryLimit;
                public UIntPtr JobMemoryLimit;
                public UIntPtr PeakProcessMemoryUsed;
                public UIntPtr PeakJobMemoryUsed;
            }
        }
    }
}