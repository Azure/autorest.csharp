// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#region Usings

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Azure.ResourceManager;
using MgmtMockTest;
#endregion

#region Parameter decalarations
// Below parameters are extracted from swagger example files, please use your own values to execute the API lively.
ArmClient GetArmClient() => new ArmClient(new DefaultAzureCredential());
var subscriptionId = Environment.GetEnvironmentVariable("SUBSCRIPTION_ID") ?? "00000000-0000-0000-0000-000000000000";
var resourceGroupName = "sample-resource-group";  // The name of the Resource Group to which the vault belongs.
var vaultName = "sample-vault";  // The name of the vault to delete
#endregion

#region API invocation
// api-version: 2021-10-01
// x-ms-original-file: file:///C:/ZZ/projects/codegen/autorest.csharp/test/TestProjects/MgmtMockTest/src/examples/deleteVault.json
// Example: Delete a vault

var vaultResourceId = MgmtMockTest.VaultResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vaultName);
var vaultResource = GetArmClient().GetVaultResource(vaultResourceId);
var operation = vaultResource.Delete(WaitUntil.Completed);

Console.WriteLine($"Response: {JsonSerializer.Serialize(operation.Value)}");
#endregion
