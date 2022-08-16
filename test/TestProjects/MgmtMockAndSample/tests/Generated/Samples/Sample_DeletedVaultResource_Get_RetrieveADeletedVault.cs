// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;

namespace MgmtMockAndSample
{
    public partial class Sample_DeletedVaultResource_Get_RetrieveADeletedVault
    {
        // Retrieve a deleted vault
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "Vaults_GetDeleted" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this DeletedVaultResource created on azure
            // for more information of creating DeletedVaultResource, please refer to the document of DeletedVaultResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            AzureLocation location = new AzureLocation("westus");
            string vaultName = "sample-vault";
            ResourceIdentifier deletedVaultResourceId = MgmtMockAndSample.DeletedVaultResource.CreateResourceIdentifier(subscriptionId, location, vaultName);
            MgmtMockAndSample.DeletedVaultResource deletedVault = client.GetDeletedVaultResource(deletedVaultResourceId);

            // invoke the operation
            MgmtMockAndSample.DeletedVaultResource result = await deletedVault.GetAsync();

            MgmtMockAndSample.DeletedVaultData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
