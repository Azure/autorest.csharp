// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Infrastructure
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture(TestServerVersion.V1)]
    [TestFixture(TestServerVersion.V2)]
    public class TestServerTestBase
    {
        private readonly TestServerVersion _version;
        private readonly string? _coverageFile;
        internal static ClientDiagnostics ClientDiagnostics = new ClientDiagnostics(new TestOptions());

        public TestServerTestBase(TestServerVersion version): this(version, null)
        {
        }

        public TestServerTestBase(TestServerVersion version, string? coverageFile)
        {
            _version = version;
            _coverageFile = coverageFile;
        }

        [Test]
        public void DefinesAllScenarios()
        {
            var scenarios = AdditionalKnownScenarios;
            if (_coverageFile != null)
            {
                scenarios = TestServerV1.GetScenariosForRoute(_coverageFile).Concat(scenarios);
            }

            var methods = this.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance).Select(m => m.Name)
                .ToArray();


            HashSet<string> missingScenarios = new HashSet<string>(StringComparer.CurrentCultureIgnoreCase);
            foreach (string scenario in scenarios)
            {
                if (!methods.Contains(scenario, StringComparer.CurrentCultureIgnoreCase))
                {
                    missingScenarios.Add(scenario);
                }
            }

            if (missingScenarios.Any())
            {
                Assert.Fail("Expected scenarios " + string.Join(Environment.NewLine, missingScenarios.OrderBy(s=>s)) + " not defined");
            }
        }

        public virtual IEnumerable<string> AdditionalKnownScenarios { get; } = Array.Empty<string>();

        public Task TestStatus(Func<Uri, HttpPipeline, Response> test, bool ignoreScenario = false, bool useSimplePipeline = false)
        {
            return TestStatus((host, pipeline) => Task.FromResult(test(host, pipeline)), ignoreScenario, useSimplePipeline);
        }

        public Task TestStatus(Func<Uri, HttpPipeline, Task<Response>> test, bool ignoreScenario = false, bool useSimplePipeline = false)
        {
            return TestStatus(GetScenarioName(), test, ignoreScenario, useSimplePipeline);
        }

        private Task TestStatus(string scenario, Func<Uri, HttpPipeline, Task<Response>> test, bool ignoreScenario = false, bool useSimplePipeline = false) => Test(scenario, async (host, pipeline) =>
        {
            var response = await test(host, pipeline);
            Assert.That(response.Status, Is.EqualTo(200).Or.EqualTo(201).Or.EqualTo(202).Or.EqualTo(204), "Unexpected response " + response.ReasonPhrase);
        }, ignoreScenario, useSimplePipeline);

        public Task Test(Action<Uri, HttpPipeline> test, bool ignoreScenario = false, bool useSimplePipeline = false)
        {
            return Test(GetScenarioName(), (host, pipeline) =>
            {
                test(host, pipeline);
                return Task.CompletedTask;
            }, ignoreScenario, useSimplePipeline);
        }

        public Task Test(Func<Uri, HttpPipeline, Task> test, bool ignoreScenario = false, bool useSimplePipeline = false)
        {
            return Test(GetScenarioName(), test, ignoreScenario, useSimplePipeline);
        }

        private async Task Test(string scenario, Func<Uri, HttpPipeline, Task> test, bool ignoreScenario = false, bool useSimplePipeline = false)
        {
            var scenarioParameter = ignoreScenario ? new string[0] : new[] {scenario};
            var server = TestServerSession.Start(scenario, _version, false, scenarioParameter);

            try
            {
                var testClientOptions = new TestClientOptions
                {
                    Transport = new HttpClientTransport(server.Server.Client),
                    Retry = { Delay = TimeSpan.FromMilliseconds(50) },
                };
                testClientOptions.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);

                var pipeline = useSimplePipeline
                    ? new HttpPipeline(new HttpClientTransport(server.Server.Client))
                    : HttpPipelineBuilder.Build(testClientOptions);

                await test(server.Host, pipeline);
            }
            catch (Exception ex)
            {
                try
                {
                    await server.DisposeAsync();
                }
                catch (Exception disposeException)
                {
                    throw new AggregateException(ex, disposeException);
                }

                throw;
            }

            await server.DisposeAsync();
        }

        private static string GetScenarioName()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            var indexOfUnderscore = testName.IndexOf('_');
            return indexOfUnderscore == -1 ? testName : testName.Substring(0, indexOfUnderscore);
        }

        private class TestClientOptions : ClientOptions
        {

        }
    }
}
