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

namespace SingleTopLevelClientWithOperations_LowLevel.Samples
{
    public class Samples_TopLevelClientWithOperationClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new TopLevelClientWithOperationClient(credential);

            Response response = client.Operation();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new TopLevelClientWithOperationClient(credential);

            Response response = client.Operation();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new TopLevelClientWithOperationClient(credential);

            Response response = await client.OperationAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new TopLevelClientWithOperationClient(credential);

            Response response = await client.OperationAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new TopLevelClientWithOperationClient(credential);

            foreach (var item in client.GetAll("<filter>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new TopLevelClientWithOperationClient(credential);

            foreach (var item in client.GetAll("<filter>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new TopLevelClientWithOperationClient(credential);

            await foreach (var item in client.GetAllAsync("<filter>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new TopLevelClientWithOperationClient(credential);

            await foreach (var item in client.GetAllAsync("<filter>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }
    }
}
