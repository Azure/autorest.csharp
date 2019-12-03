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
        public static HttpPipeline Pipeline = HttpPipelineBuilder.Build(new TestOptions() { Transport = new HttpClientTransport(new HttpClient() { Timeout = TimeSpan.FromSeconds(5)})});

        public static Task TestStatus(string scenario, Func<string, Task<Response>> test) => Test(scenario, async host =>
        {
            var response = await test(host);
            Assert.AreEqual(200, response.Status);
        });

        public static async Task Test(string scenario, Func<string, Task> test)
        {
            var server = TestServerSession.Start(scenario);
            try
            {
                await test(server.Host);
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
