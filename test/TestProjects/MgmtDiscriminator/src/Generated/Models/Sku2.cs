// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtDiscriminator.Models
{
    /// <summary> A model with a single object for testing safe-flattening. </summary>
    internal partial class Sku2
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

        /// <summary> Initializes a new instance of <see cref="Sku2"/>. </summary>
        /// <param name="nestedName"> The childmost sku property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nestedName"/> is null. </exception>
        public Sku2(string nestedName)
        {
            Argument.AssertNotNull(nestedName, nameof(nestedName));

            NestedName = nestedName;
        }

        /// <summary> Initializes a new instance of <see cref="Sku2"/>. </summary>
        /// <param name="nestedName"> The childmost sku property. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Sku2(string nestedName, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            NestedName = nestedName;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="Sku2"/> for deserialization. </summary>
        internal Sku2()
        {
        }

        /// <summary> The childmost sku property. </summary>
        [WirePath("nestedName")]
        public string NestedName { get; set; }
    }
}
