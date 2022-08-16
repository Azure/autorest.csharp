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
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    public partial class Sample_DiskEncryptionSetCollection_CreateOrUpdate_CreateADiskEncryptionSetWithKeyVaultFromADifferentTenant
    {
        // Create a disk encryption set with key vault from a different tenant.
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "DiskEncryptionSets_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "{subscription-id}";
            string resourceGroupName = "myResourceGroup";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this DiskEncryptionSetResource
            MgmtMockAndSample.DiskEncryptionSetCollection collection = resourceGroupResource.GetDiskEncryptionSets();

            // invoke the operation
            string diskEncryptionSetName = "myDiskEncryptionSet";
            MgmtMockAndSample.DiskEncryptionSetData data = new DiskEncryptionSetData()
            {
                Identity = new ManagedServiceIdentity("UserAssigned")
                {
                    UserAssignedIdentities =
{
[new ResourceIdentifier("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}")] = new UserAssignedIdentity(),
},
                },
                EncryptionType = DiskEncryptionSetType.EncryptionAtRestWithCustomerKey,
                ActiveKey = new KeyForDiskEncryptionSet(new Uri("https://myvaultdifferenttenant.vault-int.azure-int.net/keys/{key}")),
                FederatedClientId = "00000000-0000-0000-0000-000000000000",
            };
            ArmOperation<MgmtMockAndSample.DiskEncryptionSetResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, diskEncryptionSetName, data);
            MgmtMockAndSample.DiskEncryptionSetResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MgmtMockAndSample.DiskEncryptionSetData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
