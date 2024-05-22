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

namespace ResourceClients_LowLevel.Samples
{
    public partial class Samples_Resource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Item_GetItem_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Resource client = new ResourceServiceClient(credential).GetResourceGroup("<GroupId>").GetResource("<ItemId>");

            Response response = client.GetItem(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Item_GetItem_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Resource client = new ResourceServiceClient(credential).GetResourceGroup("<GroupId>").GetResource("<ItemId>");

            Response response = await client.GetItemAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Item_GetItem_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Resource client = new ResourceServiceClient(credential).GetResourceGroup("<GroupId>").GetResource("<ItemId>");

            Response response = client.GetItem(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Item_GetItem_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Resource client = new ResourceServiceClient(credential).GetResourceGroup("<GroupId>").GetResource("<ItemId>");

            Response response = await client.GetItemAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
