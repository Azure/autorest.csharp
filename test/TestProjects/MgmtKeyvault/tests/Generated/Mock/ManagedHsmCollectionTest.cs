// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using MgmtKeyvault;
using MgmtKeyvault.Models;

namespace MgmtKeyvault.Tests.Mock
{
    /// <summary> Test for ManagedHsm. </summary>
    public partial class ManagedHsmCollectionMockTests : MockTestBase
    {
        public ManagedHsmCollectionMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            // Example: Create a new managed HSM Pool or update an existing managed HSM Pool
            string name = "hsm1";
            MgmtKeyvault.ManagedHsmData parameters = new MgmtKeyvault.ManagedHsmData(location: "westus")
            {
                Properties = new MgmtKeyvault.Models.ManagedHsmProperties()
                {
                    TenantId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                    EnableSoftDelete = true,
                    SoftDeleteRetentionInDays = 90,
                    EnablePurgeProtection = true,
                },
                Sku = new MgmtKeyvault.Models.ManagedHsmSku(family: new MgmtKeyvault.Models.ManagedHsmSkuFamily("B"), name: MgmtKeyvault.Models.ManagedHsmSkuName.StandardB1),
            };
            parameters.Tags.ReplaceWith(new Dictionary<string, string>()
            {
                ["Dept"] = "hsm",
                ["Environment"] = "dogfood",
            });

            var collection = GetArmClient().GetResourceGroup(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/hsm-group")).GetManagedHsms();
            await collection.CreateOrUpdateAsync(true, name, parameters);
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: Retrieve a managed HSM Pool
            string name = "hsm1";

            var collection = GetArmClient().GetResourceGroup(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/hsm-group")).GetManagedHsms();
            await collection.GetAsync(name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            // Example: List managed HSM Pools in a resource group
            int? top = default;

            var collection = GetArmClient().GetResourceGroup(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/hsm-group")).GetManagedHsms();
            await foreach (var _ in collection.GetAllAsync(top))
            {
            }
        }
    }
}
