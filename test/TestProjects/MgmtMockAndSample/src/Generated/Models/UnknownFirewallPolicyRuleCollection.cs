// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtMockAndSample.Models
{
    /// <summary> The UnknownFirewallPolicyRuleCollection. </summary>
    internal partial class UnknownFirewallPolicyRuleCollection : FirewallPolicyRuleCollection
    {
        /// <summary>
        /// Initializes a new instance of global::MgmtMockAndSample.Models.UnknownFirewallPolicyRuleCollection
        ///
        /// </summary>
        /// <param name="ruleCollectionType"> The type of the rule collection. </param>
        /// <param name="name"> The name of the rule collection. </param>
        /// <param name="priority"> Priority of the Firewall Policy Rule Collection resource. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownFirewallPolicyRuleCollection(FirewallPolicyRuleCollectionType ruleCollectionType, string name, int? priority, Dictionary<string, BinaryData> rawData) : base(ruleCollectionType, name, priority, rawData)
        {
            RuleCollectionType = ruleCollectionType;
        }

        /// <summary> Initializes a new instance of <see cref="UnknownFirewallPolicyRuleCollection"/> for deserialization. </summary>
        internal UnknownFirewallPolicyRuleCollection()
        {
        }
    }
}
