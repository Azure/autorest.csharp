// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;

namespace MgmtMockAndSample
{
    public partial class Sample_VirtualMachineExtensionImageResource_VirtualMachineExtensionImagesGetMinimumSetGen
    {
        // VirtualMachineExtensionImages_Get_MinimumSet_Gen
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            // this example is just showing the usage of "VirtualMachineExtensionImages_Get" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            ResourceIdentifier virtualMachineExtensionImageResourceId = MgmtMockAndSample.VirtualMachineExtensionImageResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "aaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaa", "aa", "aaa");
            MgmtMockAndSample.VirtualMachineExtensionImageResource virtualMachineExtensionImage = client.GetVirtualMachineExtensionImageResource(virtualMachineExtensionImageResourceId);

            // invoke the operation

            // this is a placeholder
            await Task.Run(() => _ = string.Empty);
        }
    }
}
