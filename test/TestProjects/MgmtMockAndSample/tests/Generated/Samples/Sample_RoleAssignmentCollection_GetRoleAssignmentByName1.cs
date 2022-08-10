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
    public partial class Sample_RoleAssignmentCollection_GetRoleAssignmentByName
    {
        // Get role assignment by name
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Exists()
        {
            // this example is just showing the usage of "RoleAssignments_Get" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // we assume you already have this ArmResourceExtensions created
            // if you do not know how to create ArmResourceExtensions, please refer to the document of ArmResourceExtensions
            ResourceIdentifier resourceId = new ResourceIdentifier(string.Format("/{0}", "scope"));
            GenericResource resource = client.GetGenericResource(resourceId);

            // get the collection of this RoleAssignmentResource
            MgmtMockAndSample.RoleAssignmentCollection collection = resource.GetRoleAssignments();

            // invoke the operation

            // this is a placeholder
            await Task.Run(() => _ = string.Empty);
        }
    }
}
