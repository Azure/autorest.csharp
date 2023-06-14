// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    /// <summary>
    /// A class representing the ManagementPolicy data model.
    /// The Get Storage Account ManagementPolicies operation response.
    /// </summary>
    public partial class ManagementPolicyData : ResourceData
    {
        /// <summary> Initializes a new instance of ManagementPolicyData. </summary>
        public ManagementPolicyData()
        {
        }

        /// <summary> Initializes a new instance of ManagementPolicyData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="lastModifiedOn"> Returns the date and time the ManagementPolicies was last modified. </param>
        /// <param name="policy"> The Storage Account ManagementPolicy, in JSON format. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts. </param>
        internal ManagementPolicyData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DateTimeOffset? lastModifiedOn, ManagementPolicySchema policy) : base(id, name, resourceType, systemData)
        {
            LastModifiedOn = lastModifiedOn;
            Policy = policy;
        }

        /// <summary> Returns the date and time the ManagementPolicies was last modified. </summary>
        public DateTimeOffset? LastModifiedOn { get; }
        /// <summary> The Storage Account ManagementPolicy, in JSON format. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts. </summary>
        internal ManagementPolicySchema Policy { get; set; }
        /// <summary> The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts. </summary>
        public IList<ManagementPolicyRule> Rules
        {
            get => Policy is null ? default : Policy.Rules;
            set => Policy = new ManagementPolicySchema(value);
        }
    }
}
