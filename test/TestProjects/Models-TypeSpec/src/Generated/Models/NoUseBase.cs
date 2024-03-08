// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using ModelsTypeSpec;

namespace ModelsTypeSpec.Models
{
    /// <summary> Base model. </summary>
    public partial class NoUseBase
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
        private protected IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="NoUseBase"/>. </summary>
        /// <param name="baseModelProp"> base model property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="baseModelProp"/> is null. </exception>
        internal NoUseBase(string baseModelProp)
        {
            Argument.AssertNotNull(baseModelProp, nameof(baseModelProp));

            BaseModelProp = baseModelProp;
        }

        /// <summary> Initializes a new instance of <see cref="NoUseBase"/>. </summary>
        /// <param name="baseModelProp"> base model property. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal NoUseBase(string baseModelProp, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            BaseModelProp = baseModelProp;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="NoUseBase"/> for deserialization. </summary>
        internal NoUseBase()
        {
        }

        /// <summary> base model property. </summary>
        public string BaseModelProp { get; }
    }
}
