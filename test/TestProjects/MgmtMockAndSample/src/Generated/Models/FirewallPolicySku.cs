// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtMockAndSample.Models
{
    /// <summary> SKU of Firewall policy. </summary>
    internal partial class FirewallPolicySku
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="FirewallPolicySku"/>. </summary>
        public FirewallPolicySku()
        {
        }

        /// <summary> Initializes a new instance of <see cref="FirewallPolicySku"/>. </summary>
        /// <param name="tier"> Tier of Firewall Policy. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal FirewallPolicySku(FirewallPolicySkuTier? tier, Dictionary<string, BinaryData> rawData)
        {
            Tier = tier;
            _rawData = rawData;
        }

        /// <summary> Tier of Firewall Policy. </summary>
        public FirewallPolicySkuTier? Tier { get; set; }
    }
}
