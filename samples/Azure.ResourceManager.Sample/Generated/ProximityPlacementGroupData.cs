// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Internal;
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
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ProximityPlacementGroupData"/>. </summary>
        /// <param name="location"> The location. </param>
        public ProximityPlacementGroupData(AzureLocation location) : base(location)
        {
            VirtualMachines = new OptionalList<SubResourceWithColocationStatus>();
            VirtualMachineScaleSets = new OptionalList<SubResourceWithColocationStatus>();
            AvailabilitySets = new OptionalList<SubResourceWithColocationStatus>();
        }

        /// <summary> Initializes a new instance of <see cref="ProximityPlacementGroupData"/>. </summary>
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
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ProximityPlacementGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ExtendedLocation extendedLocation, ProximityPlacementGroupType? proximityPlacementGroupType, IReadOnlyList<SubResourceWithColocationStatus> virtualMachines, IReadOnlyList<SubResourceWithColocationStatus> virtualMachineScaleSets, IReadOnlyList<SubResourceWithColocationStatus> availabilitySets, InstanceViewStatus colocationStatus, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData, tags, location)
        {
            ExtendedLocation = extendedLocation;
            ProximityPlacementGroupType = proximityPlacementGroupType;
            VirtualMachines = virtualMachines;
            VirtualMachineScaleSets = virtualMachineScaleSets;
            AvailabilitySets = availabilitySets;
            ColocationStatus = colocationStatus;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ProximityPlacementGroupData"/> for deserialization. </summary>
        internal ProximityPlacementGroupData()
        {
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
