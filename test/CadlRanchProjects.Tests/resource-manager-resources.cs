﻿using System;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;
using _Azure.ResourceManager.Resources;
using Azure.ResourceManager.Models;
using _Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Resources;
using Azure;
using Microsoft.Extensions.Azure;

namespace CadlRanchProjects.Tests
{
    public class ResourceManagerModelsResourcesTests: CadlRanchTestBase
    {
        [Test]
        public Task Azure_ResourceManager_Resources_TopLevelTrackedResources_get() => Test(async (host) =>
        {
            var id = TopLevelTrackedResource.CreateResourceIdentifier(Guid.Empty.ToString(), "test-rg", "top");
            var response = await MgmtTestHelper.CreateArmClientWithMockAuth(host).GetTopLevelTrackedResource(id).GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(true, response.Value.HasData);
            Assert.AreEqual("top", response.Value.Data.Name);
            Assert.AreEqual("Azure.ResourceManager.Resources/topLevelTrackedResources", response.Value.Data.ResourceType.ToString());
            Assert.AreEqual(AzureLocation.EastUS, response.Value.Data.Location);
            Assert.AreEqual(ProvisioningState.Succeeded, response.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual("valid", response.Value.Data.Properties.Description);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.CreatedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.CreatedByType);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.LastModifiedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.LastModifiedByType);
        });

        [Test]
        public Task Azure_ResourceManager_Resources_TopLevelTrackedResources_actionSync() => Test(async (host) =>
        {
            var id = TopLevelTrackedResource.CreateResourceIdentifier(Guid.Empty.ToString(), "test-rg", "top");
            var response = await MgmtTestHelper.CreateArmClientWithMockAuth(host).GetTopLevelTrackedResource(id).ActionSyncAsync(new NotificationDetails("Resource action at top level.", true));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Azure_ResourceManager_Resources_TopLevelTrackedResources_createOrReplace() => Test(async (host) =>
        {
            ResourceIdentifier id = ResourceGroupResource.CreateResourceIdentifier(Guid.Empty.ToString(), "test-rg");
            TopLevelTrackedResourceData data = new TopLevelTrackedResourceData(AzureLocation.EastUS)
            {
                Properties = new TopLevelTrackedResourceProperties()
                {
                    Description = "valid"
                }
            };
            var response = await MgmtTestHelper.CreateArmClientWithMockAuth(host).GetResourceGroupResource(id).GetTopLevelTrackedResources().CreateOrUpdateAsync(WaitUntil.Completed, "top", data);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(true, response.Value.HasData);
            Assert.AreEqual("top", response.Value.Data.Name);
            Assert.AreEqual("Azure.ResourceManager.Resources/topLevelTrackedResources", response.Value.Data.ResourceType.ToString());
            Assert.AreEqual(AzureLocation.EastUS, response.Value.Data.Location);
            Assert.AreEqual(ProvisioningState.Succeeded, response.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual("valid", response.Value.Data.Properties.Description);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.CreatedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.CreatedByType);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.LastModifiedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.LastModifiedByType);
        });

        [Test]
        public Task Azure_ResourceManager_Resources_TopLevelTrackedResources_update() => Test(async (host) =>
        {
            var id = TopLevelTrackedResource.CreateResourceIdentifier(Guid.Empty.ToString(), "test-rg", "top");
            var data = new TopLevelTrackedResourceData(AzureLocation.EastUS)
            {
                Properties = new TopLevelTrackedResourceProperties()
                {
                    Description = "valid2"
                }
            };
            var response = await MgmtTestHelper.CreateArmClientWithMockAuth(host).GetTopLevelTrackedResource(id).UpdateAsync(WaitUntil.Completed, data);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(true, response.Value.HasData);
            Assert.AreEqual("top", response.Value.Data.Name);
            Assert.AreEqual("Azure.ResourceManager.Resources/topLevelTrackedResources", response.Value.Data.ResourceType.ToString());
            Assert.AreEqual(AzureLocation.EastUS, response.Value.Data.Location);
            Assert.AreEqual("valid2", response.Value.Data.Properties.Description);
            Assert.AreEqual(ProvisioningState.Succeeded, response.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.CreatedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.CreatedByType);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.LastModifiedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.LastModifiedByType);
        });

