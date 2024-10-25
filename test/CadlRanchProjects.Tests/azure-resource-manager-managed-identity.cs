using System;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.Core;
using Azure.ResourceManager;
using _Azure.ResourceManager.CommonProperties;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.Models;

namespace CadlRanchProjects.Tests
{
    public class AzureManagedIdentityTest : CadlRanchTestBase
    {
        [Test]
        public Task Azure_Managed_Identity_ManagedIdentityTrackedResource_get() => Test(async (host) =>
        {
            ArmClient client = MgmtTestHelper.CreateArmClientWithMockAuth(host);
            var resourceId = ManagedIdentityTrackedResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "test-rg", "identity");
            var resource = new ManagedIdentityTrackedResource(client, resourceId);
            var response = await resource.GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(AzureLocation.EastUS, response.Value.Data.Location);
            Assert.AreEqual(resourceId, response.Value.Data.Id);
            Assert.AreEqual("Succeeded", response.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, response.Value.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(Guid.Empty, response.Value.Data.Identity.TenantId);
            Assert.AreEqual(Guid.Empty, response.Value.Data.Identity.PrincipalId);
        });

        [Test]
        public Task Azure_Managed_Identity_ManagedIdentityTrackedResourceCollection_createWithSystemAssigned() => Test(async (host) =>
        {
            ArmClient client = MgmtTestHelper.CreateArmClientWithMockAuth(host);
            var resourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "test-rg");
            var collection = new ManagedIdentityTrackedResourceCollection(client, resourceId);
            var inputData = new ManagedIdentityTrackedResourceData(AzureLocation.EastUS)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            var response = await collection.CreateOrUpdateAsync(Azure.WaitUntil.Completed, "identity", inputData);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(AzureLocation.EastUS, response.Value.Data.Location);
            Assert.AreEqual(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Azure.ResourceManager.CommonProperties/managedIdentityTrackedResources/identity"), response.Value.Data.Id);
            Assert.AreEqual("Succeeded", response.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, response.Value.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(Guid.Empty, response.Value.Data.Identity.TenantId);
            Assert.AreEqual(Guid.Empty, response.Value.Data.Identity.PrincipalId);
        });

        [Test]
        public Task Azure_Managed_Identity_ManagedIdentityTrackedResource_updateWithUserAssignedAndSystemAssigned() => Test(async (host) =>
        {
            ArmClient client = MgmtTestHelper.CreateArmClientWithMockAuth(host);
            var resourceId = ManagedIdentityTrackedResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "test-rg", "identity");
            var resourceIdentifier = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/id1");
            var resource = new ManagedIdentityTrackedResource(client, resourceId);
            var patch = new ManagedIdentityTrackedResourceData(AzureLocation.EastUS)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned)
                {
                    UserAssignedIdentities =
                    {
                        new System.Collections.Generic.KeyValuePair<ResourceIdentifier, UserAssignedIdentity>(resourceIdentifier, new UserAssignedIdentity())
                    }
                }
            };
            var response = await resource.UpdateAsync(patch);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(AzureLocation.EastUS, response.Value.Data.Location);
            Assert.AreEqual(resourceId, response.Value.Data.Id);
            Assert.AreEqual("Succeeded", response.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssignedUserAssigned, response.Value.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(Guid.Empty, response.Value.Data.Identity.UserAssignedIdentities[resourceIdentifier].ClientId);
            Assert.AreEqual(Guid.Empty, response.Value.Data.Identity.UserAssignedIdentities[resourceIdentifier].PrincipalId);
            Assert.AreEqual(Guid.Empty, response.Value.Data.Identity.PrincipalId);
            Assert.AreEqual(Guid.Empty, response.Value.Data.Identity.TenantId);
        });
    }
}
