// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Response containing search results from an index. </summary>
    public partial class SearchDocumentsResult
    {
        /// <summary> The total count of results found by the search operation, or null if the count was not requested. If present, the count may be greater than the number of results in this response. This can happen if you use the $top or $skip parameters, or if Azure Cognitive Search can&apos;t return all the requested documents in a single Search response. </summary>
        public long? Count { get; internal set; }
        /// <summary> A value indicating the percentage of the index that was included in the query, or null if minimumCoverage was not specified in the request. </summary>
        public double? Coverage { get; internal set; }
        /// <summary> The facet query results for the search operation, organized as a collection of buckets for each faceted field; null if the query did not include any facet expressions. </summary>
        public IDictionary<string, ICollection<FacetResult>> Facets { get; internal set; }
        /// <summary> Parameters for filtering, sorting, faceting, paging, and other search query behaviors. </summary>
        public SearchRequest NextPageParameters { get; internal set; }
        /// <summary> The sequence of results returned by the query. </summary>
        public ICollection<SearchResult> Results { get; internal set; }
        /// <summary> Continuation URL returned when Azure Cognitive Search can&apos;t return all the requested results in a single Search response. You can use this URL to formulate another GET or POST Search request to get the next part of the search response. Make sure to use the same verb (GET or POST) as the request that produced this response. </summary>
        public string NextLink { get; internal set; }
    }
}
