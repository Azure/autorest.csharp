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
using ResourceClients_LowLevel;

namespace ResourceClients_LowLevel.Samples
{
    public partial class Samples_ResourceGroup
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetGroup()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ResourceGroup client = new ResourceServiceClient(credential).GetResourceGroup("<GroupId>");

            Response response = client.GetGroup(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetGroup_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ResourceGroup client = new ResourceServiceClient(credential).GetResourceGroup("<GroupId>");

            Response response = await client.GetGroupAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetGroup_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ResourceGroup client = new ResourceServiceClient(credential).GetResourceGroup("<GroupId>");

            Response response = client.GetGroup(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetGroup_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ResourceGroup client = new ResourceServiceClient(credential).GetResourceGroup("<GroupId>");

            Response response = await client.GetGroupAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetItems()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ResourceGroup client = new ResourceServiceClient(credential).GetResourceGroup("<GroupId>");

            foreach (BinaryData item in client.GetItems(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetItems_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ResourceGroup client = new ResourceServiceClient(credential).GetResourceGroup("<GroupId>");

            await foreach (BinaryData item in client.GetItemsAsync(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetItems_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ResourceGroup client = new ResourceServiceClient(credential).GetResourceGroup("<GroupId>");

            foreach (BinaryData item in client.GetItems(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetItems_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ResourceGroup client = new ResourceServiceClient(credential).GetResourceGroup("<GroupId>");

            await foreach (BinaryData item in client.GetItemsAsync(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].ToString());
            }
        }
    }
}
