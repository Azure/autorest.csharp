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
    public partial class Sample_VirtualMachineExtensionImageCollection_VirtualMachineExtensionImagesListTypesMaximumSetGen
    {
        // VirtualMachineExtensionImages_ListTypes_MaximumSet_Gen
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetAll()
        {
            // this example is just showing the usage of "VirtualMachineExtensionImages_ListTypes" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaaaaaaaaaaaaaaaaaaaaaaaa");
            string publisherName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            MgmtMockAndSample.VirtualMachineExtensionImageCollection collection = subscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation and iterate over the result
            await foreach (MgmtMockAndSample.VirtualMachineExtensionImageResource item in collection.GetAllAsync())
            {
                MgmtMockAndSample.VirtualMachineExtensionImageData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }
    }
}
