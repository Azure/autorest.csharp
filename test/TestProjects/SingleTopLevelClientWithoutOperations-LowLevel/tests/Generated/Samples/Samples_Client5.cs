// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

namespace SingleTopLevelClientWithoutOperations_LowLevel.Samples
{
    internal class Samples_Client5
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new TopLevelClientWithoutOperationClient(credential).GetClient5Client();

            Response response = client.Operation();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new TopLevelClientWithoutOperationClient(credential).GetClient5Client();

            Response response = client.Operation();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new TopLevelClientWithoutOperationClient(credential).GetClient5Client();

            Response response = await client.OperationAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new TopLevelClientWithoutOperationClient(credential).GetClient5Client();

            Response response = await client.OperationAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
