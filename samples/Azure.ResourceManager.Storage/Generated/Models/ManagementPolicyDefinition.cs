// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> An object that defines the Lifecycle rule. Each definition is made up with a filters set and an actions set. </summary>
    public partial class ManagementPolicyDefinition
    {
        /// <summary> Initializes a new instance of ManagementPolicyDefinition. </summary>
        /// <param name="actions"> An object that defines the action set. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="actions"/> is null. </exception>
        public ManagementPolicyDefinition(ManagementPolicyAction actions)
        {
            Argument.AssertNotNull(actions, nameof(actions));

            Actions = actions;
        }

        /// <summary> Initializes a new instance of ManagementPolicyDefinition. </summary>
        /// <param name="actions"> An object that defines the action set. </param>
        /// <param name="filters"> An object that defines the filter set. </param>
        internal ManagementPolicyDefinition(ManagementPolicyAction actions, ManagementPolicyFilter filters)
        {
            Actions = actions;
            Filters = filters;
        }

        /// <summary> An object that defines the action set. </summary>
        public ManagementPolicyAction Actions { get; set; }
        /// <summary> An object that defines the filter set. </summary>
        public ManagementPolicyFilter Filters { get; set; }
    }
}
