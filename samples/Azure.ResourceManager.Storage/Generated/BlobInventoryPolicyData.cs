// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    /// <summary>
    /// A class representing the BlobInventoryPolicy data model.
    /// The storage account blob inventory policy.
    /// </summary>
    public partial class BlobInventoryPolicyData : ResourceData
    {
        /// <summary> Initializes a new instance of BlobInventoryPolicyData. </summary>
        public BlobInventoryPolicyData()
        {
        }

        /// <summary> Initializes a new instance of BlobInventoryPolicyData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="lastModifiedOn"> Returns the last modified date and time of the blob inventory policy. </param>
        /// <param name="policy"> The storage account blob inventory policy object. It is composed of policy rules. </param>
        internal BlobInventoryPolicyData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DateTimeOffset? lastModifiedOn, BlobInventoryPolicySchema policy) : base(id, name, resourceType, systemData)
        {
            LastModifiedOn = lastModifiedOn;
            Policy = policy;
        }

        /// <summary> Returns the last modified date and time of the blob inventory policy. </summary>
        public DateTimeOffset? LastModifiedOn { get; }
        /// <summary> The storage account blob inventory policy object. It is composed of policy rules. </summary>
        public BlobInventoryPolicySchema Policy { get; set; }
    }
}
