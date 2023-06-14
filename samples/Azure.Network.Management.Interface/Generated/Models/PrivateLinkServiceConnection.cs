// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> PrivateLinkServiceConnection resource. </summary>
    public partial class PrivateLinkServiceConnection : SubResource
    {
        /// <summary> Initializes a new instance of PrivateLinkServiceConnection. </summary>
        public PrivateLinkServiceConnection()
        {
            GroupIds = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of PrivateLinkServiceConnection. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within a resource group. This name can be used to access the resource. </param>
        /// <param name="type"> The resource type. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="provisioningState"> The provisioning state of the private link service connection resource. </param>
        /// <param name="privateLinkServiceId"> The resource id of private link service. </param>
        /// <param name="groupIds"> The ID(s) of the group(s) obtained from the remote resource that this private endpoint should connect to. </param>
        /// <param name="requestMessage"> A message passed to the owner of the remote resource with this connection request. Restricted to 140 chars. </param>
        /// <param name="privateLinkServiceConnectionState"> A collection of read-only information about the state of the connection to the remote resource. </param>
        internal PrivateLinkServiceConnection(string id, string name, string type, string etag, ProvisioningState? provisioningState, string privateLinkServiceId, IList<string> groupIds, string requestMessage, PrivateLinkServiceConnectionState privateLinkServiceConnectionState) : base(id)
        {
            Name = name;
            Type = type;
            Etag = etag;
            ProvisioningState = provisioningState;
            PrivateLinkServiceId = privateLinkServiceId;
            GroupIds = groupIds;
            RequestMessage = requestMessage;
            PrivateLinkServiceConnectionState = privateLinkServiceConnectionState;
        }

        /// <summary> The name of the resource that is unique within a resource group. This name can be used to access the resource. </summary>
        public string Name { get; set; }
        /// <summary> The resource type. </summary>
        public string Type { get; }
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag { get; }
        /// <summary> The provisioning state of the private link service connection resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
        /// <summary> The resource id of private link service. </summary>
        public string PrivateLinkServiceId { get; set; }
        /// <summary> The ID(s) of the group(s) obtained from the remote resource that this private endpoint should connect to. </summary>
        public IList<string> GroupIds { get; }
        /// <summary> A message passed to the owner of the remote resource with this connection request. Restricted to 140 chars. </summary>
        public string RequestMessage { get; set; }
        /// <summary> A collection of read-only information about the state of the connection to the remote resource. </summary>
        public PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; set; }
    }
}
