// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using ReferenceTypes.Models;

namespace Azure.ResourceManager.Fake.Models
{
    /// <summary> A collection of information about the state of the connection between service consumer and provider. </summary>
    [TypeReferenceType]
    public partial class ReferenceTypesPrivateLinkServiceConnectionState
    {
        /// <summary> Initializes a new instance of ReferenceTypesPrivateLinkServiceConnectionState. </summary>
        [InitializationConstructor]
        public ReferenceTypesPrivateLinkServiceConnectionState()
        {
        }

        /// <summary> Initializes a new instance of ReferenceTypesPrivateLinkServiceConnectionState. </summary>
        /// <param name="status"> Indicates whether the connection has been Approved/Rejected/Removed by the owner of the service. </param>
        /// <param name="description"> The reason for approval/rejection of the connection. </param>
        /// <param name="actionsRequired"> A message indicating if changes on the service provider require any updates on the consumer. </param>
        [SerializationConstructor]
        protected ReferenceTypesPrivateLinkServiceConnectionState(ReferenceTypesPrivateEndpointServiceConnectionStatus? status, string description, string actionsRequired)
        {
            Status = status;
            Description = description;
            ActionsRequired = actionsRequired;
        }

        /// <summary> Indicates whether the connection has been Approved/Rejected/Removed by the owner of the service. </summary>
        public ReferenceTypesPrivateEndpointServiceConnectionStatus? Status { get; set; }
        /// <summary> The reason for approval/rejection of the connection. </summary>
        public string Description { get; set; }
        /// <summary> A message indicating if changes on the service provider require any updates on the consumer. </summary>
        public string ActionsRequired { get; set; }
    }
}
