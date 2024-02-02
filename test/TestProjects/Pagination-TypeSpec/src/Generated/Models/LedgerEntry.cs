// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Pagination.Models
{
    /// <summary> The LedgerEntry. </summary>
    public partial class LedgerEntry
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

        /// <summary> Initializes a new instance of <see cref="LedgerEntry"/>. </summary>
        /// <param name="contents"> Contents of the ledger entry. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="contents"/> is null. </exception>
        internal LedgerEntry(string contents)
        {
            Argument.AssertNotNull(contents, nameof(contents));

            Contents = contents;
        }

        /// <summary> Initializes a new instance of <see cref="LedgerEntry"/>. </summary>
        /// <param name="contents"> Contents of the ledger entry. </param>
        /// <param name="collectionId"></param>
        /// <param name="transactionId"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal LedgerEntry(string contents, string collectionId, string transactionId, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Contents = contents;
            CollectionId = collectionId;
            TransactionId = transactionId;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="LedgerEntry"/> for deserialization. </summary>
        internal LedgerEntry()
        {
        }

        /// <summary> Contents of the ledger entry. </summary>
        public string Contents { get; }
        /// <summary> Gets the collection id. </summary>
        public string CollectionId { get; }
        /// <summary> Gets the transaction id. </summary>
        public string TransactionId { get; }
    }
}
