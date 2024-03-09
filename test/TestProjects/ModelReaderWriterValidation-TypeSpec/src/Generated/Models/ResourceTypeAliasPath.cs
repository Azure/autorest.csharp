// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using ModelReaderWriterValidationTypeSpec;

namespace ModelReaderWriterValidationTypeSpec.Models
{
    /// <summary> The type of the paths for alias. </summary>
    public partial class ResourceTypeAliasPath
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

        /// <summary> Initializes a new instance of <see cref="ResourceTypeAliasPath"/>. </summary>
        internal ResourceTypeAliasPath()
        {
            ApiVersions = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="ResourceTypeAliasPath"/>. </summary>
        /// <param name="path"> The path of an alias. </param>
        /// <param name="apiVersions"> The API versions. </param>
        /// <param name="pattern"> The pattern for an alias path. </param>
        /// <param name="metadata"> The metadata of the alias path. If missing, fall back to the default metadata of the alias. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ResourceTypeAliasPath(string path, IReadOnlyList<string> apiVersions, ResourceTypeAliasPattern pattern, ResourceTypeAliasPathMetadata metadata, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Path = path;
            ApiVersions = apiVersions;
            Pattern = pattern;
            Metadata = metadata;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The path of an alias. </summary>
        public string Path { get; }
        /// <summary> The API versions. </summary>
        public IReadOnlyList<string> ApiVersions { get; }
        /// <summary> The pattern for an alias path. </summary>
        public ResourceTypeAliasPattern Pattern { get; }
        /// <summary> The metadata of the alias path. If missing, fall back to the default metadata of the alias. </summary>
        public ResourceTypeAliasPathMetadata Metadata { get; }
    }
}
