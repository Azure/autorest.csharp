// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public Task DpgAddOptionalInput_NoParams_Test() => Test(async (host) =>
        {
            var result = await new ParamsClient(Key, host).HeadNoParamsAsync();
            Assert.IsEmpty(result.Content.ToArray());
            Assert.AreEqual(200, result.Status);
            Assert.AreEqual(123, result.Headers.ContentLength);
            var result2 = await new ParamsClient(Key, host).HeadNoParamsAsync(new Azure.RequestContext());
            Assert.IsEmpty(result2.Content.ToArray());
            Assert.AreEqual(200, result2.Status);
            Assert.AreEqual(123, result2.Headers.ContentLength);
        });

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
            Assert.ThrowsAsync<ArgumentNullException>(async () => await new ParamsClient(Key, host).GetRequiredAsync(null));
        });

        [Test]
        public Task DpgAddOptionalInput_RequiredOptionalParam_Test() => Test(async (host) =>
        {
            var result = await new ParamsClient(Key, host).PutRequiredOptionalAsync("requiredParam");
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody["message"]);
            var result2 = await new ParamsClient(Key, host).PutRequiredOptionalAsync("requiredParam", "optionalParam");
            var responseBody2 = JsonData.FromBytes(result2.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody2["message"]);
            var result3 = await new ParamsClient(Key, host).PutRequiredOptionalAsync("requiredParam", "optionalParam", new Azure.RequestContext());
            var responseBody3 = JsonData.FromBytes(result3.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody3["message"]);
            var result4 = await new ParamsClient(Key, host).PutRequiredOptionalAsync("requiredParam", context: new Azure.RequestContext());
            var responseBody4 = JsonData.FromBytes(result4.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody4["message"]);
            Assert.ThrowsAsync<ArgumentNullException>(async () => await new ParamsClient(Key, host).PutRequiredOptionalAsync(null));
        });

        [Test]
        public Task DpgAddOptionalInput_OptionalParam_Test() => Test(async (host) =>
        {
            var result = await new ParamsClient(Key, host).GetOptionalAsync();
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody["message"]);
            var result2 = await new ParamsClient(Key, host).GetOptionalAsync("optionalParam");
            var responseBody2 = JsonData.FromBytes(result2.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody2["message"]);
            var result3 = await new ParamsClient(Key, host).GetOptionalAsync("optionalParam", new Azure.RequestContext());
            var responseBody3 = JsonData.FromBytes(result3.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody3["message"]);
            var result4 = await new ParamsClient(Key, host).GetOptionalAsync(context: new Azure.RequestContext());
            var responseBody4 = JsonData.FromBytes(result4.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody4["message"]);
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
        });
    }
}
