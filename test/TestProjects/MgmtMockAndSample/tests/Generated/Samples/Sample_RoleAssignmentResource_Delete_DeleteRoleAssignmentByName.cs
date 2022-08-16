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

namespace MgmtMockAndSample
{
    public partial class Sample_RoleAssignmentResource_Delete_DeleteRoleAssignmentByName
    {
        // Delete role assignment by name
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "RoleAssignments_Delete" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this RoleAssignmentResource created on azure
            // for more information of creating RoleAssignmentResource, please refer to the document of RoleAssignmentResource
            string scope = "scope";
            string roleAssignmentName = "roleAssignmentName";
            ResourceIdentifier roleAssignmentResourceId = MgmtMockAndSample.RoleAssignmentResource.CreateResourceIdentifier(scope, roleAssignmentName);
            MgmtMockAndSample.RoleAssignmentResource roleAssignment = client.GetRoleAssignmentResource(roleAssignmentResourceId);

            // invoke the operation
            ArmOperation<MgmtMockAndSample.RoleAssignmentResource> lro = await roleAssignment.DeleteAsync(WaitUntil.Completed);
            MgmtMockAndSample.RoleAssignmentResource result = lro.Value;

            MgmtMockAndSample.RoleAssignmentData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
