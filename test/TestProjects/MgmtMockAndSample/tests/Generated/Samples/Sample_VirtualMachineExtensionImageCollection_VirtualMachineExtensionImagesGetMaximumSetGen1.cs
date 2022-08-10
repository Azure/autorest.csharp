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
    public partial class Sample_VirtualMachineExtensionImageCollection_VirtualMachineExtensionImagesGetMaximumSetGen
    {
        // VirtualMachineExtensionImages_Get_MaximumSet_Gen
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Exists()
        {
            // this example is just showing the usage of "VirtualMachineExtensionImages_Get" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // get the collection of this VirtualMachineExtensionImageResource
            MgmtMockAndSample.VirtualMachineExtensionImageCollection collection = subscriptionResource.GetVirtualMachineExtensionImages("aaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaa");

            // invoke the operation
            bool result = await collection.ExistsAsync("aaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaa");

            Console.WriteLine($"Succeeded: {result}");
        }
    }
}
