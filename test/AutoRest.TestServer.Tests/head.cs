// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using head;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class HeadRequestTests : TestServerTestBase
    {
        public HeadRequestTests(TestServerVersion version) : base(version) { }

        [Test]
        public Task HttpSuccess200Head() => Test(async (host, pipeline) =>
        {
            var response = await new HttpSuccessClient(ClientDiagnostics, pipeline, host).Head200Async();
            Assert.AreEqual(200, response.Status);
        });

        [Test]
        public Task HttpSuccess204Head() => Test(async (host, pipeline) =>
        {
            var response = await new HttpSuccessClient(ClientDiagnostics, pipeline, host).Head204Async();
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task HttpSuccess404Head() => Test(async (host, pipeline) =>
        {
            var response = await new HttpSuccessClient(ClientDiagnostics, pipeline, host).Head404Async();
            Assert.AreEqual(404, response.Status);
        });
    }
}
