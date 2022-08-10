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
    public partial class Sample_RoleAssignmentCollection_ListRoleAssignmentsForResource
    {
        // List role assignments for resource
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetAll()
        {
            // this example is just showing the usage of "RoleAssignments_ListForResource" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this example assumes you already have this ArmResource created on azure
            // for more information of creating ArmResource, please refer to the document of ArmResource
            ResourceIdentifier resourceId = new ResourceIdentifier(string.Format("/subscriptions/{0}/resourcegroups/{1}/providers/{2}/{3}/{4}/{5}", "00000000-0000-0000-0000-000000000000", "rgname", "resourceProviderNamespace", "parentResourcePath", "resourceType", "resourceName"));
            GenericResource resource = client.GetGenericResource(resourceId);

            // get the collection of this RoleAssignmentResource
            MgmtMockAndSample.RoleAssignmentCollection collection = resource.GetRoleAssignments();

            // invoke the operation and iterate over the result
            await foreach (MgmtMockAndSample.RoleAssignmentResource item in collection.GetAllAsync())
            {
                MgmtMockAndSample.RoleAssignmentData data = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {data.Id}");
            }
        }
    }
}
