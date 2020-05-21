// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using SerializationCustomization;
using SerializationCustomization.Models;

namespace AutoRest.TestServer.Tests
{
    public class SerializationCustomizationTests: InProcTestBase
    {
        [Test]
        public async Task CanSendAndReceiveCustomJson()
        {
            var expectedJson = "{\"ArrayProperty\":[1,2,3],\"ModelProperty\":{\"Name\":\"Item\"},\"ObjectProperty\":{\"b\":{}}}";
            string actualJson = null;

            using var testServer = new InProcTestServer(async content =>
            {
                actualJson = (await JsonDocument.ParseAsync(content.Request.Body)).RootElement.ToString();

                await content.Response.WriteAsync(expectedJson);
            });

            var model = new PropertyToJsonElementModel();
            model.ArrayProperty = JsonDocument.Parse("[1, 2, 3]").RootElement;
            model.ObjectProperty = JsonDocument.Parse("{ \"b\": {} }").RootElement;
            model.ModelProperty = JsonDocument.Parse("{ \"Name\": \"Item\" }").RootElement;

            var responseModel = await new ServiceClient(ClientDiagnostics, HttpPipeline, testServer.Address).PropertyToJsonElementModelAsync(model);

            Assert.AreEqual(expectedJson, actualJson);
            Assert.AreEqual("[1,2,3]", responseModel.Value.ArrayProperty.ToString());
            Assert.AreEqual("{\"b\":{}}", responseModel.Value.ObjectProperty.ToString());
            Assert.AreEqual("{\"Name\":\"Item\"}", responseModel.Value.ModelProperty.ToString());
        }
    }
}