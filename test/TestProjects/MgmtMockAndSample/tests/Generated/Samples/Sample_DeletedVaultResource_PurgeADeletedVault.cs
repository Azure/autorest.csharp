// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;

namespace MgmtMockAndSample
{
    public partial class Sample_DeletedVaultResource_PurgeADeletedVault
    {
        // Purge a deleted vault
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task PurgeDeleted()
        {
            // this example is just showing the usage of "Vaults_PurgeDeleted" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            ResourceIdentifier deletedVaultResourceId = MgmtMockAndSample.DeletedVaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "westus", "sample-vault");
            MgmtMockAndSample.DeletedVaultResource deletedVault = client.GetDeletedVaultResource(deletedVaultResourceId);

            // invoke the operation
            ArmOperation lro = await deletedVault.PurgeDeletedAsync(WaitUntil.Completed);

            // this is a placeholder
            await Task.Run(() => _ = string.Empty);
        }
    }
}
