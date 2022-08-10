// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    public partial class Sample_VaultResource_KeyVaultListPrivateLinkResources
    {
        // KeyVaultListPrivateLinkResources
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetPrivateLinkResources()
        {
            // this example is just showing the usage of "PrivateLinkResources_ListByVault" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this VaultResource created on azure
            // for more information of creating VaultResource, please refer to the document of VaultResource
            ResourceIdentifier vaultResourceId = MgmtMockAndSample.VaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-vault");
            MgmtMockAndSample.VaultResource vault = client.GetVaultResource(vaultResourceId);

            // invoke the operation and iterate over the result
            await foreach (MgmtMockAndSample.Models.MgmtMockAndSamplePrivateLinkResource item in vault.GetPrivateLinkResourcesAsync())
            {
                Console.WriteLine($"Succeeded: {item}");
            }
        }
    }
}
