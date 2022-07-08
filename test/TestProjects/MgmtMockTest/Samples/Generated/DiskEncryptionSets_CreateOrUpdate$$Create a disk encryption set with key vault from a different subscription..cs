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
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using MgmtMockTest;
using MgmtMockTest.Models;
#endregion

#region Parameter decalarations
// Below parameters are extracted from swagger example files, please use your own values to execute the API lively.
ArmClient GetArmClient() => new ArmClient(new DefaultAzureCredential());
var subscriptionId = Environment.GetEnvironmentVariable("SUBSCRIPTION_ID") ?? "00000000-0000-0000-0000-000000000000";
var resourceGroupName = "myResourceGroup";  // Name of the resource group that contains the key vault.
var diskEncryptionSetName = "myDiskEncryptionSet";  // The name of the disk encryption set that is being created. The name can't be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The maximum name length is 80 characters.
#endregion

#region API invocation
// api-version: 2021-10-01
// x-ms-original-file: file:///C:/ZZ/projects/codegen/autorest.csharp/test/TestProjects/MgmtMockTest/src/examples/diskEncryptionSetExamples/DiskEncryptionSet_Create_WithKeyVaultFromADifferentSubscription.json
// Example: Create a disk encryption set with key vault from a different subscription.

var resourceGroupResourceId = global::Azure.ResourceManager.Resources.ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
var resourceGroupResource = GetArmClient().GetResourceGroupResource(resourceGroupResourceId);
var collection = resourceGroupResource.GetDiskEncryptionSets();
var operation = collection.CreateOrUpdate(WaitUntil.Completed, diskEncryptionSetName, new DiskEncryptionSetData()
{
    Identity = new ManagedServiceIdentity("SystemAssigned"),
    EncryptionType = DiskEncryptionSetType.EncryptionAtRestWithCustomerKey,
    ActiveKey = new KeyForDiskEncryptionSet(new Uri("https://myvaultdifferentsub.vault-int.azure-int.net/keys/{key}")),
});

Console.WriteLine($"Succeed on ResourceId: {operation.Value.Data.Id}");
Console.WriteLine($"Full Resource content: {JsonSerializer.Serialize(operation.Value.Data)}");
#endregion
