// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Storage.Management.Models
{
    /// <summary> Lease Container response schema. </summary>
    public partial class LeaseContainerResponse
    {
        /// <summary> Returned unique lease ID that must be included with any request to delete the container, or to renew, change, or release the lease. </summary>
        public string LeaseId { get; set; }
        /// <summary> Approximate time remaining in the lease period, in seconds. </summary>
        public string LeaseTimeSeconds { get; set; }
    }
}
