// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> SKU of Firewall policy. </summary>
    internal partial class FirewallPolicySku
    {
        /// <summary> Initializes a new instance of FirewallPolicySku. </summary>
        public FirewallPolicySku()
        {
        }

        /// <summary> Initializes a new instance of FirewallPolicySku. </summary>
        /// <param name="tier"> Tier of Firewall Policy. </param>
        internal FirewallPolicySku(FirewallPolicySkuTier? tier)
        {
            Tier = tier;
        }

        /// <summary> Tier of Firewall Policy. </summary>
        public FirewallPolicySkuTier? Tier { get; set; }
    }
}
