// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    [TestFixture(TestServerVersion.V1)]
    [TestFixture(TestServerVersion.V2)]
    public class TestServerTestBase
    {
        private readonly TestServerVersion _version;
        private readonly string? _coverageFile;
        //public static ClientDiagnostics ClientDiagnostics = new ClientDiagnostics(new TestOptions());

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
            if (_coverageFile != null)
            {
                var scenarios = TestServerV1.GetScenariosForRoute(_coverageFile);
                var methods = this.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance).Select(m => m.Name)
                    .ToArray();


                List<string> missingScenarios = new List<string>();
                foreach (string scenario in scenarios)
                {
                    if (!methods.Contains(scenario, StringComparer.CurrentCultureIgnoreCase))
                    {
                        missingScenarios.Add(scenario);
                    }
                }

                if (missingScenarios.Any())
                {
                    Assert.Fail("Expected scenarios " + string.Join(Environment.NewLine, missingScenarios) + " not defined");
                }
            }
        }

        public Task TestStatus(Func<string, HttpPipeline, Task<Response>> test)
        {
            return TestStatus(TestContext.CurrentContext.Test.Name, test);
        }

        public Task TestStatus(string scenario, Func<string, HttpPipeline, Task<Response>> test) => Test(scenario, async (host, pipeline) =>
        {
            var response = await test(host, pipeline);
            Assert.AreEqual(200, response.Status, "Unexpected response " + response.ReasonPhrase);
        });

        public Task Test(Func<string, HttpPipeline, Task> test)
        {
            return Test(TestContext.CurrentContext.Test.Name, test);
        }

        public async Task Test(string scenario, Func<string, HttpPipeline, Task> test)
        {
            var server = TestServerSession.Start(_version, scenario);

            try
            {
                var pipeline = new HttpPipeline(new HttpClientTransport(server.Server.Client));
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
    }
}
