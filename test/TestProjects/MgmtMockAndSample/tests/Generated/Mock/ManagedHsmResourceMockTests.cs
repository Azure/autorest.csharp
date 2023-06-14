// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

namespace MgmtMockAndSample.Tests.Mock
{
    /// <summary> Test for ManagedHsmResource. </summary>
    public partial class ManagedHsmResourceMockTests : MockTestBase
    {
        public ManagedHsmResourceMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task Delete()
        {
            // Example: Delete a managed HSM Pool

            ResourceIdentifier managedHsmResourceId = ManagedHsmResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "hsm-group", "hsm1");
            ManagedHsmResource managedHsm = GetArmClient().GetManagedHsmResource(managedHsmResourceId);
            await managedHsm.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: Retrieve a managed HSM Pool

            ResourceIdentifier managedHsmResourceId = ManagedHsmResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "hsm-group", "hsm1");
            ManagedHsmResource managedHsm = GetArmClient().GetManagedHsmResource(managedHsmResourceId);
            await managedHsm.GetAsync();
        }

        [RecordedTest]
        public async Task GetManagedHsms()
        {
            // Example: List managed HSM Pools in a subscription

            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            SubscriptionResource subscriptionResource = GetArmClient().GetSubscriptionResource(subscriptionResourceId);
            await foreach (var _ in subscriptionResource.GetManagedHsmsAsync())
            {
            }
        }

        [RecordedTest]
        public async Task GetMHSMPrivateLinkResourcesByMhsmResource()
        {
            // Example: KeyVaultListPrivateLinkResources

            ResourceIdentifier managedHsmResourceId = ManagedHsmResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-mhsm");
            ManagedHsmResource managedHsm = GetArmClient().GetManagedHsmResource(managedHsmResourceId);
            await foreach (var _ in managedHsm.GetMHSMPrivateLinkResourcesByMhsmResourceAsync())
            {
            }
        }

        [RecordedTest]
        public async Task Update()
        {
            // Example: Update an existing managed HSM Pool

            ResourceIdentifier managedHsmResourceId = ManagedHsmResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "hsm-group", "hsm1");
            ManagedHsmResource managedHsm = GetArmClient().GetManagedHsmResource(managedHsmResourceId);
            await managedHsm.UpdateAsync(WaitUntil.Completed, new ManagedHsmData(new AzureLocation("placeholder"))
            {
                Tags =
{
["Dept"] = "hsm",
["Environment"] = "dogfood",
["Slice"] = "A",
},
            });
        }
    }
}
