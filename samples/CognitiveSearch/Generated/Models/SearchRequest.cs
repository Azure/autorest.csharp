// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Parameters for filtering, sorting, faceting, paging, and other search query behaviors. </summary>
    public partial class SearchRequest
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.SearchRequest
        ///
        /// </summary>
        public SearchRequest()
        {
            Facets = new ChangeTrackingList<string>();
            ScoringParameters = new ChangeTrackingList<string>();
        }

        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.SearchRequest
        ///
        /// </summary>
        /// <param name="includeTotalResultCount"> A value that specifies whether to fetch the total count of results. Default is false. Setting this value to true may have a performance impact. Note that the count returned is an approximation. </param>
        /// <param name="facets"> The list of facet expressions to apply to the search query. Each facet expression contains a field name, optionally followed by a comma-separated list of name:value pairs. </param>
        /// <param name="filter"> The OData $filter expression to apply to the search query. </param>
        /// <param name="highlightFields"> The comma-separated list of field names to use for hit highlights. Only searchable fields can be used for hit highlighting. </param>
        /// <param name="highlightPostTag"> A string tag that is appended to hit highlights. Must be set with highlightPreTag. Default is &lt;/em&gt;. </param>
        /// <param name="highlightPreTag"> A string tag that is prepended to hit highlights. Must be set with highlightPostTag. Default is &lt;em&gt;. </param>
        /// <param name="minimumCoverage"> A number between 0 and 100 indicating the percentage of the index that must be covered by a search query in order for the query to be reported as a success. This parameter can be useful for ensuring search availability even for services with only one replica. The default is 100. </param>
        /// <param name="orderBy"> The comma-separated list of OData $orderby expressions by which to sort the results. Each expression can be either a field name or a call to either the geo.distance() or the search.score() functions. Each expression can be followed by asc to indicate ascending, or desc to indicate descending. The default is ascending order. Ties will be broken by the match scores of documents. If no $orderby is specified, the default sort order is descending by document match score. There can be at most 32 $orderby clauses. </param>
        /// <param name="queryType"> A value that specifies the syntax of the search query. The default is 'simple'. Use 'full' if your query uses the Lucene query syntax. </param>
        /// <param name="scoringParameters"> The list of parameter values to be used in scoring functions (for example, referencePointParameter) using the format name-values. For example, if the scoring profile defines a function with a parameter called 'mylocation' the parameter string would be "mylocation--122.2,44.8" (without the quotes). </param>
        /// <param name="scoringProfile"> The name of a scoring profile to evaluate match scores for matching documents in order to sort the results. </param>
        /// <param name="searchText"> A full-text search query expression; Use "*" or omit this parameter to match all documents. </param>
        /// <param name="searchFields"> The comma-separated list of field names to which to scope the full-text search. When using fielded search (fieldName:searchExpression) in a full Lucene query, the field names of each fielded search expression take precedence over any field names listed in this parameter. </param>
        /// <param name="searchMode"> A value that specifies whether any or all of the search terms must be matched in order to count the document as a match. </param>
        /// <param name="select"> The comma-separated list of fields to retrieve. If unspecified, all fields marked as retrievable in the schema are included. </param>
        /// <param name="skip"> The number of search results to skip. This value cannot be greater than 100,000. If you need to scan documents in sequence, but cannot use skip due to this limitation, consider using orderby on a totally-ordered key and filter with a range query instead. </param>
        /// <param name="top"> The number of search results to retrieve. This can be used in conjunction with $skip to implement client-side paging of search results. If results are truncated due to server-side paging, the response will include a continuation token that can be used to issue another Search request for the next page of results. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SearchRequest(bool? includeTotalResultCount, IList<string> facets, string filter, string highlightFields, string highlightPostTag, string highlightPreTag, double? minimumCoverage, string orderBy, QueryType? queryType, IList<string> scoringParameters, string scoringProfile, string searchText, string searchFields, SearchMode? searchMode, string select, int? skip, int? top, Dictionary<string, BinaryData> rawData)
        {
            IncludeTotalResultCount = includeTotalResultCount;
            Facets = facets;
            Filter = filter;
            HighlightFields = highlightFields;
            HighlightPostTag = highlightPostTag;
            HighlightPreTag = highlightPreTag;
            MinimumCoverage = minimumCoverage;
            OrderBy = orderBy;
            QueryType = queryType;
            ScoringParameters = scoringParameters;
            ScoringProfile = scoringProfile;
            SearchText = searchText;
            SearchFields = searchFields;
            SearchMode = searchMode;
            Select = select;
            Skip = skip;
            Top = top;
            _rawData = rawData;
        }

        /// <summary> A value that specifies whether to fetch the total count of results. Default is false. Setting this value to true may have a performance impact. Note that the count returned is an approximation. </summary>
        public bool? IncludeTotalResultCount { get; set; }
        /// <summary> The list of facet expressions to apply to the search query. Each facet expression contains a field name, optionally followed by a comma-separated list of name:value pairs. </summary>
        public IList<string> Facets { get; }
        /// <summary> The OData $filter expression to apply to the search query. </summary>
        public string Filter { get; set; }
        /// <summary> The comma-separated list of field names to use for hit highlights. Only searchable fields can be used for hit highlighting. </summary>
        public string HighlightFields { get; set; }
        /// <summary> A string tag that is appended to hit highlights. Must be set with highlightPreTag. Default is &lt;/em&gt;. </summary>
        public string HighlightPostTag { get; set; }
        /// <summary> A string tag that is prepended to hit highlights. Must be set with highlightPostTag. Default is &lt;em&gt;. </summary>
        public string HighlightPreTag { get; set; }
        /// <summary> A number between 0 and 100 indicating the percentage of the index that must be covered by a search query in order for the query to be reported as a success. This parameter can be useful for ensuring search availability even for services with only one replica. The default is 100. </summary>
        public double? MinimumCoverage { get; set; }
        /// <summary> The comma-separated list of OData $orderby expressions by which to sort the results. Each expression can be either a field name or a call to either the geo.distance() or the search.score() functions. Each expression can be followed by asc to indicate ascending, or desc to indicate descending. The default is ascending order. Ties will be broken by the match scores of documents. If no $orderby is specified, the default sort order is descending by document match score. There can be at most 32 $orderby clauses. </summary>
        public string OrderBy { get; set; }
        /// <summary> A value that specifies the syntax of the search query. The default is 'simple'. Use 'full' if your query uses the Lucene query syntax. </summary>
        public QueryType? QueryType { get; set; }
        /// <summary> The list of parameter values to be used in scoring functions (for example, referencePointParameter) using the format name-values. For example, if the scoring profile defines a function with a parameter called 'mylocation' the parameter string would be "mylocation--122.2,44.8" (without the quotes). </summary>
        public IList<string> ScoringParameters { get; }
        /// <summary> The name of a scoring profile to evaluate match scores for matching documents in order to sort the results. </summary>
        public string ScoringProfile { get; set; }
        /// <summary> A full-text search query expression; Use "*" or omit this parameter to match all documents. </summary>
        public string SearchText { get; set; }
        /// <summary> The comma-separated list of field names to which to scope the full-text search. When using fielded search (fieldName:searchExpression) in a full Lucene query, the field names of each fielded search expression take precedence over any field names listed in this parameter. </summary>
        public string SearchFields { get; set; }
        /// <summary> A value that specifies whether any or all of the search terms must be matched in order to count the document as a match. </summary>
        public SearchMode? SearchMode { get; set; }
        /// <summary> The comma-separated list of fields to retrieve. If unspecified, all fields marked as retrievable in the schema are included. </summary>
        public string Select { get; set; }
        /// <summary> The number of search results to skip. This value cannot be greater than 100,000. If you need to scan documents in sequence, but cannot use skip due to this limitation, consider using orderby on a totally-ordered key and filter with a range query instead. </summary>
        public int? Skip { get; set; }
        /// <summary> The number of search results to retrieve. This can be used in conjunction with $skip to implement client-side paging of search results. If results are truncated due to server-side paging, the response will include a continuation token that can be used to issue another Search request for the next page of results. </summary>
        public int? Top { get; set; }
    }
}
