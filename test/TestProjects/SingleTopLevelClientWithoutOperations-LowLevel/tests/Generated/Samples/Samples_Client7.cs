// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using SingleTopLevelClientWithoutOperations_LowLevel;

namespace SingleTopLevelClientWithoutOperations_LowLevel.Samples
{
    public partial class Samples_Client7
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Client7 client = new TopLevelClientWithoutOperationClient(credential).GetClient7Client();

            Response response = client.Operation(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Client7 client = new TopLevelClientWithoutOperationClient(credential).GetClient7Client();

            Response response = await client.OperationAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Client7 client = new TopLevelClientWithoutOperationClient(credential).GetClient7Client();

            Response response = client.Operation(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Client7 client = new TopLevelClientWithoutOperationClient(credential).GetClient7Client();

            Response response = await client.OperationAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
