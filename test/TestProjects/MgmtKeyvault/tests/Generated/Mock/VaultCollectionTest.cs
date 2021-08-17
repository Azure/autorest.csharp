// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using MgmtKeyvault;
using NUnit.Framework;

namespace MgmtKeyvault.Tests.Mock
{
    /// <summary> Test for Vault. </summary>
    public partial class VaultCollectionMockTests : MockTestBase
    {
        public VaultCollectionMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        }

        public VaultCollectionMockTests() : this(false)
        {
        }

        private async Task<MgmtKeyvault.VaultCollection> GetVaultCollectionAsync(string resourceGroupName)
        {
            ResourceGroup resourceGroup = await TestHelper.CreateResourceGroupAsync(resourceGroupName, GetArmClient());
            VaultCollection vaultCollection = resourceGroup.GetVaults();
            return vaultCollection;
        }

        [RecordedTest]
        [Ignore("Generated TestCase")]
        public async Task CreateOrUpdateAsync()
        {
            // Example: Create a new vault or update an existing vault
            var collection = await GetVaultCollectionAsync("sample-resource-group");
            await TestHelper.CreateOrUpdateExampleInstanceAsync(collection, "sample-vault");
        }

        [RecordedTest]
        [Ignore("Generated TestCase")]
        public async Task GetAllAsync()
        {
            // Example: List vaults in the specified resource group
            var collection = await GetVaultCollectionAsync("sample-group");
            TestHelper.GetAllExampleInstanceAsync(collection).AsPages();
        }
    }
}
