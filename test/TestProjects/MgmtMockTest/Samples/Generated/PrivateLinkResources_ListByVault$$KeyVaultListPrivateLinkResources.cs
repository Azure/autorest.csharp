// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#region Usings

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager;
using MgmtMockTest;
#endregion

#region Parameter decalarations
// Below parameters are extracted from swagger example files, please use your own values to execute the API lively.
ArmClient GetArmClient() => new ArmClient(new DefaultAzureCredential());
var subscriptionId = Environment.GetEnvironmentVariable("SUBSCRIPTION_ID") ?? "00000000-0000-0000-0000-000000000000";
var resourceGroupName = "sample-group";  // Name of the resource group that contains the key vault.
var vaultName = "sample-vault";  // The name of the key vault.
#endregion

#region API invocation
// api-version: 2021-10-01
// x-ms-original-file: file:///C:/ZZ/projects/codegen/autorest.csharp/test/TestProjects/MgmtMockTest/src/examples/listPrivateLinkResources.json
// Example: KeyVaultListPrivateLinkResources

var vaultResourceId = MgmtMockTest.VaultResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vaultName);
var vaultResource = GetArmClient().GetVaultResource(vaultResourceId);
foreach (var _ in vaultResource.GetPrivateLinkResources())
{
}
#endregion
