// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using MgmtMockAndSample;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample.Tests.Mock
{
    /// <summary> Test for ManagedHsmCollection. </summary>
    public partial class ManagedHsmCollectionMockTests : MockTestBase
    {
        public ManagedHsmCollectionMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            // Example: Create a new managed HSM Pool or update an existing managed HSM Pool

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "hsm-group");
            ResourceGroupResource resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetManagedHsms();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, "hsm1", new ManagedHsmData(new AzureLocation("westus"))
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
            });
        }

        [RecordedTest]
        public async Task Exists()
        {
            // Example: Retrieve a managed HSM Pool

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "hsm-group");
            ResourceGroupResource resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetManagedHsms();
            await collection.ExistsAsync("hsm1");
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: Retrieve a managed HSM Pool

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "hsm-group");
            ResourceGroupResource resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetManagedHsms();
            await collection.GetAsync("hsm1");
        }

        [RecordedTest]
        public async Task GetAll()
        {
            // Example: List managed HSM Pools in a resource group

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "hsm-group");
            ResourceGroupResource resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetManagedHsms();
            await foreach (var _ in collection.GetAllAsync())
            {
            }
        }
    }
}
