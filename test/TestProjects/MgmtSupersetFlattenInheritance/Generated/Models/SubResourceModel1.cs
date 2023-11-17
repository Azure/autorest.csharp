// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtSupersetFlattenInheritance.Models
{
    /// <summary> SubResource WITHOUT flatten properties. </summary>
    public partial class SubResourceModel1
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

        /// <summary> Initializes a new instance of <see cref="SubResourceModel1"/>. </summary>
        public SubResourceModel1()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SubResourceModel1"/>. </summary>
        /// <param name="id"></param>
        /// <param name="foo"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SubResourceModel1(string id, string foo, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Foo = foo;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets the id. </summary>
        public string Id { get; }
        /// <summary> Gets or sets the foo. </summary>
        public string Foo { get; set; }
    }
}
