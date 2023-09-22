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

namespace ResourceClients_LowLevel.Tests
{
    public class ResourceServiceClientTests : ResourceClients_LowLevelTestBase
    {
        public ResourceServiceClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task GetParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ResourceServiceClient client = CreateResourceServiceClient(credential, endpoint);

            Response response = await client.GetParametersAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        public async Task GetParameters_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ResourceServiceClient client = CreateResourceServiceClient(credential, endpoint);

            Response response = await client.GetParametersAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        public async Task GetGroups_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ResourceServiceClient client = CreateResourceServiceClient(credential, endpoint);

            await foreach (BinaryData item in client.GetGroupsAsync(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].ToString());
            }
        }

        [Test]
        public async Task GetGroups_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ResourceServiceClient client = CreateResourceServiceClient(credential, endpoint);

            await foreach (BinaryData item in client.GetGroupsAsync(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].ToString());
            }
        }

        [Test]
        public async Task GetAllItems_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ResourceServiceClient client = CreateResourceServiceClient(credential, endpoint);

            await foreach (BinaryData item in client.GetAllItemsAsync(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].ToString());
            }
        }

        [Test]
        public async Task GetAllItems_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ResourceServiceClient client = CreateResourceServiceClient(credential, endpoint);

            await foreach (BinaryData item in client.GetAllItemsAsync(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].ToString());
            }
        }
    }
}
