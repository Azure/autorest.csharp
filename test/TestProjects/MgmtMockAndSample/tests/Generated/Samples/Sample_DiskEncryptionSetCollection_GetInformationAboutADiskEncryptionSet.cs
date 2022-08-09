// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtMockAndSample
{
    public partial class Sample_DiskEncryptionSetCollection_GetInformationAboutADiskEncryptionSet
    {
        // Get information about a disk encryption set.
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            // this example is just showing the usage of "DiskEncryptionSets_Get" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // we assume you already have this ResourceGroupResourceExtensions created
            // if you do not know how to create ResourceGroupResourceExtensions, please refer to the document of ResourceGroupResourceExtensions
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroup");
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);
            // get the collection of this DiskEncryptionSetResource
            DiskEncryptionSetCollection collection = resourceGroupResource.GetDiskEncryptionSets();

            await Task.Run(() => _ = string.Empty);
        }
    }
}
