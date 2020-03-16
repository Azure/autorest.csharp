// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Storage.Management.Models
{
    /// <summary> An object that wraps the Lifecycle rule. Each rule is uniquely defined by name. </summary>
    public partial class ManagementPolicyRule
    {
        /// <summary> Initializes a new instance of ManagementPolicyRule. </summary>
        internal ManagementPolicyRule()
        {
        }

        /// <summary> Initializes a new instance of ManagementPolicyRule. </summary>
        /// <param name="enabled"> Rule is enabled if set to true. </param>
        /// <param name="name"> A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy. </param>
        /// <param name="type"> The valid value is Lifecycle. </param>
        /// <param name="definition"> An object that defines the Lifecycle rule. </param>
        internal ManagementPolicyRule(bool? enabled, string name, string type, ManagementPolicyDefinition definition)
        {
            Enabled = enabled;
            Name = name;
            Type = type;
            Definition = definition;
        }

        /// <summary> Rule is enabled if set to true. </summary>
        public bool? Enabled { get; set; }
        /// <summary> A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy. </summary>
        public string Name { get; set; }
        /// <summary> The valid value is Lifecycle. </summary>
        public string Type { get; set; } = "Lifecycle";
        /// <summary> An object that defines the Lifecycle rule. </summary>
        public ManagementPolicyDefinition Definition { get; set; } = new ManagementPolicyDefinition();
    }
}
