// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Net;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using MgmtMockAndSample;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample.Tests.Mock
{
    /// <summary> Test for GuestConfigurationAssignmentCollection. </summary>
    public partial class GuestConfigurationAssignmentCollectionMockTests : MockTestBase
    {
        public GuestConfigurationAssignmentCollectionMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            // Example: Create or update guest configuration assignment

            ResourceIdentifier scope = new ResourceIdentifier(string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Compute/virtualMachines/{2}", "00000000-0000-0000-0000-000000000000", "myResourceGroupName", "myVMName"));
            var collection = GetArmClient().GetGuestConfigurationAssignments(scope);
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, "NotInstalledApplicationForWindows", new GuestConfigurationAssignmentData()
            {
                Properties = new GuestConfigurationAssignmentProperties()
                {
                    Context = "Azure policy",
                },
                Name = "NotInstalledApplicationForWindows",
                Location = new AzureLocation("westcentralus"),
            });
        }

        [RecordedTest]
        public async Task Exists()
        {
            // Example: Get a guest configuration assignment

            ResourceIdentifier scope = new ResourceIdentifier(string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Compute/virtualMachines/{2}", "00000000-0000-0000-0000-000000000000", "myResourceGroupName", "myVMName"));
            var collection = GetArmClient().GetGuestConfigurationAssignments(scope);
            await collection.ExistsAsync("SecureProtocol");
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: Get a guest configuration assignment

            ResourceIdentifier scope = new ResourceIdentifier(string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Compute/virtualMachines/{2}", "00000000-0000-0000-0000-000000000000", "myResourceGroupName", "myVMName"));
            var collection = GetArmClient().GetGuestConfigurationAssignments(scope);
            await collection.GetAsync("SecureProtocol");
        }

        [RecordedTest]
        public async Task GetAll()
        {
            // Example: List all guest configuration assignments for a virtual machine

            ResourceIdentifier scope = new ResourceIdentifier(string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Compute/virtualMachines/{2}", "00000000-0000-0000-0000-000000000000", "myResourceGroupName", "myVMName"));
            var collection = GetArmClient().GetGuestConfigurationAssignments(scope);
            await foreach (var _ in collection.GetAllAsync())
            {
            }
        }
    }
}
