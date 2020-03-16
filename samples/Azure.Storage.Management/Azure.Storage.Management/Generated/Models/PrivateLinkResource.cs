// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Storage.Management.Models
{
    /// <summary> A private link resource. </summary>
    public partial class PrivateLinkResource : Resource
    {
        /// <summary> Initializes a new instance of PrivateLinkResource. </summary>
        internal PrivateLinkResource()
        {
        }

        /// <summary> Initializes a new instance of PrivateLinkResource. </summary>
        /// <param name="groupId"> The private link resource group id. </param>
        /// <param name="requiredMembers"> The private link resource required member names. </param>
        /// <param name="requiredZoneNames"> The private link resource Private link DNS zone name. </param>
        /// <param name="id"> Fully qualified resource Id for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="type"> The type of the resource. Ex- Microsoft.Compute/virtualMachines or Microsoft.Storage/storageAccounts. </param>
        internal PrivateLinkResource(string groupId, IList<string> requiredMembers, IList<string> requiredZoneNames, string id, string name, string type) : base(id, name, type)
        {
            GroupId = groupId;
            RequiredMembers = requiredMembers;
            RequiredZoneNames = requiredZoneNames;
        }

        /// <summary> The private link resource group id. </summary>
        public string GroupId { get; internal set; }
        /// <summary> The private link resource required member names. </summary>
        public IList<string> RequiredMembers { get; internal set; }
        /// <summary> The private link resource Private link DNS zone name. </summary>
        public IList<string> RequiredZoneNames { get; set; }
    }
}
