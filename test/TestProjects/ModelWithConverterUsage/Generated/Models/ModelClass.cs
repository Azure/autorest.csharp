// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace ModelWithConverterUsage.Models
{
    /// <summary> . </summary>
    public partial class ModelClass
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

        /// <summary> Initializes a new instance of <see cref="ModelClass"/>. </summary>
        /// <param name="enumProperty"> More Letters. </param>
        public ModelClass(EnumProperty enumProperty)
        {
            EnumProperty = enumProperty;
        }

        /// <summary> Initializes a new instance of <see cref="ModelClass"/>. </summary>
        /// <param name="stringProperty"></param>
        /// <param name="enumProperty"> More Letters. </param>
        /// <param name="objProperty"> The product documentation. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelClass(string stringProperty, EnumProperty enumProperty, Product objProperty, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            StringProperty = stringProperty;
            EnumProperty = enumProperty;
            ObjProperty = objProperty;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ModelClass"/> for deserialization. </summary>
        internal ModelClass()
        {
        }

        /// <summary> Gets or sets the string property. </summary>
        public string StringProperty { get; set; }
        /// <summary> More Letters. </summary>
        public EnumProperty EnumProperty { get; set; }
        /// <summary> The product documentation. </summary>
        public Product ObjProperty { get; set; }
    }
}
