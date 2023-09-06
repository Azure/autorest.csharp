// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> An object that defines the Lifecycle rule. Each definition is made up with a filters set and an actions set. </summary>
    public partial class ManagementPolicyDefinition
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="ManagementPolicyDefinition"/>. </summary>
        /// <param name="actions"> An object that defines the action set. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="actions"/> is null. </exception>
        public ManagementPolicyDefinition(ManagementPolicyAction actions)
        {
            Argument.AssertNotNull(actions, nameof(actions));

            Actions = actions;
        }

        /// <summary> Initializes a new instance of <see cref="ManagementPolicyDefinition"/>. </summary>
        /// <param name="actions"> An object that defines the action set. </param>
        /// <param name="filters"> An object that defines the filter set. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ManagementPolicyDefinition(ManagementPolicyAction actions, ManagementPolicyFilter filters, Dictionary<string, BinaryData> rawData)
        {
            Actions = actions;
            Filters = filters;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="ManagementPolicyDefinition"/> for deserialization. </summary>
        internal ManagementPolicyDefinition()
        {
        }

        /// <summary> An object that defines the action set. </summary>
        public ManagementPolicyAction Actions { get; set; }
        /// <summary> An object that defines the filter set. </summary>
        public ManagementPolicyFilter Filters { get; set; }
    }
}
