// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary>
    /// A class representing the AvailabilitySet data model.
    /// Specifies information about the availability set that the virtual machine should be assigned to. Virtual machines specified in the same availability set are allocated to different nodes to maximize availability. For more information about availability sets, see [Manage the availability of virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-manage-availability?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json). &lt;br&gt;&lt;br&gt; For more information on Azure planned maintenance, see [Planned maintenance for virtual machines in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-planned-maintenance?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) &lt;br&gt;&lt;br&gt; Currently, a VM can only be added to availability set at creation time. An existing VM cannot be added to an availability set.
    /// Serialized Name: AvailabilitySet
    /// </summary>
    public partial class AvailabilitySetData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of AvailabilitySetData. </summary>
        /// <param name="location"> The location. </param>
        public AvailabilitySetData(AzureLocation location) : base(location)
        {
            VirtualMachines = new ChangeTrackingList<WritableSubResource>();
            Statuses = new ChangeTrackingList<InstanceViewStatus>();
        }

        /// <summary> Initializes a new instance of AvailabilitySetData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku">
        /// Sku of the availability set, only name is required to be set. See AvailabilitySetSkuTypes for possible set of values. Use 'Aligned' for virtual machines with managed disks and 'Classic' for virtual machines with unmanaged disks. Default value is 'Classic'.
        /// Serialized Name: AvailabilitySet.sku
        /// </param>
        /// <param name="platformUpdateDomainCount">
        /// Update Domain count.
        /// Serialized Name: AvailabilitySet.properties.platformUpdateDomainCount
        /// </param>
        /// <param name="platformFaultDomainCount">
        /// Fault Domain count.
        /// Serialized Name: AvailabilitySet.properties.platformFaultDomainCount
        /// </param>
        /// <param name="virtualMachines">
        /// A list of references to all virtual machines in the availability set.
        /// Serialized Name: AvailabilitySet.properties.virtualMachines
        /// </param>
        /// <param name="proximityPlacementGroup">
        /// Specifies information about the proximity placement group that the availability set should be assigned to. &lt;br&gt;&lt;br&gt;Minimum api-version: 2018-04-01.
        /// Serialized Name: AvailabilitySet.properties.proximityPlacementGroup
        /// </param>
        /// <param name="statuses">
        /// The resource status information.
        /// Serialized Name: AvailabilitySet.properties.statuses
        /// </param>
        internal AvailabilitySetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SampleSku sku, int? platformUpdateDomainCount, int? platformFaultDomainCount, IList<WritableSubResource> virtualMachines, WritableSubResource proximityPlacementGroup, IReadOnlyList<InstanceViewStatus> statuses) : base(id, name, resourceType, systemData, tags, location)
        {
            Sku = sku;
            PlatformUpdateDomainCount = platformUpdateDomainCount;
            PlatformFaultDomainCount = platformFaultDomainCount;
            VirtualMachines = virtualMachines;
            ProximityPlacementGroup = proximityPlacementGroup;
            Statuses = statuses;
        }

        /// <summary>
        /// Sku of the availability set, only name is required to be set. See AvailabilitySetSkuTypes for possible set of values. Use 'Aligned' for virtual machines with managed disks and 'Classic' for virtual machines with unmanaged disks. Default value is 'Classic'.
        /// Serialized Name: AvailabilitySet.sku
        /// </summary>
        public SampleSku Sku { get; set; }
        /// <summary>
        /// Update Domain count.
        /// Serialized Name: AvailabilitySet.properties.platformUpdateDomainCount
        /// </summary>
        public int? PlatformUpdateDomainCount { get; set; }
        /// <summary>
        /// Fault Domain count.
        /// Serialized Name: AvailabilitySet.properties.platformFaultDomainCount
        /// </summary>
        public int? PlatformFaultDomainCount { get; set; }
        /// <summary>
        /// A list of references to all virtual machines in the availability set.
        /// Serialized Name: AvailabilitySet.properties.virtualMachines
        /// </summary>
        public IList<WritableSubResource> VirtualMachines { get; }
        /// <summary>
        /// Specifies information about the proximity placement group that the availability set should be assigned to. &lt;br&gt;&lt;br&gt;Minimum api-version: 2018-04-01.
        /// Serialized Name: AvailabilitySet.properties.proximityPlacementGroup
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
        /// Serialized Name: AvailabilitySet.properties.statuses
        /// </summary>
        public IReadOnlyList<InstanceViewStatus> Statuses { get; }
    }
}
