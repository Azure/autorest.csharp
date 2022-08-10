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
    public partial class Sample_DiskEncryptionSetResource_UpdateADiskEncryptionSetWithRotationToLatestKeyVersionEnabledSetToTrueSucceeded
    {
        // Update a disk encryption set with rotationToLatestKeyVersionEnabled set to true - Succeeded
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update()
        {
            // this example is just showing the usage of "DiskEncryptionSets_Update" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this DiskEncryptionSetResource created on azure
            // for more information of creating DiskEncryptionSetResource, please refer to the document of DiskEncryptionSetResource
            ResourceIdentifier diskEncryptionSetResourceId = MgmtMockAndSample.DiskEncryptionSetResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroup", "myDiskEncryptionSet");
            MgmtMockAndSample.DiskEncryptionSetResource diskEncryptionSet = client.GetDiskEncryptionSetResource(diskEncryptionSetResourceId);

            // invoke the operation
            ArmOperation<MgmtMockAndSample.DiskEncryptionSetResource> lro = await diskEncryptionSet.UpdateAsync(WaitUntil.Completed, new DiskEncryptionSetPatch()
            {
                Identity = new ManagedServiceIdentity("SystemAssigned"),
                EncryptionType = DiskEncryptionSetType.EncryptionAtRestWithCustomerKey,
                ActiveKey = new KeyForDiskEncryptionSet(new Uri("https://myvaultdifferentsub.vault-int.azure-int.net/keys/keyName/keyVersion1")),
                RotationToLatestKeyVersionEnabled = true,
            });
            MgmtMockAndSample.DiskEncryptionSetResource result = lro.Value;

            MgmtMockAndSample.DiskEncryptionSetData data = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {data.Id}");
        }
    }
}
