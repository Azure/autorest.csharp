// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager;

namespace MgmtMockAndSample
{
    public partial class Sample_VaultResource_UpdateAnExistingVault
    {
        // Update an existing vault
        [NUnit.Framework.TestCase]
        public async Task Update()
        {
            // this example is just showing the usage of "Vaults_Update" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            await Task.Run(() => _ = string.Empty);
        }
    }
}
