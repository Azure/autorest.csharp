// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> An object that wraps the Lifecycle rule. Each rule is uniquely defined by name. </summary>
    public partial class ManagementPolicyRule
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.ManagementPolicyRule
        ///
        /// </summary>
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

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.ManagementPolicyRule
        ///
        /// </summary>
        /// <param name="enabled"> Rule is enabled if set to true. </param>
        /// <param name="name"> A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy. </param>
        /// <param name="ruleType"> The valid value is Lifecycle. </param>
        /// <param name="definition"> An object that defines the Lifecycle rule. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ManagementPolicyRule(bool? enabled, string name, RuleType ruleType, ManagementPolicyDefinition definition, Dictionary<string, BinaryData> rawData)
        {
            Enabled = enabled;
            Name = name;
            RuleType = ruleType;
            Definition = definition;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="ManagementPolicyRule"/> for deserialization. </summary>
        internal ManagementPolicyRule()
        {
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
