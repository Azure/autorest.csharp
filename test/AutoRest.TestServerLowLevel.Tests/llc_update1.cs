// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using AutoRest.TestServer.Tests.Infrastructure;
using llc_update1_LowLevel;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class LlcUpdate1Test : TestServerLowLevelTestBase
    {
        [Test]
        public Task LLCAddOptionalInput() => Test(async (host) =>
        {
            var result = await new ParamsClient(Key, host).GetRequiredAsync("a");
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody["message"]);
        });

        [Test]
        public Task LLCNewBodyType_JSON() => Test(async (host) =>
        {
            var value = new
            {
                url = "http://example.org/myimage.jpeg"
            };
            var result = await new ParamsClient(Key, host).PostParametersAsync(RequestContent.Create(value), ContentType.ApplicationJson);
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        public Task LLCNewBodyType_JPEG() => Test(async (host) =>
        {
            await using var value = new MemoryStream(Encoding.UTF8.GetBytes("JPEG"));
            var result = await new ParamsClient(Key, host).PostParametersAsync(RequestContent.Create(value), new ContentType("image/jpeg"));
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        public Task LLCAddNewOperation() => Test(async (host) =>
        {
            var result = await new ParamsClient(Key, host).DeleteParametersAsync();
            Assert.AreEqual(204, result.Status);
        });

        [Test]
        public Task LLCAddNewPath() => Test(async (host) =>
        {
            var result = await new ParamsClient(Key, host).GetNewOperationAsync();
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody["message"]);
        });
    }
}
