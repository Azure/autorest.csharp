// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    /// <summary> Collection item model. </summary>
    public partial class CollectionItem
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

        /// <summary> Initializes a new instance of <see cref="CollectionItem"/>. </summary>
        /// <param name="requiredModelRecord"> Required model record. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredModelRecord"/> is null. </exception>
        public CollectionItem(IDictionary<string, RecordItem> requiredModelRecord)
        {
            Argument.AssertNotNull(requiredModelRecord, nameof(requiredModelRecord));

            RequiredModelRecord = requiredModelRecord;
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="CollectionItem"/>. </summary>
        /// <param name="requiredModelRecord"> Required model record. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CollectionItem(IDictionary<string, RecordItem> requiredModelRecord, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            RequiredModelRecord = requiredModelRecord;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CollectionItem"/> for deserialization. </summary>
        internal CollectionItem()
        {
        }

        /// <summary> Required model record. </summary>
        public IDictionary<string, RecordItem> RequiredModelRecord { get; }
    }
}
