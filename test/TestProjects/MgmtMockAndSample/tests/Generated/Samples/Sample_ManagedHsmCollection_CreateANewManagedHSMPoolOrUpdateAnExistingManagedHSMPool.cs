// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    public partial class Sample_ManagedHsmCollection_CreateANewManagedHSMPoolOrUpdateAnExistingManagedHSMPool
    {
        // Create a new managed HSM Pool or update an existing managed HSM Pool
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate()
        {
            // this example is just showing the usage of "ManagedHsms_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // we assume you already have this ResourceGroupResourceExtensions created
            // if you do not know how to create ResourceGroupResourceExtensions, please refer to the document of ResourceGroupResourceExtensions
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "hsm-group");
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this ManagedHsmResource
            ManagedHsmCollection collection = resourceGroupResource.GetManagedHsms();

            // invoke the operation
            ArmOperation<MgmtMockAndSample.ManagedHsmResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, "hsm1", new ManagedHsmData(new AzureLocation("westus"))
            {
                Properties = new ManagedHsmProperties()
                {
                    Settings = BinaryData.FromObjectAsJson(new
                    {
                        config1 = "value1",
                        config2 = "8427",
                        config3 = "false",
                        config4 = new[] { "1", "2" },
                        config5 = new
                        {
                            inner = "something"
                        }
                    }),
                    ProtectedSettings = BinaryData.FromObjectAsJson(new
                    {
                        protected1 = "value2",
                        protected2 = "10",
                        protected3 = "false",
                        protected4 = new[] { "1", "2", "3" },
                        protected5 = new
                        {
                            protectedInner = "something else"
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
            });
            MgmtMockAndSample.ManagedHsmResource result = lro.Value;
            MgmtMockAndSample.ManagedHsmData data = result.Data;

            await Task.Run(() => _ = string.Empty);
        }
    }
}
