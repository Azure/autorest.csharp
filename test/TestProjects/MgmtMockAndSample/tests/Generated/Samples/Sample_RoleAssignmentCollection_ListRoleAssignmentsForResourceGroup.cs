// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtMockAndSample
{
    public partial class Sample_RoleAssignmentCollection_ListRoleAssignmentsForResourceGroup
    {
        // List role assignments for resource group
        [NUnit.Framework.TestCase]
        public async Task GetAll()
        {
            // this example is just showing the usage of "RoleAssignments_ListForResourceGroup" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // we assume you already have this ArmResourceExtensions created
            // if you do not know how to create ArmResourceExtensions, please refer to the document of ArmResourceExtensions
            ResourceIdentifier resourceId = new ResourceIdentifier(string.Format("/subscriptions/{0}/resourceGroups/{1}", "00000000-0000-0000-0000-000000000000", "rgname"));
            GenericResource resource = client.GetGenericResource(resourceId);
            // get the collection of this RoleAssignmentResource
            RoleAssignmentCollection collection = resource.GetRoleAssignments();

            await Task.Run(() => _ = string.Empty);
        }
    }
}
