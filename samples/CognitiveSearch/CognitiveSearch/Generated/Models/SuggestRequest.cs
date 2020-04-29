// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    /// <summary> Parameters for filtering, sorting, fuzzy matching, and other suggestions query behaviors. </summary>
    public partial class SuggestRequest
    {
        /// <summary> Initializes a new instance of SuggestRequest. </summary>
        /// <param name="searchText"> The search text to use to suggest documents. Must be at least 1 character, and no more than 100 characters. </param>
        /// <param name="suggesterName"> The name of the suggester as specified in the suggesters collection that&apos;s part of the index definition. </param>
        public SuggestRequest(string searchText, string suggesterName)
        {
            if (searchText == null)
            {
                throw new ArgumentNullException(nameof(searchText));
            }
            if (suggesterName == null)
            {
                throw new ArgumentNullException(nameof(suggesterName));
            }

            SearchText = searchText;
            SuggesterName = suggesterName;
        }

        /// <summary> Initializes a new instance of SuggestRequest. </summary>
        /// <param name="filter"> An OData expression that filters the documents considered for suggestions. </param>
        /// <param name="useFuzzyMatching"> A value indicating whether to use fuzzy matching for the suggestion query. Default is false. When set to true, the query will find suggestions even if there&apos;s a substituted or missing character in the search text. While this provides a better experience in some scenarios, it comes at a performance cost as fuzzy suggestion searches are slower and consume more resources. </param>
        /// <param name="highlightPostTag"> A string tag that is appended to hit highlights. Must be set with highlightPreTag. If omitted, hit highlighting of suggestions is disabled. </param>
        /// <param name="highlightPreTag"> A string tag that is prepended to hit highlights. Must be set with highlightPostTag. If omitted, hit highlighting of suggestions is disabled. </param>
        /// <param name="minimumCoverage"> A number between 0 and 100 indicating the percentage of the index that must be covered by a suggestion query in order for the query to be reported as a success. This parameter can be useful for ensuring search availability even for services with only one replica. The default is 80. </param>
        /// <param name="orderBy"> The comma-separated list of OData $orderby expressions by which to sort the results. Each expression can be either a field name or a call to either the geo.distance() or the search.score() functions. Each expression can be followed by asc to indicate ascending, or desc to indicate descending. The default is ascending order. Ties will be broken by the match scores of documents. If no $orderby is specified, the default sort order is descending by document match score. There can be at most 32 $orderby clauses. </param>
        /// <param name="searchText"> The search text to use to suggest documents. Must be at least 1 character, and no more than 100 characters. </param>
        /// <param name="searchFields"> The comma-separated list of field names to search for the specified search text. Target fields must be included in the specified suggester. </param>
        /// <param name="select"> The comma-separated list of fields to retrieve. If unspecified, only the key field will be included in the results. </param>
        /// <param name="suggesterName"> The name of the suggester as specified in the suggesters collection that&apos;s part of the index definition. </param>
        /// <param name="top"> The number of suggestions to retrieve. This must be a value between 1 and 100. The default is 5. </param>
        internal SuggestRequest(string filter, bool? useFuzzyMatching, string highlightPostTag, string highlightPreTag, double? minimumCoverage, string orderBy, string searchText, string searchFields, string select, string suggesterName, int? top)
        {
            Filter = filter;
            UseFuzzyMatching = useFuzzyMatching;
            HighlightPostTag = highlightPostTag;
            HighlightPreTag = highlightPreTag;
            MinimumCoverage = minimumCoverage;
            OrderBy = orderBy;
            SearchText = searchText;
            SearchFields = searchFields;
            Select = select;
            SuggesterName = suggesterName;
            Top = top;
        }

        /// <summary> An OData expression that filters the documents considered for suggestions. </summary>
        public string Filter { get; set; }
        /// <summary> A value indicating whether to use fuzzy matching for the suggestion query. Default is false. When set to true, the query will find suggestions even if there&apos;s a substituted or missing character in the search text. While this provides a better experience in some scenarios, it comes at a performance cost as fuzzy suggestion searches are slower and consume more resources. </summary>
        public bool? UseFuzzyMatching { get; set; }
        /// <summary> A string tag that is appended to hit highlights. Must be set with highlightPreTag. If omitted, hit highlighting of suggestions is disabled. </summary>
        public string HighlightPostTag { get; set; }
        /// <summary> A string tag that is prepended to hit highlights. Must be set with highlightPostTag. If omitted, hit highlighting of suggestions is disabled. </summary>
        public string HighlightPreTag { get; set; }
        /// <summary> A number between 0 and 100 indicating the percentage of the index that must be covered by a suggestion query in order for the query to be reported as a success. This parameter can be useful for ensuring search availability even for services with only one replica. The default is 80. </summary>
        public double? MinimumCoverage { get; set; }
        /// <summary> The comma-separated list of OData $orderby expressions by which to sort the results. Each expression can be either a field name or a call to either the geo.distance() or the search.score() functions. Each expression can be followed by asc to indicate ascending, or desc to indicate descending. The default is ascending order. Ties will be broken by the match scores of documents. If no $orderby is specified, the default sort order is descending by document match score. There can be at most 32 $orderby clauses. </summary>
        public string OrderBy { get; set; }
        /// <summary> The search text to use to suggest documents. Must be at least 1 character, and no more than 100 characters. </summary>
        public string SearchText { get; set; }
        /// <summary> The comma-separated list of field names to search for the specified search text. Target fields must be included in the specified suggester. </summary>
        public string SearchFields { get; set; }
        /// <summary> The comma-separated list of fields to retrieve. If unspecified, only the key field will be included in the results. </summary>
        public string Select { get; set; }
        /// <summary> The name of the suggester as specified in the suggesters collection that&apos;s part of the index definition. </summary>
        public string SuggesterName { get; set; }
        /// <summary> The number of suggestions to retrieve. This must be a value between 1 and 100. The default is 5. </summary>
        public int? Top { get; set; }
    }
}
