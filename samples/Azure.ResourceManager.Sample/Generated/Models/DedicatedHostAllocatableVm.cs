// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Represents the dedicated host unutilized capacity in terms of a specific VM size.
    /// Serialized Name: DedicatedHostAllocatableVM
    /// </summary>
    public partial class DedicatedHostAllocatableVm
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

        /// <summary> Initializes a new instance of <see cref="DedicatedHostAllocatableVm"/>. </summary>
        internal DedicatedHostAllocatableVm()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DedicatedHostAllocatableVm"/>. </summary>
        /// <param name="vmSize">
        /// VM size in terms of which the unutilized capacity is represented.
        /// Serialized Name: DedicatedHostAllocatableVM.vmSize
        /// </param>
        /// <param name="count">
        /// Maximum number of VMs of size vmSize that can fit in the dedicated host's remaining capacity.
        /// Serialized Name: DedicatedHostAllocatableVM.count
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DedicatedHostAllocatableVm(string vmSize, double? count, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            VmSize = vmSize;
            Count = count;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// VM size in terms of which the unutilized capacity is represented.
        /// Serialized Name: DedicatedHostAllocatableVM.vmSize
        /// </summary>
        public string VmSize { get; }
        /// <summary>
        /// Maximum number of VMs of size vmSize that can fit in the dedicated host's remaining capacity.
        /// Serialized Name: DedicatedHostAllocatableVM.count
        /// </summary>
        public double? Count { get; }
    }
}
