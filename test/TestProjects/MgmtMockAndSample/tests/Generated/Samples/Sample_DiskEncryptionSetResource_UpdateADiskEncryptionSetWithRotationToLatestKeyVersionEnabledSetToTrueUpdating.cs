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
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    public partial class Sample_DiskEncryptionSetResource_UpdateADiskEncryptionSetWithRotationToLatestKeyVersionEnabledSetToTrueUpdating
    {
        // Update a disk encryption set with rotationToLatestKeyVersionEnabled set to true - Updating
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update()
        {
            // this example is just showing the usage of "DiskEncryptionSets_Update" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this DiskEncryptionSetResource created on azure
            // for more information of creating DiskEncryptionSetResource, please refer to the document of DiskEncryptionSetResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "myResourceGroup";
            string diskEncryptionSetName = "myDiskEncryptionSet";
            ResourceIdentifier diskEncryptionSetResourceId = MgmtMockAndSample.DiskEncryptionSetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, diskEncryptionSetName);
            MgmtMockAndSample.DiskEncryptionSetResource diskEncryptionSet = client.GetDiskEncryptionSetResource(diskEncryptionSetResourceId);

            // invoke the operation
            MgmtMockAndSample.Models.DiskEncryptionSetPatch patch = new DiskEncryptionSetPatch()
            {
                Identity = new ManagedServiceIdentity("SystemAssigned"),
                EncryptionType = DiskEncryptionSetType.EncryptionAtRestWithCustomerKey,
                ActiveKey = new KeyForDiskEncryptionSet(new Uri("https://myvaultdifferentsub.vault-int.azure-int.net/keys/keyName/keyVersion1")),
                RotationToLatestKeyVersionEnabled = true,
            };
            ArmOperation<MgmtMockAndSample.DiskEncryptionSetResource> lro = await diskEncryptionSet.UpdateAsync(WaitUntil.Completed, patch);
            MgmtMockAndSample.DiskEncryptionSetResource result = lro.Value;

            MgmtMockAndSample.DiskEncryptionSetData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
