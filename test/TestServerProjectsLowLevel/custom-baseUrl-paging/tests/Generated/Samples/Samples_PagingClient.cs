// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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

namespace custom_baseUrl_paging_LowLevel.Samples
{
    public class Samples_PagingClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPagesPartialUrl()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetPagesPartialUrl("<accountName>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPagesPartialUrl_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetPagesPartialUrl("<accountName>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPagesPartialUrl_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetPagesPartialUrlAsync("<accountName>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPagesPartialUrl_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetPagesPartialUrlAsync("<accountName>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPagesPartialUrlOperation()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetPagesPartialUrlOperation("<accountName>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPagesPartialUrlOperation_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetPagesPartialUrlOperation("<accountName>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPagesPartialUrlOperation_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetPagesPartialUrlOperationAsync("<accountName>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPagesPartialUrlOperation_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetPagesPartialUrlOperationAsync("<accountName>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPagesPartialUrlOperationNext()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetPagesPartialUrlOperationNext("<accountName>", "<nextLink>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPagesPartialUrlOperationNext_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetPagesPartialUrlOperationNext("<accountName>", "<nextLink>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPagesPartialUrlOperationNext_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetPagesPartialUrlOperationNextAsync("<accountName>", "<nextLink>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPagesPartialUrlOperationNext_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetPagesPartialUrlOperationNextAsync("<accountName>", "<nextLink>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }
    }
}
