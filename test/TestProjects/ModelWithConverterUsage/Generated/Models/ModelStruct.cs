// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace ModelWithConverterUsage.Models
{
    /// <summary> The ModelStruct. </summary>
    public readonly partial struct ModelStruct
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
        private readonly IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ModelStruct"/>. </summary>
        /// <param name="modelProperty"> . </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelProperty"/> is null. </exception>
        public ModelStruct(string modelProperty)
        {
            Argument.AssertNotNull(modelProperty, nameof(modelProperty));

            ModelProperty = modelProperty;
        }

        /// <summary> Initializes a new instance of <see cref="ModelStruct"/>. </summary>
        /// <param name="modelProperty"> . </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelStruct(string modelProperty, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ModelProperty = modelProperty;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ModelStruct"/> for deserialization. </summary>
        public ModelStruct()
        {
        }

        /// <summary> . </summary>
        public string ModelProperty { get; }
    }
}
