// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Pagination
{
    /// <summary> The LedgerEntry. </summary>
    public partial class LedgerEntry
    {
        /// <summary> Initializes a new instance of LedgerEntry. </summary>
        /// <param name="contents"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="contents"/> is null. </exception>
        internal LedgerEntry(string contents)
        {
            Argument.AssertNotNull(contents, nameof(contents));

            Contents = contents;
        }
        /// <summary> Initializes a new instance of LedgerEntry. </summary>
        /// <param name="contents"></param>
        /// <param name="collectionId"></param>
        /// <param name="transactionId"></param>
        internal LedgerEntry(string contents, string collectionId, string transactionId)
        {
            Contents = contents;
            CollectionId = collectionId;
            TransactionId = transactionId;
        }

        public string Contents { get; }

        public string CollectionId { get; }

        public string TransactionId { get; }
    }
}
