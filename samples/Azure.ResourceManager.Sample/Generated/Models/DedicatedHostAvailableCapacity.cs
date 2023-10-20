// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
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
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="DedicatedHostAvailableCapacity"/>. </summary>
        internal DedicatedHostAvailableCapacity()
        {
            AllocatableVms = new ChangeTrackingList<DedicatedHostAllocatableVm>();
        }

        /// <summary> Initializes a new instance of <see cref="DedicatedHostAvailableCapacity"/>. </summary>
        /// <param name="allocatableVms">
        /// The unutilized capacity of the dedicated host represented in terms of each VM size that is allowed to be deployed to the dedicated host.
        /// Serialized Name: DedicatedHostAvailableCapacity.allocatableVMs
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DedicatedHostAvailableCapacity(IReadOnlyList<DedicatedHostAllocatableVm> allocatableVms, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            AllocatableVms = allocatableVms;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// The unutilized capacity of the dedicated host represented in terms of each VM size that is allowed to be deployed to the dedicated host.
        /// Serialized Name: DedicatedHostAvailableCapacity.allocatableVMs
        /// </summary>
        public IReadOnlyList<DedicatedHostAllocatableVm> AllocatableVms { get; }
    }
}
