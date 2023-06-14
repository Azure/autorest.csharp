// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace _Type.Property.ValueTypes.Models
{
    /// <summary> Model with a property unknown, and the data is a dictionnary. </summary>
    public partial class UnknownDictProperty
    {
        /// <summary> Initializes a new instance of UnknownDictProperty. </summary>
        /// <param name="property"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="property"/> is null. </exception>
        public UnknownDictProperty(BinaryData property)
        {
            Argument.AssertNotNull(property, nameof(property));

            Property = property;
        }

        /// <summary>
        /// Property
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formated json string to this property use <see cref="BinaryData.FromString(string)"/>.
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
        public BinaryData Property { get; set; }
    }
}
