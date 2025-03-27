// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace _Azure.ResourceManager.NonResources.Models
{
    /// <summary> Though this model has `id`, `name`, `type` properties, it is not a resource as it doesn't extends `Resource`. </summary>
    public partial class NonResource
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

        /// <summary> Initializes a new instance of <see cref="NonResource"/>. </summary>
        public NonResource()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NonResource"/>. </summary>
        /// <param name="id"> An id. </param>
        /// <param name="name"> A name. </param>
        /// <param name="type"> A type. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal NonResource(string id, string name, string type, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Name = name;
            Type = type;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> An id. </summary>
        public string Id { get; set; }
        /// <summary> A name. </summary>
        public string Name { get; set; }
        /// <summary> A type. </summary>
        public string Type { get; set; }
    }
}
