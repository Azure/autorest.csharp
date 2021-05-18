// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using FlatArray;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class FlatArray : InProcTestBase
    {
        [Test]
        public async Task FlatArray_NullSerialized()
        {
            var requestMemoryStream = new MemoryStream();
            using var testServer = new InProcTestServer(async content =>
            {
                await content.Request.Body.CopyToAsync(requestMemoryStream);
            });

            var response = await new FlatArrayClient(ClientDiagnostics, HttpPipeline, testServer.Address).OperationAsync();

            var doc = JsonDocument.Parse(Encoding.UTF8.GetString(requestMemoryStream.ToArray()));
            JsonElement items = doc.RootElement.GetProperty("items");
            Assert.NotNull (items);
            Assert.AreEqual (JsonValueKind.Null, items.ValueKind);
        }

        [Test]
        public async Task FlatArray_EmptySerialized()
        {
            var requestMemoryStream = new MemoryStream();
            using var testServer = new InProcTestServer(async content =>
            {
                await content.Request.Body.CopyToAsync(requestMemoryStream);
            });

            var response = await new FlatArrayClient(ClientDiagnostics, HttpPipeline, testServer.Address).OperationAsync(new string [] {} );

            var doc = JsonDocument.Parse(Encoding.UTF8.GetString(requestMemoryStream.ToArray()));
            JsonElement items = doc.RootElement.GetProperty("items");
            Assert.NotNull (items);
            Assert.AreEqual (0, items.GetArrayLength());
        }
    }
}
