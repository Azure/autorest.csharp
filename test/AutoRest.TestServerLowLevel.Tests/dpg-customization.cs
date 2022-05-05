﻿using System;
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
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Response<Product> result = await new DPGClient(Key, host).GetModelValueAsync("model");
            Assert.AreEqual(1, scopes.Count);
            Assert.AreEqual("DPGClient.GetModel", scopes[0].Name);
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
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            var scopes = diagnosticListener.Scopes;
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Input input = new Input("world!");
            Response<Product> result = await new DPGClient(Key, host).PostModelAsync("model", input);
            Assert.True(scopes.Count == 1);
            Assert.AreEqual(scopes[0].Name, "DPGClient.PostModel");
            Assert.True(scopes[0].IsCompleted);
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
        public Task HandwrittenModelLro() => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Operation<Product> lro = await new DPGClient(Key, host).LroValueAsync(WaitUntil.Started, "model");
            Assert.AreEqual(1, diagnosticListener.Scopes.Count);
            Assert.AreEqual("DPGClient.LroValue", diagnosticListener.Scopes[0].Name);
            Assert.IsTrue(diagnosticListener.Scopes[0].IsCompleted);

            await lro.WaitForCompletionAsync();
            Assert.AreEqual(2, diagnosticListener.Scopes.Count);
            Assert.AreEqual("model", $"{lro.Value.Received}");
            Assert.AreEqual("DPGClient.LroValue", diagnosticListener.Scopes[1].Name);
            Assert.IsTrue(diagnosticListener.Scopes[1].IsCompleted);
        });

        [Test]
        public Task HandwrittenModelLro_ManualIteration() => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Operation<Product> lro = await new DPGClient(Key, host).LroValueAsync(WaitUntil.Started, "model");
            Assert.AreEqual(1, diagnosticListener.Scopes.Count);
            Assert.AreEqual("DPGClient.LroValue", diagnosticListener.Scopes[0].Name);
            Assert.IsTrue(diagnosticListener.Scopes[0].IsCompleted);

            var updatesCount = 0;
            while (!lro.HasCompleted)
            {
                await lro.UpdateStatusAsync();
                updatesCount++;
                Assert.AreEqual("DPGClient.LroValue.UpdateStatus", diagnosticListener.Scopes[updatesCount].Name);
                Assert.IsTrue(diagnosticListener.Scopes[updatesCount].IsCompleted);
            }

            // +1 due to the first scope being created by LroValueAsync
            Assert.AreEqual(updatesCount + 1, diagnosticListener.Scopes.Count);
        });

        [Test]
        public Task HandwrittenModelLro_WaitUntilCompleted() => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dpg_customization_LowLevel", asyncLocal: true);
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Operation<Product> lro = await new DPGClient(Key, host).LroValueAsync(WaitUntil.Completed, "model");
            Assert.AreEqual(1, diagnosticListener.Scopes.Count);
            Assert.AreEqual("DPGClient.LroValue", diagnosticListener.Scopes[0].Name);
            Assert.IsTrue(diagnosticListener.Scopes[0].IsCompleted);
            Assert.AreEqual("model", $"{lro.Value.Received}");
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