        [Test]
        public Task Azure_ResourceManager_Resources_TopLevelTrackedResources_delete() => Test(async (host) =>
        {
            var id = TopLevelTrackedResource.CreateResourceIdentifier(Guid.Empty.ToString(), "test-rg", "top");
            var response = await MgmtTestHelper.CreateArmClientWithMockAuth(host).GetTopLevelTrackedResource(id).DeleteAsync(WaitUntil.Completed);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Azure_ResourceManager_Resources_TopLevelTrackedResources_listByResourceGroup() => Test(async (host) =>
        {
            var id = ResourceGroupResource.CreateResourceIdentifier(Guid.Empty.ToString(), "test-rg");
            var response = await MgmtTestHelper.CreateArmClientWithMockAuth(host).GetResourceGroupResource(id).GetTopLevelTrackedResourceAsync("top");
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(true, response.Value.HasData);
            Assert.AreEqual("top", response.Value.Data.Name);
            Assert.AreEqual("Azure.ResourceManager.Resources/topLevelTrackedResources", response.Value.Data.ResourceType.ToString());
            Assert.AreEqual(AzureLocation.EastUS, response.Value.Data.Location);
            Assert.AreEqual("valid", response.Value.Data.Properties.Description);
            Assert.AreEqual(ProvisioningState.Succeeded, response.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.CreatedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.CreatedByType);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.LastModifiedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.LastModifiedByType);
        });

        [Test]
        public Task Azure_ResourceManager_Resources_TopLevelTrackedResources_listBySubscription() => Test(async (host) =>
        {
            var id = SubscriptionResource.CreateResourceIdentifier(Guid.Empty.ToString());
            var responses = MgmtTestHelper.CreateArmClientWithMockAuth(host).GetSubscriptionResource(id).GetTopLevelTrackedResourcesAsync();
            var sum = 0;
            await foreach (var response in responses)
            {
                sum++;
                Assert.AreEqual(true, response.HasData);
                Assert.AreEqual("top", response.Data.Name);
                Assert.AreEqual("Azure.ResourceManager.Resources/topLevelTrackedResources", response.Data.ResourceType.ToString());
                Assert.AreEqual(AzureLocation.EastUS, response.Data.Location);
                Assert.AreEqual("valid", response.Data.Properties.Description);
                Assert.AreEqual(ProvisioningState.Succeeded, response.Data.Properties.ProvisioningState);
                Assert.AreEqual("AzureSDK", response.Data.SystemData.CreatedBy);
                Assert.AreEqual(CreatedByType.User, response.Data.SystemData.CreatedByType);
                Assert.AreEqual("AzureSDK", response.Data.SystemData.LastModifiedBy);
                Assert.AreEqual(CreatedByType.User, response.Data.SystemData.LastModifiedByType);
            }
            Assert.AreEqual(1, sum);
        });

        [Test]
        public Task Azure_ResourceManager_Resources_NestedProxyResources_get() => Test(async (host) =>
        {
            var id = NestedProxyResource.CreateResourceIdentifier(Guid.Empty.ToString(), "test-rg", "top", "nested");
            var response = await MgmtTestHelper.CreateArmClientWithMockAuth(host).GetNestedProxyResource(id).GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(true, response.Value.HasData);
            Assert.AreEqual("Azure.ResourceManager.Resources/topLevelTrackedResources/top/nestedProxyResources", response.Value.Data.ResourceType.ToString());
            Assert.AreEqual("valid", response.Value.Data.Properties.Description);
            Assert.AreEqual(ProvisioningState.Succeeded, response.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.CreatedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.CreatedByType);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.LastModifiedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.LastModifiedByType);
        });

