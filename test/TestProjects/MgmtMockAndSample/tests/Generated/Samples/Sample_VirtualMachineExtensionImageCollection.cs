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
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    public partial class Sample_VirtualMachineExtensionImageCollection
    {
        // VirtualMachineExtensionImages_Get_MaximumSet_Gen
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_VirtualMachineExtensionImagesGetMaximumSetGen()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "VirtualMachineExtensionImages_Get" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaaaaaaaaaaa");
            string publisherName = "aaaaaaaaaaaaaaaaaaaa";
            VirtualMachineExtensionImageCollection collection = subscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation
            string type = "aaaaaaaaaaaaaaaaaa";
            string version = "aaaaaaaaaaaaaa";
            VirtualMachineExtensionImageResource result = await collection.GetAsync(type, version);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            VirtualMachineExtensionImageData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // VirtualMachineExtensionImages_Get_MaximumSet_Gen
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Exists_VirtualMachineExtensionImagesGetMaximumSetGen()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "VirtualMachineExtensionImages_Get" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaaaaaaaaaaa");
            string publisherName = "aaaaaaaaaaaaaaaaaaaa";
            VirtualMachineExtensionImageCollection collection = subscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation
            string type = "aaaaaaaaaaaaaaaaaa";
            string version = "aaaaaaaaaaaaaa";
            bool result = await collection.ExistsAsync(type, version);

            Console.WriteLine($"Succeeded: {result}");
        }

        // VirtualMachineExtensionImages_Get_MinimumSet_Gen
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_VirtualMachineExtensionImagesGetMinimumSetGen()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "VirtualMachineExtensionImages_Get" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaaaaaaaaaaaa");
            string publisherName = "aaaaaaaaaaaaaaaaaaaaaaaaaa";
            VirtualMachineExtensionImageCollection collection = subscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation
            string type = "aa";
            string version = "aaa";
            VirtualMachineExtensionImageResource result = await collection.GetAsync(type, version);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            VirtualMachineExtensionImageData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // VirtualMachineExtensionImages_Get_MinimumSet_Gen
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Exists_VirtualMachineExtensionImagesGetMinimumSetGen()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "VirtualMachineExtensionImages_Get" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaaaaaaaaaaaa");
            string publisherName = "aaaaaaaaaaaaaaaaaaaaaaaaaa";
            VirtualMachineExtensionImageCollection collection = subscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation
            string type = "aa";
            string version = "aaa";
            bool result = await collection.ExistsAsync(type, version);

            Console.WriteLine($"Succeeded: {result}");
        }

        // VirtualMachineExtensionImages_ListTypes_MaximumSet_Gen
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetAll_VirtualMachineExtensionImagesListTypesMaximumSetGen()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "VirtualMachineExtensionImages_ListTypes" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaaaaaaaaaaaaaaaaaaaaaaaa");
            string publisherName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            VirtualMachineExtensionImageCollection collection = subscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation and iterate over the result
            await foreach (VirtualMachineExtensionImageResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                VirtualMachineExtensionImageData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }

        // VirtualMachineExtensionImages_ListTypes_MinimumSet_Gen
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetAll_VirtualMachineExtensionImagesListTypesMinimumSetGen()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "VirtualMachineExtensionImages_ListTypes" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaa");
            string publisherName = "aa";
            VirtualMachineExtensionImageCollection collection = subscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation and iterate over the result
            await foreach (VirtualMachineExtensionImageResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                VirtualMachineExtensionImageData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }

        // VirtualMachineExtensionImages_ListVersions_MaximumSet_Gen
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetAll_VirtualMachineExtensionImagesListVersionsMaximumSetGen()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "VirtualMachineExtensionImages_ListVersions" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaaaaaaaaaaaaaaaaaaaaaaaa");
            string publisherName = "aaaaaaaaaaaaaaaaaaaa";
            VirtualMachineExtensionImageCollection collection = subscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation and iterate over the result
            VirtualMachineExtensionImageCollectionGetAllOptions options = new VirtualMachineExtensionImageCollectionGetAllOptions(type: "aaaaaaaaaaaaaaaaaa") { Filter = "aaaaaaaaaaaaaaaaaaaaaaaaa", Top = 22, Orderby = "a" };
            await foreach (VirtualMachineExtensionImageResource item in collection.GetAllAsync(options))
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                VirtualMachineExtensionImageData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }

        // VirtualMachineExtensionImages_ListVersions_MinimumSet_Gen
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetAll_VirtualMachineExtensionImagesListVersionsMinimumSetGen()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "VirtualMachineExtensionImages_ListVersions" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaaaaaaa");
            string publisherName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            VirtualMachineExtensionImageCollection collection = subscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation and iterate over the result
            VirtualMachineExtensionImageCollectionGetAllOptions options = new VirtualMachineExtensionImageCollectionGetAllOptions(type: "aaaa") { };
            await foreach (VirtualMachineExtensionImageResource item in collection.GetAllAsync(options))
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                VirtualMachineExtensionImageData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }
    }
}
