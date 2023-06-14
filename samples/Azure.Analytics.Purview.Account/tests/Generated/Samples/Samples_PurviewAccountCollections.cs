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

namespace Azure.Analytics.Purview.Account.Samples
{
    internal class Samples_PurviewAccountCollections
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollection()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            Response response = client.GetCollection();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollection_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            Response response = client.GetCollection();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("collectionProvisioningState").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("friendlyName").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("parentCollection").GetProperty("referenceName").ToString());
            Console.WriteLine(result.GetProperty("parentCollection").GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdByType").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedByType").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollection_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            Response response = await client.GetCollectionAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollection_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            Response response = await client.GetCollectionAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("collectionProvisioningState").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("friendlyName").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("parentCollection").GetProperty("referenceName").ToString());
            Console.WriteLine(result.GetProperty("parentCollection").GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdByType").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedByType").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateOrUpdateCollection()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            var data = new { };

            Response response = client.CreateOrUpdateCollection(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateOrUpdateCollection_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            var data = new
            {
                description = "<description>",
                friendlyName = "<friendlyName>",
                parentCollection = new
                {
                    referenceName = "<referenceName>",
                },
            };

            Response response = client.CreateOrUpdateCollection(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("collectionProvisioningState").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("friendlyName").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("parentCollection").GetProperty("referenceName").ToString());
            Console.WriteLine(result.GetProperty("parentCollection").GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdByType").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedByType").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateOrUpdateCollection_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            var data = new { };

            Response response = await client.CreateOrUpdateCollectionAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateOrUpdateCollection_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            var data = new
            {
                description = "<description>",
                friendlyName = "<friendlyName>",
                parentCollection = new
                {
                    referenceName = "<referenceName>",
                },
            };

            Response response = await client.CreateOrUpdateCollectionAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("collectionProvisioningState").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("friendlyName").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("parentCollection").GetProperty("referenceName").ToString());
            Console.WriteLine(result.GetProperty("parentCollection").GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdByType").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedByType").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteCollection()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            Response response = client.DeleteCollection();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteCollection_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            Response response = client.DeleteCollection();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteCollection_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            Response response = await client.DeleteCollectionAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteCollection_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            Response response = await client.DeleteCollectionAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollectionPath()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            Response response = client.GetCollectionPath();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollectionPath_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            Response response = client.GetCollectionPath();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("parentFriendlyNameChain")[0].ToString());
            Console.WriteLine(result.GetProperty("parentNameChain")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionPath_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            Response response = await client.GetCollectionPathAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionPath_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            Response response = await client.GetCollectionPathAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("parentFriendlyNameChain")[0].ToString());
            Console.WriteLine(result.GetProperty("parentNameChain")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollections()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            foreach (var item in client.GetCollections())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollections_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            foreach (var item in client.GetCollections("<skipToken>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("collectionProvisioningState").ToString());
                Console.WriteLine(result.GetProperty("description").ToString());
                Console.WriteLine(result.GetProperty("friendlyName").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("parentCollection").GetProperty("referenceName").ToString());
                Console.WriteLine(result.GetProperty("parentCollection").GetProperty("type").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("createdAt").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("createdBy").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("createdByType").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedAt").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedBy").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedByType").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollections_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            await foreach (var item in client.GetCollectionsAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollections_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            await foreach (var item in client.GetCollectionsAsync("<skipToken>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("collectionProvisioningState").ToString());
                Console.WriteLine(result.GetProperty("description").ToString());
                Console.WriteLine(result.GetProperty("friendlyName").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("parentCollection").GetProperty("referenceName").ToString());
                Console.WriteLine(result.GetProperty("parentCollection").GetProperty("type").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("createdAt").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("createdBy").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("createdByType").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedAt").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedBy").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedByType").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetChildCollectionNames()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            foreach (var item in client.GetChildCollectionNames())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetChildCollectionNames_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            foreach (var item in client.GetChildCollectionNames("<skipToken>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("friendlyName").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetChildCollectionNames_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            await foreach (var item in client.GetChildCollectionNamesAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetChildCollectionNames_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<collectionName>");

            await foreach (var item in client.GetChildCollectionNamesAsync("<skipToken>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("friendlyName").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
            }
        }
    }
}
