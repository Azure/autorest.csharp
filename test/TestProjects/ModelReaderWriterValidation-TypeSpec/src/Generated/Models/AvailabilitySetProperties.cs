// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using ModelReaderWriterValidationTypeSpec;

namespace ModelReaderWriterValidationTypeSpec.Models
{
    /// <summary> The availability set properties. </summary>
    public partial class AvailabilitySetProperties
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

        /// <summary> Initializes a new instance of <see cref="AvailabilitySetProperties"/>. </summary>
        public AvailabilitySetProperties()
        {
            VirtualMachines = new ChangeTrackingList<WritableSubResource>();
        }

        /// <summary> Initializes a new instance of <see cref="AvailabilitySetProperties"/>. </summary>
        /// <param name="virtualMachines"> The virtual machines. </param>
        /// <param name="platformFaultDomainCount"> The platform fault domain count property. </param>
        /// <param name="platformUpdateDomainCount"> The platform update domain count property. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AvailabilitySetProperties(IList<WritableSubResource> virtualMachines, int? platformFaultDomainCount, int? platformUpdateDomainCount, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            VirtualMachines = virtualMachines;
            PlatformFaultDomainCount = platformFaultDomainCount;
            PlatformUpdateDomainCount = platformUpdateDomainCount;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The virtual machines. </summary>
        public IList<WritableSubResource> VirtualMachines { get; }
        /// <summary> The platform fault domain count property. </summary>
        public int? PlatformFaultDomainCount { get; set; }
        /// <summary> The platform update domain count property. </summary>
        public int? PlatformUpdateDomainCount { get; set; }
    }
}
