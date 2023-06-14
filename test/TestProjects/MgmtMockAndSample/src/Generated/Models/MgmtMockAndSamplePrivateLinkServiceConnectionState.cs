// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> An object that represents the approval state of the private link connection. </summary>
    public partial class MgmtMockAndSamplePrivateLinkServiceConnectionState
    {
        /// <summary> Initializes a new instance of MgmtMockAndSamplePrivateLinkServiceConnectionState. </summary>
        public MgmtMockAndSamplePrivateLinkServiceConnectionState()
        {
        }

        /// <summary> Initializes a new instance of MgmtMockAndSamplePrivateLinkServiceConnectionState. </summary>
        /// <param name="status"> Indicates whether the connection has been approved, rejected or removed by the key vault owner. </param>
        /// <param name="description"> The reason for approval or rejection. </param>
        /// <param name="actionsRequired"> A message indicating if changes on the service provider require any updates on the consumer. </param>
        internal MgmtMockAndSamplePrivateLinkServiceConnectionState(MgmtMockAndSamplePrivateEndpointServiceConnectionStatus? status, string description, ActionsRequired? actionsRequired)
        {
            Status = status;
            Description = description;
            ActionsRequired = actionsRequired;
        }

        /// <summary> Indicates whether the connection has been approved, rejected or removed by the key vault owner. </summary>
        public MgmtMockAndSamplePrivateEndpointServiceConnectionStatus? Status { get; set; }
        /// <summary> The reason for approval or rejection. </summary>
        public string Description { get; set; }
        /// <summary> A message indicating if changes on the service provider require any updates on the consumer. </summary>
        public ActionsRequired? ActionsRequired { get; set; }
    }
}
