// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace MgmtResourceName.Models
{
    /// <summary> Operation. </summary>
    public partial class ResourceOperation
    {
        /// <summary> Initializes a new instance of ResourceOperation. </summary>
        internal ResourceOperation()
        {
        }

        /// <summary> Initializes a new instance of ResourceOperation. </summary>
        /// <param name="name"> The operation name. </param>
        /// <param name="displayName"> The operation display name. </param>
        /// <param name="description"> The operation description. </param>
        /// <param name="origin"> The operation origin. </param>
        /// <param name="properties"> The operation properties. </param>
        internal ResourceOperation(string name, string displayName, string description, string origin, BinaryData properties)
        {
            Name = name;
            DisplayName = displayName;
            Description = description;
            Origin = origin;
            Properties = properties;
        }

        /// <summary> The operation name. </summary>
        public string Name { get; }
        /// <summary> The operation display name. </summary>
        public string DisplayName { get; }
        /// <summary> The operation description. </summary>
        public string Description { get; }
        /// <summary> The operation origin. </summary>
        public string Origin { get; }
        /// <summary>
        /// The operation properties.
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
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
        public BinaryData Properties { get; }
    }
}
