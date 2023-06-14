// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> An object that wraps the Lifecycle rule. Each rule is uniquely defined by name. </summary>
    public partial class ManagementPolicyRule
    {
        /// <summary> Initializes a new instance of ManagementPolicyRule. </summary>
        /// <param name="name"> A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy. </param>
        /// <param name="ruleType"> The valid value is Lifecycle. </param>
        /// <param name="definition"> An object that defines the Lifecycle rule. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="definition"/> is null. </exception>
        public ManagementPolicyRule(string name, RuleType ruleType, ManagementPolicyDefinition definition)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(definition, nameof(definition));

            Name = name;
            RuleType = ruleType;
            Definition = definition;
        }

        /// <summary> Initializes a new instance of ManagementPolicyRule. </summary>
        /// <param name="enabled"> Rule is enabled if set to true. </param>
        /// <param name="name"> A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy. </param>
        /// <param name="ruleType"> The valid value is Lifecycle. </param>
        /// <param name="definition"> An object that defines the Lifecycle rule. </param>
        internal ManagementPolicyRule(bool? enabled, string name, RuleType ruleType, ManagementPolicyDefinition definition)
        {
            Enabled = enabled;
            Name = name;
            RuleType = ruleType;
            Definition = definition;
        }

        /// <summary> Rule is enabled if set to true. </summary>
        public bool? Enabled { get; set; }
        /// <summary> A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy. </summary>
        public string Name { get; set; }
        /// <summary> The valid value is Lifecycle. </summary>
        public RuleType RuleType { get; set; }
        /// <summary> An object that defines the Lifecycle rule. </summary>
        public ManagementPolicyDefinition Definition { get; set; }
    }
}
