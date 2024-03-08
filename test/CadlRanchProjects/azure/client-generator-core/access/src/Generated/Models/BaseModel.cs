// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using _Specs_.Azure.ClientGenerator.Core.Access;

namespace _Specs_.Azure.ClientGenerator.Core.Access.Models
{
    /// <summary> Used in internal operations, should be generated but not exported. </summary>
    internal partial class BaseModel
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
        private protected IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="BaseModel"/>. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal BaseModel(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }

        /// <summary> Initializes a new instance of <see cref="BaseModel"/>. </summary>
        /// <param name="name"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal BaseModel(string name, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="BaseModel"/> for deserialization. </summary>
        internal BaseModel()
        {
        }

        /// <summary> Gets the name. </summary>
        public string Name { get; }
    }
}
