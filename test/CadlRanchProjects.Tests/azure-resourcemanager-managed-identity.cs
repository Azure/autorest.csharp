using System;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.ResourceManager.Models.CommonTypes.ManagedIdentity;
using Azure.ResourceManager.Models.CommonTypes.ManagedIdentity.Models;
using Azure.Core;
using NUnit.Framework;
using Azure.ResourceManager;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure;
using Microsoft.Extensions.Hosting;

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
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, response.Value.Data.Identity.Type);
            Assert.AreEqual(Guid.Empty, response.Value.Data.Identity.TenantId);
            Assert.AreEqual(Guid.Empty, response.Value.Data.Identity.PrincipalId);
        });

        [Test]
        [Ignore("known issue: tags{} in data")]
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
            Assert.AreEqual(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Azure.ResourceManager.Models.CommonTypes.ManagedIdentity/managedIdentityTrackedResources/identity"), response.Value.Data.Id);
            Assert.AreEqual("Succeeded", response.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, response.Value.Data.Identity.Type);
            Assert.AreEqual(Guid.Empty, response.Value.Data.Identity.TenantId);
            Assert.AreEqual(Guid.Empty, response.Value.Data.Identity.PrincipalId);
        });

        [Test]
        public Task Azure_Managed_Identity_ManagedIdentityTrackedResource_updateWithUserAssignedAndSystemAssigned() => Test(async (host) =>
        {
            ArmClient client = MgmtTestHelper.CreateArmClientWithMockAuth(host);
            var resourceId = ManagedIdentityTrackedResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "test-rg", "identity");
            var resource = new ManagedIdentityTrackedResource(client, resourceId);
            var patch = new ManagedIdentityTrackedResourcePatch()
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAndUserAssignedV3)
                {
                    UserAssignedIdentities =
                    {
                        new System.Collections.Generic.KeyValuePair<string, Azure.ResourceManager.Models.UserAssignedIdentity>("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/id1", new Azure.ResourceManager.Models.UserAssignedIdentity())
                    }
                }
            };
            var response = await resource.UpdateAsync(patch);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(AzureLocation.EastUS, response.Value.Data.Location);
            Assert.AreEqual(resourceId, response.Value.Data.Id);
            Assert.AreEqual("Succeeded", response.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAndUserAssignedV3, response.Value.Data.Identity.Type);
            Assert.AreEqual(Guid.Empty, response.Value.Data.Identity.UserAssignedIdentities["/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/id1"].ClientId);
            Assert.AreEqual(Guid.Empty, response.Value.Data.Identity.UserAssignedIdentities["/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/id1"].PrincipalId);
            Assert.AreEqual(Guid.Empty, response.Value.Data.Identity.PrincipalId);
            Assert.AreEqual(Guid.Empty, response.Value.Data.Identity.TenantId);
        });
    }
}
