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
    /// <summary> Test for GuestConfigurationAssignmentResource. </summary>
    public partial class GuestConfigurationAssignmentResourceMockTests : MockTestBase
    {
        public GuestConfigurationAssignmentResourceMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task Delete()
        {
            // Example: Delete an guest configuration assignment

            ResourceIdentifier guestConfigurationAssignmentResourceId = GuestConfigurationAssignmentResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroupName", "myVMName", "SecureProtocol");
            GuestConfigurationAssignmentResource guestConfigurationAssignment = GetArmClient().GetGuestConfigurationAssignmentResource(guestConfigurationAssignmentResourceId);
            await guestConfigurationAssignment.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: Get a guest configuration assignment

            ResourceIdentifier guestConfigurationAssignmentResourceId = GuestConfigurationAssignmentResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroupName", "myVMName", "SecureProtocol");
            GuestConfigurationAssignmentResource guestConfigurationAssignment = GetArmClient().GetGuestConfigurationAssignmentResource(guestConfigurationAssignmentResourceId);
            await guestConfigurationAssignment.GetAsync();
        }

        [RecordedTest]
        public async Task Update()
        {
            // Example: Create or update guest configuration assignment

            ResourceIdentifier guestConfigurationAssignmentResourceId = GuestConfigurationAssignmentResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "myResourceGroupName", "myVMName", "NotInstalledApplicationForWindows");
            GuestConfigurationAssignmentResource guestConfigurationAssignment = GetArmClient().GetGuestConfigurationAssignmentResource(guestConfigurationAssignmentResourceId);
            await guestConfigurationAssignment.UpdateAsync(WaitUntil.Completed, new GuestConfigurationAssignmentData()
            {
                Properties = new GuestConfigurationAssignmentProperties()
                {
                    Context = "Azure policy",
                },
                Name = "NotInstalledApplicationForWindows",
                Location = new AzureLocation("westcentralus"),
            });
        }
    }
}
