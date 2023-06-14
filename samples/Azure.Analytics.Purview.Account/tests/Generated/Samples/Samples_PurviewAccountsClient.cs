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
    public class Samples_PurviewAccountsClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAccountProperties()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            Response response = client.GetAccountProperties();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAccountProperties_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            Response response = client.GetAccountProperties();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("identity").GetProperty("principalId").ToString());
            Console.WriteLine(result.GetProperty("identity").GetProperty("tenantId").ToString());
            Console.WriteLine(result.GetProperty("identity").GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("cloudConnectors").GetProperty("awsExternalId").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("createdAt").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("createdByObjectId").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("endpoints").GetProperty("catalog").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("endpoints").GetProperty("guardian").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("endpoints").GetProperty("scan").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("friendlyName").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("managedResourceGroupName").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("managedResources").GetProperty("eventHubNamespace").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("managedResources").GetProperty("resourceGroup").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("managedResources").GetProperty("storageAccount").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("privateEndpoint").GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("privateLinkServiceConnectionState").GetProperty("actionsRequired").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("privateLinkServiceConnectionState").GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("privateLinkServiceConnectionState").GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("publicNetworkAccess").ToString());
            Console.WriteLine(result.GetProperty("sku").GetProperty("capacity").ToString());
            Console.WriteLine(result.GetProperty("sku").GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdByType").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedByType").ToString());
            Console.WriteLine(result.GetProperty("tags").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("type").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAccountProperties_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            Response response = await client.GetAccountPropertiesAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAccountProperties_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            Response response = await client.GetAccountPropertiesAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("identity").GetProperty("principalId").ToString());
            Console.WriteLine(result.GetProperty("identity").GetProperty("tenantId").ToString());
            Console.WriteLine(result.GetProperty("identity").GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("cloudConnectors").GetProperty("awsExternalId").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("createdAt").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("createdByObjectId").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("endpoints").GetProperty("catalog").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("endpoints").GetProperty("guardian").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("endpoints").GetProperty("scan").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("friendlyName").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("managedResourceGroupName").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("managedResources").GetProperty("eventHubNamespace").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("managedResources").GetProperty("resourceGroup").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("managedResources").GetProperty("storageAccount").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("privateEndpoint").GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("privateLinkServiceConnectionState").GetProperty("actionsRequired").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("privateLinkServiceConnectionState").GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("privateLinkServiceConnectionState").GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("publicNetworkAccess").ToString());
            Console.WriteLine(result.GetProperty("sku").GetProperty("capacity").ToString());
            Console.WriteLine(result.GetProperty("sku").GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdByType").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedByType").ToString());
            Console.WriteLine(result.GetProperty("tags").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("type").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UpdateAccountProperties()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            var data = new { };

            Response response = client.UpdateAccountProperties(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UpdateAccountProperties_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            var data = new
            {
                friendlyName = "<friendlyName>",
            };

            Response response = client.UpdateAccountProperties(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("identity").GetProperty("principalId").ToString());
            Console.WriteLine(result.GetProperty("identity").GetProperty("tenantId").ToString());
            Console.WriteLine(result.GetProperty("identity").GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("cloudConnectors").GetProperty("awsExternalId").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("createdAt").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("createdByObjectId").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("endpoints").GetProperty("catalog").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("endpoints").GetProperty("guardian").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("endpoints").GetProperty("scan").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("friendlyName").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("managedResourceGroupName").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("managedResources").GetProperty("eventHubNamespace").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("managedResources").GetProperty("resourceGroup").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("managedResources").GetProperty("storageAccount").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("privateEndpoint").GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("privateLinkServiceConnectionState").GetProperty("actionsRequired").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("privateLinkServiceConnectionState").GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("privateLinkServiceConnectionState").GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("publicNetworkAccess").ToString());
            Console.WriteLine(result.GetProperty("sku").GetProperty("capacity").ToString());
            Console.WriteLine(result.GetProperty("sku").GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdByType").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedByType").ToString());
            Console.WriteLine(result.GetProperty("tags").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("type").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UpdateAccountProperties_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            var data = new { };

            Response response = await client.UpdateAccountPropertiesAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UpdateAccountProperties_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            var data = new
            {
                friendlyName = "<friendlyName>",
            };

            Response response = await client.UpdateAccountPropertiesAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("identity").GetProperty("principalId").ToString());
            Console.WriteLine(result.GetProperty("identity").GetProperty("tenantId").ToString());
            Console.WriteLine(result.GetProperty("identity").GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("cloudConnectors").GetProperty("awsExternalId").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("createdAt").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("createdByObjectId").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("endpoints").GetProperty("catalog").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("endpoints").GetProperty("guardian").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("endpoints").GetProperty("scan").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("friendlyName").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("managedResourceGroupName").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("managedResources").GetProperty("eventHubNamespace").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("managedResources").GetProperty("resourceGroup").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("managedResources").GetProperty("storageAccount").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("privateEndpoint").GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("privateLinkServiceConnectionState").GetProperty("actionsRequired").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("privateLinkServiceConnectionState").GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("privateLinkServiceConnectionState").GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("privateEndpointConnections")[0].GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("publicNetworkAccess").ToString());
            Console.WriteLine(result.GetProperty("sku").GetProperty("capacity").ToString());
            Console.WriteLine(result.GetProperty("sku").GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdByType").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedByType").ToString());
            Console.WriteLine(result.GetProperty("tags").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("type").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAccessKeys()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            Response response = client.GetAccessKeys();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAccessKeys_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            Response response = client.GetAccessKeys();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("atlasKafkaPrimaryEndpoint").ToString());
            Console.WriteLine(result.GetProperty("atlasKafkaSecondaryEndpoint").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAccessKeys_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            Response response = await client.GetAccessKeysAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAccessKeys_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            Response response = await client.GetAccessKeysAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("atlasKafkaPrimaryEndpoint").ToString());
            Console.WriteLine(result.GetProperty("atlasKafkaSecondaryEndpoint").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RegenerateAccessKey()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            var data = new { };

            Response response = client.RegenerateAccessKey(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RegenerateAccessKey_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            var data = new
            {
                keyType = "PrimaryAtlasKafkaKey",
            };

            Response response = client.RegenerateAccessKey(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("atlasKafkaPrimaryEndpoint").ToString());
            Console.WriteLine(result.GetProperty("atlasKafkaSecondaryEndpoint").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RegenerateAccessKey_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            var data = new { };

            Response response = await client.RegenerateAccessKeyAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RegenerateAccessKey_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            var data = new
            {
                keyType = "PrimaryAtlasKafkaKey",
            };

            Response response = await client.RegenerateAccessKeyAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("atlasKafkaPrimaryEndpoint").ToString());
            Console.WriteLine(result.GetProperty("atlasKafkaSecondaryEndpoint").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetResourceSetRules()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            foreach (var item in client.GetResourceSetRules())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetResourceSetRules_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            foreach (var item in client.GetResourceSetRules("<skipToken>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("advancedResourceSet").GetProperty("modifiedAt").ToString());
                Console.WriteLine(result.GetProperty("advancedResourceSet").GetProperty("resourceSetProcessing").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("createdBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("filterType").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("lastUpdatedTimestamp").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("modifiedBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("path").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("createdBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("description").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("disabled").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("disableRecursiveReplacerApplication").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("lastUpdatedTimestamp").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("modifiedBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("typeName").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("createdBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("enableDefaultPatterns").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("lastUpdatedTimestamp").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("modifiedBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("description").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("disabled").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("dynamicReplacement").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("entityTypes")[0].ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("lastUpdatedTimestamp").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("maxDigits").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("maxLetters").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDashes").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDigits").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDigitsOrLetters").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDots").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minHex").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minLetters").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minUnderscores").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("options").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("regexStr").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("replaceWith").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("version").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("condition").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("createdBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("description").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("disabled").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("disableRecursiveReplacerApplication").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("maxDigits").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("maxLetters").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDashes").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDigits").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDigitsOrLetters").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDots").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minHex").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minLetters").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minUnderscores").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("options").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("regexStr").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("lastUpdatedTimestamp").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("modifiedBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("maxDigits").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("maxLetters").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDashes").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDigits").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDigitsOrLetters").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDots").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minHex").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minLetters").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minUnderscores").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("options").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("regexStr").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("replaceWith").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("createdBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("filterType").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("lastUpdatedTimestamp").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("modifiedBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("path").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("bindingUrl").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("displayName").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("isResourceSet").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("lastUpdatedTimestamp").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("qualifiedName").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("storeType").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("version").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetResourceSetRules_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            await foreach (var item in client.GetResourceSetRulesAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetResourceSetRules_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential);

            await foreach (var item in client.GetResourceSetRulesAsync("<skipToken>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("advancedResourceSet").GetProperty("modifiedAt").ToString());
                Console.WriteLine(result.GetProperty("advancedResourceSet").GetProperty("resourceSetProcessing").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("createdBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("filterType").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("lastUpdatedTimestamp").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("modifiedBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("path").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("createdBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("description").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("disabled").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("disableRecursiveReplacerApplication").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("lastUpdatedTimestamp").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("modifiedBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("typeName").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("createdBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("enableDefaultPatterns").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("lastUpdatedTimestamp").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("modifiedBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("description").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("disabled").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("dynamicReplacement").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("entityTypes")[0].ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("lastUpdatedTimestamp").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("maxDigits").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("maxLetters").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDashes").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDigits").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDigitsOrLetters").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDots").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minHex").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minLetters").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minUnderscores").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("options").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("regexStr").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("replaceWith").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("version").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("condition").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("createdBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("description").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("disabled").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("disableRecursiveReplacerApplication").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("maxDigits").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("maxLetters").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDashes").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDigits").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDigitsOrLetters").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDots").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minHex").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minLetters").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minUnderscores").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("options").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("regexStr").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("lastUpdatedTimestamp").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("modifiedBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("maxDigits").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("maxLetters").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDashes").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDigits").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDigitsOrLetters").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDots").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minHex").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minLetters").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minUnderscores").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("options").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("regexStr").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("replaceWith").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("createdBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("filterType").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("lastUpdatedTimestamp").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("modifiedBy").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("path").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("bindingUrl").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("displayName").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("isResourceSet").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("lastUpdatedTimestamp").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("qualifiedName").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("storeType").ToString());
                Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("version").ToString());
            }
        }
    }
}
