// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> The result of Autocomplete query. </summary>
    public partial class AutocompleteResult
    {
        /// <summary> Initializes a new instance of AutocompleteResult. </summary>
        /// <param name="results"> The list of returned Autocompleted items. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="results"/> is null. </exception>
        internal AutocompleteResult(IEnumerable<AutocompleteItem> results)
        {
            Argument.AssertNotNull(results, nameof(results));

            Results = results.ToList();
        }

        /// <summary> Initializes a new instance of AutocompleteResult. </summary>
        /// <param name="coverage"> A value indicating the percentage of the index that was considered by the autocomplete request, or null if minimumCoverage was not specified in the request. </param>
        /// <param name="results"> The list of returned Autocompleted items. </param>
        internal AutocompleteResult(double? coverage, IReadOnlyList<AutocompleteItem> results)
        {
            Coverage = coverage;
            Results = results;
        }

        /// <summary> A value indicating the percentage of the index that was considered by the autocomplete request, or null if minimumCoverage was not specified in the request. </summary>
        public double? Coverage { get; }
        /// <summary> The list of returned Autocompleted items. </summary>
        public IReadOnlyList<AutocompleteItem> Results { get; }
    }
}
