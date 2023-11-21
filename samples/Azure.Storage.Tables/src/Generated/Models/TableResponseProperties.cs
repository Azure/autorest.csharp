// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.Storage.Tables.Models
{
    /// <summary> The properties for the table response. </summary>
    public partial class TableResponseProperties
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

        /// <summary> Initializes a new instance of <see cref="TableResponseProperties"/>. </summary>
        internal TableResponseProperties()
        {
        }

        /// <summary> Initializes a new instance of <see cref="TableResponseProperties"/>. </summary>
        /// <param name="tableName"> The name of the table. </param>
        /// <param name="odataType"> The odata type of the table. </param>
        /// <param name="odataId"> The id of the table. </param>
        /// <param name="odataEditLink"> The edit link of the table. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal TableResponseProperties(string tableName, string odataType, string odataId, string odataEditLink, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            TableName = tableName;
            OdataType = odataType;
            OdataId = odataId;
            OdataEditLink = odataEditLink;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The name of the table. </summary>
        public string TableName { get; }
        /// <summary> The odata type of the table. </summary>
        public string OdataType { get; }
        /// <summary> The id of the table. </summary>
        public string OdataId { get; }
        /// <summary> The edit link of the table. </summary>
        public string OdataEditLink { get; }
    }
}
