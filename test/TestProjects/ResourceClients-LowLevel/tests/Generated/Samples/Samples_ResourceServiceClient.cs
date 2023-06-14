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
    public class Samples_ResourceServiceClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential);

            Response response = client.GetParameters();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetParameters_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential);

            Response response = client.GetParameters();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential);

            Response response = await client.GetParametersAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetParameters_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential);

            Response response = await client.GetParametersAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetGroups()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential);

            foreach (var item in client.GetGroups())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetGroups_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential);

            foreach (var item in client.GetGroups())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetGroups_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential);

            await foreach (var item in client.GetGroupsAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetGroups_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential);

            await foreach (var item in client.GetGroupsAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAllItems()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential);

            foreach (var item in client.GetAllItems())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAllItems_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential);

            foreach (var item in client.GetAllItems())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAllItems_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential);

            await foreach (var item in client.GetAllItemsAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAllItems_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ResourceServiceClient(credential);

            await foreach (var item in client.GetAllItemsAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }
    }
}
