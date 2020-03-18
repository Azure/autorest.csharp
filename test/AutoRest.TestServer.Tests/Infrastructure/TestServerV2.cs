// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoRest.TestServer.Tests.Infrastructure
{
    public class TestServerV2 : IDisposable, ITestServer
    {
        private readonly Process _process;

        public HttpClient Client { get; }
        public string Host { get; }

        public TestServerV2()
        {
            var portPhrase = "port: ";
            var nodeModules = FindNodeModulesDirectory();
            var wiremock = Path.Combine(nodeModules, "wiremock", "jdeploy-bundle");
            var wiremockJar = Directory.GetFiles(wiremock, "*.jar").Single();
            var root = GetBaseDirectory();

            var processStartInfo = new ProcessStartInfo("java", $"-jar {wiremockJar} --root-dir {root} --port 0");
            // Use random port
            processStartInfo.Environment["PORT"] = "0";
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;

            _process = Process.Start(processStartInfo);
            ProcessTracker.Add(_process);
            Debug.Assert(_process != null);
            while (!_process.HasExited)
            {
                var s = _process.StandardOutput.ReadLine();
                if (s?.StartsWith(portPhrase) == true)
                {
                    Host = $"http://localhost:{s.Substring(portPhrase.Length).Trim()}";
                    Client = new HttpClient
                    {
                        BaseAddress = new Uri(Host)
                    };
                    _ = Task.Run(() => ReadOutput(_process.StandardError));
                    _ = Task.Run(() => ReadOutput(_process.StandardOutput));
                    return;
                }
            }

            if (Client == null)
            {
                throw new InvalidOperationException($"Unable to detect server port {_process.StandardOutput.ReadToEnd()} {_process.StandardError.ReadToEnd()}");
            }

        }

        public static string GetBaseDirectory()
        {
            return Path.Combine(FindNodeModulesDirectory(), "@microsoft.azure", "autorest.testserver");
        }

        public static string FindNodeModulesDirectory()
        {
            var assemblyFile = new DirectoryInfo(typeof(TestServerV2).Assembly.Location);
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

            throw new InvalidOperationException($"Cannot find 'node_modules' in parent directories of {typeof(TestServerV2).Assembly.Location}.");
        }

        public async Task<string[]> GetRequests()
        {
            var coverageString = await Client.GetStringAsync("/__admin/requests/unmatched");
            var coverageDocument = JsonDocument.Parse(coverageString);

            return coverageDocument.RootElement.GetProperty("requests").EnumerateArray().Select(request => request.ToString()).ToArray();
        }

        public async Task ResetAsync()
        {
            ByteArrayContent emptyContent = new ByteArrayContent(Array.Empty<byte>());

            using var response = await Client.PostAsync("/__admin/reset", emptyContent);
            response.EnsureSuccessStatusCode();
        }

        public async Task<string[]> GetMatchedStubs(string testName)
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

        private void ReadOutput(StreamReader stream)
        {
            while (!_process.HasExited && !stream.EndOfStream)
            {
                stream.ReadToEnd();
            }
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
    }
}
