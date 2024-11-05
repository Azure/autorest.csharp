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
using NUnit.Framework;

namespace MgmtMockAndSample.Samples
{
    public partial class Sample_RoleAssignmentResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetRoleAssignmentByName()
        {
            // Generated from example definition:
            // this example is just showing the usage of "RoleAssignments_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this RoleAssignmentResource created on azure
            // for more information of creating RoleAssignmentResource, please refer to the document of RoleAssignmentResource
            string scope = "scope";
            string roleAssignmentName = "roleAssignmentName";
            ResourceIdentifier roleAssignmentResourceId = RoleAssignmentResource.CreateResourceIdentifier(scope, roleAssignmentName);
            RoleAssignmentResource roleAssignment = client.GetRoleAssignmentResource(roleAssignmentResourceId);

            // invoke the operation
            RoleAssignmentResource result = await roleAssignment.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            RoleAssignmentData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_DeleteRoleAssignmentByName()
        {
            // Generated from example definition:
            // this example is just showing the usage of "RoleAssignments_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this RoleAssignmentResource created on azure
            // for more information of creating RoleAssignmentResource, please refer to the document of RoleAssignmentResource
            string scope = "scope";
            string roleAssignmentName = "roleAssignmentName";
            ResourceIdentifier roleAssignmentResourceId = RoleAssignmentResource.CreateResourceIdentifier(scope, roleAssignmentName);
            RoleAssignmentResource roleAssignment = client.GetRoleAssignmentResource(roleAssignmentResourceId);

            // invoke the operation
            ArmOperation<RoleAssignmentResource> lro = await roleAssignment.DeleteAsync(WaitUntil.Completed);
            RoleAssignmentResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            RoleAssignmentData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_CreateRoleAssignment()
        {
            // Generated from example definition:
            // this example is just showing the usage of "RoleAssignments_Create" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this RoleAssignmentResource created on azure
            // for more information of creating RoleAssignmentResource, please refer to the document of RoleAssignmentResource
            string scope = "scope";
            string roleAssignmentName = "roleAssignmentName";
            ResourceIdentifier roleAssignmentResourceId = RoleAssignmentResource.CreateResourceIdentifier(scope, roleAssignmentName);
            RoleAssignmentResource roleAssignment = client.GetRoleAssignmentResource(roleAssignmentResourceId);

            // invoke the operation
            RoleAssignmentCreateOrUpdateContent content = new RoleAssignmentCreateOrUpdateContent
            {
                RoleDefinitionId = "/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f/providers/Microsoft.Authorization/roleDefinitions/de139f84-1756-47ae-9be6-808fbbe84772",
                PrincipalId = "d93a38bc-d029-4160-bfb0-fbda779ac214",
                CanDelegate = false,
            };
            ArmOperation<RoleAssignmentResource> lro = await roleAssignment.UpdateAsync(WaitUntil.Completed, content);
            RoleAssignmentResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            RoleAssignmentData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Validate_ValidateRoleAssignmentsForSubscription()
        {
            // Generated from example definition:
            // this example is just showing the usage of "RoleAssignments_Validate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this RoleAssignmentResource created on azure
            // for more information of creating RoleAssignmentResource, please refer to the document of RoleAssignmentResource
            string subscriptionId = "subId";
            string scope = $"/subscriptions/{subscriptionId}";
            string roleAssignmentName = "roleAssignmentId";
            ResourceIdentifier roleAssignmentResourceId = RoleAssignmentResource.CreateResourceIdentifier(scope, roleAssignmentName);
            RoleAssignmentResource roleAssignment = client.GetRoleAssignmentResource(roleAssignmentResourceId);

            // invoke the operation
            await roleAssignment.ValidateAsync().ConfigureAwait(false);

            Console.WriteLine("Succeeded");
        }
    }
}
