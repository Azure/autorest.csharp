// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Versioning.TypeChangedFrom.Models
{
    /// <summary> The TestModel. </summary>
    public partial class TestModel
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

        /// <summary> Initializes a new instance of <see cref="TestModel"/>. </summary>
        /// <param name="prop"></param>
        /// <param name="changedProp"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="prop"/> or <paramref name="changedProp"/> is null. </exception>
        public TestModel(string prop, string changedProp)
        {
            Argument.AssertNotNull(prop, nameof(prop));
            Argument.AssertNotNull(changedProp, nameof(changedProp));

            Prop = prop;
            ChangedProp = changedProp;
        }

        /// <summary> Initializes a new instance of <see cref="TestModel"/>. </summary>
        /// <param name="prop"></param>
        /// <param name="changedProp"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal TestModel(string prop, string changedProp, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Prop = prop;
            ChangedProp = changedProp;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="TestModel"/> for deserialization. </summary>
        internal TestModel()
        {
        }

        /// <summary> Gets or sets the prop. </summary>
        public string Prop { get; set; }
        /// <summary> Gets or sets the changed prop. </summary>
        public string ChangedProp { get; set; }
    }
}
