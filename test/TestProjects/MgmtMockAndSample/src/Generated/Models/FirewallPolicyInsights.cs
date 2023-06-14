// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> Firewall Policy Insights. </summary>
    public partial class FirewallPolicyInsights
    {
        /// <summary> Initializes a new instance of FirewallPolicyInsights. </summary>
        public FirewallPolicyInsights()
        {
        }

        /// <summary> Initializes a new instance of FirewallPolicyInsights. </summary>
        /// <param name="isEnabled"> A flag to indicate if the insights are enabled on the policy. </param>
        /// <param name="retentionDays"> Number of days the insights should be enabled on the policy. </param>
        /// <param name="logAnalyticsResources"> Workspaces needed to configure the Firewall Policy Insights. </param>
        internal FirewallPolicyInsights(bool? isEnabled, int? retentionDays, FirewallPolicyLogAnalyticsResources logAnalyticsResources)
        {
            IsEnabled = isEnabled;
            RetentionDays = retentionDays;
            LogAnalyticsResources = logAnalyticsResources;
        }

        /// <summary> A flag to indicate if the insights are enabled on the policy. </summary>
        public bool? IsEnabled { get; set; }
        /// <summary> Number of days the insights should be enabled on the policy. </summary>
        public int? RetentionDays { get; set; }
        /// <summary> Workspaces needed to configure the Firewall Policy Insights. </summary>
        public FirewallPolicyLogAnalyticsResources LogAnalyticsResources { get; set; }
    }
}
