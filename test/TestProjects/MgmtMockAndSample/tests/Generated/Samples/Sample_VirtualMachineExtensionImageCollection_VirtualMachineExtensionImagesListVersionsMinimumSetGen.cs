// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtMockAndSample
{
    public partial class Sample_VirtualMachineExtensionImageCollection_VirtualMachineExtensionImagesListVersionsMinimumSetGen
    {
        // VirtualMachineExtensionImages_ListVersions_MinimumSet_Gen
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetAll()
        {
            // this example is just showing the usage of "VirtualMachineExtensionImages_ListVersions" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // we assume you already have this SubscriptionResourceExtensions created
            // if you do not know how to create SubscriptionResourceExtensions, please refer to the document of SubscriptionResourceExtensions
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // get the collection of this VirtualMachineExtensionImageResource
            MgmtMockAndSample.VirtualMachineExtensionImageCollection collection = subscriptionResource.GetVirtualMachineExtensionImages("aaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

            // invoke the operation and iterate over the result
            await foreach (MgmtMockAndSample.VirtualMachineExtensionImageResource item in collection.GetAllAsync("aaaa"))
            {
                MgmtMockAndSample.VirtualMachineExtensionImageData data = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {data.Id}");
            }
        }
    }
}
