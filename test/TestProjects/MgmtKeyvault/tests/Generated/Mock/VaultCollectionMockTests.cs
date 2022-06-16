// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Net;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace MgmtKeyvault.Tests.Mock
{
    /// <summary> Test for VaultCollection. </summary>
    public partial class VaultCollectionMockTests : MockTestBase
    {
        public VaultCollectionMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task CreateOrUpdate_CreateANewVaultOrUpdateAnExistingVault()
        {
            // Example: Create a new vault or update an existing vault

            var resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier();
            var resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetVaults();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, default, default);
        }

        [RecordedTest]
        public async Task CreateOrUpdate_CreateOrUpdateAVaultWithNetworkAcls()
        {
            // Example: Create or update a vault with network acls

            var resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier();
            var resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetVaults();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, default, default);
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: Retrieve a vault

            var resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier();
            var resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetVaults();
            await collection.GetAsync(default);
        }

        [RecordedTest]
        public async Task Exists()
        {
            // Example: Retrieve a vault

            var resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier();
            var resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetVaults();
            await collection.ExistsAsync(default);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            // Example: List vaults in the specified resource group

            var resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier();
            var resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetVaults();
            await collection.GetAllAsync();
        }
    }
}
