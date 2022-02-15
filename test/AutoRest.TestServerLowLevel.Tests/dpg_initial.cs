// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using AutoRest.TestServer.Tests.Infrastructure;
using dpg_initial_LowLevel;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class DpgInitialTest : TestServerLowLevelTestBase
    {
        [Test]
        public Task DPGAddOptionalInput() => Test(async (host) =>
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
        });

        [Test]
        public Task DPGNewBodyType_JSON() => Test(async (host) =>
        {
            var value = new
            {
                url = "http://example.org/myimage.jpeg"
            };
            var result = await new ParamsClient(Key, host).PostParametersAsync(RequestContent.Create(value));
            Assert.AreEqual(200, result.Status);
            var result2 = await new ParamsClient(Key, host).PostParametersAsync(RequestContent.Create(value), default);
            Assert.AreEqual(200, result2.Status);
        });
    }
}
