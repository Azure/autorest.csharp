// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public Task DpgAddOptionalInput_NoParams_Test() => Test(async (host) =>
        {
            // compatible with dpg_initial
            var result = await new ParamsClient(Key, host).HeadNoParamsAsync();
            Assert.IsEmpty(result.Content.ToArray());
            Assert.AreEqual(200, result.Status);
            Assert.AreEqual(123, result.Headers.ContentLength);
            var result2 = await new ParamsClient(Key, host).HeadNoParamsAsync(new Azure.RequestContext());
            Assert.IsEmpty(result2.Content.ToArray());
            Assert.AreEqual(200, result2.Status);
            Assert.AreEqual(123, result2.Headers.ContentLength);
            // use methods in dpg_update1
            var result3 = await new ParamsClient(Key, host).HeadNoParamsAsync("newParam");
            Assert.IsEmpty(result3.Content.ToArray());
            Assert.AreEqual(200, result3.Status);
            Assert.AreEqual(123, result3.Headers.ContentLength);
            var result4 = await new ParamsClient(Key, host).HeadNoParamsAsync("newParam", new Azure.RequestContext());
            Assert.IsEmpty(result4.Content.ToArray());
            Assert.AreEqual(200, result4.Status);
            Assert.AreEqual(123, result4.Headers.ContentLength);
        });

        [Test]
        public Task DpgAddOptionalInput() => Test(async (host) =>
        {
            // compatible with dpg_initial
            var result = await new ParamsClient(Key, host).GetRequiredAsync("param");
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody["message"]);
            var result2 = await new ParamsClient(Key, host).GetRequiredAsync("param", default);
            var responseBody2 = JsonData.FromBytes(result2.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody2["message"]);
            var result3 = await new ParamsClient(Key, host).GetRequiredAsync("param", context: default);
            var responseBody3 = JsonData.FromBytes(result3.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody3["message"]);
            Assert.ThrowsAsync<ArgumentNullException>(async () => await new ParamsClient(Key, host).GetRequiredAsync(null));
            // use methods in dpg_update1
            var result4 = await new ParamsClient(Key, host).GetRequiredAsync("param", "newParam");
            var responseBody4 = JsonData.FromBytes(result4.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody4["message"]);
            var result5 = await new ParamsClient(Key, host).GetRequiredAsync("param", "newParam", default);
            var responseBody5 = JsonData.FromBytes(result5.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody5["message"]);
            var result6 = await new ParamsClient(Key, host).GetRequiredAsync("param", context: default, newParameter: "newParam");
            var responseBody6 = JsonData.FromBytes(result6.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody6["message"]);
        });

        [Test]
        public Task DpgAddOptionalInput_RequiredOptionalParam_Test() => Test(async (host) =>
        {
            // compatible with dpg_initial
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
            // use methods in dpg_update1
            var result5 = await new ParamsClient(Key, host).PutRequiredOptionalAsync("requiredParam", newParameter: "newParam");
            var responseBody5 = JsonData.FromBytes(result5.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody5["message"]);
            var result6 = await new ParamsClient(Key, host).PutRequiredOptionalAsync("requiredParam", "optionalParam", "newParam");
            var responseBody6 = JsonData.FromBytes(result6.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody6["message"]);
            var result7 = await new ParamsClient(Key, host).PutRequiredOptionalAsync("requiredParam", "optionalParam", "newParam", new Azure.RequestContext());
            var responseBody7 = JsonData.FromBytes(result7.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody7["message"]);
            var result8 = await new ParamsClient(Key, host).PutRequiredOptionalAsync("requiredParam", newParameter: "newParam", context: new Azure.RequestContext());
            var responseBody8 = JsonData.FromBytes(result8.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody8["message"]);
        });

        [Test]
        public Task DpgAddOptionalInput_OptionalParam_Test() => Test(async (host) =>
        {
            // compatible with dpg_initial
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
            // use methods in dpg_update1
            var result5 = await new ParamsClient(Key, host).GetOptionalAsync(newParameter: "newParam");
            var responseBody5 = JsonData.FromBytes(result5.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody5["message"]);
            var result6 = await new ParamsClient(Key, host).GetOptionalAsync("optionalParam", "newParam");
            var responseBody6 = JsonData.FromBytes(result6.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody6["message"]);
            var result7 = await new ParamsClient(Key, host).GetOptionalAsync("optionalParam", "newParam", new Azure.RequestContext());
            var responseBody7 = JsonData.FromBytes(result7.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody7["message"]);
            var result8 = await new ParamsClient(Key, host).GetOptionalAsync(newParameter: "newParam", context: new Azure.RequestContext());
            var responseBody8 = JsonData.FromBytes(result8.Content.ToMemory());
            Assert.AreEqual("An object was successfully returned", (string)responseBody8["message"]);
        });

        [Test]
        public Task DpgNewBodyType_JSON() => Test(async (host) =>
        {
            // compatible with dpg_initial
            var value = new
            {
                url = "http://example.org/myimage.jpeg"
            };
            var result = await new ParamsClient(Key, host).PostParametersAsync(RequestContent.Create(value));
            Assert.AreEqual(200, result.Status);
            var result2 = await new ParamsClient(Key, host).PostParametersAsync(RequestContent.Create(value), default);
            Assert.AreEqual(200, result2.Status);
            // use methods in dpg_update1
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
