// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Pagination.Models
{
    /// <summary> The LedgerEntry. </summary>
    public partial class LedgerEntry
    {
        /// <summary> Initializes a new instance of LedgerEntry. </summary>
        /// <param name="contents"> Contents of the ledger entry. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="contents"/> is null. </exception>
        internal LedgerEntry(string contents)
        {
            Argument.AssertNotNull(contents, nameof(contents));

            Contents = contents;
        }

        /// <summary> Initializes a new instance of LedgerEntry. </summary>
        /// <param name="contents"> Contents of the ledger entry. </param>
        /// <param name="collectionId"></param>
        /// <param name="transactionId"></param>
        internal LedgerEntry(string contents, string collectionId, string transactionId)
        {
            Contents = contents;
            CollectionId = collectionId;
            TransactionId = transactionId;
        }

        /// <summary> Contents of the ledger entry. </summary>
        public string Contents { get; }
        /// <summary> Gets the collection id. </summary>
        public string CollectionId { get; }
        /// <summary> Gets the transaction id. </summary>
        public string TransactionId { get; }
    }
}
