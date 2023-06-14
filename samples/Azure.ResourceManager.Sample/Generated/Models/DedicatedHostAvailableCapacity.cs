// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Dedicated host unutilized capacity.
    /// Serialized Name: DedicatedHostAvailableCapacity
    /// </summary>
    internal partial class DedicatedHostAvailableCapacity
    {
        /// <summary> Initializes a new instance of DedicatedHostAvailableCapacity. </summary>
        internal DedicatedHostAvailableCapacity()
        {
            AllocatableVMs = new ChangeTrackingList<DedicatedHostAllocatableVM>();
        }

        /// <summary> Initializes a new instance of DedicatedHostAvailableCapacity. </summary>
        /// <param name="allocatableVMs">
        /// The unutilized capacity of the dedicated host represented in terms of each VM size that is allowed to be deployed to the dedicated host.
        /// Serialized Name: DedicatedHostAvailableCapacity.allocatableVMs
        /// </param>
        internal DedicatedHostAvailableCapacity(IReadOnlyList<DedicatedHostAllocatableVM> allocatableVMs)
        {
            AllocatableVMs = allocatableVMs;
        }

        /// <summary>
        /// The unutilized capacity of the dedicated host represented in terms of each VM size that is allowed to be deployed to the dedicated host.
        /// Serialized Name: DedicatedHostAvailableCapacity.allocatableVMs
        /// </summary>
        public IReadOnlyList<DedicatedHostAllocatableVM> AllocatableVMs { get; }
    }
}
