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

namespace ResourceClients_LowLevel.Samples
{
    internal class Samples_ResourceGroup
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetGroup()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential).GetResourceGroup("<groupId>");

            Response response = client.GetGroup();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetGroup_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential).GetResourceGroup("<groupId>");

            Response response = client.GetGroup();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetGroup_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential).GetResourceGroup("<groupId>");

            Response response = await client.GetGroupAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetGroup_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential).GetResourceGroup("<groupId>");

            Response response = await client.GetGroupAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetItems()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential).GetResourceGroup("<groupId>");

            foreach (var item in client.GetItems())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetItems_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential).GetResourceGroup("<groupId>");

            foreach (var item in client.GetItems())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetItems_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential).GetResourceGroup("<groupId>");

            await foreach (var item in client.GetItemsAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetItems_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential).GetResourceGroup("<groupId>");

            await foreach (var item in client.GetItemsAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }
    }
}
