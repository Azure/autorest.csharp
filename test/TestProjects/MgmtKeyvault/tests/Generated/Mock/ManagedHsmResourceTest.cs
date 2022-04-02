// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using MgmtKeyvault;

namespace MgmtKeyvault.Tests.Mock
{
    /// <summary> Test for ManagedHsm. </summary>
    public partial class ManagedHsmResourceMockTests : MockTestBase
    {
        public ManagedHsmResourceMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: Retrieve a managed HSM Pool
            var managedHsmResourceId = MgmtKeyvault.ManagedHsmResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "hsm-group", "hsm1");
            var managedHsmResource = GetArmClient().GetManagedHsmResource(managedHsmResourceId);

            await managedHsmResource.GetAsync();
        }

        [RecordedTest]
        public async Task Delete()
        {
            // Example: Delete a managed HSM Pool
            var managedHsmResourceId = MgmtKeyvault.ManagedHsmResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "hsm-group", "hsm1");
            var managedHsmResource = GetArmClient().GetManagedHsmResource(managedHsmResourceId);

            await managedHsmResource.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task Update()
        {
            // Example: Update an existing managed HSM Pool
            var managedHsmResourceId = MgmtKeyvault.ManagedHsmResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "hsm-group", "hsm1");
            var managedHsmResource = GetArmClient().GetManagedHsmResource(managedHsmResourceId);
            MgmtKeyvault.ManagedHsmData data = new MgmtKeyvault.ManagedHsmData(location: AzureLocation.WestUS)
            {
            };
            data.Tags.ReplaceWith(new Dictionary<string, string>()
            {
                ["Dept"] = "hsm",
                ["Environment"] = "dogfood",
                ["Slice"] = "A",
            });

            await managedHsmResource.UpdateAsync(WaitUntil.Completed, data);
        }

        [RecordedTest]
        public async Task GetMHSMPrivateLinkResourcesByMhsmResource()
        {
            // Example: KeyVaultListPrivateLinkResources
            var managedHsmResourceId = MgmtKeyvault.ManagedHsmResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "sample-group", "sample-mhsm");
            var managedHsmResource = GetArmClient().GetManagedHsmResource(managedHsmResourceId);

            await foreach (var _ in managedHsmResource.GetMHSMPrivateLinkResourcesByMhsmResourceAsync())
            {
            }
        }
    }
}
