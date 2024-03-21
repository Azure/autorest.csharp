// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtDiscriminator.Models
{
    /// <summary> A shell type that can be used to validate bicep generation when no child properties are set. </summary>
    public partial class Shell
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

        /// <summary> Initializes a new instance of <see cref="Shell"/>. </summary>
        public Shell()
        {
        }

        /// <summary> Initializes a new instance of <see cref="Shell"/>. </summary>
        /// <param name="name"> The name of the shell. </param>
        /// <param name="shellType"> The type of the shell. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Shell(string name, string shellType, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            ShellType = shellType;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The name of the shell. </summary>
        [WirePath("name")]
        public string Name { get; set; }
        /// <summary> The type of the shell. </summary>
        [WirePath("type")]
        public string ShellType { get; set; }
    }
}
