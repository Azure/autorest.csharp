// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The List Virtual Machine operation response.
    /// Serialized Name: VirtualMachineScaleSetListWithLinkResult
    /// </summary>
    internal partial class VirtualMachineScaleSetListWithLinkResult
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

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetListWithLinkResult"/>. </summary>
        /// <param name="value">
        /// The list of virtual machine scale sets.
        /// Serialized Name: VirtualMachineScaleSetListWithLinkResult.value
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal VirtualMachineScaleSetListWithLinkResult(IEnumerable<VirtualMachineScaleSetData> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetListWithLinkResult"/>. </summary>
        /// <param name="value">
        /// The list of virtual machine scale sets.
        /// Serialized Name: VirtualMachineScaleSetListWithLinkResult.value
        /// </param>
        /// <param name="nextLink">
        /// The uri to fetch the next page of Virtual Machine Scale Sets. Call ListNext() with this to fetch the next page of Virtual Machine Scale Sets.
        /// Serialized Name: VirtualMachineScaleSetListWithLinkResult.nextLink
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetListWithLinkResult(IReadOnlyList<VirtualMachineScaleSetData> value, string nextLink, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            NextLink = nextLink;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetListWithLinkResult"/> for deserialization. </summary>
        internal VirtualMachineScaleSetListWithLinkResult()
        {
        }

        /// <summary>
        /// The list of virtual machine scale sets.
        /// Serialized Name: VirtualMachineScaleSetListWithLinkResult.value
        /// </summary>
        public IReadOnlyList<VirtualMachineScaleSetData> Value { get; }
        /// <summary>
        /// The uri to fetch the next page of Virtual Machine Scale Sets. Call ListNext() with this to fetch the next page of Virtual Machine Scale Sets.
        /// Serialized Name: VirtualMachineScaleSetListWithLinkResult.nextLink
        /// </summary>
        public string NextLink { get; }
    }
}
