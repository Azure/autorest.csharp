// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Parameter group. </summary>
    public partial class AutocompleteOptions
    {
        /// <summary> Initializes a new instance of AutocompleteOptions. </summary>
        public AutocompleteOptions()
        {
            SearchFields = new ChangeTrackingList<string>();
        }

        /// <summary> Specifies the mode for Autocomplete. The default is 'oneTerm'. Use 'twoTerms' to get shingles and 'oneTermWithContext' to use the current context while producing auto-completed terms. </summary>
        public AutocompleteMode? AutocompleteMode { get; set; }
        /// <summary> An OData expression that filters the documents used to produce completed terms for the Autocomplete result. </summary>
        public string Filter { get; set; }
        /// <summary> A value indicating whether to use fuzzy matching for the autocomplete query. Default is false. When set to true, the query will find terms even if there's a substituted or missing character in the search text. While this provides a better experience in some scenarios, it comes at a performance cost as fuzzy autocomplete queries are slower and consume more resources. </summary>
        public bool? UseFuzzyMatching { get; set; }
        /// <summary> A string tag that is appended to hit highlights. Must be set with highlightPreTag. If omitted, hit highlighting is disabled. </summary>
        public string HighlightPostTag { get; set; }
        /// <summary> A string tag that is prepended to hit highlights. Must be set with highlightPostTag. If omitted, hit highlighting is disabled. </summary>
        public string HighlightPreTag { get; set; }
        /// <summary> A number between 0 and 100 indicating the percentage of the index that must be covered by an autocomplete query in order for the query to be reported as a success. This parameter can be useful for ensuring search availability even for services with only one replica. The default is 80. </summary>
        public double? MinimumCoverage { get; set; }
        /// <summary> The list of field names to consider when querying for auto-completed terms. Target fields must be included in the specified suggester. </summary>
        public IList<string> SearchFields { get; }
        /// <summary> The number of auto-completed terms to retrieve. This must be a value between 1 and 100. The default is 5. </summary>
        public int? Top { get; set; }
    }
}
