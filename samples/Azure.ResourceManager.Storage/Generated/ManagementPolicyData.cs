// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.ManagementPolicyData
        ///
        /// </summary>
        public ManagementPolicyData()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.ManagementPolicyData
        ///
        /// </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="lastModifiedOn"> Returns the date and time the ManagementPolicies was last modified. </param>
        /// <param name="policy"> The Storage Account ManagementPolicy, in JSON format. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ManagementPolicyData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DateTimeOffset? lastModifiedOn, ManagementPolicySchema policy, Dictionary<string, BinaryData> rawData) : base(id, name, resourceType, systemData)
        {
            LastModifiedOn = lastModifiedOn;
            Policy = policy;
            _rawData = rawData;
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
