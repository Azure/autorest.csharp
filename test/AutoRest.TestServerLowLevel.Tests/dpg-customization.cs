using System;
using System.IO;
using System.Linq;
using System.Text.Json;
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
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());
            Assert.AreEqual("raw", (string)responseBody["received"]);
        });

        [Test]
        public Task GetHandwrittenModel() => Test(async (host) =>
        {
            Product result = await new DPGClient(Key, host).GetModelAsync("model");
            Assert.AreEqual("model", $"{result.Received}");
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
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());
            Assert.AreEqual("raw", (string)responseBody["received"]);
        });

        [Test]
        public Task PostHandwrittenModel() => Test(async (host) =>
        {
            IUtf8JsonSerializable input = new Input("world!");
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            input.Write(writer);
            writer.Flush();
            Response result = await new DPGClient(Key, host).PostModelAsync("model", RequestContent.Create(stream.ToArray()));
            Assert.AreEqual(200, result.Status);
            var responseBody = JsonData.FromBytes(result.Content.ToMemory());
            Assert.AreEqual("model", (string)responseBody["received"]);
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
            AsyncPageable<BinaryData> allPages = new DPGClient(Key, host).GetPagesAsync("model");
            await foreach (Page<BinaryData> page in allPages.AsPages())
            {
                ProductResult result = page.GetRawResponse();
                Assert.AreEqual("model", $"{result.Values.First().Received}");
            }
        });
    }
}
