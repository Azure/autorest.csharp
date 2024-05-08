// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace _Type.Property.AdditionalProperties.Models
{
    /// <summary> The model spread Record&lt;WidgetData2 | WidgetData1&gt;. </summary>
    public partial class SpreadRecordForNonDiscriminatedUnion2
    {
        /// <summary> Initializes a new instance of <see cref="SpreadRecordForNonDiscriminatedUnion2"/>. </summary>
        /// <param name="name"> The name property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public SpreadRecordForNonDiscriminatedUnion2(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            AdditionalProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="SpreadRecordForNonDiscriminatedUnion2"/>. </summary>
        /// <param name="name"> The name property. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        internal SpreadRecordForNonDiscriminatedUnion2(string name, IDictionary<string, BinaryData> additionalProperties)
        {
            Name = name;
            AdditionalProperties = additionalProperties;
        }

        /// <summary> Initializes a new instance of <see cref="SpreadRecordForNonDiscriminatedUnion2"/> for deserialization. </summary>
        internal SpreadRecordForNonDiscriminatedUnion2()
        {
        }

        /// <summary> The name property. </summary>
        public string Name { get; set; }
        /// <summary>
        /// Additional Properties
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// <remarks>
        /// Supported types:
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="WidgetData2"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="WidgetData1"/></description>
        /// </item>
        /// </list>
        /// </remarks>
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
        public IDictionary<string, BinaryData> AdditionalProperties { get; }
    }
}
