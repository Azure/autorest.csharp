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

namespace MgmtMockAndSample.Samples
{
    public partial class Sample_DiskEncryptionSetResource
    {
        // Update a disk encryption set with rotationToLatestKeyVersionEnabled set to true - Succeeded
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update_UpdateADiskEncryptionSetWithRotationToLatestKeyVersionEnabledSetToTrueSucceeded()
        {
            // Generated from example definition:
            // this example is just showing the usage of "DiskEncryptionSets_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DiskEncryptionSetResource created on azure
            // for more information of creating DiskEncryptionSetResource, please refer to the document of DiskEncryptionSetResource
            string subscriptionId = "{subscription-id}";
            string resourceGroupName = "myResourceGroup";
            string diskEncryptionSetName = "myDiskEncryptionSet";
            ResourceIdentifier diskEncryptionSetResourceId = DiskEncryptionSetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, diskEncryptionSetName);
            DiskEncryptionSetResource diskEncryptionSet = client.GetDiskEncryptionSetResource(diskEncryptionSetResourceId);

            // invoke the operation
            DiskEncryptionSetPatch patch = new DiskEncryptionSetPatch()
            {
                Identity = new ManagedServiceIdentity("SystemAssigned"),
                EncryptionType = DiskEncryptionSetType.EncryptionAtRestWithCustomerKey,
                ActiveKey = new KeyForDiskEncryptionSet("https://myvaultdifferentsub.vault-int.azure-int.net/keys/keyName/keyVersion1"),
                RotationToLatestKeyVersionEnabled = true,
            };
            ArmOperation<DiskEncryptionSetResource> lro = await diskEncryptionSet.UpdateAsync(WaitUntil.Completed, patch);
            DiskEncryptionSetResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DiskEncryptionSetData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Update a disk encryption set with rotationToLatestKeyVersionEnabled set to true - Updating
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update_UpdateADiskEncryptionSetWithRotationToLatestKeyVersionEnabledSetToTrueUpdating()
        {
            // Generated from example definition:
            // this example is just showing the usage of "DiskEncryptionSets_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DiskEncryptionSetResource created on azure
            // for more information of creating DiskEncryptionSetResource, please refer to the document of DiskEncryptionSetResource
            string subscriptionId = "{subscription-id}";
            string resourceGroupName = "myResourceGroup";
            string diskEncryptionSetName = "myDiskEncryptionSet";
            ResourceIdentifier diskEncryptionSetResourceId = DiskEncryptionSetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, diskEncryptionSetName);
            DiskEncryptionSetResource diskEncryptionSet = client.GetDiskEncryptionSetResource(diskEncryptionSetResourceId);

            // invoke the operation
            DiskEncryptionSetPatch patch = new DiskEncryptionSetPatch()
            {
                Identity = new ManagedServiceIdentity("SystemAssigned"),
                EncryptionType = DiskEncryptionSetType.EncryptionAtRestWithCustomerKey,
                ActiveKey = new KeyForDiskEncryptionSet("https://myvaultdifferentsub.vault-int.azure-int.net/keys/keyName/keyVersion1"),
                RotationToLatestKeyVersionEnabled = true,
            };
            ArmOperation<DiskEncryptionSetResource> lro = await diskEncryptionSet.UpdateAsync(WaitUntil.Completed, patch);
            DiskEncryptionSetResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DiskEncryptionSetData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Update a disk encryption set.
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update_UpdateADiskEncryptionSet()
        {
            // Generated from example definition:
            // this example is just showing the usage of "DiskEncryptionSets_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DiskEncryptionSetResource created on azure
            // for more information of creating DiskEncryptionSetResource, please refer to the document of DiskEncryptionSetResource
            string subscriptionId = "{subscription-id}";
            string resourceGroupName = "myResourceGroup";
            string diskEncryptionSetName = "myDiskEncryptionSet";
            ResourceIdentifier diskEncryptionSetResourceId = DiskEncryptionSetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, diskEncryptionSetName);
            DiskEncryptionSetResource diskEncryptionSet = client.GetDiskEncryptionSetResource(diskEncryptionSetResourceId);

