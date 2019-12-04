// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoRest.TestServer.Tests
{
    public class TestServerV1 : IDisposable, ITestServer
    {
        private Process _process;
        private List<string> _lines = new List<string>();

        public HttpClient Client { get; }
        public string Host { get; }

        public TestServerV1()
        {
            var portPhrase = "Server started at port ";
            var nodeModules = TestServerV2.FindNodeModulesDirectory();
            var startup = Path.Combine(nodeModules, "@microsoft.azure", "autorest.testserver", "startup", "www.js");

            var processStartInfo = new ProcessStartInfo("node", @"d:\github\azure\autorest.testserver\startup\www.js");

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
                    Host = $"http://localhost:{s.Substring(portPhrase.Length).Trim()}";
                    Client = new HttpClient()
                    {
                        BaseAddress = new Uri(Host),
                        Timeout = TimeSpan.FromSeconds(1),
                    };
                    _ = Task.Run(ReadOutput);
                    return;
                }

            }

            if (Client == null)
            {
                throw new InvalidOperationException($"Unable to detect server port {_process.StandardOutput.ReadToEnd()} {_process.StandardError.ReadToEnd()}");
            }

        }

        private void ReadOutput()
        {
            while (!_process.HasExited && !_process.StandardOutput.EndOfStream)
            {
                _process.StandardOutput.ReadToEnd();
                _process.StandardError.ReadToEnd();
            }
        }

        public Task<string[]> GetRequests()
        {
            return Task.FromResult(Array.Empty<string>());
        }

        public async Task ResetAsync()
        {
            ByteArrayContent emptyContent = new ByteArrayContent(Array.Empty<byte>());

            using var response = await Client.PostAsync("/coverage/clear", emptyContent);
            response.EnsureSuccessStatusCode();
        }

        public async Task<string[]> GetMatchedStubs()
        {
            var coverageString = await Client.GetStringAsync("/coverage");
            var coverageDocument = JsonDocument.Parse(coverageString);

            List<string> results = new List<string>();
            foreach (var request in coverageDocument.RootElement.EnumerateObject())
            {
                var mapping = request.Name;
                if (request.Value.GetInt32() != 0)
                {
                    results.Add(mapping);
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
    }
}
