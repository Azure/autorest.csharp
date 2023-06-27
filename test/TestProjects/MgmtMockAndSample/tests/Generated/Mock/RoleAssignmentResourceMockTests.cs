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
using Azure.ResourceManager.TestFramework;
using MgmtMockAndSample;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample.Tests.Mock
{
    /// <summary> Test for RoleAssignmentResource. </summary>
    public partial class RoleAssignmentResourceMockTests : MockTestBase
    {
        public RoleAssignmentResourceMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task Delete()
        {
            // Example: Delete role assignment by name

            ResourceIdentifier roleAssignmentResourceId = RoleAssignmentResource.CreateResourceIdentifier("scope", "roleAssignmentName");
            RoleAssignmentResource roleAssignment = GetArmClient().GetRoleAssignmentResource(roleAssignmentResourceId);
            await roleAssignment.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: Get role assignment by name

            ResourceIdentifier roleAssignmentResourceId = RoleAssignmentResource.CreateResourceIdentifier("scope", "roleAssignmentName");
            RoleAssignmentResource roleAssignment = GetArmClient().GetRoleAssignmentResource(roleAssignmentResourceId);
            await roleAssignment.GetAsync();
        }

        [RecordedTest]
        public async Task Update()
        {
            // Example: Create role assignment

            ResourceIdentifier roleAssignmentResourceId = RoleAssignmentResource.CreateResourceIdentifier("scope", "roleAssignmentName");
            RoleAssignmentResource roleAssignment = GetArmClient().GetRoleAssignmentResource(roleAssignmentResourceId);
            await roleAssignment.UpdateAsync(WaitUntil.Completed, new RoleAssignmentCreateOrUpdateContent()
            {
                RoleDefinitionId = "/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f/providers/Microsoft.Authorization/roleDefinitions/de139f84-1756-47ae-9be6-808fbbe84772",
                PrincipalId = "d93a38bc-d029-4160-bfb0-fbda779ac214",
                CanDelegate = false,
            });
        }

        [RecordedTest]
        public async Task Validate()
        {
            // Example: Validate role assignments for subscription

            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            ResourceIdentifier roleAssignmentResourceId = RoleAssignmentResource.CreateResourceIdentifier($"/subscriptions/{subscriptionId}", "roleAssignmentId");
            RoleAssignmentResource roleAssignment = GetArmClient().GetRoleAssignmentResource(roleAssignmentResourceId);
            await roleAssignment.ValidateAsync();
        }
    }
}
