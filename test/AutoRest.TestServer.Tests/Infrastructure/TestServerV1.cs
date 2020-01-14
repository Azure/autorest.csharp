// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoRest.TestServer.Tests.Infrastructure
{
    public class TestServerV1 : IDisposable, ITestServer
    {
        private static readonly Regex _scenariosRegex = new Regex("(coverage|optionalCoverage|optCoverage)\\[(\"|')(?<name>\\w+)(\"|')\\]", RegexOptions.Compiled);

        private readonly Process _process;
        public HttpClient Client { get; }
        public string Host { get; }

        public TestServerV1()
        {
            var portPhrase = "Server started at port ";
            var startup = Path.Combine(GetBaseDirectory(), "legacy", "startup", "www.js");
            var port = new Random().Next(10000, 65536).ToString();
            var processStartInfo = new ProcessStartInfo("node", startup)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            processStartInfo.Environment["PORT"] = port;

            _process = Process.Start(processStartInfo);
            ProcessTracker.Add(_process);
            Debug.Assert(_process != null);
            while (!_process.HasExited)
            {
                var s = _process?.StandardOutput.ReadLine();
                if (s?.StartsWith(portPhrase) != true) continue;

                Host = $"http://localhost:{port}";
                Client = new HttpClient { BaseAddress = new Uri(Host) };
                _ = Task.Run(ReadOutput);
                return;
            }

            if (Client == null)
            {
                throw new InvalidOperationException($"Unable to detect server port {_process.StandardOutput.ReadToEnd()} {_process.StandardError.ReadToEnd()}");
            }

        }

        public static string[] GetScenariosForRoute(string name)
        {
            var scenarios = _scenariosRegex.Matches(File.ReadAllText(Path.Combine(GetBaseDirectory(), "legacy", "routes", name + ".js")))
                .Select(m => m.Groups["name"].Value).ToArray();

            if (!scenarios.Any())
            {
                throw new InvalidOperationException("No scenarios found");
            }

            return scenarios;
        }

        private static string GetBaseDirectory()
        {
            var nodeModules = TestServerV2.FindNodeModulesDirectory();
            return Path.Combine(nodeModules, "@microsoft.azure", "autorest.testserver");
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
                if (request.Value.ValueKind != JsonValueKind.Number) continue;
                int value = request.Value.GetInt32();
                // HeaderParameterProtectedKey is always matched
                if (mapping == "HeaderParameterProtectedKey" && value == 1)
                {
                    continue;
                }
                if (value != 0)
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
