// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using MgmtMockAndSample;

namespace MgmtMockAndSample.Samples
{
    public partial class Sample_DeletedManagedHsmCollection
    {
        // Retrieve a deleted managed HSM
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_RetrieveADeletedManagedHSM()
        {
            // Generated from example definition:
            // this example is just showing the usage of "ManagedHsms_GetDeleted" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // get the collection of this DeletedManagedHsmResource
            DeletedManagedHsmCollection collection = subscriptionResource.GetDeletedManagedHsms();

            // invoke the operation
            AzureLocation location = new AzureLocation("westus");
            string name = "hsm1";
            DeletedManagedHsmResource result = await collection.GetAsync(location, name);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DeletedManagedHsmData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Retrieve a deleted managed HSM
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Exists_RetrieveADeletedManagedHSM()
        {
            // Generated from example definition:
            // this example is just showing the usage of "ManagedHsms_GetDeleted" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // get the collection of this DeletedManagedHsmResource
            DeletedManagedHsmCollection collection = subscriptionResource.GetDeletedManagedHsms();

            // invoke the operation
            AzureLocation location = new AzureLocation("westus");
            string name = "hsm1";
            bool result = await collection.ExistsAsync(location, name);

            Console.WriteLine($"Succeeded: {result}");
        }
    }
}
