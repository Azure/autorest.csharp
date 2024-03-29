// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace MgmtMockAndSample.Models
{
    /// <summary>
    /// Properties of a rule.
    /// Please note <see cref="FirewallPolicyRule"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="ApplicationRule"/>, <see cref="NatRule"/> and <see cref="NetworkRule"/>.
    /// </summary>
    public abstract partial class FirewallPolicyRule
    {
        /// <summary> Initializes a new instance of <see cref="FirewallPolicyRule"/>. </summary>
        protected FirewallPolicyRule()
        {
            NewArraySerializedProperty = new ChangeTrackingList<string>();
            NewDictionarySerializedProperty = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="FirewallPolicyRule"/>. </summary>
        /// <param name="name"> Name of the rule. </param>
        /// <param name="description"> Description of the rule. </param>
        /// <param name="ruleType"> Rule Type. </param>
        /// <param name="newStringSerializeProperty"></param>
        /// <param name="newArraySerializedProperty"></param>
        /// <param name="newDictionarySerializedProperty"></param>
        internal FirewallPolicyRule(string name, string description, FirewallPolicyRuleType ruleType, string newStringSerializeProperty, IList<string> newArraySerializedProperty, IDictionary<string, string> newDictionarySerializedProperty)
        {
            Name = name;
            Description = description;
            RuleType = ruleType;
            NewStringSerializeProperty = newStringSerializeProperty;
            NewArraySerializedProperty = newArraySerializedProperty;
            NewDictionarySerializedProperty = newDictionarySerializedProperty;
        }

        /// <summary> Name of the rule. </summary>
        public string Name { get; set; }
        /// <summary> Description of the rule. </summary>
        public string Description { get; set; }
        /// <summary> Rule Type. </summary>
        internal FirewallPolicyRuleType RuleType { get; set; }
    }
}
