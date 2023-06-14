// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using MgmtMockAndSample;

namespace MgmtMockAndSample.Samples
{
    public partial class Sample_DeletedVaultResource
    {
        // Purge a deleted vault
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task PurgeDeleted_PurgeADeletedVault()
        {
            // Generated from example definition:
            // this example is just showing the usage of "Vaults_PurgeDeleted" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DeletedVaultResource created on azure
            // for more information of creating DeletedVaultResource, please refer to the document of DeletedVaultResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            AzureLocation location = new AzureLocation("westus");
            string vaultName = "sample-vault";
            ResourceIdentifier deletedVaultResourceId = DeletedVaultResource.CreateResourceIdentifier(subscriptionId, location, vaultName);
            DeletedVaultResource deletedVault = client.GetDeletedVaultResource(deletedVaultResourceId);

            // invoke the operation
            await deletedVault.PurgeDeletedAsync(WaitUntil.Completed);

            Console.WriteLine($"Succeeded");
        }
    }
}