        [Test]
        public Task Azure_ResourceManager_Resources_NestedProxyResources_createOrReplace() => Test(async (host) =>
        {
            var id = TopLevelTrackedResource.CreateResourceIdentifier(Guid.Empty.ToString(), "test-rg", "top");
            var data = new NestedProxyResourceData()
            {
                Properties = new NestedProxyResourceProperties()
                {
                    Description = "valid"
                }
            };
            var response =await (await MgmtTestHelper.CreateArmClientWithMockAuth(host).GetTopLevelTrackedResource(id).GetAsync()).Value.GetNestedProxyResources().CreateOrUpdateAsync(WaitUntil.Completed, "nested", data);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(true, response.Value.HasData);
            Assert.AreEqual("Azure.ResourceManager.Resources/topLevelTrackedResources/top/nestedProxyResources", response.Value.Data.ResourceType.ToString());
            Assert.AreEqual("valid", response.Value.Data.Properties.Description);
            Assert.AreEqual(ProvisioningState.Succeeded, response.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.CreatedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.CreatedByType);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.LastModifiedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.LastModifiedByType);
        });

        [Test]
        public Task Azure_ResourceManager_Resources_NestedProxyResources_update() => Test(async (host) =>
        {
            var id = NestedProxyResource.CreateResourceIdentifier(Guid.Empty.ToString(), "test-rg", "top", "nested");
            var data = new NestedProxyResourceData()
            {
                Properties = new NestedProxyResourceProperties()
                {
                    Description = "valid2"
                }
            };
            var response = await MgmtTestHelper.CreateArmClientWithMockAuth(host).GetNestedProxyResource(id).UpdateAsync(WaitUntil.Completed, data);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(true, response.Value.HasData);
            Assert.AreEqual("Azure.ResourceManager.Resources/topLevelTrackedResources/top/nestedProxyResources", response.Value.Data.ResourceType.ToString());
            Assert.AreEqual("valid2", response.Value.Data.Properties.Description);
            Assert.AreEqual(ProvisioningState.Succeeded, response.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.CreatedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.CreatedByType);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.LastModifiedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.LastModifiedByType);
        });

        [Test]
        public Task Azure_ResourceManager_Resources_NestedProxyResources_delete() => Test(async (host) =>
        {
            var id = NestedProxyResource.CreateResourceIdentifier(Guid.Empty.ToString(), "test-rg", "top", "nested");
            var response = await MgmtTestHelper.CreateArmClientWithMockAuth(host).GetNestedProxyResource(id).DeleteAsync(WaitUntil.Completed);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task Azure_ResourceManager_Resources_NestedProxyResources_listByTopLevelTrackedResource() => Test(async (host) =>
        {
            var id = TopLevelTrackedResource.CreateResourceIdentifier(Guid.Empty.ToString(), "test-rg", "top");
            var response = await MgmtTestHelper.CreateArmClientWithMockAuth(host).GetTopLevelTrackedResource(id).GetNestedProxyResourceAsync("nested");
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(true, response.Value.HasData);
            Assert.AreEqual("Azure.ResourceManager.Resources/topLevelTrackedResources/top/nestedProxyResources", response.Value.Data.ResourceType.ToString());
            Assert.AreEqual("valid", response.Value.Data.Properties.Description);
            Assert.AreEqual(ProvisioningState.Succeeded, response.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.CreatedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.CreatedByType);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.LastModifiedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.LastModifiedByType);
        });

        [Test]
        public Task Azure_ResourceManager_Resources_SingletonTrackedResource_createOrUpdate() => Test(async (host) =>
        {
            var id = SingletonTrackedResource.CreateResourceIdentifier(Guid.Empty.ToString(), "test-rg");
            var data = new SingletonTrackedResourceData(AzureLocation.EastUS)
            {
                Properties = new SingletonTrackedResourceProperties()
                {
                    Description = "valid"
                }
            };
            var response = await MgmtTestHelper.CreateArmClientWithMockAuth(host).GetSingletonTrackedResource(id).CreateOrUpdateAsync(WaitUntil.Completed, data);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(true, response.Value.HasData);
            Assert.AreEqual("Azure.ResourceManager.Resources/singletonTrackedResources", response.Value.Data.ResourceType.ToString());
            Assert.AreEqual("valid", response.Value.Data.Properties.Description);
            Assert.AreEqual(ProvisioningState.Succeeded, response.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.CreatedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.CreatedByType);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.LastModifiedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.LastModifiedByType);
        });

        [Test]
        public Task Azure_ResourceManager_Resources_SingletonTrackedResource_update() => Test(async (host) =>
        {
            var id = SingletonTrackedResource.CreateResourceIdentifier(Guid.Empty.ToString(), "test-rg");
            var data = new SingletonTrackedResourceData(AzureLocation.EastUS2)
            {
                Properties = new SingletonTrackedResourceProperties()
                {
                    Description = "valid2"
                }
            };
            var response = await MgmtTestHelper.CreateArmClientWithMockAuth(host).GetSingletonTrackedResource(id).UpdateAsync(data);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(true, response.Value.HasData);
            Assert.AreEqual("Azure.ResourceManager.Resources/singletonTrackedResources", response.Value.Data.ResourceType.ToString());
            Assert.AreEqual("valid2", response.Value.Data.Properties.Description);
            Assert.AreEqual(ProvisioningState.Succeeded, response.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.CreatedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.CreatedByType);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.LastModifiedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.LastModifiedByType);
        });

        [Test]
        public Task Azure_ResourceManager_Resources_SingletonTrackedResource_getByResourceGroup() => Test(async (host) =>
        {
            var id = SingletonTrackedResource.CreateResourceIdentifier(Guid.Empty.ToString(), "test-rg");
            var response = await MgmtTestHelper.CreateArmClientWithMockAuth(host).GetSingletonTrackedResource(id).GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(true, response.Value.HasData);
            Assert.AreEqual("Azure.ResourceManager.Resources/singletonTrackedResources", response.Value.Data.ResourceType.ToString());
            Assert.AreEqual("valid", response.Value.Data.Properties.Description);
            Assert.AreEqual(ProvisioningState.Succeeded, response.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.CreatedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.CreatedByType);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.LastModifiedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.LastModifiedByType);
        });
    }
}
