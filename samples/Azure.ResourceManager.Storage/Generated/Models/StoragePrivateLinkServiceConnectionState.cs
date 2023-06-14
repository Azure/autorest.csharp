// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> A collection of information about the state of the connection between service consumer and provider. </summary>
    public partial class StoragePrivateLinkServiceConnectionState
    {
        /// <summary> Initializes a new instance of StoragePrivateLinkServiceConnectionState. </summary>
        public StoragePrivateLinkServiceConnectionState()
        {
        }

        /// <summary> Initializes a new instance of StoragePrivateLinkServiceConnectionState. </summary>
        /// <param name="status"> Indicates whether the connection has been Approved/Rejected/Removed by the owner of the service. </param>
        /// <param name="description"> The reason for approval/rejection of the connection. </param>
        /// <param name="actionRequired"> A message indicating if changes on the service provider require any updates on the consumer. </param>
        internal StoragePrivateLinkServiceConnectionState(StoragePrivateEndpointServiceConnectionStatus? status, string description, string actionRequired)
        {
            Status = status;
            Description = description;
            ActionRequired = actionRequired;
        }

        /// <summary> Indicates whether the connection has been Approved/Rejected/Removed by the owner of the service. </summary>
        public StoragePrivateEndpointServiceConnectionStatus? Status { get; set; }
        /// <summary> The reason for approval/rejection of the connection. </summary>
        public string Description { get; set; }
        /// <summary> A message indicating if changes on the service provider require any updates on the consumer. </summary>
        public string ActionRequired { get; set; }
    }
}
