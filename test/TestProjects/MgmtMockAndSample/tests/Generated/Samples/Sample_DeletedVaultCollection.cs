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
using MgmtMockAndSample;

namespace MgmtMockAndSample.Samples
{
    public partial class Sample_DeletedVaultCollection
    {
        // Retrieve a deleted vault
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_RetrieveADeletedVault()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "Vaults_GetDeleted" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // get the collection of this DeletedVaultResource
            DeletedVaultCollection collection = subscriptionResource.GetDeletedVaults();

            // invoke the operation
            AzureLocation location = new AzureLocation("westus");
            string vaultName = "sample-vault";
            DeletedVaultResource result = await collection.GetAsync(location, vaultName);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DeletedVaultData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Retrieve a deleted vault
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Exists_RetrieveADeletedVault()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "Vaults_GetDeleted" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // get the collection of this DeletedVaultResource
            DeletedVaultCollection collection = subscriptionResource.GetDeletedVaults();

            // invoke the operation
            AzureLocation location = new AzureLocation("westus");
            string vaultName = "sample-vault";
            bool result = await collection.ExistsAsync(location, vaultName);

            Console.WriteLine($"Succeeded: {result}");
        }
    }
}
