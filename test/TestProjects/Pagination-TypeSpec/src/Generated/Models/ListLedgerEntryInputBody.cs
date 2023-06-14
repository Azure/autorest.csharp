// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Pagination.Models
{
    /// <summary> Type for input model body. </summary>
    public partial class ListLedgerEntryInputBody
    {
        /// <summary> Initializes a new instance of ListLedgerEntryInputBody. </summary>
        /// <param name="requiredString"> Required string. </param>
        /// <param name="requiredInt"> Required int. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredString"/> is null. </exception>
        public ListLedgerEntryInputBody(string requiredString, int requiredInt)
        {
            Argument.AssertNotNull(requiredString, nameof(requiredString));

            RequiredString = requiredString;
            RequiredInt = requiredInt;
        }

        /// <summary> Required string. </summary>
        public string RequiredString { get; }
        /// <summary> Required int. </summary>
        public int RequiredInt { get; }
    }
}
