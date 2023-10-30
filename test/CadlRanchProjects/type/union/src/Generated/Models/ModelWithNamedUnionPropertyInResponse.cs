// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace _Type.Union.Models
{
    /// <summary> The ModelWithNamedUnionPropertyInResponse. </summary>
    public partial class ModelWithNamedUnionPropertyInResponse
    {
        /// <summary> Initializes a new instance of ModelWithNamedUnionPropertyInResponse. </summary>
        /// <param name="namedUnion"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="namedUnion"/> is null. </exception>
        internal ModelWithNamedUnionPropertyInResponse(BinaryData namedUnion)
        {
            Argument.AssertNotNull(namedUnion, nameof(namedUnion));

            NamedUnion = namedUnion;
        }

        /// <summary>
        /// Gets the named union
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// <remarks>
        /// The following types are supported by this property:
        /// <list type="bullet">
        /// <item>
        /// Model1
        /// </item>
        /// <item>
        /// Model2
        /// </item>
        /// </list>
        /// </remarks>
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
        public BinaryData NamedUnion { get; }
    }
}
