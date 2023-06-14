// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Specifies information about the availability set that the virtual machine should be assigned to. Only tags may be updated.
    /// Serialized Name: AvailabilitySetUpdate
    /// </summary>
    public partial class AvailabilitySetPatch : UpdateResource
    {
        /// <summary> Initializes a new instance of AvailabilitySetPatch. </summary>
        public AvailabilitySetPatch()
        {
            VirtualMachines = new ChangeTrackingList<WritableSubResource>();
            Statuses = new ChangeTrackingList<InstanceViewStatus>();
        }

        /// <summary>
        /// Sku of the availability set
        /// Serialized Name: AvailabilitySetUpdate.sku
        /// </summary>
        public SampleSku Sku { get; set; }
        /// <summary>
        /// Update Domain count.
        /// Serialized Name: AvailabilitySetUpdate.properties.platformUpdateDomainCount
        /// </summary>
        public int? PlatformUpdateDomainCount { get; set; }
        /// <summary>
        /// Fault Domain count.
        /// Serialized Name: AvailabilitySetUpdate.properties.platformFaultDomainCount
        /// </summary>
        public int? PlatformFaultDomainCount { get; set; }
        /// <summary>
        /// A list of references to all virtual machines in the availability set.
        /// Serialized Name: AvailabilitySetUpdate.properties.virtualMachines
        /// </summary>
        public IList<WritableSubResource> VirtualMachines { get; }
        /// <summary>
        /// Specifies information about the proximity placement group that the availability set should be assigned to. &lt;br&gt;&lt;br&gt;Minimum api-version: 2018-04-01.
        /// Serialized Name: AvailabilitySetUpdate.properties.proximityPlacementGroup
        /// </summary>
        internal WritableSubResource ProximityPlacementGroup { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier ProximityPlacementGroupId
        {
            get => ProximityPlacementGroup is null ? default : ProximityPlacementGroup.Id;
            set
            {
                if (ProximityPlacementGroup is null)
                    ProximityPlacementGroup = new WritableSubResource();
                ProximityPlacementGroup.Id = value;
            }
        }

        /// <summary>
        /// The resource status information.
        /// Serialized Name: AvailabilitySetUpdate.properties.statuses
        /// </summary>
        public IReadOnlyList<InstanceViewStatus> Statuses { get; }
    }
}
