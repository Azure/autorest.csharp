// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace SingleTopLevelClientWithOperations_LowLevel.Samples
{
    internal class Samples_Client1
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new TopLevelClientWithOperationClient(credential).GetClient1Client();

            Response response = client.Operation(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new TopLevelClientWithOperationClient(credential).GetClient1Client();

            Response response = client.Operation(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new TopLevelClientWithOperationClient(credential).GetClient1Client();

            Response response = await client.OperationAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new TopLevelClientWithOperationClient(credential).GetClient1Client();

            Response response = await client.OperationAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
