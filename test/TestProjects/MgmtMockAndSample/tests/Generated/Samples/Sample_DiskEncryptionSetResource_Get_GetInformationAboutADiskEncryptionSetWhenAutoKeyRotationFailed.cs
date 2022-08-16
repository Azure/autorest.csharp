// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;

namespace MgmtMockAndSample
{
    public partial class Sample_DiskEncryptionSetResource_Get_GetInformationAboutADiskEncryptionSetWhenAutoKeyRotationFailed
    {
        // Get information about a disk encryption set when auto-key rotation failed.
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "DiskEncryptionSets_Get" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this DiskEncryptionSetResource created on azure
            // for more information of creating DiskEncryptionSetResource, please refer to the document of DiskEncryptionSetResource
            string subscriptionId = "{subscription-id}";
            string resourceGroupName = "myResourceGroup";
            string diskEncryptionSetName = "myDiskEncryptionSet";
            ResourceIdentifier diskEncryptionSetResourceId = MgmtMockAndSample.DiskEncryptionSetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, diskEncryptionSetName);
            MgmtMockAndSample.DiskEncryptionSetResource diskEncryptionSet = client.GetDiskEncryptionSetResource(diskEncryptionSetResourceId);

            // invoke the operation
            DiskEncryptionSetResource result = await diskEncryptionSet.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DiskEncryptionSetData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
