// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Net;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using MgmtMockAndSample;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample.Tests.Mock
{
    /// <summary> Test for FirewallPolicyResource. </summary>
    public partial class FirewallPolicyResourceMockTests : MockTestBase
    {
        public FirewallPolicyResourceMockTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", $"https://localhost:8443");
        }

        [RecordedTest]
        public async Task Delete()
        {
            // Example: Delete Firewall Policy

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            await firewallPolicy.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task Get()
        {
            // Example: Get FirewallPolicy

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            await firewallPolicy.GetAsync();
        }

        [RecordedTest]
        public async Task GetFirewallPolicies()
        {
            // Example: List all Firewall Policies for a given subscription

            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000");
            SubscriptionResource subscriptionResource = GetArmClient().GetSubscriptionResource(subscriptionResourceId);
            await foreach (var _ in subscriptionResource.GetFirewallPoliciesAsync())
            {
            }
        }

        [RecordedTest]
        public async Task Update_CreateFirewallPolicy()
        {
            // Example: Create FirewallPolicy

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            await firewallPolicy.UpdateAsync(WaitUntil.Completed, new FirewallPolicyData(new AzureLocation("West US"))
            {
                StartupProbe = null,
                ReadinessProbe = new Probe(false)
                {
                    InitialDelaySeconds = 30,
                    PeriodSeconds = 10,
                    FailureThreshold = 3,
                },
                DesiredStatusCode = DesiredStatusCode.TwoHundredTwo,
                ThreatIntelWhitelist = new FirewallPolicyThreatIntelWhitelist()
                {
                    IpAddresses =
{
IPAddress.Parse("20.3.4.5")
},
                    Fqdns =
{
"*.microsoft.com"
},
                },
                Insights = new FirewallPolicyInsights()
                {
                    IsEnabled = true,
                    RetentionDays = 100,
                    LogAnalyticsResources = new FirewallPolicyLogAnalyticsResources()
                    {
                        Workspaces =
{
new FirewallPolicyLogAnalyticsWorkspace()
{
Region = "westus",
WorkspaceIdId = new ResourceIdentifier("/subscriptions/subid/resourcegroups/rg1/providers/microsoft.operationalinsights/workspaces/workspace1"),
},new FirewallPolicyLogAnalyticsWorkspace()
{
Region = "eastus",
WorkspaceIdId = new ResourceIdentifier("/subscriptions/subid/resourcegroups/rg1/providers/microsoft.operationalinsights/workspaces/workspace2"),
}
},
                        DefaultWorkspaceIdId = new ResourceIdentifier("/subscriptions/subid/resourcegroups/rg1/providers/microsoft.operationalinsights/workspaces/defaultWorkspace"),
                    },
                },
                SnatPrivateRanges =
{
"IANAPrivateRanges"
},
                DnsSettings = new DnsSettings()
                {
                    Servers =
{
"30.3.4.5"
},
                    EnableProxy = true,
                    RequireProxyForNetworkRules = false,
                },
                IntrusionDetection = new FirewallPolicyIntrusionDetection()
                {
                    Mode = FirewallPolicyIntrusionDetectionStateType.Alert,
                    Configuration = new FirewallPolicyIntrusionDetectionConfiguration()
                    {
                        SignatureOverrides =
{
new FirewallPolicyIntrusionDetectionSignatureSpecification()
{
Id = "2525004",
Mode = FirewallPolicyIntrusionDetectionStateType.Deny,
}
},
                        BypassTrafficSettings =
{
new FirewallPolicyIntrusionDetectionBypassTrafficSpecifications()
{
Name = "bypassRule1",
Description = "Rule 1",
Protocol = FirewallPolicyIntrusionDetectionProtocol.TCP,
SourceAddresses =
{
"1.2.3.4"
},
DestinationAddresses =
{
"5.6.7.8"
},
DestinationPorts =
{
"*"
},
}
},
                    },
                },
                TransportSecurityCertificateAuthority = new FirewallPolicyCertificateAuthority()
                {
                    KeyVaultSecretId = "https://kv/secret",
                    Name = "clientcert",
                },
                SkuTier = FirewallPolicySkuTier.Premium,
                Tags =
{
["key1"] = "value1",
},
            });
        }

        [RecordedTest]
        public async Task Update_CreateFirewallPolicyWithDifferentValues()
        {
            // Example: Create FirewallPolicy with different values

            ResourceIdentifier firewallPolicyResourceId = FirewallPolicyResource.CreateResourceIdentifier("00000000-0000-0000-0000-000000000000", "rg1", "firewallPolicy");
            FirewallPolicyResource firewallPolicy = GetArmClient().GetFirewallPolicyResource(firewallPolicyResourceId);
            await firewallPolicy.UpdateAsync(WaitUntil.Completed, new FirewallPolicyData(new AzureLocation("West US"))
            {
                StartupProbe = null,
                ReadinessProbe = new Probe(false)
                {
                    InitialDelaySeconds = 30,
                    PeriodSeconds = 10,
                    FailureThreshold = 3,
                },
                DesiredStatusCode = new DesiredStatusCode(600),
                ThreatIntelWhitelist = new FirewallPolicyThreatIntelWhitelist()
                {
                    IpAddresses =
{
IPAddress.Parse("20.3.4.5")
},
                    Fqdns =
{
"*.microsoft.com"
},
                },
                Insights = new FirewallPolicyInsights()
                {
                    IsEnabled = true,
                    RetentionDays = 100,
                    LogAnalyticsResources = new FirewallPolicyLogAnalyticsResources()
                    {
                        Workspaces =
{
new FirewallPolicyLogAnalyticsWorkspace()
{
Region = "westus",
WorkspaceIdId = new ResourceIdentifier("/subscriptions/subid/resourcegroups/rg1/providers/microsoft.operationalinsights/workspaces/workspace1"),
},new FirewallPolicyLogAnalyticsWorkspace()
{
Region = "eastus",
WorkspaceIdId = new ResourceIdentifier("/subscriptions/subid/resourcegroups/rg1/providers/microsoft.operationalinsights/workspaces/workspace2"),
}
},
                        DefaultWorkspaceIdId = new ResourceIdentifier("/subscriptions/subid/resourcegroups/rg1/providers/microsoft.operationalinsights/workspaces/defaultWorkspace"),
                    },
                },
                SnatPrivateRanges =
{
"IANAPrivateRanges"
},
                DnsSettings = new DnsSettings()
                {
                    Servers =
{
"30.3.4.5"
},
                    EnableProxy = true,
                    RequireProxyForNetworkRules = false,
                },
                IntrusionDetection = new FirewallPolicyIntrusionDetection()
                {
                    Mode = FirewallPolicyIntrusionDetectionStateType.Alert,
                    Configuration = new FirewallPolicyIntrusionDetectionConfiguration()
                    {
                        SignatureOverrides =
{
new FirewallPolicyIntrusionDetectionSignatureSpecification()
{
Id = "2525004",
Mode = FirewallPolicyIntrusionDetectionStateType.Deny,
}
},
                        BypassTrafficSettings =
{
new FirewallPolicyIntrusionDetectionBypassTrafficSpecifications()
{
Name = "bypassRule1",
Description = "Rule 1",
Protocol = FirewallPolicyIntrusionDetectionProtocol.TCP,
SourceAddresses =
{
"1.2.3.4"
},
DestinationAddresses =
{
"5.6.7.8"
},
DestinationPorts =
{
"*"
},
}
},
                    },
                },
                TransportSecurityCertificateAuthority = new FirewallPolicyCertificateAuthority()
                {
                    KeyVaultSecretId = "https://kv/secret",
                    Name = "clientcert",
                },
                SkuTier = FirewallPolicySkuTier.Premium,
                Tags =
{
["key1"] = "value1",
},
            });
        }
    }
}
