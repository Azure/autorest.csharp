// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#region Usings

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using MgmtMockTest.Models;
#endregion

#region Parameter decalarations
// Below parameters are extracted from swagger example files, please use your own values to execute the API lively.
ArmClient GetArmClient() => new ArmClient(new DefaultAzureCredential());
var subscriptionId = Environment.GetEnvironmentVariable("SUBSCRIPTION_ID") ?? "00000000-0000-0000-0000-000000000000";
var resourceGroupName = "sample-resource-group";  // The name of the Resource Group to which the server belongs.
var vaultName = "sample-vault";  // Name of the vault
#endregion

#region API invocation
// api-version: 2021-10-01
// x-ms-original-file: file:///C:/ZZ/projects/codegen/autorest.csharp/test/TestProjects/MgmtMockTest/src/examples/createVault.json
// Example: Create a new vault or update an existing vault

var resourceGroupResourceId = global::Azure.ResourceManager.Resources.ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
var resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
var collection = resourceGroupResource.GetVaults();
var operation = collection.CreateOrUpdate(WaitUntil.Completed, vaultName, new VaultCreateOrUpdateContent(new AzureLocation("westus"), new VaultProperties(Guid.Parse("00000000-0000-0000-0000-000000000000"), new MgmtMockTestSku(MgmtMockTestSkuFamily.A, MgmtMockTestSkuName.Standard))
{
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

Console.WriteLine($"Succeed on ResourceId: {operation.Value.Data.Id}");
Console.WriteLine($"Full Resource content: {JsonSerializer.Serialize(operation.Value.Data)}");
#endregion
