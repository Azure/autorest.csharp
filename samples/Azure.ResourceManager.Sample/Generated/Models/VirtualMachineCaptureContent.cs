// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Capture Virtual Machine parameters.
    /// Serialized Name: VirtualMachineCaptureParameters
    /// </summary>
    public partial class VirtualMachineCaptureContent
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

        /// <summary> Initializes a new instance of <see cref="VirtualMachineCaptureContent"/>. </summary>
        /// <param name="vhdPrefix">
        /// The captured virtual hard disk's name prefix.
        /// Serialized Name: VirtualMachineCaptureParameters.vhdPrefix
        /// </param>
        /// <param name="destinationContainerName">
        /// The destination container name.
        /// Serialized Name: VirtualMachineCaptureParameters.destinationContainerName
        /// </param>
        /// <param name="overwriteVhds">
        /// Specifies whether to overwrite the destination virtual hard disk, in case of conflict.
        /// Serialized Name: VirtualMachineCaptureParameters.overwriteVhds
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vhdPrefix"/> or <paramref name="destinationContainerName"/> is null. </exception>
        public VirtualMachineCaptureContent(string vhdPrefix, string destinationContainerName, bool overwriteVhds)
        {
            Argument.AssertNotNull(vhdPrefix, nameof(vhdPrefix));
            Argument.AssertNotNull(destinationContainerName, nameof(destinationContainerName));

            VhdPrefix = vhdPrefix;
            DestinationContainerName = destinationContainerName;
            OverwriteVhds = overwriteVhds;
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineCaptureContent"/>. </summary>
        /// <param name="vhdPrefix">
        /// The captured virtual hard disk's name prefix.
        /// Serialized Name: VirtualMachineCaptureParameters.vhdPrefix
        /// </param>
        /// <param name="destinationContainerName">
        /// The destination container name.
        /// Serialized Name: VirtualMachineCaptureParameters.destinationContainerName
        /// </param>
        /// <param name="overwriteVhds">
        /// Specifies whether to overwrite the destination virtual hard disk, in case of conflict.
        /// Serialized Name: VirtualMachineCaptureParameters.overwriteVhds
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineCaptureContent(string vhdPrefix, string destinationContainerName, bool overwriteVhds, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            VhdPrefix = vhdPrefix;
            DestinationContainerName = destinationContainerName;
            OverwriteVhds = overwriteVhds;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineCaptureContent"/> for deserialization. </summary>
        internal VirtualMachineCaptureContent()
        {
        }

        /// <summary>
        /// The captured virtual hard disk's name prefix.
        /// Serialized Name: VirtualMachineCaptureParameters.vhdPrefix
        /// </summary>
        [WirePath("vhdPrefix")]
        public string VhdPrefix { get; }
        /// <summary>
        /// The destination container name.
        /// Serialized Name: VirtualMachineCaptureParameters.destinationContainerName
        /// </summary>
        [WirePath("destinationContainerName")]
        public string DestinationContainerName { get; }
        /// <summary>
        /// Specifies whether to overwrite the destination virtual hard disk, in case of conflict.
        /// Serialized Name: VirtualMachineCaptureParameters.overwriteVhds
        /// </summary>
        [WirePath("overwriteVhds")]
        public bool OverwriteVhds { get; }
    }
}
