// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using AutoRest.TestServer.Tests.Infrastructure;
using dpg_update1_LowLevel;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class DpgUpdate1Test : TestServerLowLevelTestBase
    {
        [Test]
        public Task DpgAddOptionalInput() => Test(async (host) =>
        {
            var result = await new ParamsClient(Key, host).GetRequiredAsync("a");
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody["message"]);
            var result2 = await new ParamsClient(Key, host).GetRequiredAsync("a", default);
            var responseBody2 = JsonData.FromBytes(result2.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody2["message"]);
            var result3 = await new ParamsClient(Key, host).GetRequiredAsync("a", context: default);
            var responseBody3 = JsonData.FromBytes(result3.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody3["message"]);
            var result4 = await new ParamsClient(Key, host).GetRequiredAsync("a", "b");
            var responseBody4 = JsonData.FromBytes(result4.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody4["message"]);
            var result5 = await new ParamsClient(Key, host).GetRequiredAsync("a", "b", default);
            var responseBody5 = JsonData.FromBytes(result5.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody5["message"]);
            var result6 = await new ParamsClient(Key, host).GetRequiredAsync("a", context: default, newParameter: "b");
            var responseBody6 = JsonData.FromBytes(result6.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody6["message"]);
        });

        [Test]
        public Task DpgNewBodyType_JSON() => Test(async (host) =>
        {
            var value = new
            {
                url = "http://example.org/myimage.jpeg"
            };
            var result = await new ParamsClient(Key, host).PostParametersAsync(RequestContent.Create(value));
            Assert.AreEqual(200, result.Status);
            var result2 = await new ParamsClient(Key, host).PostParametersAsync(RequestContent.Create(value), default);
            Assert.AreEqual(200, result2.Status);
            var result3 = await new ParamsClient(Key, host).PostParametersAsync(RequestContent.Create(value), ContentType.ApplicationJson);
            Assert.AreEqual(200, result3.Status);
            var result4 = await new ParamsClient(Key, host).PostParametersAsync(RequestContent.Create(value), ContentType.ApplicationJson, default);
            Assert.AreEqual(200, result4.Status);
        });

        [Test]
        public Task DpgNewBodyType_JPEG() => Test(async (host) =>
        {
            await using var value = new MemoryStream(Encoding.UTF8.GetBytes("JPEG"));
            var result = await new ParamsClient(Key, host).PostParametersAsync(RequestContent.Create(value), new ContentType("image/jpeg"));
            Assert.AreEqual(200, result.Status);
        });

        [Test]
        public Task DpgAddNewOperation() => Test(async (host) =>
        {
            var result = await new ParamsClient(Key, host).DeleteParametersAsync();
            Assert.AreEqual(204, result.Status);
        });

        [Test]
        public Task DpgAddNewPath() => Test(async (host) =>
        {
            var result = await new ParamsClient(Key, host).GetNewOperationAsync();
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody["message"]);
        });
    }
}
