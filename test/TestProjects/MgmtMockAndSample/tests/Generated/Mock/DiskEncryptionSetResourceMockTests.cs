// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Net;
using System.Threading.Tasks;
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
    /// <summary> Test for DiskEncryptionSetResource. </summary>
    public partial class DiskEncryptionSetResourceMockTests : MockTestBase
    {
        public DiskEncryptionSetResourceMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task Delete()
        {
            // Example: Delete a disk encryption set.

            ResourceIdentifier diskEncryptionSetResourceId = DiskEncryptionSetResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroup", "myDiskEncryptionSet");
            DiskEncryptionSetResource diskEncryptionSet = GetArmClient().GetDiskEncryptionSetResource(diskEncryptionSetResourceId);
            await diskEncryptionSet.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task Get_GetInformationAboutADiskEncryptionSetWhenAutoKeyRotationFailed()
        {
            // Example: Get information about a disk encryption set when auto-key rotation failed.

            ResourceIdentifier diskEncryptionSetResourceId = DiskEncryptionSetResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroup", "myDiskEncryptionSet");
            DiskEncryptionSetResource diskEncryptionSet = GetArmClient().GetDiskEncryptionSetResource(diskEncryptionSetResourceId);
            await diskEncryptionSet.GetAsync();
        }

        [RecordedTest]
        public async Task Get_GetInformationAboutADiskEncryptionSet()
        {
            // Example: Get information about a disk encryption set.

            ResourceIdentifier diskEncryptionSetResourceId = DiskEncryptionSetResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroup", "myDiskEncryptionSet");
            DiskEncryptionSetResource diskEncryptionSet = GetArmClient().GetDiskEncryptionSetResource(diskEncryptionSetResourceId);
            await diskEncryptionSet.GetAsync();
        }

        [RecordedTest]
        public async Task GetDiskEncryptionSets()
        {
            // Example: List all disk encryption sets in a subscription.

            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            SubscriptionResource subscriptionResource = GetArmClient().GetSubscriptionResource(subscriptionResourceId);
            await foreach (var _ in subscriptionResource.GetDiskEncryptionSetsAsync())
            {
            }
        }

        [RecordedTest]
        public async Task Update_UpdateADiskEncryptionSetWithRotationToLatestKeyVersionEnabledSetToTrueSucceeded()
        {
            // Example: Update a disk encryption set with rotationToLatestKeyVersionEnabled set to true - Succeeded

            ResourceIdentifier diskEncryptionSetResourceId = DiskEncryptionSetResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroup", "myDiskEncryptionSet");
            DiskEncryptionSetResource diskEncryptionSet = GetArmClient().GetDiskEncryptionSetResource(diskEncryptionSetResourceId);
            await diskEncryptionSet.UpdateAsync(WaitUntil.Completed, new DiskEncryptionSetPatch()
            {
                Identity = new ManagedServiceIdentity("SystemAssigned"),
                EncryptionType = DiskEncryptionSetType.EncryptionAtRestWithCustomerKey,
                ActiveKey = new KeyForDiskEncryptionSet(new Uri("https://myvaultdifferentsub.vault-int.azure-int.net/keys/keyName/keyVersion1")),
                RotationToLatestKeyVersionEnabled = true,
            });
        }

        [RecordedTest]
        public async Task Update_UpdateADiskEncryptionSetWithRotationToLatestKeyVersionEnabledSetToTrueUpdating()
        {
            // Example: Update a disk encryption set with rotationToLatestKeyVersionEnabled set to true - Updating

            ResourceIdentifier diskEncryptionSetResourceId = DiskEncryptionSetResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroup", "myDiskEncryptionSet");
            DiskEncryptionSetResource diskEncryptionSet = GetArmClient().GetDiskEncryptionSetResource(diskEncryptionSetResourceId);
            await diskEncryptionSet.UpdateAsync(WaitUntil.Completed, new DiskEncryptionSetPatch()
            {
                Identity = new ManagedServiceIdentity("SystemAssigned"),
                EncryptionType = DiskEncryptionSetType.EncryptionAtRestWithCustomerKey,
                ActiveKey = new KeyForDiskEncryptionSet(new Uri("https://myvaultdifferentsub.vault-int.azure-int.net/keys/keyName/keyVersion1")),
                RotationToLatestKeyVersionEnabled = true,
            });
        }

        [RecordedTest]
        public async Task Update_UpdateADiskEncryptionSet()
        {
            // Example: Update a disk encryption set.

            ResourceIdentifier diskEncryptionSetResourceId = DiskEncryptionSetResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroup", "myDiskEncryptionSet");
            DiskEncryptionSetResource diskEncryptionSet = GetArmClient().GetDiskEncryptionSetResource(diskEncryptionSetResourceId);
            await diskEncryptionSet.UpdateAsync(WaitUntil.Completed, new DiskEncryptionSetPatch()
            {
                Tags =
{
["department"] = "Development",
["project"] = "Encryption",
},
                EncryptionType = DiskEncryptionSetType.EncryptionAtRestWithCustomerKey,
                ActiveKey = new KeyForDiskEncryptionSet(new Uri("https://myvmvault.vault-int.azure-int.net/keys/keyName/keyVersion"))
                {
                    SourceVaultId = new ResourceIdentifier("/subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.KeyVault/vaults/myVMVault"),
                },
            });
        }
    }
}
