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
    public partial class Sample_DiskEncryptionSetCollection_CreateADiskEncryptionSetWithKeyVaultFromADifferentSubscription
    {
        // Create a disk encryption set with key vault from a different subscription.
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate()
        {
            // this example is just showing the usage of "DiskEncryptionSets_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // we assume you already have this ResourceGroupResourceExtensions created
            // if you do not know how to create ResourceGroupResourceExtensions, please refer to the document of ResourceGroupResourceExtensions
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroup");
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this DiskEncryptionSetResource
            MgmtMockAndSample.DiskEncryptionSetCollection collection = resourceGroupResource.GetDiskEncryptionSets();

            // invoke the operation
            ArmOperation<MgmtMockAndSample.DiskEncryptionSetResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, "myDiskEncryptionSet", new DiskEncryptionSetData()
            {
                Identity = new ManagedServiceIdentity("SystemAssigned"),
                EncryptionType = DiskEncryptionSetType.EncryptionAtRestWithCustomerKey,
                ActiveKey = new KeyForDiskEncryptionSet(new Uri("https://myvaultdifferentsub.vault-int.azure-int.net/keys/{key}")),
                MinimumTlsVersion = MinimumTlsVersion.Tls1_1,
            });
            MgmtMockAndSample.DiskEncryptionSetResource result = lro.Value;
            MgmtMockAndSample.DiskEncryptionSetData data = result.Data;

            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {data}.Id");
        }
    }
}
