// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtMockAndSample.Models
{
    /// <summary> An object that represents the approval state of the private link connection. </summary>
    public partial class MhsmPrivateLinkServiceConnectionState
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="MhsmPrivateLinkServiceConnectionState"/>. </summary>
        public MhsmPrivateLinkServiceConnectionState()
        {
        }

        /// <summary> Initializes a new instance of <see cref="MhsmPrivateLinkServiceConnectionState"/>. </summary>
        /// <param name="status"> Indicates whether the connection has been approved, rejected or removed by the key vault owner. </param>
        /// <param name="description"> The reason for approval or rejection. </param>
        /// <param name="actionsRequired"> A message indicating if changes on the service provider require any updates on the consumer. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal MhsmPrivateLinkServiceConnectionState(MgmtMockAndSamplePrivateEndpointServiceConnectionStatus? status, string description, ActionsRequired? actionsRequired, Dictionary<string, BinaryData> rawData)
        {
            Status = status;
            Description = description;
            ActionsRequired = actionsRequired;
            _rawData = rawData;
        }

        /// <summary> Indicates whether the connection has been approved, rejected or removed by the key vault owner. </summary>
        public MgmtMockAndSamplePrivateEndpointServiceConnectionStatus? Status { get; set; }
        /// <summary> The reason for approval or rejection. </summary>
        public string Description { get; set; }
        /// <summary> A message indicating if changes on the service provider require any updates on the consumer. </summary>
        public ActionsRequired? ActionsRequired { get; set; }
    }
}
