// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace ConfidentLevelsInTsp.Models
{
    /// <summary> Indirect self reference model. </summary>
    public partial class IndirectSelfReferenceModel
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

        /// <summary> Initializes a new instance of <see cref="IndirectSelfReferenceModel"/>. </summary>
        /// <param name="something"> Something not important. </param>
        /// <param name="unionProperty"> The non-confident part. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="something"/> or <paramref name="unionProperty"/> is null. </exception>
        public IndirectSelfReferenceModel(string something, BinaryData unionProperty)
        {
            Argument.AssertNotNull(something, nameof(something));
            Argument.AssertNotNull(unionProperty, nameof(unionProperty));

            Something = something;
            UnionProperty = unionProperty;
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="IndirectSelfReferenceModel"/>. </summary>
        /// <param name="something"> Something not important. </param>
        /// <param name="reference"> Reference back. </param>
        /// <param name="unionProperty"> The non-confident part. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal IndirectSelfReferenceModel(string something, NonConfidentModelWithSelfReference reference, BinaryData unionProperty, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Something = something;
            Reference = reference;
            UnionProperty = unionProperty;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="IndirectSelfReferenceModel"/> for deserialization. </summary>
        internal IndirectSelfReferenceModel()
        {
        }

        /// <summary> Something not important. </summary>
        public string Something { get; }
        /// <summary> Reference back. </summary>
        public NonConfidentModelWithSelfReference Reference { get; set; }
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
