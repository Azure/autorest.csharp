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
using Azure.ResourceManager.Resources;
#endregion

#region Parameter decalarations
// Below parameters are extracted from swagger example files, please use your own values to execute the API lively.
ArmClient GetArmClient() => new ArmClient(new DefaultAzureCredential());
var subscriptionId = Environment.GetEnvironmentVariable("SUBSCRIPTION_ID") ?? "00000000-0000-0000-0000-000000000000";
var location = "aaaa";  // The name of a supported Azure region.
var publisherName = "aa";  // 
#endregion

#region API invocation
// api-version: 2021-10-01
// x-ms-original-file: file:///C:/ZZ/projects/codegen/autorest.csharp/test/TestProjects/MgmtMockTest/src/examples/virtualMachineExtensionImageExamples/VirtualMachineExtensionImages_ListTypes_MinimumSet_Gen.json
// Example: VirtualMachineExtensionImages_ListTypes_MinimumSet_Gen

var subscriptionResourceId = global::Azure.ResourceManager.Resources.SubscriptionResource.CreateResourceIdentifier(subscriptionId);
var subscriptionResource = GetArmClient().GetSubscriptionResource(subscriptionResourceId);
var collection = subscriptionResource.GetVirtualMachineExtensionImages("aaaa", "aa");
foreach (var _ in collection.GetAll())
{
    Console.WriteLine($"ResourceId: {_.Data.Id}");
    Console.WriteLine($"Full Resource content: {JsonSerializer.Serialize(_.Data)}");
}
#endregion
