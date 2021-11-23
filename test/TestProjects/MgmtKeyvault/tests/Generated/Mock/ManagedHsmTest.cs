// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using MgmtKeyvault;
using NUnit.Framework;

namespace MgmtKeyvault.Tests.Mock
{
    /// <summary> Test for ManagedHsm. </summary>
    public partial class ManagedHsmMockTests : MockTestBase
    {
        public ManagedHsmMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            System.Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        private async Task<MgmtKeyvault.ManagedHsmCollection> GetManagedHsmCollectionAsync(string resourceGroupName)
        {
            ResourceGroup resourceGroup = await TestHelper.CreateResourceGroupAsync(resourceGroupName, GetArmClient());
            ManagedHsmCollection managedHsmCollection = resourceGroup.GetManagedHsms();
            return managedHsmCollection;
        }

        private async Task<MgmtKeyvault.ManagedHsm> GetManagedHsmAsync()
        {
            var collection = await GetManagedHsmCollectionAsync("hsm-group");
            var createOperation = await TestHelper.CreateOrUpdateExampleInstanceAsync(collection, "hsm1");
            return createOperation.Value;
        }

        [RecordedTest]
        [Ignore("Generated TestCase")]
        public async Task GetAsync()
        {
            // Example: Retrieve a managed HSM Pool
            var resource = await GetManagedHsmAsync();

            await resource.GetAsync();
        }

        [RecordedTest]
        [Ignore("Generated TestCase")]
        public async Task DeleteAsync()
        {
            // Example: Delete a managed HSM Pool
            var resource = await GetManagedHsmAsync();

            await resource.DeleteAsync();
        }

        [RecordedTest]
        [Ignore("Generated TestCase")]
        public async Task UpdateAsync()
        {
            // Example: Update an existing managed HSM Pool
            var resource = await GetManagedHsmAsync();
            var parameters = new MgmtKeyvault.ManagedHsmData("westus")
            {
            };
            parameters.Tags.ReplaceWith(new Dictionary<string, string>() { { "Dept", "hsm" }, { "Environment", "dogfood" }, { "Slice", "A" }, });
            await resource.UpdateAsync(parameters);
        }

        [RecordedTest]
        [Ignore("Generated TestCase")]
        public async Task GetMHSMPrivateLinkResourcesByMhsmResourceAsync()
        {
            // Example: KeyVaultListPrivateLinkResources
            var resource = await GetManagedHsmAsync();

            await resource.GetMHSMPrivateLinkResourcesByMhsmResourceAsync();
        }
    }
}
