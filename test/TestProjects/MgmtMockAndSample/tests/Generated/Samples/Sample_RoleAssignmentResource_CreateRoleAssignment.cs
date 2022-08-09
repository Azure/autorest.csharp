// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    public partial class Sample_RoleAssignmentResource_CreateRoleAssignment
    {
        // Create role assignment
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update()
        {
            // this example is just showing the usage of "RoleAssignments_Create" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            ResourceIdentifier roleAssignmentResourceId = MgmtMockAndSample.RoleAssignmentResource.CreateResourceIdentifier("scope", "roleAssignmentName");
            MgmtMockAndSample.RoleAssignmentResource roleAssignment = client.GetRoleAssignmentResource(roleAssignmentResourceId);

            // invoke the operation
            ArmOperation<MgmtMockAndSample.RoleAssignmentResource> lro = await roleAssignment.UpdateAsync(WaitUntil.Completed, new RoleAssignmentCreateOrUpdateContent()
            {
                RoleDefinitionId = "/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f/providers/Microsoft.Authorization/roleDefinitions/de139f84-1756-47ae-9be6-808fbbe84772",
                PrincipalId = "d93a38bc-d029-4160-bfb0-fbda779ac214",
                CanDelegate = false,
            });
            MgmtMockAndSample.RoleAssignmentResource result = lro.Value;
            MgmtMockAndSample.RoleAssignmentData data = result.Data;

            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {data}.Id");
        }
    }
}
