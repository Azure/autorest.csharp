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
    public partial class Samples_TopLevelClientWithOperationClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            TopLevelClientWithOperationClient client = new TopLevelClientWithOperationClient(credential);

            Response response = client.Operation(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            TopLevelClientWithOperationClient client = new TopLevelClientWithOperationClient(credential);

            Response response = await client.OperationAsync(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            TopLevelClientWithOperationClient client = new TopLevelClientWithOperationClient(credential);

            Response response = client.Operation(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            TopLevelClientWithOperationClient client = new TopLevelClientWithOperationClient(credential);

            Response response = await client.OperationAsync(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            TopLevelClientWithOperationClient client = new TopLevelClientWithOperationClient(credential);

            foreach (BinaryData item in client.GetAll("<filter>", null))
            {
                JsonElement element = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(element.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            TopLevelClientWithOperationClient client = new TopLevelClientWithOperationClient(credential);

            await foreach (BinaryData item in client.GetAllAsync("<filter>", null))
            {
                JsonElement element = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(element.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            TopLevelClientWithOperationClient client = new TopLevelClientWithOperationClient(credential);

            foreach (BinaryData item in client.GetAll("<filter>", null))
            {
                JsonElement element = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(element.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            TopLevelClientWithOperationClient client = new TopLevelClientWithOperationClient(credential);

            await foreach (BinaryData item in client.GetAllAsync("<filter>", null))
            {
                JsonElement element = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(element.ToString());
            }
        }
    }
}
