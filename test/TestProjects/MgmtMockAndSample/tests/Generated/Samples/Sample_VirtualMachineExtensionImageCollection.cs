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
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace MgmtMockAndSample.Samples
{
    public partial class Sample_VirtualMachineExtensionImageCollection
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_VirtualMachineExtensionImagesGetMaximumSetGen()
        {
            // Generated from example definition:
            // this example is just showing the usage of "VirtualMachineExtensionImages_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = Azure.ResourceManager.Resources.SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource SubscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);
            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaaaaaaaaaaa");
            string publisherName = "aaaaaaaaaaaaaaaaaaaa";
            VirtualMachineExtensionImageCollection collection = SubscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation
            string type = "aaaaaaaaaaaaaaaaaa";
            string version = "aaaaaaaaaaaaaa";
            VirtualMachineExtensionImageResource result = await collection.GetAsync(type, version).ConfigureAwait(false);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            VirtualMachineExtensionImageData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_VirtualMachineExtensionImagesGetMinimumSetGen()
        {
            // Generated from example definition:
            // this example is just showing the usage of "VirtualMachineExtensionImages_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = Azure.ResourceManager.Resources.SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource SubscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);
            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaaaaaaaaaaaa");
            string publisherName = "aaaaaaaaaaaaaaaaaaaaaaaaaa";
            VirtualMachineExtensionImageCollection collection = SubscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation
            string type = "aa";
            string version = "aaa";
            VirtualMachineExtensionImageResource result = await collection.GetAsync(type, version).ConfigureAwait(false);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            VirtualMachineExtensionImageData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAll_VirtualMachineExtensionImagesListTypesMaximumSetGen()
        {
            // Generated from example definition:
            // this example is just showing the usage of "VirtualMachineExtensionImages_ListTypes" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = Azure.ResourceManager.Resources.SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource SubscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);
            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaaaaaaaaaaaaaaaaaaaaaaaa");
            string publisherName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            VirtualMachineExtensionImageCollection collection = SubscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation and iterate over the result
            await foreach (VirtualMachineExtensionImageResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                VirtualMachineExtensionImageData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAll_VirtualMachineExtensionImagesListTypesMinimumSetGen()
        {
            // Generated from example definition:
            // this example is just showing the usage of "VirtualMachineExtensionImages_ListTypes" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = Azure.ResourceManager.Resources.SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource SubscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);
            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaa");
            string publisherName = "aa";
            VirtualMachineExtensionImageCollection collection = SubscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation and iterate over the result
            await foreach (VirtualMachineExtensionImageResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                VirtualMachineExtensionImageData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAll_VirtualMachineExtensionImagesListVersionsMaximumSetGen()
        {
            // Generated from example definition:
            // this example is just showing the usage of "VirtualMachineExtensionImages_ListVersions" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = Azure.ResourceManager.Resources.SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource SubscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);
            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaaaaaaaaaaaaaaaaaaaaaaaa");
            string publisherName = "aaaaaaaaaaaaaaaaaaaa";
            VirtualMachineExtensionImageCollection collection = SubscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation and iterate over the result
            string type = "aaaaaaaaaaaaaaaaaa";
            string filter = "aaaaaaaaaaaaaaaaaaaaaaaaa";
            int? top = 22;
            string orderby = "a";
            await foreach (VirtualMachineExtensionImageResource item in collection.GetAllAsync(type, filter, top, orderby))
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                VirtualMachineExtensionImageData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAll_VirtualMachineExtensionImagesListVersionsMinimumSetGen()
        {
            // Generated from example definition:
            // this example is just showing the usage of "VirtualMachineExtensionImages_ListVersions" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = Azure.ResourceManager.Resources.SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource SubscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);
            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaaaaaaa");
            string publisherName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            VirtualMachineExtensionImageCollection collection = SubscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation and iterate over the result
            string type = "aaaa";
            await foreach (VirtualMachineExtensionImageResource item in collection.GetAllAsync(type))
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                VirtualMachineExtensionImageData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Exists_VirtualMachineExtensionImagesGetMaximumSetGen()
        {
            // Generated from example definition:
            // this example is just showing the usage of "VirtualMachineExtensionImages_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = Azure.ResourceManager.Resources.SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource SubscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);
            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaaaaaaaaaaa");
            string publisherName = "aaaaaaaaaaaaaaaaaaaa";
            VirtualMachineExtensionImageCollection collection = SubscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation
            string type = "aaaaaaaaaaaaaaaaaa";
            string version = "aaaaaaaaaaaaaa";
            bool result = await collection.ExistsAsync(type, version).ConfigureAwait(false);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Exists_VirtualMachineExtensionImagesGetMinimumSetGen()
        {
            // Generated from example definition:
            // this example is just showing the usage of "VirtualMachineExtensionImages_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = Azure.ResourceManager.Resources.SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource SubscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);
            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaaaaaaaaaaaa");
            string publisherName = "aaaaaaaaaaaaaaaaaaaaaaaaaa";
            VirtualMachineExtensionImageCollection collection = SubscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation
            string type = "aa";
            string version = "aaa";
            bool result = await collection.ExistsAsync(type, version).ConfigureAwait(false);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetIfExists_VirtualMachineExtensionImagesGetMaximumSetGen()
        {
            // Generated from example definition:
            // this example is just showing the usage of "VirtualMachineExtensionImages_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = Azure.ResourceManager.Resources.SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource SubscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);
            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaaaaaaaaaaa");
            string publisherName = "aaaaaaaaaaaaaaaaaaaa";
            VirtualMachineExtensionImageCollection collection = SubscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation
            string type = "aaaaaaaaaaaaaaaaaa";
            string version = "aaaaaaaaaaaaaa";
            NullableResponse<VirtualMachineExtensionImageResource> response = await collection.GetIfExistsAsync(type, version).ConfigureAwait(false);
            VirtualMachineExtensionImageResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine("Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                VirtualMachineExtensionImageData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetIfExists_VirtualMachineExtensionImagesGetMinimumSetGen()
        {
            // Generated from example definition:
            // this example is just showing the usage of "VirtualMachineExtensionImages_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "{subscription-id}";
            ResourceIdentifier subscriptionResourceId = Azure.ResourceManager.Resources.SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource SubscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);
            // get the collection of this VirtualMachineExtensionImageResource
            AzureLocation location = new AzureLocation("aaaaaaaaaaaaaa");
            string publisherName = "aaaaaaaaaaaaaaaaaaaaaaaaaa";
            VirtualMachineExtensionImageCollection collection = SubscriptionResource.GetVirtualMachineExtensionImages(location, publisherName);

            // invoke the operation
            string type = "aa";
            string version = "aaa";
            NullableResponse<VirtualMachineExtensionImageResource> response = await collection.GetIfExistsAsync(type, version).ConfigureAwait(false);
            VirtualMachineExtensionImageResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine("Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                VirtualMachineExtensionImageData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }
    }
}
