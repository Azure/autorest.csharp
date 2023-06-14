// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Response containing the status of operations for all documents in the indexing request. </summary>
    public partial class IndexDocumentsResult
    {
        /// <summary> Initializes a new instance of IndexDocumentsResult. </summary>
        /// <param name="results"> The list of status information for each document in the indexing request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="results"/> is null. </exception>
        internal IndexDocumentsResult(IEnumerable<IndexingResult> results)
        {
            Argument.AssertNotNull(results, nameof(results));

            Results = results.ToList();
        }

        /// <summary> Initializes a new instance of IndexDocumentsResult. </summary>
        /// <param name="results"> The list of status information for each document in the indexing request. </param>
        internal IndexDocumentsResult(IReadOnlyList<IndexingResult> results)
        {
            Results = results;
        }

        /// <summary> The list of status information for each document in the indexing request. </summary>
        public IReadOnlyList<IndexingResult> Results { get; }
    }
}
