// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace _Type.Union.Models
{
    /// <summary> The SendRequest7. </summary>
    internal partial class SendRequest7
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

        /// <summary> Initializes a new instance of <see cref="SendRequest7"/>. </summary>
        /// <param name="prop"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="prop"/> is null. </exception>
        internal SendRequest7(StringAndArrayCases prop)
        {
            Argument.AssertNotNull(prop, nameof(prop));

            Prop = prop;
        }

        /// <summary> Initializes a new instance of <see cref="SendRequest7"/>. </summary>
        /// <param name="prop"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SendRequest7(StringAndArrayCases prop, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Prop = prop;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="SendRequest7"/> for deserialization. </summary>
        internal SendRequest7()
        {
        }

        /// <summary> Gets the prop. </summary>
        public StringAndArrayCases Prop { get; }
    }
}
