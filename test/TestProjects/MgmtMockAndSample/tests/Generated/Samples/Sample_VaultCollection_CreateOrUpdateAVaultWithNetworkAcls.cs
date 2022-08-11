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
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    public partial class Sample_VaultCollection_CreateOrUpdateAVaultWithNetworkAcls
    {
        // Create or update a vault with network acls
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate()
        {
            // this example is just showing the usage of "Vaults_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-resource-group";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this VaultResource
            MgmtMockAndSample.VaultCollection collection = resourceGroupResource.GetVaults();

            // invoke the operation
            string vaultName = "sample-vault";
            MgmtMockAndSample.Models.VaultCreateOrUpdateContent content = new VaultCreateOrUpdateContent(new AzureLocation("westus"), new VaultProperties(Guid.Parse("00000000-0000-0000-0000-000000000000"), new MgmtMockAndSampleSku(MgmtMockAndSampleSkuFamily.A, MgmtMockAndSampleSkuName.Standard))
            {
                EnabledForDiskEncryption = true,
                EnabledForTemplateDeployment = true,
                NetworkAcls = new NetworkRuleSet()
                {
                    Bypass = NetworkRuleBypassOption.AzureServices,
                    DefaultAction = NetworkRuleAction.Deny,
                    IpRules =
{
new IPRule("124.56.78.91"),new IPRule("'10.91.4.0/24'")
},
                    VirtualNetworkRules =
{
new VirtualNetworkRule("/subscriptions/subid/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/subnet1")
},
                },
                ReadWriteSingleStringPropertySomething = "test",
                DeepSomething = "deep-value",
            });
            ArmOperation<MgmtMockAndSample.VaultResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, content);
            MgmtMockAndSample.VaultResource result = lro.Value;

            MgmtMockAndSample.VaultData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
