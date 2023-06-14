// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using MgmtMockAndSample;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample.Tests.Mock
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

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-resource-group");
            ResourceGroupResource resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetVaults();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, "sample-vault", new VaultCreateOrUpdateContent(new AzureLocation("westus"), new VaultProperties(Guid.Parse("00000000-0000-0000-0000-000000000000"), new MgmtMockAndSampleSku(MgmtMockAndSampleSkuFamily.A, MgmtMockAndSampleSkuName.Standard))
            {
                Duration = XmlConvert.ToTimeSpan("P7D"),
                CreateOn = DateTimeOffset.Parse("2017-05-04T07:12:28.191Z"),
                AccessPolicies =
{
new AccessPolicyEntry(Guid.Parse("00000000-0000-0000-0000-000000000000"),"00000000-0000-0000-0000-000000000000",new Permissions()
{
Keys =
{
KeyPermission.Encrypt,KeyPermission.Decrypt,KeyPermission.WrapKey,KeyPermission.UnwrapKey,KeyPermission.Sign,KeyPermission.Verify,KeyPermission.Get,KeyPermission.List,KeyPermission.Create,KeyPermission.Update,KeyPermission.Import,KeyPermission.Delete,KeyPermission.Backup,KeyPermission.Restore,KeyPermission.Recover,KeyPermission.Purge
},
Secrets =
{
SecretPermission.Get,SecretPermission.List,SecretPermission.Set,SecretPermission.Delete,SecretPermission.Backup,SecretPermission.Restore,SecretPermission.Recover,SecretPermission.Purge
},
Certificates =
{
CertificatePermission.Get,CertificatePermission.List,CertificatePermission.Delete,CertificatePermission.Create,CertificatePermission.Import,CertificatePermission.Update,CertificatePermission.Managecontacts,CertificatePermission.Getissuers,CertificatePermission.Listissuers,CertificatePermission.Setissuers,CertificatePermission.Deleteissuers,CertificatePermission.Manageissuers,CertificatePermission.Recover,CertificatePermission.Purge
},
})
},
                EnabledForDiskEncryption = true,
                EnabledForTemplateDeployment = true,
                PublicNetworkAccess = "Enabled",
            })
            {
                Identity = new ManagedServiceIdentity("SystemAssigned"),
            });
        }

        [RecordedTest]
        public async Task CreateOrUpdate_CreateOrUpdateAVaultWithNetworkAcls()
        {
            // Example: Create or update a vault with network acls

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-resource-group");
            ResourceGroupResource resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetVaults();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, "sample-vault", new VaultCreateOrUpdateContent(new AzureLocation("westus"), new VaultProperties(Guid.Parse("00000000-0000-0000-0000-000000000000"), new MgmtMockAndSampleSku(MgmtMockAndSampleSkuFamily.A, MgmtMockAndSampleSkuName.Standard))
            {
                EnabledForDiskEncryption = true,
                EnabledForTemplateDeployment = true,
                NetworkAcls = new NetworkRuleSet()
                {
                    Bypass = NetworkRuleBypassOption.AzureServices,
                    DefaultAction = NetworkRuleAction.Deny,
                    IpRules =
{
new IPRule("124.56.78.91"),new IPRule("'10.91.4.0/24'")
},
                    VirtualNetworkRules =
{
new VirtualNetworkRule("/subscriptions/subid/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/subnet1")
},
                },
                ReadWriteSingleStringPropertySomething = "test",
                DeepSomething = "deep-value",
            }));
        }

        [RecordedTest]
        public async Task Exists()
        {
            // Example: Retrieve a vault

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-resource-group");
            ResourceGroupResource resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetVaults();
            await collection.ExistsAsync("sample-vault");
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: Retrieve a vault

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-resource-group");
            ResourceGroupResource resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetVaults();
            await collection.GetAsync("sample-vault");
        }

        [RecordedTest]
        public async Task GetAll()
        {
            // Example: List vaults in the specified resource group

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group");
            ResourceGroupResource resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
            var collection = resourceGroupResource.GetVaults();
            await foreach (var _ in collection.GetAllAsync(top: 1))
            {
            }
        }
    }
}
