// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using NUnit.Framework;

namespace MgmtTypeSpec.Samples
{
    public partial class Sample_FooResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetAFoo()
        {
            // Generated from example definition: 2024-05-01/Foos_Get.json
            // this example is just showing the usage of "Foos_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this FooResource created on azure
            // for more information of creating FooResource, please refer to the document of FooResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "myRg";
            string fooName = "myFoo";
            ResourceIdentifier fooResourceId = FooResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, fooName);
            FooResource foo = client.GetFooResource(fooResourceId);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_CreateAFoo()
        {
            // Generated from example definition: 2024-05-01/Foos_CreateOrUpdate.json
            // this example is just showing the usage of "Foos_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this FooResource created on azure
            // for more information of creating FooResource, please refer to the document of FooResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "myRg";
            string fooName = "myFoo";
            ResourceIdentifier fooResourceId = FooResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, fooName);
            FooResource foo = client.GetFooResource(fooResourceId);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task AddTag_GetAFoo()
        {
            // Generated from example definition: 2024-05-01/Foos_Get.json
            // this example is just showing the usage of "Foos_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this FooResource created on azure
            // for more information of creating FooResource, please refer to the document of FooResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "myRg";
            string fooName = "myFoo";
            ResourceIdentifier fooResourceId = FooResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, fooName);
            FooResource foo = client.GetFooResource(fooResourceId);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task SetTags_GetAFoo()
        {
            // Generated from example definition: 2024-05-01/Foos_Get.json
            // this example is just showing the usage of "Foos_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this FooResource created on azure
            // for more information of creating FooResource, please refer to the document of FooResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "myRg";
            string fooName = "myFoo";
            ResourceIdentifier fooResourceId = FooResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, fooName);
            FooResource foo = client.GetFooResource(fooResourceId);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task RemoveTag_GetAFoo()
        {
            // Generated from example definition: 2024-05-01/Foos_Get.json
            // this example is just showing the usage of "Foos_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this FooResource created on azure
            // for more information of creating FooResource, please refer to the document of FooResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "myRg";
            string fooName = "myFoo";
            ResourceIdentifier fooResourceId = FooResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, fooName);
            FooResource foo = client.GetFooResource(fooResourceId);
        }
    }
}
