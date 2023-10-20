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
    /// A class representing the BlobInventoryPolicy data model.
    /// The storage account blob inventory policy.
    /// </summary>
    public partial class BlobInventoryPolicyData : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="BlobInventoryPolicyData"/>. </summary>
        public BlobInventoryPolicyData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="BlobInventoryPolicyData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="lastModifiedOn"> Returns the last modified date and time of the blob inventory policy. </param>
        /// <param name="policy"> The storage account blob inventory policy object. It is composed of policy rules. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal BlobInventoryPolicyData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DateTimeOffset? lastModifiedOn, BlobInventoryPolicySchema policy, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            LastModifiedOn = lastModifiedOn;
            Policy = policy;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Returns the last modified date and time of the blob inventory policy. </summary>
        public DateTimeOffset? LastModifiedOn { get; }
        /// <summary> The storage account blob inventory policy object. It is composed of policy rules. </summary>
        public BlobInventoryPolicySchema Policy { get; set; }
    }
}
