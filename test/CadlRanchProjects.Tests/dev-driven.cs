// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using Azure.Core.Tests;
using dev_driven_cadl;
using NUnit.Framework;
using Testserver;

namespace CadlRanchProjects.Tests
{
    public class DevDrivenTest : TestServerLowLevelTestBase
    {
        [Test]
        public Task GetRawModel() => Test(async (host) =>
        {
            Response response = await new TestserverClient(host, null).GetModelAsync(Mode.Raw.ToSerialString());
            JsonData responseBody = JsonData.FromBytes(response.Content.ToMemory());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Assert.AreEqual("raw", result.GetProperty("received").ToString());
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task GetHandwrittenModel() => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dev_driven_cadl", asyncLocal: true);
            var scopes = diagnosticListener.Scopes;
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Response<Product> result = await new TestserverClient(host, null).GetModelValueAsync(Mode.Model);
            Assert.AreEqual(1, scopes.Count);
            Assert.AreEqual("TestserverClient.GetModelValue", scopes[0].Name);
            Assert.True(scopes[0].IsCompleted);
            Assert.AreEqual("model", result.Value.Received.ToSerialString());
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task PostRawModel() => Test(async (host) =>
        {
            var value = new
            {
                hello = "world!"
            };
            Response result = await new TestserverClient(host, null).PostModelAsync(Mode.Raw.ToSerialString(), RequestContent.Create(value));
            Assert.AreEqual(200, result.Status);
            JsonData responseBody = JsonData.FromBytes(result.Content.ToMemory());
            Assert.AreEqual("raw", (string)responseBody["received"]);
        }, new[] { TestServerType.CadlRanch });

        [Test]
        public Task PostHandwrittenModel() => Test(async (host) =>
        {
            using var diagnosticListener = new ClientDiagnosticListener("dev_driven_cadl", asyncLocal: true);
            var scopes = diagnosticListener.Scopes;
            CollectionAssert.IsEmpty(diagnosticListener.Scopes);

            Input input = new Input("world!");
            Response<Product> result = await new TestserverClient(host, null).PostModelAsync(Mode.Model, input);
            Assert.True(scopes.Count == 1);
            Assert.AreEqual(scopes[0].Name, "TestserverClient.PostModel");
            Assert.True(scopes[0].IsCompleted);
            Assert.AreEqual("model", result.Value.Received.ToSerialString());
        }, new[] { TestServerType.CadlRanch });
    }
}
