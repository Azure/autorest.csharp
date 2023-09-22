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

namespace SingleTopLevelClientWithOperations_LowLevel.Tests
{
    public class TopLevelClientWithOperationClientTests : SingleTopLevelClientWithOperations_LowLevelTestBase
    {
        public TopLevelClientWithOperationClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task Operation_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TopLevelClientWithOperationClient client = CreateTopLevelClientWithOperationClient(credential, endpoint);

            Response response = await client.OperationAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        public async Task Operation_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TopLevelClientWithOperationClient client = CreateTopLevelClientWithOperationClient(credential, endpoint);

            Response response = await client.OperationAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        public async Task GetAll_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TopLevelClientWithOperationClient client = CreateTopLevelClientWithOperationClient(credential, endpoint);

            await foreach (BinaryData item in client.GetAllAsync("<filter>", null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].ToString());
            }
        }

        [Test]
        public async Task GetAll_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TopLevelClientWithOperationClient client = CreateTopLevelClientWithOperationClient(credential, endpoint);

            await foreach (BinaryData item in client.GetAllAsync("<filter>", null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].ToString());
            }
        }
    }
}
