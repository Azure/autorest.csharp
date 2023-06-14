// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Net;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using MgmtMockAndSample;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample.Tests.Mock
{
    /// <summary> Test for FirewallPolicyRuleCollectionGroupCollection. </summary>
    public partial class FirewallPolicyRuleCollectionGroupCollectionMockTests : MockTestBase
    {
        public FirewallPolicyRuleCollectionGroupCollectionMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task CreateOrUpdate_CreateFirewallPolicyNatRuleCollectionGroup()
        {
            // Example: Create FirewallPolicyNatRuleCollectionGroup

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            var collection = firewallPolicy.GetFirewallPolicyRuleCollectionGroups();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, "ruleCollectionGroup1", new FirewallPolicyRuleCollectionGroupData()
            {
                Priority = 100,
                RuleCollections =
{
new FirewallPolicyNatRuleCollection()
{
ActionType = FirewallPolicyNatRuleCollectionActionType.Dnat,
Rules =
{
new NatRule()
{
IpProtocols =
{
FirewallPolicyRuleNetworkProtocol.TCP,FirewallPolicyRuleNetworkProtocol.UDP
},
SourceAddresses =
{
"2.2.2.2"
},
DestinationAddresses =
{
"152.23.32.23"
},
DestinationPorts =
{
"8080"
},
TranslatedPort = "8080",
SourceIpGroups =
{
},
TranslatedFqdn = "internalhttp.server.net",
Name = "nat-rule1",
}
},
Name = "Example-Nat-Rule-Collection",
Priority = 100,
}
},
            });
        }

        [RecordedTest]
        public async Task CreateOrUpdate_CreateFirewallPolicyRuleCollectionGroup()
        {
            // Example: Create FirewallPolicyRuleCollectionGroup

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            var collection = firewallPolicy.GetFirewallPolicyRuleCollectionGroups();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, "ruleCollectionGroup1", new FirewallPolicyRuleCollectionGroupData()
            {
                Priority = 100,
                RuleCollections =
{
new FirewallPolicyFilterRuleCollection()
{
ActionType = FirewallPolicyFilterRuleCollectionActionType.Deny,
Rules =
{
new NetworkRule()
{
IpProtocols =
{
FirewallPolicyRuleNetworkProtocol.TCP
},
SourceAddresses =
{
"10.1.25.0/24"
},
DestinationAddresses =
{
"*"
},
DestinationPorts =
{
"*"
},
Name = "network-rule1",
}
},
Name = "Example-Filter-Rule-Collection",
Priority = 100,
}
},
            });
        }

        [RecordedTest]
        public async Task CreateOrUpdate_CreateFirewallPolicyRuleCollectionGroupWithAllDefaultValues()
        {
            // Example: Create FirewallPolicyRuleCollectionGroup With All Default Values

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            var collection = firewallPolicy.GetFirewallPolicyRuleCollectionGroups();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, "ruleCollectionGroup1", new FirewallPolicyRuleCollectionGroupData());
        }

        [RecordedTest]
        public async Task CreateOrUpdate_CreateFirewallPolicyRuleCollectionGroupWithIpGroups()
        {
            // Example: Create FirewallPolicyRuleCollectionGroup With IpGroups

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            var collection = firewallPolicy.GetFirewallPolicyRuleCollectionGroups();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, "ruleCollectionGroup1", new FirewallPolicyRuleCollectionGroupData()
            {
                Priority = 110,
                RuleCollections =
{
new FirewallPolicyFilterRuleCollection()
{
ActionType = FirewallPolicyFilterRuleCollectionActionType.Deny,
Rules =
{
new NetworkRule()
{
IpProtocols =
{
FirewallPolicyRuleNetworkProtocol.TCP
},
DestinationPorts =
{
"*"
},
SourceIpGroups =
{
"/subscriptions/subid/providers/Microsoft.Network/resourceGroup/rg1/ipGroups/ipGroups1"
},
DestinationIpGroups =
{
"/subscriptions/subid/providers/Microsoft.Network/resourceGroup/rg1/ipGroups/ipGroups2"
},
Name = "network-1",
}
},
Name = "Example-Filter-Rule-Collection",
}
},
            });
        }

        [RecordedTest]
        public async Task CreateOrUpdate_CreateFirewallPolicyRuleCollectionGroupWithWebCategories()
        {
            // Example: Create FirewallPolicyRuleCollectionGroup With Web Categories

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            var collection = firewallPolicy.GetFirewallPolicyRuleCollectionGroups();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, "ruleCollectionGroup1", new FirewallPolicyRuleCollectionGroupData()
            {
                Priority = 110,
                RuleCollections =
{
new FirewallPolicyFilterRuleCollection()
{
ActionType = FirewallPolicyFilterRuleCollectionActionType.Deny,
Rules =
{
new ApplicationRule()
{
SourceAddresses =
{
"216.58.216.164","10.0.0.0/24"
},
Protocols =
{
new FirewallPolicyRuleApplicationProtocol()
{
ProtocolType = FirewallPolicyRuleApplicationProtocolType.Https,
Port = 443,
}
},
WebCategories =
{
"Hacking"
},
Name = "rule1",
Description = "Deny inbound rule",
}
},
Name = "Example-Filter-Rule-Collection",
}
},
            });
        }

        [RecordedTest]
        public async Task Exists_GetFirewallPolicyNatRuleCollectionGroup()
        {
            // Example: Get FirewallPolicyNatRuleCollectionGroup

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            var collection = firewallPolicy.GetFirewallPolicyRuleCollectionGroups();
            await collection.ExistsAsync("ruleCollectionGroup1");
        }

        [RecordedTest]
        public async Task Exists_GetFirewallPolicyRuleCollectionGroup()
        {
            // Example: Get FirewallPolicyRuleCollectionGroup

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            var collection = firewallPolicy.GetFirewallPolicyRuleCollectionGroups();
            await collection.ExistsAsync("ruleCollectionGroup1");
        }

        [RecordedTest]
        public async Task Exists_GetFirewallPolicyRuleCollectionGroupWithIpGroups()
        {
            // Example: Get FirewallPolicyRuleCollectionGroup With IpGroups

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            var collection = firewallPolicy.GetFirewallPolicyRuleCollectionGroups();
            await collection.ExistsAsync("ruleGroup1");
        }

        [RecordedTest]
        public async Task Exists_GetFirewallPolicyRuleCollectionGroupWithWebCategories()
        {
            // Example: Get FirewallPolicyRuleCollectionGroup With Web Categories

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            var collection = firewallPolicy.GetFirewallPolicyRuleCollectionGroups();
            await collection.ExistsAsync("ruleCollectionGroup1");
        }

        [RecordedTest]
        public async Task Get_GetFirewallPolicyNatRuleCollectionGroup()
        {
            // Example: Get FirewallPolicyNatRuleCollectionGroup

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            var collection = firewallPolicy.GetFirewallPolicyRuleCollectionGroups();
            await collection.GetAsync("ruleCollectionGroup1");
        }

        [RecordedTest]
        public async Task Get_GetFirewallPolicyRuleCollectionGroup()
        {
            // Example: Get FirewallPolicyRuleCollectionGroup

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            var collection = firewallPolicy.GetFirewallPolicyRuleCollectionGroups();
            await collection.GetAsync("ruleCollectionGroup1");
        }

        [RecordedTest]
        public async Task Get_GetFirewallPolicyRuleCollectionGroupWithIpGroups()
        {
            // Example: Get FirewallPolicyRuleCollectionGroup With IpGroups

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            var collection = firewallPolicy.GetFirewallPolicyRuleCollectionGroups();
            await collection.GetAsync("ruleGroup1");
        }

        [RecordedTest]
        public async Task Get_GetFirewallPolicyRuleCollectionGroupWithWebCategories()
        {
            // Example: Get FirewallPolicyRuleCollectionGroup With Web Categories

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            var collection = firewallPolicy.GetFirewallPolicyRuleCollectionGroups();
            await collection.GetAsync("ruleCollectionGroup1");
        }

        [RecordedTest]
        public async Task GetAll_ListAllFirewallPolicyRuleCollectionGroupWithWebCategories()
        {
            // Example: List all FirewallPolicyRuleCollectionGroup With Web Categories

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            var collection = firewallPolicy.GetFirewallPolicyRuleCollectionGroups();
            await foreach (var _ in collection.GetAllAsync())
            {
            }
        }

        [RecordedTest]
        public async Task GetAll_ListAllFirewallPolicyRuleCollectionGroupsForAGivenFirewallPolicy()
        {
            // Example: List all FirewallPolicyRuleCollectionGroups for a given FirewallPolicy

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            var collection = firewallPolicy.GetFirewallPolicyRuleCollectionGroups();
            await foreach (var _ in collection.GetAllAsync())
            {
            }
        }

        [RecordedTest]
        public async Task GetAll_ListAllFirewallPolicyRuleCollectionGroupsWithIpGroupsForAGivenFirewallPolicy()
        {
            // Example: List all FirewallPolicyRuleCollectionGroups with IpGroups for a given FirewallPolicy

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            var collection = firewallPolicy.GetFirewallPolicyRuleCollectionGroups();
            await foreach (var _ in collection.GetAllAsync())
            {
            }
        }
    }
}
