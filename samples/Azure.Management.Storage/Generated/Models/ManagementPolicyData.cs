// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.ResourceManager.Core;

namespace Azure.Management.Storage.Models
{
    /// <summary> A class representing the ManagementPolicy data model. </summary>
    public partial class ManagementPolicyData : Resource<TenantResourceIdentifier>
    {
        /// <summary> Initializes a new instance of ManagementPolicyData. </summary>
        public ManagementPolicyData()
        {
        }

        /// <summary> Initializes a new instance of ManagementPolicyData. </summary>
        /// <param name="lastModifiedTime"> Returns the date and time the ManagementPolicies was last modified. </param>
        /// <param name="policy"> The Storage Account ManagementPolicy, in JSON format. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts. </param>
        internal ManagementPolicyData(DateTimeOffset? lastModifiedTime, ManagementPolicySchema policy)
        {
            LastModifiedTime = lastModifiedTime;
            Policy = policy;
        }

        /// <summary> ARM resource type. </summary>
        public static ResourceType ResourceType => "todo: find out resource type";

        /// <summary> Returns the date and time the ManagementPolicies was last modified. </summary>
        public DateTimeOffset? LastModifiedTime { get; }
        /// <summary> The Storage Account ManagementPolicy, in JSON format. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts. </summary>
        public ManagementPolicySchema Policy { get; set; }
    }
}
