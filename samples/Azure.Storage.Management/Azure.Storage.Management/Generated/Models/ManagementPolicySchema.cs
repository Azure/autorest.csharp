// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Storage.Management.Models
{
    /// <summary> The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts. </summary>
    public partial class ManagementPolicySchema
    {
        /// <summary> Initializes a new instance of ManagementPolicySchema. </summary>
        internal ManagementPolicySchema()
        {
        }

        /// <summary> Initializes a new instance of ManagementPolicySchema. </summary>
        /// <param name="rules"> The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts. </param>
        internal ManagementPolicySchema(IList<ManagementPolicyRule> rules)
        {
            Rules = rules;
        }

        /// <summary> The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts. </summary>
        public IList<ManagementPolicyRule> Rules { get; set; } = new List<ManagementPolicyRule>();
    }
}
