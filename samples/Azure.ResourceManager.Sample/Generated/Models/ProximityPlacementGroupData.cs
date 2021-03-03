// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing the ProximityPlacementGroup data model. </summary>
    public partial class ProximityPlacementGroupData
    {
        /// <summary> Specifies the type of the proximity placement group. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Standard** : Co-locate resources within an Azure region or Availability Zone. &lt;br&gt;&lt;br&gt; **Ultra** : For future use. </summary>
        public ProximityPlacementGroupType? ProximityPlacementGroupType { get; set; }
        /// <summary> A list of references to all virtual machines in the proximity placement group. </summary>
        public IReadOnlyList<SubResourceWithColocationStatus> VirtualMachines { get; }
        /// <summary> A list of references to all virtual machine scale sets in the proximity placement group. </summary>
        public IReadOnlyList<SubResourceWithColocationStatus> VirtualMachineScaleSets { get; }
        /// <summary> A list of references to all availability sets in the proximity placement group. </summary>
        public IReadOnlyList<SubResourceWithColocationStatus> AvailabilitySets { get; }
        /// <summary> Describes colocation status of the Proximity Placement Group. </summary>
        public InstanceViewStatus ColocationStatus { get; set; }
    }
}
