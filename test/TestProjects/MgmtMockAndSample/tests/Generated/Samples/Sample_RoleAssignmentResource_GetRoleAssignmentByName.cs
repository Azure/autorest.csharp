// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager;

namespace MgmtMockAndSample
{
    public partial class Sample_RoleAssignmentResource_GetRoleAssignmentByName
    {
        // Get role assignment by name
        [NUnit.Framework.TestCase]
        public async Task Get()
        {
            // this example is just showing the usage of "RoleAssignments_Get" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            await Task.Run(() => _ = string.Empty);
        }
    }
}
