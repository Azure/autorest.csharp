// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample.Samples
{
    public partial class Sample_ManagedHsmCollection
    {
        // Create a new managed HSM Pool or update an existing managed HSM Pool
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate_CreateANewManagedHSMPoolOrUpdateAnExistingManagedHSMPool()
        {
            // Generated from example definition:
            // this example is just showing the usage of "ManagedHsms_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "hsm-group";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this ManagedHsmResource
            ManagedHsmCollection collection = resourceGroupResource.GetManagedHsms();

            // invoke the operation
            string name = "hsm1";
            ManagedHsmData data = new ManagedHsmData(new AzureLocation("westus"))
            {
                Properties = new ManagedHsmProperties()
                {
                    Settings = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                    {
                        ["config1"] = "value1",
                        ["config2"] = "8427",
                        ["config3"] = "false",
                        ["config4"] = new object[] { "1", "2" },
                        ["config5"] = new Dictionary<string, object>()
                        {
                            ["inner"] = "something"
                        }
                    }),
                    ProtectedSettings = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                    {
                        ["protected1"] = "value2",
                        ["protected2"] = "10",
                        ["protected3"] = "false",
                        ["protected4"] = new object[] { "1", "2", "3" },
                        ["protected5"] = new Dictionary<string, object>()
                        {
                            ["protectedInner"] = "something else"
                        }
                    }),
                    RawMessage = Convert.FromBase64String("PFX-or-PEM-blob"),
                    TenantId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                    InitialAdminObjectIds =
{
"00000000-0000-0000-0000-000000000000"
},
                    EnableSoftDelete = true,
                    SoftDeleteRetentionInDays = 90,
                    EnablePurgeProtection = true,
                    NetworkAcls = new MhsmNetworkRuleSet()
                    {
                        VirtualNetworkRules =
{
new WritableSubResource()
{
Id = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/hsm-group/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/default"),
}
},
                    },
                },
                Sku = new ManagedHsmSku(ManagedHsmSkuFamily.B, ManagedHsmSkuName.StandardB1),
                Tags =
{
["Dept"] = "hsm",
["Environment"] = "dogfood",
},
            };
            ArmOperation<ManagedHsmResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            ManagedHsmResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            ManagedHsmData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Retrieve a managed HSM Pool
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_RetrieveAManagedHSMPool()
        {
            // Generated from example definition:
            // this example is just showing the usage of "ManagedHsms_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "hsm-group";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this ManagedHsmResource
            ManagedHsmCollection collection = resourceGroupResource.GetManagedHsms();

            // invoke the operation
            string name = "hsm1";
            ManagedHsmResource result = await collection.GetAsync(name);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            ManagedHsmData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Retrieve a managed HSM Pool
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Exists_RetrieveAManagedHSMPool()
        {
            // Generated from example definition:
            // this example is just showing the usage of "ManagedHsms_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "hsm-group";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this ManagedHsmResource
            ManagedHsmCollection collection = resourceGroupResource.GetManagedHsms();

            // invoke the operation
            string name = "hsm1";
            bool result = await collection.ExistsAsync(name);

            Console.WriteLine($"Succeeded: {result}");
        }

        // List managed HSM Pools in a resource group
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetAll_ListManagedHSMPoolsInAResourceGroup()
        {
            // Generated from example definition:
            // this example is just showing the usage of "ManagedHsms_ListByResourceGroup" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "hsm-group";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this ManagedHsmResource
            ManagedHsmCollection collection = resourceGroupResource.GetManagedHsms();

            // invoke the operation and iterate over the result
            await foreach (ManagedHsmResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                ManagedHsmData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }
    }
}
