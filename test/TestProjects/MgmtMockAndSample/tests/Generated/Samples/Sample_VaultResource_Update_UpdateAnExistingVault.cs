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
    public partial class Sample_VaultResource_Update_UpdateAnExistingVault
    {
        // Update an existing vault
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "Vaults_Update" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this VaultResource created on azure
            // for more information of creating VaultResource, please refer to the document of VaultResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "sample-resource-group";
            string vaultName = "sample-vault";
            ResourceIdentifier vaultResourceId = MgmtMockAndSample.VaultResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vaultName);
            MgmtMockAndSample.VaultResource vault = client.GetVaultResource(vaultResourceId);

            // invoke the operation
            MgmtMockAndSample.Models.VaultPatch patch = new VaultPatch()
            {
                Properties = new VaultPatchProperties()
                {
                    TenantId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                    Sku = new MgmtMockAndSampleSku(MgmtMockAndSampleSkuFamily.A, MgmtMockAndSampleSkuName.Standard),
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
                    EnabledForDeployment = true,
                    EnabledForDiskEncryption = true,
                    EnabledForTemplateDeployment = true,
                    PublicNetworkAccess = "Enabled",
                },
            };
            MgmtMockAndSample.VaultResource result = await vault.UpdateAsync(patch);

            MgmtMockAndSample.VaultData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
