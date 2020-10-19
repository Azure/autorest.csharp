// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using HeadAsBooleanTrue;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class HeadAsBooleanTrueTests : TestServerTestBase
    {
        public HeadAsBooleanTrueTests(TestServerVersion version) : base(version) { }

        [Test]
        public Task HttpSuccess200Head() => Test(async (host, pipeline) =>
        {
            var response = await new HttpSuccessClient(ClientDiagnostics, pipeline, host).Head200Async();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(true, response.Value);
        });

        [Test]
        public Task HttpSuccess204Head() => Test(async (host, pipeline) =>
        {
            var response = await new HttpSuccessClient(ClientDiagnostics, pipeline, host).Head204Async();
            Assert.AreEqual(204, response.GetRawResponse().Status);
            Assert.AreEqual(true, response.Value);
        });

        [Test]
        public Task HttpSuccess404Head() => Test(async (host, pipeline) =>
        {
            var response = await new HttpSuccessClient(ClientDiagnostics, pipeline, host).Head404Async();
            Assert.AreEqual(404, response.GetRawResponse().Status);
            Assert.AreEqual(false, response.Value);
        });
    }
}
