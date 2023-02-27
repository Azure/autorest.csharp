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
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using MgmtMockAndSample.Mock;

namespace MgmtMockAndSample.Tests.Mock
{
    /// <summary> Test for MgmtMockAndSampleExtensions. </summary>
    public partial class MgmtMockAndSampleExtensionsMockTests : MockTestBase
    {
        public MgmtMockAndSampleExtensionsMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task GetDeletedVaults()
        {
            // Example: List deleted vaults in the specified subscription

            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            SubscriptionResource subscriptionResource = GetArmClient().GetSubscriptionResource(subscriptionResourceId);
            await foreach (var _ in subscriptionResource.GetDeletedVaultsAsync())
            {
            }
        }

        [RecordedTest]
        public async Task GetDeletedManagedHsms()
        {
            // Example: List deleted managed HSMs in the specified subscription

            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            SubscriptionResource subscriptionResource = GetArmClient().GetSubscriptionResource(subscriptionResourceId);
            await foreach (var _ in subscriptionResource.GetDeletedManagedHsmsAsync())
            {
            }
        }

        [RecordedTest]
        public async Task CalculateTemplateHashDeployment()
        {
            // Example: Calculate template hash

            var tenantResource = GetArmClient().GetTenants().GetAllAsync().GetAsyncEnumerator().Current;
            await tenantResource.CalculateTemplateHashDeploymentAsync(BinaryData.FromObjectAsJson(new Dictionary<string, object>()
            {
                ["$schema"] = "http://schemas.management.azure.com/deploymentTemplate?api-version=2014-04-01-preview",
                ["contentVersion"] = "1.0.0.0",
                ["outputs"] = new Dictionary<string, object>()
                {
                    ["string"] = new Dictionary<string, object>()
                    {
                        ["type"] = "string",
                        ["value"] = "myvalue"
                    }
                },
                ["parameters"] = new Dictionary<string, object>()
                {
                    ["string"] = new Dictionary<string, object>()
                    {
                        ["type"] = "string"
                    }
                },
                ["resources"] = new object[] { },
                ["variables"] = new Dictionary<string, object>()
                {
                    ["array"] = new object[] { "1", "2", "3", "4" },
                    ["bool"] = "true",
                    ["int"] = "42",
                    ["object"] = new Dictionary<string, object>()
                    {
                        ["object"] = new Dictionary<string, object>()
                        {
                            ["location"] = "West US",
                            ["vmSize"] = "Large"
                        }
                    },
                    ["string"] = "string"
                }
            }));
        }

        [RecordedTest]
        public async Task GetTenantActivityLogs()
        {
            // Example: Get Tenant Activity Logs without filter or select

            var tenantResource = GetArmClient().GetTenants().GetAllAsync().GetAsyncEnumerator().Current;
            await foreach (var _ in tenantResource.GetTenantActivityLogsAsync())
            {
            }
        }
    }
}
