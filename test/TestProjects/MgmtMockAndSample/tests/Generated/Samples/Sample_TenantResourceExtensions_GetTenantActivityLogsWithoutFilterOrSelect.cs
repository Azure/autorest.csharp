// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager;

namespace MgmtMockAndSample
{
    public partial class Sample_TenantResourceExtensions_GetTenantActivityLogsWithoutFilterOrSelect
    {
        // Get Tenant Activity Logs without filter or select
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetTenantActivityLogs()
        {
            // this example is just showing the usage of "TenantActivityLogs_List" operation, for the dependent resources, they will have to be created separately.

            // authenticate your client
            ArmClient client = new ArmClient(new DefaultAzureCredential());

            // this is a placeholder
            await Task.Run(() => _ = string.Empty);
        }
    }
}
