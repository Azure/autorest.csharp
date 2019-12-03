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
    public class TestServerTestBase
    {
        public static ClientDiagnostics ClientDiagnostics = new ClientDiagnostics(new TestOptions());
        private static HttpPipeline Pipeline = new HttpPipeline(
            new HttpClientTransport(
                new HttpClient(new SocketsHttpHandler() { PooledConnectionLifetime = TimeSpan.Zero })
                {
                    Timeout = TimeSpan.FromSeconds(5)
                }));

        public static Task TestStatus(string scenario, Func<string, HttpPipeline, Task<Response>> test) => Test(scenario, async (host, pipeline) =>
        {
            var response = await test(host, pipeline);
            Assert.AreEqual(200, response.Status);
        });

        public static async Task Test(string scenario, Func<string, HttpPipeline, Task> test)
        {
            var server = TestServerSession.Start(scenario);

            try
            {
                await test(server.Host, Pipeline);
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
