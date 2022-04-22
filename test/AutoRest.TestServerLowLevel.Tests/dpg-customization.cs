using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using Azure.Core.Tests;
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
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            var scopes = diagnosticListener.Scopes;
            Response<Product> result = await new DPGClient(Key, host).GetModelValueAsync("model");
            var scopeCount = scopes.Count;
            Assert.True(scopeCount == 1);
            Assert.AreEqual(scopes[0].Name, "DPGClient.GetModelValue");
            Assert.True(scopes[0].IsCompleted);
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
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            AsyncPageable<Product> allPages = new DPGClient(Key, host).GetPagesValuesAsync("model");
            var pagesCount = 0;
            await foreach (Page<Product> page in allPages.AsPages())
            {
                pagesCount++;
                Assert.AreEqual("model", $"{page.Values.First().Received}");
            }

            // +1 due to the last iteration of enumeration that doesn't make a call
            Assert.AreEqual(pagesCount + 1, diagnosticListener.Scopes.Count);
        });

        [Test]
        public Task DPGGlassBreaker() => Test(async (host) =>
        {
            var pipeline = new DPGClient(Key, host).Pipeline;
            HttpMessage message = pipeline.CreateMessage();
            Request request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(host);
            uri.AppendPath("/servicedriven/glassbreaker", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            Response result = await pipeline.ProcessMessageAsync(message, null).ConfigureAwait(false);

            Assert.AreEqual(200, result.Status);
        });
    }
}
