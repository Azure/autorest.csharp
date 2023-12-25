// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Net;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using MgmtMockAndSample;
using MgmtMockAndSample.Models;
using NUnit.Framework;

namespace MgmtMockAndSample.Tests.Mock
{
    /// <summary> Test for VaultResource. </summary>
    public partial class VaultResourceMockTests : MockTestBase
    {
        public VaultResourceMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [Test]
        public async Task CheckNameAvailabilityVault()
        {
            // Example: Validate a vault name

            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            SubscriptionResource subscriptionResource = GetArmClient().GetSubscriptionResource(subscriptionResourceId);
            await subscriptionResource.CheckNameAvailabilityVaultAsync(new VaultCheckNameAvailabilityContent("sample-vault"));
        }

        [Test]
        public async Task Delete()
        {
            // Example: Delete a vault

            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-resource-group", "sample-vault");
            VaultResource vault = GetArmClient().GetVaultResource(vaultResourceId);
            await vault.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task Disable()
        {
            // Example: Disable a vault

            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-resource-group", "sample-vault");
            VaultResource vault = GetArmClient().GetVaultResource(vaultResourceId);
            await vault.DisableAsync();
        }

        [Test]
        public async Task Get()
        {
            // Example: Retrieve a vault

            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-resource-group", "sample-vault");
            VaultResource vault = GetArmClient().GetVaultResource(vaultResourceId);
            await vault.GetAsync();
        }

        [Test]
        public async Task GetKeys()
        {
            // Example: List keys on an existing vault

            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-resource-group", "sample-vault");
            VaultResource vault = GetArmClient().GetVaultResource(vaultResourceId);
            await foreach (var _ in vault.GetKeysAsync())
            {
            }
        }

        [Test]
        public async Task GetPrivateLinkResources()
        {
            // Example: KeyVaultListPrivateLinkResources

            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-vault");
            VaultResource vault = GetArmClient().GetVaultResource(vaultResourceId);
            await foreach (var _ in vault.GetPrivateLinkResourcesAsync())
            {
            }
        }

        [Test]
        public async Task GetVaults()
        {
            // Example: List vaults in the specified subscription

            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            SubscriptionResource subscriptionResource = GetArmClient().GetSubscriptionResource(subscriptionResourceId);
            await foreach (var _ in subscriptionResource.GetVaultsAsync(top: 1))
            {
            }
        }

        [Test]
        public async Task UpdateAccessPolicy()
        {
            // Example: Add an access policy, or update an access policy with new permissions

            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-vault");
            VaultResource vault = GetArmClient().GetVaultResource(vaultResourceId);
            await vault.UpdateAccessPolicyAsync(AccessPolicyUpdateKind.Add, new VaultAccessPolicyParameters(new VaultAccessPolicyProperties(new AccessPolicyEntry[]
            {
new AccessPolicyEntry(Guid.Parse("00000000-0000-0000-0000-000000000000"),"00000000-0000-0000-0000-000000000000",new Permissions()
{
Keys =
{
KeyPermission.Encrypt
},
Secrets =
{
SecretPermission.Get
},
Certificates =
{
CertificatePermission.Get
},
})
            })));
        }

        [Test]
        public async Task Validate()
        {
            // Example: Validate an existing vault

            ResourceIdentifier vaultResourceId = VaultResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-resource-group", "sample-vault");
            VaultResource vault = GetArmClient().GetVaultResource(vaultResourceId);
            await vault.ValidateAsync();
        }
    }
}
