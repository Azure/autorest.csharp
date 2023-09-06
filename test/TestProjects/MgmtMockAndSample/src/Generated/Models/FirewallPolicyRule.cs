// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core.Serialization;

namespace MgmtMockAndSample.Models
{
    /// <summary>
    /// Properties of a rule.
    /// Please note <see cref="FirewallPolicyRule"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="ApplicationRule"/>, <see cref="NatRule"/> and <see cref="NetworkRule"/>.
    /// </summary>
    [AbstractTypeDeserializer(typeof(UnknownFirewallPolicyRule))]
    public abstract partial class FirewallPolicyRule
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="FirewallPolicyRule"/>. </summary>
        protected FirewallPolicyRule()
        {
        }

        /// <summary> Initializes a new instance of <see cref="FirewallPolicyRule"/>. </summary>
        /// <param name="name"> Name of the rule. </param>
        /// <param name="description"> Description of the rule. </param>
        /// <param name="ruleType"> Rule Type. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal FirewallPolicyRule(string name, string description, FirewallPolicyRuleType ruleType, Dictionary<string, BinaryData> rawData)
        {
            Name = name;
            Description = description;
            RuleType = ruleType;
            _rawData = rawData;
        }

        /// <summary> Name of the rule. </summary>
        public string Name { get; set; }
        /// <summary> Description of the rule. </summary>
        public string Description { get; set; }
        /// <summary> Rule Type. </summary>
        internal FirewallPolicyRuleType RuleType { get; set; }
    }
}