            // invoke the operation
            DiskEncryptionSetPatch patch = new DiskEncryptionSetPatch()
            {
                Tags =
{
["department"] = "Development",
["project"] = "Encryption",
},
                EncryptionType = DiskEncryptionSetType.EncryptionAtRestWithCustomerKey,
                ActiveKey = new KeyForDiskEncryptionSet("https://myvmvault.vault-int.azure-int.net/keys/keyName/keyVersion")
                {
                    SourceVaultId = new ResourceIdentifier("/subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.KeyVault/vaults/myVMVault"),
                },
            };
            ArmOperation<DiskEncryptionSetResource> lro = await diskEncryptionSet.UpdateAsync(WaitUntil.Completed, patch);
            DiskEncryptionSetResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DiskEncryptionSetData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Get information about a disk encryption set when auto-key rotation failed.
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_GetInformationAboutADiskEncryptionSetWhenAutoKeyRotationFailed()
        {
            // Generated from example definition:
            // this example is just showing the usage of "DiskEncryptionSets_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DiskEncryptionSetResource created on azure
            // for more information of creating DiskEncryptionSetResource, please refer to the document of DiskEncryptionSetResource
            string subscriptionId = "{subscription-id}";
            string resourceGroupName = "myResourceGroup";
            string diskEncryptionSetName = "myDiskEncryptionSet";
            ResourceIdentifier diskEncryptionSetResourceId = DiskEncryptionSetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, diskEncryptionSetName);
            DiskEncryptionSetResource diskEncryptionSet = client.GetDiskEncryptionSetResource(diskEncryptionSetResourceId);

            // invoke the operation
            DiskEncryptionSetResource result = await diskEncryptionSet.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DiskEncryptionSetData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Get information about a disk encryption set.
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_GetInformationAboutADiskEncryptionSet()
        {
            // Generated from example definition:
            // this example is just showing the usage of "DiskEncryptionSets_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DiskEncryptionSetResource created on azure
            // for more information of creating DiskEncryptionSetResource, please refer to the document of DiskEncryptionSetResource
            string subscriptionId = "{subscription-id}";
            string resourceGroupName = "myResourceGroup";
            string diskEncryptionSetName = "myDiskEncryptionSet";
            ResourceIdentifier diskEncryptionSetResourceId = DiskEncryptionSetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, diskEncryptionSetName);
            DiskEncryptionSetResource diskEncryptionSet = client.GetDiskEncryptionSetResource(diskEncryptionSetResourceId);

            // invoke the operation
            DiskEncryptionSetResource result = await diskEncryptionSet.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DiskEncryptionSetData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Delete a disk encryption set.
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Delete_DeleteADiskEncryptionSet()
        {
            // Generated from example definition:
            // this example is just showing the usage of "DiskEncryptionSets_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DiskEncryptionSetResource created on azure
            // for more information of creating DiskEncryptionSetResource, please refer to the document of DiskEncryptionSetResource
            string subscriptionId = "{subscription-id}";
            string resourceGroupName = "myResourceGroup";
            string diskEncryptionSetName = "myDiskEncryptionSet";
            ResourceIdentifier diskEncryptionSetResourceId = DiskEncryptionSetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, diskEncryptionSetName);
            DiskEncryptionSetResource diskEncryptionSet = client.GetDiskEncryptionSetResource(diskEncryptionSetResourceId);

            // invoke the operation
            await diskEncryptionSet.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine($"Succeeded");
        }

        // List all disk encryption sets in a subscription.
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetDiskEncryptionSets_ListAllDiskEncryptionSetsInASubscription()
        {
            // Generated from example definition:
            // this example is just showing the usage of "DiskEncryptionSets_List" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation and iterate over the result
            await foreach (DiskEncryptionSetResource item in subscriptionResource.GetDiskEncryptionSetsAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                DiskEncryptionSetData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }
    }
}
