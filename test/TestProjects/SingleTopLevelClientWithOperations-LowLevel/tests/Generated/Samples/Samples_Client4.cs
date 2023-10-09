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
using SingleTopLevelClientWithOperations_LowLevel;

namespace SingleTopLevelClientWithOperations_LowLevel.Samples
{
    public partial class Samples_Client4
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Client4 client = new TopLevelClientWithOperationClient(credential).GetClient4("<ClientParameter>");

            Response response = client.Patch("<filter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Client4 client = new TopLevelClientWithOperationClient(credential).GetClient4("<ClientParameter>");

            Response response = await client.PatchAsync("<filter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Client4 client = new TopLevelClientWithOperationClient(credential).GetClient4("<ClientParameter>");

            Response response = client.Patch("<filter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Client4 client = new TopLevelClientWithOperationClient(credential).GetClient4("<ClientParameter>");

            Response response = await client.PatchAsync("<filter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
