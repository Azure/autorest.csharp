// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace FirstTestTypeSpec.Models
{
    /// <summary> containself. </summary>
    public partial class ContainSelf
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

        /// <summary> Initializes a new instance of <see cref="ContainSelf"/>. </summary>
        /// <param name="self"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="self"/> is null. </exception>
        public ContainSelf(ContainSelf self)
        {
            Argument.AssertNotNull(self, nameof(self));

            Self = self;
        }

        /// <summary> Initializes a new instance of <see cref="ContainSelf"/>. </summary>
        /// <param name="self"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ContainSelf(ContainSelf self, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Self = self;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ContainSelf"/> for deserialization. </summary>
        internal ContainSelf()
        {
        }

        /// <summary> Gets the self. </summary>
        public ContainSelf Self { get; }
    }
}
