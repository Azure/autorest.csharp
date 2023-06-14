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
    /// A class representing the ProximityPlacementGroup data model.
    /// Specifies information about the proximity placement group.
    /// Serialized Name: ProximityPlacementGroup
    /// </summary>
    public partial class ProximityPlacementGroupData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of ProximityPlacementGroupData. </summary>
        /// <param name="location"> The location. </param>
        public ProximityPlacementGroupData(AzureLocation location) : base(location)
        {
            VirtualMachines = new ChangeTrackingList<SubResourceWithColocationStatus>();
            VirtualMachineScaleSets = new ChangeTrackingList<SubResourceWithColocationStatus>();
            AvailabilitySets = new ChangeTrackingList<SubResourceWithColocationStatus>();
        }

        /// <summary> Initializes a new instance of ProximityPlacementGroupData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation">
        /// The extended location of the custom IP prefix.
        /// Serialized Name: ProximityPlacementGroup.extendedLocation
        /// </param>
        /// <param name="proximityPlacementGroupType">
        /// Specifies the type of the proximity placement group. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Standard** : Co-locate resources within an Azure region or Availability Zone. &lt;br&gt;&lt;br&gt; **Ultra** : For future use.
        /// Serialized Name: ProximityPlacementGroup.properties.proximityPlacementGroupType
        /// </param>
        /// <param name="virtualMachines">
        /// A list of references to all virtual machines in the proximity placement group.
        /// Serialized Name: ProximityPlacementGroup.properties.virtualMachines
        /// </param>
        /// <param name="virtualMachineScaleSets">
        /// A list of references to all virtual machine scale sets in the proximity placement group.
        /// Serialized Name: ProximityPlacementGroup.properties.virtualMachineScaleSets
        /// </param>
        /// <param name="availabilitySets">
        /// A list of references to all availability sets in the proximity placement group.
        /// Serialized Name: ProximityPlacementGroup.properties.availabilitySets
        /// </param>
        /// <param name="colocationStatus">
        /// Describes colocation status of the Proximity Placement Group.
        /// Serialized Name: ProximityPlacementGroup.properties.colocationStatus
        /// </param>
        internal ProximityPlacementGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, ProximityPlacementGroupType? proximityPlacementGroupType, IReadOnlyList<SubResourceWithColocationStatus> virtualMachines, IReadOnlyList<SubResourceWithColocationStatus> virtualMachineScaleSets, IReadOnlyList<SubResourceWithColocationStatus> availabilitySets, InstanceViewStatus colocationStatus) : base(id, name, resourceType, systemData, tags, location)
        {
            ExtendedLocation = extendedLocation;
            ProximityPlacementGroupType = proximityPlacementGroupType;
            VirtualMachines = virtualMachines;
            VirtualMachineScaleSets = virtualMachineScaleSets;
            AvailabilitySets = availabilitySets;
            ColocationStatus = colocationStatus;
        }

        /// <summary>
        /// The extended location of the custom IP prefix.
        /// Serialized Name: ProximityPlacementGroup.extendedLocation
        /// </summary>
        public ExtendedLocation ExtendedLocation { get; set; }
        /// <summary>
        /// Specifies the type of the proximity placement group. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Standard** : Co-locate resources within an Azure region or Availability Zone. &lt;br&gt;&lt;br&gt; **Ultra** : For future use.
        /// Serialized Name: ProximityPlacementGroup.properties.proximityPlacementGroupType
        /// </summary>
        public ProximityPlacementGroupType? ProximityPlacementGroupType { get; set; }
        /// <summary>
        /// A list of references to all virtual machines in the proximity placement group.
        /// Serialized Name: ProximityPlacementGroup.properties.virtualMachines
        /// </summary>
        public IReadOnlyList<SubResourceWithColocationStatus> VirtualMachines { get; }
        /// <summary>
        /// A list of references to all virtual machine scale sets in the proximity placement group.
        /// Serialized Name: ProximityPlacementGroup.properties.virtualMachineScaleSets
        /// </summary>
        public IReadOnlyList<SubResourceWithColocationStatus> VirtualMachineScaleSets { get; }
        /// <summary>
        /// A list of references to all availability sets in the proximity placement group.
        /// Serialized Name: ProximityPlacementGroup.properties.availabilitySets
        /// </summary>
        public IReadOnlyList<SubResourceWithColocationStatus> AvailabilitySets { get; }
        /// <summary>
        /// Describes colocation status of the Proximity Placement Group.
        /// Serialized Name: ProximityPlacementGroup.properties.colocationStatus
        /// </summary>
        public InstanceViewStatus ColocationStatus { get; set; }
    }
}
