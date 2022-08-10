// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;

namespace MgmtMockAndSample
{
    public partial class Sample_DiskEncryptionSetResource_DeleteADiskEncryptionSet
    {
        // Delete a disk encryption set.
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            // this example is just showing the usage of "DiskEncryptionSets_Delete" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            ResourceIdentifier diskEncryptionSetResourceId = MgmtMockAndSample.DiskEncryptionSetResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroup", "myDiskEncryptionSet");
            MgmtMockAndSample.DiskEncryptionSetResource diskEncryptionSet = client.GetDiskEncryptionSetResource(diskEncryptionSetResourceId);

            // invoke the operation
            await diskEncryptionSet.DeleteAsync(WaitUntil.Completed);
        }
    }
}
