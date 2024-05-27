// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Versioning.Added.Models
{
    /// <summary> The ModelV1. </summary>
    public partial class ModelV1
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

        /// <summary> Initializes a new instance of <see cref="ModelV1"/>. </summary>
        /// <param name="prop"></param>
        /// <param name="enumProp"></param>
        /// <param name="unionProp"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="prop"/> or <paramref name="unionProp"/> is null. </exception>
        public ModelV1(string prop, EnumV1 enumProp, BinaryData unionProp)
        {
            Argument.AssertNotNull(prop, nameof(prop));
            Argument.AssertNotNull(unionProp, nameof(unionProp));

            Prop = prop;
            EnumProp = enumProp;
            UnionProp = unionProp;
        }

        /// <summary> Initializes a new instance of <see cref="ModelV1"/>. </summary>
        /// <param name="prop"></param>
        /// <param name="enumProp"></param>
        /// <param name="unionProp"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelV1(string prop, EnumV1 enumProp, BinaryData unionProp, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Prop = prop;
            EnumProp = enumProp;
            UnionProp = unionProp;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ModelV1"/> for deserialization. </summary>
        internal ModelV1()
        {
        }

        /// <summary> Gets or sets the prop. </summary>
        public string Prop { get; set; }
        /// <summary> Gets or sets the enum prop. </summary>
        public EnumV1 EnumProp { get; set; }
        /// <summary>
        /// Gets or sets the union prop
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// <remarks>
        /// Supported types:
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="string"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="int"/></description>
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
        public BinaryData UnionProp { get; set; }
    }
}
