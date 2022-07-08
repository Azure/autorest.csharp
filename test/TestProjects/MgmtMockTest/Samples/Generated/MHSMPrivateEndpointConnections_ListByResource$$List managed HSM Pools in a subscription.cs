// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#region Usings

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager;
using MgmtMockTest;
#endregion

#region Parameter decalarations
// Below parameters are extracted from swagger example files, please use your own values to execute the API lively.
ArmClient GetArmClient() => new ArmClient(new DefaultAzureCredential());
var subscriptionId = Environment.GetEnvironmentVariable("SUBSCRIPTION_ID") ?? "00000000-0000-0000-0000-000000000000";
var resourceGroupName = "sample-group";  // Name of the resource group that contains the managed HSM pool.
var name = "sample-mhsm";  // Name of the managed HSM Pool
#endregion

#region API invocation
// api-version: 2021-10-01
// x-ms-original-file: file:///C:/ZZ/projects/codegen/autorest.csharp/test/TestProjects/MgmtMockTest/src/examples/ManagedHsm_ListPrivateEndpointConnectionsByResource.json
// Example: List managed HSM Pools in a subscription

var managedHsmResourceId = MgmtMockTest.ManagedHsmResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, name);
var managedHsmResource = GetArmClient().GetManagedHsmResource(managedHsmResourceId);
var collection = managedHsmResource.GetMhsmPrivateEndpointConnections();
foreach (var _ in collection.GetAll())
{
    Console.WriteLine($"ResourceId: {_.Data.Id}");
    Console.WriteLine($"Full Resource content: {JsonSerializer.Serialize(_.Data)}");
}
#endregion
