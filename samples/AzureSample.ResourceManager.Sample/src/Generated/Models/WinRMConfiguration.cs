// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace AzureSample.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes Windows Remote Management configuration of the VM
    /// Serialized Name: WinRMConfiguration
    /// </summary>
    internal partial class WinRMConfiguration
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

        /// <summary> Initializes a new instance of <see cref="WinRMConfiguration"/>. </summary>
        public WinRMConfiguration()
        {
            Listeners = new ChangeTrackingList<WinRMListener>();
        }

        /// <summary> Initializes a new instance of <see cref="WinRMConfiguration"/>. </summary>
        /// <param name="listeners">
        /// The list of Windows Remote Management listeners
        /// Serialized Name: WinRMConfiguration.listeners
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal WinRMConfiguration(IList<WinRMListener> listeners, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Listeners = listeners;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// The list of Windows Remote Management listeners
        /// Serialized Name: WinRMConfiguration.listeners
        /// </summary>
        [WirePath("listeners")]
        public IList<WinRMListener> Listeners { get; }
    }
}
