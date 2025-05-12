using System.Threading.Tasks;
using _Azure.ResourceManager.NonResources;
using _Azure.ResourceManager.NonResources.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class AzureResourceManagerNonResourceTests: CadlRanchTestBase
    {
        [Test]
        public Task Azure_ResourceManager_NonResource_NonResourceOperations_get() => Test(async (host) =>
        {
            ArmClient client = MgmtTestHelper.CreateArmClientWithMockAuth(host);
            var resourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            var subscriptionResource = client.GetSubscriptionResource(resourceId);
            var response = await subscriptionResource.GetNonResourceOperationAsync("eastus", "hello");

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("id", response.Value.Id);
            Assert.AreEqual("hello", response.Value.Name);
            Assert.AreEqual("nonResource", response.Value.Type);
        });

        [Test]
        public Task Azure_ResourceManager_NonResource_NonResourceOperations_create() => Test(async (host) =>
        {
            ArmClient client = MgmtTestHelper.CreateArmClientWithMockAuth(host);
            var resourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            var subscriptionResource = client.GetSubscriptionResource(resourceId);
            var response = await subscriptionResource.CreateNonResourceOperationAsync("eastus", "hello", new NonResource()
            {
                Id = "id",
                Name = "hello",
                Type = "nonResource"
            });

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("id", response.Value.Id);
            Assert.AreEqual("hello", response.Value.Name);
            Assert.AreEqual("nonResource", response.Value.Type);
        });
    }
}
