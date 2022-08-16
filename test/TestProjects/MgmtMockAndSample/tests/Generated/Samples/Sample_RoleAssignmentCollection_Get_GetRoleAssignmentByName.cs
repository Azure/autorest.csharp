// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtMockAndSample
{
    public partial class Sample_RoleAssignmentCollection_Get_GetRoleAssignmentByName
    {
        // Get role assignment by name
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            // Generated from example definition: 
            // this example is just showing the usage of "RoleAssignments_Get" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this ArmResource created on azure
            // for more information of creating ArmResource, please refer to the document of ArmResource
            string scope = "scope";
            ResourceIdentifier resourceId = new ResourceIdentifier(string.Format("/{0}", scope));
            GenericResource resource = client.GetGenericResource(resourceId);

            // get the collection of this RoleAssignmentResource
            MgmtMockAndSample.RoleAssignmentCollection collection = resource.GetRoleAssignments();

            // invoke the operation
            string roleAssignmentName = "roleAssignmentName";
            MgmtMockAndSample.RoleAssignmentResource result = await collection.GetAsync(roleAssignmentName);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            MgmtMockAndSample.RoleAssignmentData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
