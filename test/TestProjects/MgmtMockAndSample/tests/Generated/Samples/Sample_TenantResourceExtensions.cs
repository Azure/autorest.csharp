// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using MgmtMockAndSample;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample.Samples
{
    public partial class Sample_TenantResourceExtensions
    {
        // Get Tenant Activity Logs without filter or select
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetTenantActivityLogs_GetTenantActivityLogsWithoutFilterOrSelect()
        {
            // Generated from example definition:
            // this example is just showing the usage of "TenantActivityLogs_List" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this TenantResource created on azure
            // for more information of creating TenantResource, please refer to the document of TenantResource
            var tenantResource = client.GetTenants().GetAllAsync().GetAsyncEnumerator().Current;

            // invoke the operation and iterate over the result
            await foreach (EventData item in tenantResource.GetTenantActivityLogsAsync())
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine($"Succeeded");
        }

        // Calculate template hash
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task CalculateTemplateHashDeployment_CalculateTemplateHash()
        {
            // Generated from example definition:
            // this example is just showing the usage of "Deployments_CalculateTemplateHash" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this TenantResource created on azure
            // for more information of creating TenantResource, please refer to the document of TenantResource
            var tenantResource = client.GetTenants().GetAllAsync().GetAsyncEnumerator().Current;

            // invoke the operation
            BinaryData template = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
            {
                ["$schema"] = "http://schemas.management.azure.com/deploymentTemplate?api-version=2014-04-01-preview",
                ["contentVersion"] = "1.0.0.0",
                ["outputs"] = new Dictionary<string, object>()
                {
                    ["string"] = new Dictionary<string, object>()
                    {
                        ["type"] = "string",
                        ["value"] = "myvalue"
                    }
                },
                ["parameters"] = new Dictionary<string, object>()
                {
                    ["string"] = new Dictionary<string, object>()
                    {
                        ["type"] = "string"
                    }
                },
                ["resources"] = new object[] { },
                ["variables"] = new Dictionary<string, object>()
                {
                    ["array"] = new object[] { "1", "2", "3", "4" },
                    ["bool"] = "true",
                    ["int"] = "42",
                    ["object"] = new Dictionary<string, object>()
                    {
                        ["object"] = new Dictionary<string, object>()
                        {
                            ["location"] = "West US",
                            ["vmSize"] = "Large"
                        }
                    },
                    ["string"] = "string"
                }
            });
            TemplateHashResult result = await tenantResource.CalculateTemplateHashDeploymentAsync(template);

            Console.WriteLine($"Succeeded: {result}");
        }
    }
}
