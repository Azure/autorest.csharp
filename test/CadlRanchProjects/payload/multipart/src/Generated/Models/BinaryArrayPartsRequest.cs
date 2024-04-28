// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Payload.MultiPart.Models
{
    /// <summary> The BinaryArrayPartsRequest. </summary>
    public partial class BinaryArrayPartsRequest
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

        /// <summary> Initializes a new instance of <see cref="BinaryArrayPartsRequest"/>. </summary>
        /// <param name="id"></param>
        /// <param name="pictures"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="pictures"/> is null. </exception>
        public BinaryArrayPartsRequest(string id, IEnumerable<Stream> pictures)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(pictures, nameof(pictures));

            Id = id;
            Pictures = pictures.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="BinaryArrayPartsRequest"/>. </summary>
        /// <param name="id"></param>
        /// <param name="pictures"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal BinaryArrayPartsRequest(string id, IList<Stream> pictures, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Pictures = pictures;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="BinaryArrayPartsRequest"/> for deserialization. </summary>
        internal BinaryArrayPartsRequest()
        {
        }

        /// <summary> Gets the id. </summary>
        public string Id { get; }
        /// <summary> Gets the pictures. </summary>
        public IList<Stream> Pictures { get; }
    }
}
