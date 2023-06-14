// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtMockAndSample;

namespace MgmtMockAndSample.Models
{
    /// <summary> Response for ListFirewallPolicyRuleCollectionGroups API service call. </summary>
    internal partial class FirewallPolicyRuleCollectionGroupListResult
    {
        /// <summary> Initializes a new instance of FirewallPolicyRuleCollectionGroupListResult. </summary>
        internal FirewallPolicyRuleCollectionGroupListResult()
        {
            Value = new ChangeTrackingList<FirewallPolicyRuleCollectionGroupData>();
        }

        /// <summary> Initializes a new instance of FirewallPolicyRuleCollectionGroupListResult. </summary>
        /// <param name="value"> List of FirewallPolicyRuleCollectionGroups in a FirewallPolicy. </param>
        /// <param name="nextLink"> URL to get the next set of results. </param>
        internal FirewallPolicyRuleCollectionGroupListResult(IReadOnlyList<FirewallPolicyRuleCollectionGroupData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> List of FirewallPolicyRuleCollectionGroups in a FirewallPolicy. </summary>
        public IReadOnlyList<FirewallPolicyRuleCollectionGroupData> Value { get; }
        /// <summary> URL to get the next set of results. </summary>
        public string NextLink { get; }
    }
}
