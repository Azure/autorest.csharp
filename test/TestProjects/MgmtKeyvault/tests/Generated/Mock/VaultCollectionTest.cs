// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Net;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using MgmtKeyvault.Models;

namespace MgmtKeyvault.Tests.Mock
{
    /// <summary> Test for Vault. </summary>
    public partial class VaultCollectionMockTests : MockTestBase
    {
        public VaultCollectionMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            // Example: Create a new vault or update an existing vault
            string vaultName = "sample-vault";
            MgmtKeyvault.Models.VaultCreateOrUpdateContent content = new MgmtKeyvault.Models.VaultCreateOrUpdateContent(location: "westus", properties: new MgmtKeyvault.Models.VaultProperties(tenantId: Guid.Parse("00000000-0000-0000-0000-000000000000"), sku: new MgmtKeyvault.Models.MgmtKeyvaultSku(family: new MgmtKeyvault.Models.MgmtKeyvaultSkuFamily("A"), name: MgmtKeyvault.Models.MgmtKeyvaultSkuName.Standard))
            {
                EnabledForDeployment = true,
                EnabledForDiskEncryption = true,
                EnabledForTemplateDeployment = true,
            });

            var collection = GetArmClient().GetResourceGroupResource(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-resource-group")).GetVaults();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, content);
        }

        [RecordedTest]
        public async Task CreateOrUpdate2()
        {
            // Example: Create or update a vault with network acls
            string vaultName = "sample-vault";
            MgmtKeyvault.Models.VaultCreateOrUpdateContent content = new MgmtKeyvault.Models.VaultCreateOrUpdateContent(location: "westus", properties: new MgmtKeyvault.Models.VaultProperties(tenantId: Guid.Parse("00000000-0000-0000-0000-000000000000"), sku: new MgmtKeyvault.Models.MgmtKeyvaultSku(family: new MgmtKeyvault.Models.MgmtKeyvaultSkuFamily("A"), name: MgmtKeyvault.Models.MgmtKeyvaultSkuName.Standard))
            {
                EnabledForDeployment = true,
                EnabledForDiskEncryption = true,
                EnabledForTemplateDeployment = true,
                NetworkAcls = new MgmtKeyvault.Models.NetworkRuleSet()
                {
                    Bypass = new MgmtKeyvault.Models.NetworkRuleBypassOptions("AzureServices"),
                    DefaultAction = new MgmtKeyvault.Models.NetworkRuleAction("Deny"),
                },
            });

            var collection = GetArmClient().GetResourceGroupResource(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-resource-group")).GetVaults();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, vaultName, content);
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: Retrieve a vault
            string vaultName = "sample-vault";

            var collection = GetArmClient().GetResourceGroupResource(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-resource-group")).GetVaults();
            await collection.GetAsync(vaultName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            // Example: List vaults in the specified resource group
            int? top = 1;

            var collection = GetArmClient().GetResourceGroupResource(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-group")).GetVaults();
            await foreach (var _ in collection.GetAllAsync(top))
            {
            }
        }
    }
}
