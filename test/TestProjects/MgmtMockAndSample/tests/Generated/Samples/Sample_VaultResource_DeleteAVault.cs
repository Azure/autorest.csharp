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
    public partial class Sample_VaultResource_DeleteAVault
    {
        // Delete a vault
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            // this example is just showing the usage of "Vaults_Delete" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            ResourceIdentifier vaultResourceId = MgmtMockAndSample.VaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-resource-group", "sample-vault");
            MgmtMockAndSample.VaultResource vault = client.GetVaultResource(vaultResourceId);

            // invoke the operation
            ArmOperation lro = await vault.DeleteAsync(WaitUntil.Completed);

            // this is a placeholder
            await Task.Run(() => _ = string.Empty);
        }
    }
}
