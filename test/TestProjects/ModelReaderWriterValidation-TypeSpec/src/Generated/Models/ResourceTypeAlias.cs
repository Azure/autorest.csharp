// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace ModelReaderWriterValidationTypeSpec.Models
{
    /// <summary> The alias type. </summary>
    public partial class ResourceTypeAlias
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

        /// <summary> Initializes a new instance of <see cref="ResourceTypeAlias"/>. </summary>
        internal ResourceTypeAlias()
        {
            Paths = new ChangeTrackingList<ResourceTypeAliasPath>();
        }

        /// <summary> Initializes a new instance of <see cref="ResourceTypeAlias"/>. </summary>
        /// <param name="name"> The alias name. </param>
        /// <param name="paths"> The paths for an alias. </param>
        /// <param name="aliasType"> The type of the alias. </param>
        /// <param name="defaultPath"> The default path for an alias. </param>
        /// <param name="defaultPattern"> The default pattern for an alias. </param>
        /// <param name="defaultMetadata"> The default alias path metadata. Applies to the default path and to any alias path that doesn't have metadata. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ResourceTypeAlias(string name, IReadOnlyList<ResourceTypeAliasPath> paths, ResourceTypeAliasType? aliasType, string defaultPath, ResourceTypeAliasPattern defaultPattern, ResourceTypeAliasPathMetadata defaultMetadata, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Paths = paths;
            AliasType = aliasType;
            DefaultPath = defaultPath;
            DefaultPattern = defaultPattern;
            DefaultMetadata = defaultMetadata;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The alias name. </summary>
        public string Name { get; }
        /// <summary> The paths for an alias. </summary>
        public IReadOnlyList<ResourceTypeAliasPath> Paths { get; }
        /// <summary> The type of the alias. </summary>
        public ResourceTypeAliasType? AliasType { get; }
        /// <summary> The default path for an alias. </summary>
        public string DefaultPath { get; }
        /// <summary> The default pattern for an alias. </summary>
        public ResourceTypeAliasPattern DefaultPattern { get; }
        /// <summary> The default alias path metadata. Applies to the default path and to any alias path that doesn't have metadata. </summary>
        public ResourceTypeAliasPathMetadata DefaultMetadata { get; }
    }
}
