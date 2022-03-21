﻿using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using dpg_customization_LowLevel;
using dpg_customization_LowLevel.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class DpgCustomizationTest : TestServerLowLevelTestBase
    {
        [Test]
        public Task GetRawModel() => Test(async (host) =>
        {
            Response result = await new DPGClient(Key, host).GetModelAsync("raw");
            JsonData responseBody = JsonData.FromBytes(result.Content.ToMemory());
            Assert.AreEqual("raw", (string)responseBody["received"]);
        });

        [Test]
        public Task GetHandwrittenModel() => Test(async (host) =>
        {
            Response<Product> result = await new DPGClient(Key, host).GetModelValueAsync("model");
            Assert.AreEqual("model", $"{result.Value.Received}");
        });

        [Test]
        public Task PostRawModel() => Test(async (host) =>
        {
            var value = new
            {
                hello = "world!"
            };
            Response result = await new DPGClient(Key, host).PostModelAsync("raw", RequestContent.Create(value));
            Assert.AreEqual(200, result.Status);
            JsonData responseBody = JsonData.FromBytes(result.Content.ToMemory());
            Assert.AreEqual("raw", (string)responseBody["received"]);
        });

        [Test]
        public Task PostHandwrittenModel() => Test(async (host) =>
        {
            Input input = new Input("world!");
            Response<Product> result = await new DPGClient(Key, host).PostModelAsync("model", input);
            Assert.AreEqual("model", $"{result.Value.Received}");
        });

        [Test]
        public Task GetRawPages() => Test(async (host) =>
        {
            AsyncPageable<BinaryData> allPages = new DPGClient(Key, host).GetPagesAsync("raw");
            await foreach (Page<BinaryData> page in allPages.AsPages())
            {
                var firstItem = JsonData.FromBytes(page.Values.First());
                Assert.AreEqual("raw", (string)firstItem["received"]);
            }
        });

        [Test]
        public Task GetHandwrittenModelPages() => Test(async (host) =>
        {
            AsyncPageable<Product> allPages = new DPGClient(Key, host).GetPagesValuesAsync("model");
            await foreach (Page<Product> page in allPages.AsPages())
            {
                Assert.AreEqual("model", $"{page.Values.First().Received}");
            }
        });
    }
}
