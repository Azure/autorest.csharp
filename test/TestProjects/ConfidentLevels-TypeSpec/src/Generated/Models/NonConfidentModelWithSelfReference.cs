// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace ConfidentLevelsInTsp.Models
{
    /// <summary> Non-confident model that contains self reference. </summary>
    public partial class NonConfidentModelWithSelfReference
    {
        /// <summary> Initializes a new instance of NonConfidentModelWithSelfReference. </summary>
        /// <param name="name"> The name. </param>
        /// <param name="selfReference"> The self reference. </param>
        /// <param name="unionProperty"> The non-confident part. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="selfReference"/> or <paramref name="unionProperty"/> is null. </exception>
        public NonConfidentModelWithSelfReference(string name, IEnumerable<NonConfidentModelWithSelfReference> selfReference, BinaryData unionProperty)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(selfReference, nameof(selfReference));
            Argument.AssertNotNull(unionProperty, nameof(unionProperty));

            Name = name;
            SelfReference = selfReference.ToList();
            UnionProperty = unionProperty;
        }

        /// <summary> Initializes a new instance of NonConfidentModelWithSelfReference. </summary>
        /// <param name="name"> The name. </param>
        /// <param name="selfReference"> The self reference. </param>
        /// <param name="unionProperty"> The non-confident part. </param>
        internal NonConfidentModelWithSelfReference(string name, IList<NonConfidentModelWithSelfReference> selfReference, BinaryData unionProperty)
        {
            Name = name;
            SelfReference = selfReference;
            UnionProperty = unionProperty;
        }

        /// <summary> The name. </summary>
        public string Name { get; }
        /// <summary> The self reference. </summary>
        public IList<NonConfidentModelWithSelfReference> SelfReference { get; }
        /// <summary>
        /// The non-confident part
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// <remarks>
        /// Supported types:
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="string"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="IList{T}"/> Where <c>T</c> is of type <see cref="int"/></description>
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
        public BinaryData UnionProperty { get; }
    }
}
