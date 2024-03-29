// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Analytics.Purview.Account;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace AzureSample.Analytics.Purview.Account.Tests
{
    public partial class PurviewAccountCollectionsTests : AzureSampleAnalyticsPurviewAccountTestBase
    {
        public PurviewAccountCollectionsTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetCollection_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = CreatePurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            Response response = await client.GetCollectionAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetCollection_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = CreatePurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            Response response = await client.GetCollectionAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CreateOrUpdateCollection_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = CreatePurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.CreateOrUpdateCollectionAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CreateOrUpdateCollection_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = CreatePurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            using RequestContent content = RequestContent.Create(new
            {
                description = "<description>",
                friendlyName = "<friendlyName>",
                parentCollection = new
                {
                    referenceName = "<referenceName>",
                },
            });
            Response response = await client.CreateOrUpdateCollectionAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DeleteCollection_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = CreatePurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            Response response = await client.DeleteCollectionAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DeleteCollection_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = CreatePurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            Response response = await client.DeleteCollectionAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetCollectionPath_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = CreatePurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            Response response = await client.GetCollectionPathAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetCollectionPath_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = CreatePurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            Response response = await client.GetCollectionPathAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetCollections_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = CreatePurviewAccountsClient(endpoint, credential).GetCollectionsClient(null);

            await foreach (BinaryData item in client.GetCollectionsAsync(null, null))
            {
            }
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetCollections_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = CreatePurviewAccountsClient(endpoint, credential).GetCollectionsClient(null);

            await foreach (BinaryData item in client.GetCollectionsAsync("<skipToken>", null))
            {
            }
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetChildCollectionNames_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = CreatePurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            await foreach (BinaryData item in client.GetChildCollectionNamesAsync(null, null))
            {
            }
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetChildCollectionNames_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = CreatePurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            await foreach (BinaryData item in client.GetChildCollectionNamesAsync("<skipToken>", null))
            {
            }
        }
    }
}
