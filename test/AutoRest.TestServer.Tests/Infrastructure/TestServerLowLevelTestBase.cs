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
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Infrastructure
{
    [TestFixture(TestServerVersion.V1)]
    public class TestServerLowLevelTestBase
    {
        private readonly TestServerVersion _version;
        internal AzureKeyCredential Key = new AzureKeyCredential("NOT-A-VALID-KEY");

        public TestServerLowLevelTestBase(TestServerVersion version)
        {
            _version = version;
        }

        public virtual IEnumerable<string> AdditionalKnownScenarios { get; } = Array.Empty<string>();

        public Task TestStatus(Func<Uri, AzureKeyCredential, Response> test, bool ignoreScenario = false)
        {
            return TestStatus((host, key) => Task.FromResult(test(host, key)), ignoreScenario);
        }

        public Task TestStatus(Func<Uri, AzureKeyCredential, Task<Response>> test, bool ignoreScenario = false)
        {
            return TestStatus(GetScenarioName(), test, ignoreScenario);
        }

        private Task TestStatus(string scenario, Func<Uri, AzureKeyCredential, Task<Response>> test, bool ignoreScenario = false) => Test(scenario, async (host, key) =>
        {
            var response = await test(host, key);
            Assert.That(response.Status, Is.EqualTo(200).Or.EqualTo(201).Or.EqualTo(202).Or.EqualTo(204), "Unexpected response " + response.ReasonPhrase);
        }, ignoreScenario);

        public Task Test(Action<Uri, AzureKeyCredential> test, bool ignoreScenario = false)
        {
            return Test(GetScenarioName(), (host, key) =>
            {
                test(host, key);
                return Task.CompletedTask;
            }, ignoreScenario);
        }

        public Task Test(Func<Uri, AzureKeyCredential, Task> test, bool ignoreScenario = false)
        {
            return Test(GetScenarioName(), test, ignoreScenario);
        }

        private async Task Test(string scenario, Func<Uri, AzureKeyCredential, Task> test, bool ignoreScenario = false)
        {
            var scenarioParameter = ignoreScenario ? new string[0] : new[] {scenario};
            var server = TestServerSession.Start(scenario, _version, false, scenarioParameter);

            try
            {
                var transport = new HttpClientTransport(server.Server.Client);
                var testClientOptions = new TestClientOptions
                {
                    Transport = new FailureInjectingTransport(transport),
                    Retry = { Delay = TimeSpan.FromMilliseconds(1) },
                };
                testClientOptions.AddPolicy(new CustomClientRequestIdPolicy(), HttpPipelinePosition.PerCall);

                await test(server.Host, Key);
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
