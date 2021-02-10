// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace compute.Models
{
    /// <summary> Dedicated host unutilized capacity. </summary>
    public partial class DedicatedHostAvailableCapacity
    {
        /// <summary> Initializes a new instance of DedicatedHostAvailableCapacity. </summary>
        internal DedicatedHostAvailableCapacity()
        {
            AllocatableVMs = new ChangeTrackingList<DedicatedHostAllocatableVM>();
        }

        /// <summary> Initializes a new instance of DedicatedHostAvailableCapacity. </summary>
        /// <param name="allocatableVMs"> The unutilized capacity of the dedicated host represented in terms of each VM size that is allowed to be deployed to the dedicated host. </param>
        internal DedicatedHostAvailableCapacity(IReadOnlyList<DedicatedHostAllocatableVM> allocatableVMs)
        {
            AllocatableVMs = allocatableVMs;
        }

        /// <summary> The unutilized capacity of the dedicated host represented in terms of each VM size that is allowed to be deployed to the dedicated host. </summary>
        public IReadOnlyList<DedicatedHostAllocatableVM> AllocatableVMs { get; }
    }
}
