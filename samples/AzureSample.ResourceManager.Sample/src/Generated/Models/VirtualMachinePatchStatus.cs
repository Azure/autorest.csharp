// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace AzureSample.ResourceManager.Sample.Models
{
    /// <summary>
    /// The status of virtual machine patch operations.
    /// Serialized Name: VirtualMachinePatchStatus
    /// </summary>
    public partial class VirtualMachinePatchStatus
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

        /// <summary> Initializes a new instance of <see cref="VirtualMachinePatchStatus"/>. </summary>
        internal VirtualMachinePatchStatus()
        {
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachinePatchStatus"/>. </summary>
        /// <param name="availablePatchSummary">
        /// The available patch summary of the latest assessment operation for the virtual machine.
        /// Serialized Name: VirtualMachinePatchStatus.availablePatchSummary
        /// </param>
        /// <param name="lastPatchInstallationSummary">
        /// The installation summary of the latest installation operation for the virtual machine.
        /// Serialized Name: VirtualMachinePatchStatus.lastPatchInstallationSummary
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachinePatchStatus(AvailablePatchSummary availablePatchSummary, LastPatchInstallationSummary lastPatchInstallationSummary, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            AvailablePatchSummary = availablePatchSummary;
            LastPatchInstallationSummary = lastPatchInstallationSummary;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// The available patch summary of the latest assessment operation for the virtual machine.
        /// Serialized Name: VirtualMachinePatchStatus.availablePatchSummary
        /// </summary>
        [WirePath("availablePatchSummary")]
        public AvailablePatchSummary AvailablePatchSummary { get; }
        /// <summary>
        /// The installation summary of the latest installation operation for the virtual machine.
        /// Serialized Name: VirtualMachinePatchStatus.lastPatchInstallationSummary
        /// </summary>
        [WirePath("lastPatchInstallationSummary")]
        public LastPatchInstallationSummary LastPatchInstallationSummary { get; }
    }
}
