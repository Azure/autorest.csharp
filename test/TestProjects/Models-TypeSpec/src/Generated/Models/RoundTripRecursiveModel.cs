// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using ModelsTypeSpec;

namespace ModelsTypeSpec.Models
{
    /// <summary> Roundtrip model that has property of its own type. </summary>
    public partial class RoundTripRecursiveModel
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

        /// <summary> Initializes a new instance of <see cref="RoundTripRecursiveModel"/>. </summary>
        /// <param name="message"> Message. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="message"/> is null. </exception>
        public RoundTripRecursiveModel(string message)
        {
            Argument.AssertNotNull(message, nameof(message));

            Message = message;
        }

        /// <summary> Initializes a new instance of <see cref="RoundTripRecursiveModel"/>. </summary>
        /// <param name="message"> Message. </param>
        /// <param name="inner"> Required Record. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RoundTripRecursiveModel(string message, RoundTripRecursiveModel inner, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Message = message;
            Inner = inner;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="RoundTripRecursiveModel"/> for deserialization. </summary>
        internal RoundTripRecursiveModel()
        {
        }

        /// <summary> Message. </summary>
        public string Message { get; set; }
        /// <summary> Required Record. </summary>
        public RoundTripRecursiveModel Inner { get; set; }
    }
}
