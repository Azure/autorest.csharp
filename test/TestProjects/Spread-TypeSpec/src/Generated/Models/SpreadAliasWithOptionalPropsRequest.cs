// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace SpreadTypeSpec.Models
{
    /// <summary> The SpreadAliasWithOptionalPropsRequest. </summary>
    internal partial class SpreadAliasWithOptionalPropsRequest
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

        /// <summary> Initializes a new instance of <see cref="SpreadAliasWithOptionalPropsRequest"/>. </summary>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="items"> required array. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="items"/> is null. </exception>
        public SpreadAliasWithOptionalPropsRequest(string name, IEnumerable<int> items)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(items, nameof(items));

            Name = name;
            Items = items.ToList();
            Elements = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="SpreadAliasWithOptionalPropsRequest"/>. </summary>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="color"> optional property of the Thing. </param>
        /// <param name="age"> age of the Thing. </param>
        /// <param name="items"> required array. </param>
        /// <param name="elements"> optional array. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SpreadAliasWithOptionalPropsRequest(string name, string color, int? age, IList<int> items, IList<string> elements, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Color = color;
            Age = age;
            Items = items;
            Elements = elements;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="SpreadAliasWithOptionalPropsRequest"/> for deserialization. </summary>
        internal SpreadAliasWithOptionalPropsRequest()
        {
        }

        /// <summary> name of the Thing. </summary>
        public string Name { get; }
        /// <summary> optional property of the Thing. </summary>
        public string Color { get; set; }
        /// <summary> age of the Thing. </summary>
        public int? Age { get; set; }
        /// <summary> required array. </summary>
        public IList<int> Items { get; }
        /// <summary> optional array. </summary>
        public IList<string> Elements { get; }
    }
}
