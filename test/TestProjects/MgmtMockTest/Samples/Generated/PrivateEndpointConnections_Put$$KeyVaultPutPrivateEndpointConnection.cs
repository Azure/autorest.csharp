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
using MgmtMockTest.Models;
#endregion

#region Parameter decalarations
// Below parameters are extracted from swagger example files, please use your own values to execute the API lively.
ArmClient GetArmClient() => new ArmClient(new DefaultAzureCredential());
var subscriptionId = Environment.GetEnvironmentVariable("SUBSCRIPTION_ID") ?? "00000000-0000-0000-0000-000000000000";
var resourceGroupName = "sample-group";  // Name of the resource group that contains the key vault.
var vaultName = "sample-vault";  // The name of the key vault.
var privateEndpointConnectionName = "sample-pec";  // Name of the private endpoint connection associated with the key vault.
#endregion

#region API invocation
// api-version: 2021-10-01
// x-ms-original-file: file:///C:/ZZ/projects/codegen/autorest.csharp/test/TestProjects/MgmtMockTest/src/examples/putPrivateEndpointConnection.json
// Example: KeyVaultPutPrivateEndpointConnection

var vaultResourceId = MgmtMockTest.VaultResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vaultName);
var vaultResource = GetArmClient().GetVaultResource(vaultResourceId);
var collection = vaultResource.GetMgmtMockTestPrivateEndpointConnections();
var operation = collection.CreateOrUpdate(WaitUntil.Completed, privateEndpointConnectionName, new MgmtMockTestPrivateEndpointConnectionData()
{
    Etag = "",
    ConnectionState = new MgmtMockTestPrivateLinkServiceConnectionState()
    {
        Status = MgmtMockTestPrivateEndpointServiceConnectionStatus.Approved,
        Description = "My name is Joe and I'm approving this.",
    },
});

Console.WriteLine($"Succeed on ResourceId: {operation.Value.Data.Id}");
Console.WriteLine($"Full Resource content: {JsonSerializer.Serialize(operation.Value.Data)}");
#endregion
