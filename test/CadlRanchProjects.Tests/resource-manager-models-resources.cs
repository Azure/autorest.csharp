using System;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;
using _Azure.ResourceManager.Models.Resources;
using Azure.ResourceManager.Models;
using _Azure.ResourceManager.Models.Resources.Models;
using Azure.ResourceManager.Resources;
using Azure;

namespace CadlRanchProjects.Tests
{
    public class ResourceManagerModelsResourcesTests: CadlRanchTestBase
    {
        [Test]
        public Task Azure_Arm_Models_Resources_TopLevelTrackedResources_get() => Test(async (host) =>
        {
            var id = TopLevelTrackedResource.CreateResourceIdentifier(Guid.Empty.ToString(), "test-rg", "top");
            var response = await MgmtTestHelper.CreateArmClientWithMockAuth(host).GetTopLevelTrackedResource(id).GetAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(true, response.Value.HasData);
            Assert.AreEqual("top", response.Value.Data.Name);
            Assert.AreEqual("Azure.ResourceManager.Models.Resources/topLevelTrackedResources", response.Value.Data.ResourceType.ToString());
            Assert.AreEqual(AzureLocation.EastUS, response.Value.Data.Location);
            Assert.AreEqual(ProvisioningState.Succeeded, response.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual("valid", response.Value.Data.Properties.Description);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.CreatedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.CreatedByType);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.LastModifiedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.LastModifiedByType);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/4876")]
        public Task Azure_Arm_Models_Resources_TopLevelTrackedResources_createOrReplace() => Test(async (host) =>
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
            Assert.AreEqual("Azure.ResourceManager.Models.Resources/topLevelTrackedResources", response.Value.Data.ResourceType.ToString());
            Assert.AreEqual(AzureLocation.EastUS, response.Value.Data.Location);
            Assert.AreEqual(ProvisioningState.Succeeded, response.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual("valid", response.Value.Data.Properties.Description);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.CreatedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.CreatedByType);
            Assert.AreEqual("AzureSDK", response.Value.Data.SystemData.LastModifiedBy);
            Assert.AreEqual(CreatedByType.User, response.Value.Data.SystemData.LastModifiedByType);
        });
    }
}
