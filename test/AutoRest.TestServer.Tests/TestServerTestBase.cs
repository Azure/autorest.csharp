// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
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
        public static ClientDiagnostics ClientDiagnostics = new ClientDiagnostics(new TestOptions());

        public TestServerTestBase(TestServerVersion version)
        {
            _version = version;
        }

        public Task TestStatus(string scenario, Func<string, HttpPipeline, Task<Response>> test) => Test(scenario, async (host, pipeline) =>
        {
            var response = await test(host, pipeline);
            Assert.AreEqual(200, response.Status);
        });

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
