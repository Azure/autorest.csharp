// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace AzureSample.ResourceManager.Sample.Models
{
    /// <summary>
    /// The VMScaleSetConvertToSinglePlacementGroupInput.
    /// Serialized Name: VMScaleSetConvertToSinglePlacementGroupInput
    /// </summary>
    public partial class VmScaleSetConvertToSinglePlacementGroupContent
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

        /// <summary> Initializes a new instance of <see cref="VmScaleSetConvertToSinglePlacementGroupContent"/>. </summary>
        public VmScaleSetConvertToSinglePlacementGroupContent()
        {
        }

        /// <summary> Initializes a new instance of <see cref="VmScaleSetConvertToSinglePlacementGroupContent"/>. </summary>
        /// <param name="activePlacementGroupId">
        /// Id of the placement group in which you want future virtual machine instances to be placed. To query placement group Id, please use Virtual Machine Scale Set VMs - Get API. If not provided, the platform will choose one with maximum number of virtual machine instances.
        /// Serialized Name: VMScaleSetConvertToSinglePlacementGroupInput.activePlacementGroupId
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VmScaleSetConvertToSinglePlacementGroupContent(string activePlacementGroupId, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ActivePlacementGroupId = activePlacementGroupId;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// Id of the placement group in which you want future virtual machine instances to be placed. To query placement group Id, please use Virtual Machine Scale Set VMs - Get API. If not provided, the platform will choose one with maximum number of virtual machine instances.
        /// Serialized Name: VMScaleSetConvertToSinglePlacementGroupInput.activePlacementGroupId
        /// </summary>
        [WirePath("activePlacementGroupId")]
        public string ActivePlacementGroupId { get; set; }
    }
}
