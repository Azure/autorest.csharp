// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using MgmtMockAndSample;

namespace MgmtMockAndSample.Models
{
    /// <summary> Response for ListFirewallPolicyRuleCollectionGroups API service call. </summary>
    internal partial class FirewallPolicyRuleCollectionGroupListResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="FirewallPolicyRuleCollectionGroupListResult"/>. </summary>
        internal FirewallPolicyRuleCollectionGroupListResult()
        {
            Value = new ChangeTrackingList<FirewallPolicyRuleCollectionGroupData>();
        }

        /// <summary> Initializes a new instance of <see cref="FirewallPolicyRuleCollectionGroupListResult"/>. </summary>
        /// <param name="value"> List of FirewallPolicyRuleCollectionGroups in a FirewallPolicy. </param>
        /// <param name="nextLink"> URL to get the next set of results. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal FirewallPolicyRuleCollectionGroupListResult(IReadOnlyList<FirewallPolicyRuleCollectionGroupData> value, string nextLink, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            NextLink = nextLink;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> List of FirewallPolicyRuleCollectionGroups in a FirewallPolicy. </summary>
        public IReadOnlyList<FirewallPolicyRuleCollectionGroupData> Value { get; }
        /// <summary> URL to get the next set of results. </summary>
        public string NextLink { get; }
    }
}
