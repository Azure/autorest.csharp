// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Response containing suggestion query results from an index. </summary>
    public partial class SuggestDocumentsResult
    {
        /// <summary> Initializes a new instance of <see cref="SuggestDocumentsResult"/>. </summary>
        /// <param name="results"> The sequence of results returned by the query. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="results"/> is null. </exception>
        internal SuggestDocumentsResult(IEnumerable<SuggestResult> results)
        {
            Argument.AssertNotNull(results, nameof(results));

            Results = results.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="SuggestDocumentsResult"/>. </summary>
        /// <param name="results"> The sequence of results returned by the query. </param>
        /// <param name="coverage"> A value indicating the percentage of the index that was included in the query, or null if minimumCoverage was not set in the request. </param>
        internal SuggestDocumentsResult(IReadOnlyList<SuggestResult> results, double? coverage)
        {
            Results = results;
            Coverage = coverage;
        }

        /// <summary> The sequence of results returned by the query. </summary>
        public IReadOnlyList<SuggestResult> Results { get; }
        /// <summary> A value indicating the percentage of the index that was included in the query, or null if minimumCoverage was not set in the request. </summary>
        public double? Coverage { get; }
    }
}
