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
    public partial class PurviewAccountsClientTests : AzureSampleAnalyticsPurviewAccountTestBase
    {
        public PurviewAccountsClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetAccountProperties_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountsClient client = CreatePurviewAccountsClient(endpoint, credential);

            Response response = await client.GetAccountPropertiesAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetAccountProperties_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountsClient client = CreatePurviewAccountsClient(endpoint, credential);

            Response response = await client.GetAccountPropertiesAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UpdateAccountProperties_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountsClient client = CreatePurviewAccountsClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.UpdateAccountPropertiesAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UpdateAccountProperties_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountsClient client = CreatePurviewAccountsClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                friendlyName = "<friendlyName>",
            });
            Response response = await client.UpdateAccountPropertiesAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetAccessKeys_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountsClient client = CreatePurviewAccountsClient(endpoint, credential);

            Response response = await client.GetAccessKeysAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetAccessKeys_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountsClient client = CreatePurviewAccountsClient(endpoint, credential);

            Response response = await client.GetAccessKeysAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RegenerateAccessKey_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountsClient client = CreatePurviewAccountsClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.RegenerateAccessKeyAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task RegenerateAccessKey_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountsClient client = CreatePurviewAccountsClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                keyType = "PrimaryAtlasKafkaKey",
            });
            Response response = await client.RegenerateAccessKeyAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetResourceSetRules_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountsClient client = CreatePurviewAccountsClient(endpoint, credential);

            await foreach (BinaryData item in client.GetResourceSetRulesAsync(null, null))
            {
            }
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetResourceSetRules_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountsClient client = CreatePurviewAccountsClient(endpoint, credential);

            await foreach (BinaryData item in client.GetResourceSetRulesAsync("<skipToken>", null))
            {
            }
        }
    }
}
