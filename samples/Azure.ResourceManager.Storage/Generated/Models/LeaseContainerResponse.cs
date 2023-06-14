// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Lease Container response schema. </summary>
    public partial class LeaseContainerResponse
    {
        /// <summary> Initializes a new instance of LeaseContainerResponse. </summary>
        internal LeaseContainerResponse()
        {
        }

        /// <summary> Initializes a new instance of LeaseContainerResponse. </summary>
        /// <param name="leaseId"> Returned unique lease ID that must be included with any request to delete the container, or to renew, change, or release the lease. </param>
        /// <param name="leaseTimeSeconds"> Approximate time remaining in the lease period, in seconds. </param>
        internal LeaseContainerResponse(string leaseId, string leaseTimeSeconds)
        {
            LeaseId = leaseId;
            LeaseTimeSeconds = leaseTimeSeconds;
        }

        /// <summary> Returned unique lease ID that must be included with any request to delete the container, or to renew, change, or release the lease. </summary>
        public string LeaseId { get; }
        /// <summary> Approximate time remaining in the lease period, in seconds. </summary>
        public string LeaseTimeSeconds { get; }
    }
}
