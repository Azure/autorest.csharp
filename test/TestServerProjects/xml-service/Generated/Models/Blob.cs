// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace xml_service.Models
{
    /// <summary> An Azure Storage blob. </summary>
    public partial class Blob
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

        /// <summary> Initializes a new instance of <see cref="Blob"/>. </summary>
        /// <param name="name"></param>
        /// <param name="deleted"></param>
        /// <param name="snapshot"></param>
        /// <param name="properties"> Properties of a blob. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="snapshot"/> or <paramref name="properties"/> is null. </exception>
        internal Blob(string name, bool deleted, string snapshot, BlobProperties properties)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(snapshot, nameof(snapshot));
            Argument.AssertNotNull(properties, nameof(properties));

            Name = name;
            Deleted = deleted;
            Snapshot = snapshot;
            Properties = properties;
            Metadata = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="Blob"/>. </summary>
        /// <param name="name"></param>
        /// <param name="deleted"></param>
        /// <param name="snapshot"></param>
        /// <param name="properties"> Properties of a blob. </param>
        /// <param name="metadata"> Dictionary of &lt;string&gt;. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Blob(string name, bool deleted, string snapshot, BlobProperties properties, IReadOnlyDictionary<string, string> metadata, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Deleted = deleted;
            Snapshot = snapshot;
            Properties = properties;
            Metadata = metadata;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="Blob"/> for deserialization. </summary>
        internal Blob()
        {
        }

        /// <summary> Gets the name. </summary>
        public string Name { get; }
        /// <summary> Gets the deleted. </summary>
        public bool Deleted { get; }
        /// <summary> Gets the snapshot. </summary>
        public string Snapshot { get; }
        /// <summary> Properties of a blob. </summary>
        public BlobProperties Properties { get; }
        /// <summary> Dictionary of &lt;string&gt;. </summary>
        public IReadOnlyDictionary<string, string> Metadata { get; }
    }
}
