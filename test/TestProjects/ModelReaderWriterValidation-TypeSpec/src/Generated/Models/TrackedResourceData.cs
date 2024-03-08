// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using ModelReaderWriterValidationTypeSpec;

namespace ModelReaderWriterValidationTypeSpec.Models
{
    /// <summary> The tracked resource data. </summary>
    public partial class TrackedResourceData
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

        /// <summary> Initializes a new instance of <see cref="TrackedResourceData"/>. </summary>
        /// <param name="location"> The location property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        internal TrackedResourceData(string location)
        {
            Argument.AssertNotNull(location, nameof(location));

            Location = location;
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="TrackedResourceData"/>. </summary>
        /// <param name="id"> The id property. </param>
        /// <param name="name"> The name property. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="location"> The location property. </param>
        /// <param name="tags"> The tags property. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal TrackedResourceData(string id, string name, string resourceType, string location, IReadOnlyDictionary<string, string> tags, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Name = name;
            ResourceType = resourceType;
            Location = location;
            Tags = tags;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="TrackedResourceData"/> for deserialization. </summary>
        internal TrackedResourceData()
        {
        }

        /// <summary> The id property. </summary>
        public string Id { get; }
        /// <summary> The name property. </summary>
        public string Name { get; }
        /// <summary> The resource type. </summary>
        public string ResourceType { get; }
        /// <summary> The location property. </summary>
        public string Location { get; }
        /// <summary> The tags property. </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }
    }
}
