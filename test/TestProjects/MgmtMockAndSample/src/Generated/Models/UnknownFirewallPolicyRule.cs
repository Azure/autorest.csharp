// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> The UnknownFirewallPolicyRule. </summary>
    internal partial class UnknownFirewallPolicyRule : FirewallPolicyRule
    {
        /// <summary> Initializes a new instance of <see cref="UnknownFirewallPolicyRule"/>. </summary>
        /// <param name="name"> Name of the rule. </param>
        /// <param name="description"> Description of the rule. </param>
        /// <param name="ruleType"> Rule Type. </param>
        internal UnknownFirewallPolicyRule(string name, string description, FirewallPolicyRuleType ruleType) : base(name, description, ruleType)
        {
            RuleType = ruleType;
        }
    }
}
