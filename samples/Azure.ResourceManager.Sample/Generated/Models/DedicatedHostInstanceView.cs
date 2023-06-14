// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The instance view of a dedicated host.
    /// Serialized Name: DedicatedHostInstanceView
    /// </summary>
    public partial class DedicatedHostInstanceView
    {
        /// <summary> Initializes a new instance of DedicatedHostInstanceView. </summary>
        internal DedicatedHostInstanceView()
        {
            Statuses = new ChangeTrackingList<InstanceViewStatus>();
        }

        /// <summary> Initializes a new instance of DedicatedHostInstanceView. </summary>
        /// <param name="assetId">
        /// Specifies the unique id of the dedicated physical machine on which the dedicated host resides.
        /// Serialized Name: DedicatedHostInstanceView.assetId
        /// </param>
        /// <param name="availableCapacity">
        /// Unutilized capacity of the dedicated host.
        /// Serialized Name: DedicatedHostInstanceView.availableCapacity
        /// </param>
        /// <param name="statuses">
        /// The resource status information.
        /// Serialized Name: DedicatedHostInstanceView.statuses
        /// </param>
        internal DedicatedHostInstanceView(string assetId, DedicatedHostAvailableCapacity availableCapacity, IReadOnlyList<InstanceViewStatus> statuses)
        {
            AssetId = assetId;
            AvailableCapacity = availableCapacity;
            Statuses = statuses;
        }

        /// <summary>
        /// Specifies the unique id of the dedicated physical machine on which the dedicated host resides.
        /// Serialized Name: DedicatedHostInstanceView.assetId
        /// </summary>
        public string AssetId { get; }
        /// <summary>
        /// Unutilized capacity of the dedicated host.
        /// Serialized Name: DedicatedHostInstanceView.availableCapacity
        /// </summary>
        internal DedicatedHostAvailableCapacity AvailableCapacity { get; }
        /// <summary>
        /// The unutilized capacity of the dedicated host represented in terms of each VM size that is allowed to be deployed to the dedicated host.
        /// Serialized Name: DedicatedHostAvailableCapacity.allocatableVMs
        /// </summary>
        public IReadOnlyList<DedicatedHostAllocatableVM> AvailableCapacityAllocatableVMs
        {
            get => AvailableCapacity?.AllocatableVMs;
        }

        /// <summary>
        /// The resource status information.
        /// Serialized Name: DedicatedHostInstanceView.statuses
        /// </summary>
        public IReadOnlyList<InstanceViewStatus> Statuses { get; }
    }
}
