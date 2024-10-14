// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using NUnit.Framework;

namespace MgmtMockAndSample.Samples
{
    public partial class Sample_FirewallPolicyRuleCollectionGroupResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetFirewallPolicyNatRuleCollectionGroup()
        {
            // Generated from example definition:
            // this example is just showing the usage of "FirewallPolicyRuleCollectionGroups_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this FirewallPolicyRuleCollectionGroupResource created on azure
            // for more information of creating FirewallPolicyRuleCollectionGroupResource, please refer to the document of FirewallPolicyRuleCollectionGroupResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string firewallPolicyName = "firewallPolicy";
            string ruleCollectionGroupName = "ruleCollectionGroup1";
            ResourceIdentifier firewallPolicyRuleCollectionGroupResourceId = FirewallPolicyRuleCollectionGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, firewallPolicyName, ruleCollectionGroupName);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetFirewallPolicyRuleCollectionGroup()
        {
            // Generated from example definition:
            // this example is just showing the usage of "FirewallPolicyRuleCollectionGroups_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this FirewallPolicyRuleCollectionGroupResource created on azure
            // for more information of creating FirewallPolicyRuleCollectionGroupResource, please refer to the document of FirewallPolicyRuleCollectionGroupResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string firewallPolicyName = "firewallPolicy";
            string ruleCollectionGroupName = "ruleCollectionGroup1";
            ResourceIdentifier firewallPolicyRuleCollectionGroupResourceId = FirewallPolicyRuleCollectionGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, firewallPolicyName, ruleCollectionGroupName);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetFirewallPolicyRuleCollectionGroupWithIpGroups()
        {
            // Generated from example definition:
            // this example is just showing the usage of "FirewallPolicyRuleCollectionGroups_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this FirewallPolicyRuleCollectionGroupResource created on azure
            // for more information of creating FirewallPolicyRuleCollectionGroupResource, please refer to the document of FirewallPolicyRuleCollectionGroupResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string firewallPolicyName = "firewallPolicy";
            string ruleCollectionGroupName = "ruleGroup1";
            ResourceIdentifier firewallPolicyRuleCollectionGroupResourceId = FirewallPolicyRuleCollectionGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, firewallPolicyName, ruleCollectionGroupName);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetFirewallPolicyRuleCollectionGroupWithWebCategories()
        {
            // Generated from example definition:
            // this example is just showing the usage of "FirewallPolicyRuleCollectionGroups_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this FirewallPolicyRuleCollectionGroupResource created on azure
            // for more information of creating FirewallPolicyRuleCollectionGroupResource, please refer to the document of FirewallPolicyRuleCollectionGroupResource
            string subscriptionId = "e747cc13-97d4-4a79-b463-42d7f4e558f2";
            string resourceGroupName = "rg1";
            string firewallPolicyName = "firewallPolicy";
            string ruleCollectionGroupName = "ruleCollectionGroup1";
            ResourceIdentifier firewallPolicyRuleCollectionGroupResourceId = FirewallPolicyRuleCollectionGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, firewallPolicyName, ruleCollectionGroupName);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_DeleteFirewallPolicyRuleCollectionGroup()
        {
            // Generated from example definition:
            // this example is just showing the usage of "FirewallPolicyRuleCollectionGroups_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this FirewallPolicyRuleCollectionGroupResource created on azure
            // for more information of creating FirewallPolicyRuleCollectionGroupResource, please refer to the document of FirewallPolicyRuleCollectionGroupResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string firewallPolicyName = "firewallPolicy";
            string ruleCollectionGroupName = "ruleCollectionGroup1";
            ResourceIdentifier firewallPolicyRuleCollectionGroupResourceId = FirewallPolicyRuleCollectionGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, firewallPolicyName, ruleCollectionGroupName);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_CreateFirewallPolicyNatRuleCollectionGroup()
        {
            // Generated from example definition:
            // this example is just showing the usage of "FirewallPolicyRuleCollectionGroups_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this FirewallPolicyRuleCollectionGroupResource created on azure
            // for more information of creating FirewallPolicyRuleCollectionGroupResource, please refer to the document of FirewallPolicyRuleCollectionGroupResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string firewallPolicyName = "firewallPolicy";
            string ruleCollectionGroupName = "ruleCollectionGroup1";
            ResourceIdentifier firewallPolicyRuleCollectionGroupResourceId = FirewallPolicyRuleCollectionGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, firewallPolicyName, ruleCollectionGroupName);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_CreateFirewallPolicyRuleCollectionGroup()
        {
            // Generated from example definition:
            // this example is just showing the usage of "FirewallPolicyRuleCollectionGroups_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this FirewallPolicyRuleCollectionGroupResource created on azure
            // for more information of creating FirewallPolicyRuleCollectionGroupResource, please refer to the document of FirewallPolicyRuleCollectionGroupResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string firewallPolicyName = "firewallPolicy";
            string ruleCollectionGroupName = "ruleCollectionGroup1";
            ResourceIdentifier firewallPolicyRuleCollectionGroupResourceId = FirewallPolicyRuleCollectionGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, firewallPolicyName, ruleCollectionGroupName);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_CreateFirewallPolicyRuleCollectionGroupWithAllDefaultValues()
        {
            // Generated from example definition:
            // this example is just showing the usage of "FirewallPolicyRuleCollectionGroups_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this FirewallPolicyRuleCollectionGroupResource created on azure
            // for more information of creating FirewallPolicyRuleCollectionGroupResource, please refer to the document of FirewallPolicyRuleCollectionGroupResource
            string subscriptionId = "e747cc13-97d4-4a79-b463-42d7f4e558f2";
            string resourceGroupName = "rg1";
            string firewallPolicyName = "firewallPolicy";
            string ruleCollectionGroupName = "ruleCollectionGroup1";
            ResourceIdentifier firewallPolicyRuleCollectionGroupResourceId = FirewallPolicyRuleCollectionGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, firewallPolicyName, ruleCollectionGroupName);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_CreateFirewallPolicyRuleCollectionGroupWithIpGroups()
        {
            // Generated from example definition:
            // this example is just showing the usage of "FirewallPolicyRuleCollectionGroups_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this FirewallPolicyRuleCollectionGroupResource created on azure
            // for more information of creating FirewallPolicyRuleCollectionGroupResource, please refer to the document of FirewallPolicyRuleCollectionGroupResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string firewallPolicyName = "firewallPolicy";
            string ruleCollectionGroupName = "ruleCollectionGroup1";
            ResourceIdentifier firewallPolicyRuleCollectionGroupResourceId = FirewallPolicyRuleCollectionGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, firewallPolicyName, ruleCollectionGroupName);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_CreateFirewallPolicyRuleCollectionGroupWithWebCategories()
        {
            // Generated from example definition:
            // this example is just showing the usage of "FirewallPolicyRuleCollectionGroups_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this FirewallPolicyRuleCollectionGroupResource created on azure
            // for more information of creating FirewallPolicyRuleCollectionGroupResource, please refer to the document of FirewallPolicyRuleCollectionGroupResource
            string subscriptionId = "e747cc13-97d4-4a79-b463-42d7f4e558f2";
            string resourceGroupName = "rg1";
            string firewallPolicyName = "firewallPolicy";
            string ruleCollectionGroupName = "ruleCollectionGroup1";
            ResourceIdentifier firewallPolicyRuleCollectionGroupResourceId = FirewallPolicyRuleCollectionGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, firewallPolicyName, ruleCollectionGroupName);
        }
    }
}
