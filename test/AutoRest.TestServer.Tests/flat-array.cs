// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using FlattenedParameters;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class FlatArray : InProcTestBase
    {
        private async Task<JsonDocument> TestCore (Func<FlattenedParametersClient, Task> testProc)
        {
            var requestMemoryStream = new MemoryStream();
            using var testServer = new InProcTestServer(async content =>
            {
                await content.Request.Body.CopyToAsync(requestMemoryStream);
            });

            var client = new FlattenedParametersClient(ClientDiagnostics, HttpPipeline, testServer.Address);

            await testProc(client);

            return JsonDocument.Parse(Encoding.UTF8.GetString(requestMemoryStream.ToArray()));
        }

        [Test]
        public async Task FlatArray_NullSerialized()
        {
            var doc = await TestCore (async c => await c.OperationAsync ());
            JsonElement items = doc.RootElement.GetProperty("items");
            Assert.NotNull(items);
            Assert.AreEqual(JsonValueKind.Null, items.ValueKind);
        }

        [Test]
        public async Task FlatArray_EmptySerialized()
        {
            var doc = await TestCore (async c => await c.OperationAsync (new string [] {}));
            JsonElement items = doc.RootElement.GetProperty("items");
            Assert.NotNull(items);
            Assert.AreEqual(0, items.GetArrayLength());
        }

        [Test]
        public void FlatArray_NullSerializedNotNullable()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await TestCore (async c => await c.OperationNotNullAsync (null)));
        }

        [Test]
        public async Task FlatArray_EmptySerializedNotNullable()
        {
            var doc = await TestCore (async c => await c.OperationNotNullAsync (new string [] {}));
            JsonElement items = doc.RootElement.GetProperty("items");
            Assert.NotNull(items);
            Assert.AreEqual(0, items.GetArrayLength());
        }
    }
}
