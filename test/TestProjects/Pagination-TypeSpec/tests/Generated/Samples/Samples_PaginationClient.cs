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
using Pagination.Models;

namespace Pagination.Samples
{
    public class Samples_PaginationClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPaginationLedgerEntries()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
            };

            foreach (var item in client.GetPaginationLedgerEntries(RequestContent.Create(data)))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("contents").ToString());
                Console.WriteLine(result.GetProperty("collectionId").ToString());
                Console.WriteLine(result.GetProperty("transactionId").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPaginationLedgerEntries_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
            };

            foreach (var item in client.GetPaginationLedgerEntries(RequestContent.Create(data)))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("contents").ToString());
                Console.WriteLine(result.GetProperty("collectionId").ToString());
                Console.WriteLine(result.GetProperty("transactionId").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPaginationLedgerEntries_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
            };

            await foreach (var item in client.GetPaginationLedgerEntriesAsync(RequestContent.Create(data)))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("contents").ToString());
                Console.WriteLine(result.GetProperty("collectionId").ToString());
                Console.WriteLine(result.GetProperty("transactionId").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPaginationLedgerEntries_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            var data = new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
            };

            await foreach (var item in client.GetPaginationLedgerEntriesAsync(RequestContent.Create(data)))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("contents").ToString());
                Console.WriteLine(result.GetProperty("collectionId").ToString());
                Console.WriteLine(result.GetProperty("transactionId").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPaginationLedgerEntries_Convenience_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            var bodyInput = new ListLedgerEntryInputBody("<requiredString>", 1234);
            await foreach (var item in client.GetPaginationLedgerEntriesAsync(bodyInput))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLedgerEntries()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            foreach (var item in client.GetLedgerEntries(new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("contents").ToString());
                Console.WriteLine(result.GetProperty("collectionId").ToString());
                Console.WriteLine(result.GetProperty("transactionId").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLedgerEntries_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            foreach (var item in client.GetLedgerEntries(new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("contents").ToString());
                Console.WriteLine(result.GetProperty("collectionId").ToString());
                Console.WriteLine(result.GetProperty("transactionId").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLedgerEntries_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            await foreach (var item in client.GetLedgerEntriesAsync(new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("contents").ToString());
                Console.WriteLine(result.GetProperty("collectionId").ToString());
                Console.WriteLine(result.GetProperty("transactionId").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLedgerEntries_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            await foreach (var item in client.GetLedgerEntriesAsync(new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("contents").ToString());
                Console.WriteLine(result.GetProperty("collectionId").ToString());
                Console.WriteLine(result.GetProperty("transactionId").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLedgerEntries_Convenience_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            await foreach (var item in client.GetLedgerEntriesAsync())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTextBlocklists()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            foreach (var item in client.GetTextBlocklists(new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("blocklistName").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTextBlocklists_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            foreach (var item in client.GetTextBlocklists(new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("blocklistName").ToString());
                Console.WriteLine(result.GetProperty("description").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTextBlocklists_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            await foreach (var item in client.GetTextBlocklistsAsync(new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("blocklistName").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTextBlocklists_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            await foreach (var item in client.GetTextBlocklistsAsync(new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("blocklistName").ToString());
                Console.WriteLine(result.GetProperty("description").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTextBlocklists_Convenience_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            await foreach (var item in client.GetTextBlocklistsAsync())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTextBlocklistItems()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            foreach (var item in client.GetTextBlocklistItems("<blocklistName>", 1234, 1234, 1234, new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("blockItemId").ToString());
                Console.WriteLine(result.GetProperty("text").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTextBlocklistItems_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            foreach (var item in client.GetTextBlocklistItems("<blocklistName>", 1234, 1234, 1234, new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("blockItemId").ToString());
                Console.WriteLine(result.GetProperty("description").ToString());
                Console.WriteLine(result.GetProperty("text").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTextBlocklistItems_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            await foreach (var item in client.GetTextBlocklistItemsAsync("<blocklistName>", 1234, 1234, 1234, new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("blockItemId").ToString());
                Console.WriteLine(result.GetProperty("text").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTextBlocklistItems_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            await foreach (var item in client.GetTextBlocklistItemsAsync("<blocklistName>", 1234, 1234, 1234, new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("blockItemId").ToString());
                Console.WriteLine(result.GetProperty("description").ToString());
                Console.WriteLine(result.GetProperty("text").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTextBlocklistItems_Convenience_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PaginationClient(endpoint, credential);

            await foreach (var item in client.GetTextBlocklistItemsAsync("<blocklistName>", 1234, 1234, 1234))
            {
            }
        }
    }
}
