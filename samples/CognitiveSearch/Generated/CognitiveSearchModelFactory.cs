// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace CognitiveSearch.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class CognitiveSearchModelFactory
    {
        /// <summary> Initializes a new instance of SearchDocumentsResult. </summary>
        /// <param name="count"> The total count of results found by the search operation, or null if the count was not requested. If present, the count may be greater than the number of results in this response. This can happen if you use the $top or $skip parameters, or if Azure Cognitive Search can't return all the requested documents in a single Search response. </param>
        /// <param name="coverage"> A value indicating the percentage of the index that was included in the query, or null if minimumCoverage was not specified in the request. </param>
        /// <param name="facets"> The facet query results for the search operation, organized as a collection of buckets for each faceted field; null if the query did not include any facet expressions. </param>
        /// <param name="nextPageParameters"> Continuation JSON payload returned when Azure Cognitive Search can't return all the requested results in a single Search response. You can use this JSON along with @odata.nextLink to formulate another POST Search request to get the next part of the search response. </param>
        /// <param name="results"> The sequence of results returned by the query. </param>
        /// <param name="nextLink"> Continuation URL returned when Azure Cognitive Search can't return all the requested results in a single Search response. You can use this URL to formulate another GET or POST Search request to get the next part of the search response. Make sure to use the same verb (GET or POST) as the request that produced this response. </param>
        /// <returns> A new <see cref="Models.SearchDocumentsResult"/> instance for mocking. </returns>
        public static SearchDocumentsResult SearchDocumentsResult(long? count = null, double? coverage = null, IReadOnlyDictionary<string, IList<FacetResult>> facets = null, SearchRequest nextPageParameters = null, IEnumerable<SearchResult> results = null, string nextLink = null)
        {
            facets ??= new Dictionary<string, IList<FacetResult>>();
            results ??= new List<SearchResult>();

            return new SearchDocumentsResult(count, coverage, facets, nextPageParameters, results?.ToList(), nextLink);
        }

        /// <summary> Initializes a new instance of FacetResult. </summary>
        /// <param name="count"> The approximate count of documents falling within the bucket described by this facet. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        /// <returns> A new <see cref="Models.FacetResult"/> instance for mocking. </returns>
        public static FacetResult FacetResult(long? count = null, IReadOnlyDictionary<string, object> additionalProperties = null)
        {
            additionalProperties ??= new Dictionary<string, object>();

            return new FacetResult(count, additionalProperties);
        }

        /// <summary> Initializes a new instance of SearchResult. </summary>
        /// <param name="score"> The relevance score of the document compared to other documents returned by the query. </param>
        /// <param name="highlights"> Text fragments from the document that indicate the matching search terms, organized by each applicable field; null if hit highlighting was not enabled for the query. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        /// <returns> A new <see cref="Models.SearchResult"/> instance for mocking. </returns>
        public static SearchResult SearchResult(double score = default, IReadOnlyDictionary<string, IList<string>> highlights = null, IReadOnlyDictionary<string, object> additionalProperties = null)
        {
            highlights ??= new Dictionary<string, IList<string>>();
            additionalProperties ??= new Dictionary<string, object>();

            return new SearchResult(score, highlights, additionalProperties);
        }

        /// <summary> Initializes a new instance of SuggestDocumentsResult. </summary>
        /// <param name="results"> The sequence of results returned by the query. </param>
        /// <param name="coverage"> A value indicating the percentage of the index that was included in the query, or null if minimumCoverage was not set in the request. </param>
        /// <returns> A new <see cref="Models.SuggestDocumentsResult"/> instance for mocking. </returns>
        public static SuggestDocumentsResult SuggestDocumentsResult(IEnumerable<SuggestResult> results = null, double? coverage = null)
        {
            results ??= new List<SuggestResult>();

            return new SuggestDocumentsResult(results?.ToList(), coverage);
        }

        /// <summary> Initializes a new instance of SuggestResult. </summary>
        /// <param name="text"> The text of the suggestion result. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        /// <returns> A new <see cref="Models.SuggestResult"/> instance for mocking. </returns>
        public static SuggestResult SuggestResult(string text = null, IReadOnlyDictionary<string, object> additionalProperties = null)
        {
            additionalProperties ??= new Dictionary<string, object>();

            return new SuggestResult(text, additionalProperties);
        }

        /// <summary> Initializes a new instance of SuggestRequest. </summary>
        /// <param name="filter"> An OData expression that filters the documents considered for suggestions. </param>
        /// <param name="useFuzzyMatching"> A value indicating whether to use fuzzy matching for the suggestion query. Default is false. When set to true, the query will find suggestions even if there's a substituted or missing character in the search text. While this provides a better experience in some scenarios, it comes at a performance cost as fuzzy suggestion searches are slower and consume more resources. </param>
        /// <param name="highlightPostTag"> A string tag that is appended to hit highlights. Must be set with highlightPreTag. If omitted, hit highlighting of suggestions is disabled. </param>
        /// <param name="highlightPreTag"> A string tag that is prepended to hit highlights. Must be set with highlightPostTag. If omitted, hit highlighting of suggestions is disabled. </param>
        /// <param name="minimumCoverage"> A number between 0 and 100 indicating the percentage of the index that must be covered by a suggestion query in order for the query to be reported as a success. This parameter can be useful for ensuring search availability even for services with only one replica. The default is 80. </param>
        /// <param name="orderBy"> The comma-separated list of OData $orderby expressions by which to sort the results. Each expression can be either a field name or a call to either the geo.distance() or the search.score() functions. Each expression can be followed by asc to indicate ascending, or desc to indicate descending. The default is ascending order. Ties will be broken by the match scores of documents. If no $orderby is specified, the default sort order is descending by document match score. There can be at most 32 $orderby clauses. </param>
        /// <param name="searchText"> The search text to use to suggest documents. Must be at least 1 character, and no more than 100 characters. </param>
        /// <param name="searchFields"> The comma-separated list of field names to search for the specified search text. Target fields must be included in the specified suggester. </param>
        /// <param name="select"> The comma-separated list of fields to retrieve. If unspecified, only the key field will be included in the results. </param>
        /// <param name="suggesterName"> The name of the suggester as specified in the suggesters collection that's part of the index definition. </param>
        /// <param name="top"> The number of suggestions to retrieve. This must be a value between 1 and 100. The default is 5. </param>
        /// <returns> A new <see cref="Models.SuggestRequest"/> instance for mocking. </returns>
        public static SuggestRequest SuggestRequest(string filter = null, bool? useFuzzyMatching = null, string highlightPostTag = null, string highlightPreTag = null, double? minimumCoverage = null, string orderBy = null, string searchText = null, string searchFields = null, string select = null, string suggesterName = null, int? top = null)
        {
            return new SuggestRequest(filter, useFuzzyMatching, highlightPostTag, highlightPreTag, minimumCoverage, orderBy, searchText, searchFields, select, suggesterName, top);
        }

        /// <summary> Initializes a new instance of IndexDocumentsResult. </summary>
        /// <param name="results"> The list of status information for each document in the indexing request. </param>
        /// <returns> A new <see cref="Models.IndexDocumentsResult"/> instance for mocking. </returns>
        public static IndexDocumentsResult IndexDocumentsResult(IEnumerable<IndexingResult> results = null)
        {
            results ??= new List<IndexingResult>();

            return new IndexDocumentsResult(results?.ToList());
        }

        /// <summary> Initializes a new instance of IndexingResult. </summary>
        /// <param name="key"> The key of a document that was in the indexing request. </param>
        /// <param name="errorMessage"> The error message explaining why the indexing operation failed for the document identified by the key; null if indexing succeeded. </param>
        /// <param name="succeeded"> A value indicating whether the indexing operation succeeded for the document identified by the key. </param>
        /// <param name="statusCode"> The status code of the indexing operation. Possible values include: 200 for a successful update or delete, 201 for successful document creation, 400 for a malformed input document, 404 for document not found, 409 for a version conflict, 422 when the index is temporarily unavailable, or 503 for when the service is too busy. </param>
        /// <returns> A new <see cref="Models.IndexingResult"/> instance for mocking. </returns>
        public static IndexingResult IndexingResult(string key = null, string errorMessage = null, bool succeeded = default, int statusCode = default)
        {
            return new IndexingResult(key, errorMessage, succeeded, statusCode);
        }

        /// <summary> Initializes a new instance of AutocompleteResult. </summary>
        /// <param name="coverage"> A value indicating the percentage of the index that was considered by the autocomplete request, or null if minimumCoverage was not specified in the request. </param>
        /// <param name="results"> The list of returned Autocompleted items. </param>
        /// <returns> A new <see cref="Models.AutocompleteResult"/> instance for mocking. </returns>
        public static AutocompleteResult AutocompleteResult(double? coverage = null, IEnumerable<AutocompleteItem> results = null)
        {
            results ??= new List<AutocompleteItem>();

            return new AutocompleteResult(coverage, results?.ToList());
        }

        /// <summary> Initializes a new instance of AutocompleteItem. </summary>
        /// <param name="text"> The completed term. </param>
        /// <param name="queryPlusText"> The query along with the completed term. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> or <paramref name="queryPlusText"/> is null. </exception>
        /// <returns> A new <see cref="Models.AutocompleteItem"/> instance for mocking. </returns>
        public static AutocompleteItem AutocompleteItem(string text = null, string queryPlusText = null)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            if (queryPlusText == null)
            {
                throw new ArgumentNullException(nameof(queryPlusText));
            }

            return new AutocompleteItem(text, queryPlusText);
        }

        /// <summary> Initializes a new instance of AutocompleteRequest. </summary>
        /// <param name="searchText"> The search text on which to base autocomplete results. </param>
        /// <param name="autocompleteMode"> Specifies the mode for Autocomplete. The default is 'oneTerm'. Use 'twoTerms' to get shingles and 'oneTermWithContext' to use the current context while producing auto-completed terms. </param>
        /// <param name="filter"> An OData expression that filters the documents used to produce completed terms for the Autocomplete result. </param>
        /// <param name="useFuzzyMatching"> A value indicating whether to use fuzzy matching for the autocomplete query. Default is false. When set to true, the query will autocomplete terms even if there's a substituted or missing character in the search text. While this provides a better experience in some scenarios, it comes at a performance cost as fuzzy autocomplete queries are slower and consume more resources. </param>
        /// <param name="highlightPostTag"> A string tag that is appended to hit highlights. Must be set with highlightPreTag. If omitted, hit highlighting is disabled. </param>
        /// <param name="highlightPreTag"> A string tag that is prepended to hit highlights. Must be set with highlightPostTag. If omitted, hit highlighting is disabled. </param>
        /// <param name="minimumCoverage"> A number between 0 and 100 indicating the percentage of the index that must be covered by an autocomplete query in order for the query to be reported as a success. This parameter can be useful for ensuring search availability even for services with only one replica. The default is 80. </param>
        /// <param name="searchFields"> The comma-separated list of field names to consider when querying for auto-completed terms. Target fields must be included in the specified suggester. </param>
        /// <param name="suggesterName"> The name of the suggester as specified in the suggesters collection that's part of the index definition. </param>
        /// <param name="top"> The number of auto-completed terms to retrieve. This must be a value between 1 and 100. The default is 5. </param>
        /// <returns> A new <see cref="Models.AutocompleteRequest"/> instance for mocking. </returns>
        public static AutocompleteRequest AutocompleteRequest(string searchText = null, AutocompleteMode? autocompleteMode = null, string filter = null, bool? useFuzzyMatching = null, string highlightPostTag = null, string highlightPreTag = null, double? minimumCoverage = null, string searchFields = null, string suggesterName = null, int? top = null)
        {
            return new AutocompleteRequest(searchText, autocompleteMode, filter, useFuzzyMatching, highlightPostTag, highlightPreTag, minimumCoverage, searchFields, suggesterName, top);
        }

        /// <summary> Initializes a new instance of ListDataSourcesResult. </summary>
        /// <param name="dataSources"> The datasources in the Search service. </param>
        /// <returns> A new <see cref="Models.ListDataSourcesResult"/> instance for mocking. </returns>
        public static ListDataSourcesResult ListDataSourcesResult(IEnumerable<DataSource> dataSources = null)
        {
            dataSources ??= new List<DataSource>();

            return new ListDataSourcesResult(dataSources?.ToList());
        }

        /// <summary> Initializes a new instance of ListIndexersResult. </summary>
        /// <param name="indexers"> The indexers in the Search service. </param>
        /// <returns> A new <see cref="Models.ListIndexersResult"/> instance for mocking. </returns>
        public static ListIndexersResult ListIndexersResult(IEnumerable<Indexer> indexers = null)
        {
            indexers ??= new List<Indexer>();

            return new ListIndexersResult(indexers?.ToList());
        }

        /// <summary> Initializes a new instance of IndexerExecutionInfo. </summary>
        /// <param name="status"> Overall indexer status. </param>
        /// <param name="lastResult"> The result of the most recent or an in-progress indexer execution. </param>
        /// <param name="executionHistory"> History of the recent indexer executions, sorted in reverse chronological order. </param>
        /// <param name="limits"> The execution limits for the indexer. </param>
        /// <returns> A new <see cref="Models.IndexerExecutionInfo"/> instance for mocking. </returns>
        public static IndexerExecutionInfo IndexerExecutionInfo(IndexerStatus status = default, IndexerExecutionResult lastResult = null, IEnumerable<IndexerExecutionResult> executionHistory = null, IndexerLimits limits = null)
        {
            executionHistory ??= new List<IndexerExecutionResult>();

            return new IndexerExecutionInfo(status, lastResult, executionHistory?.ToList(), limits);
        }

        /// <summary> Initializes a new instance of IndexerExecutionResult. </summary>
        /// <param name="status"> The outcome of this indexer execution. </param>
        /// <param name="errorMessage"> The error message indicating the top-level error, if any. </param>
        /// <param name="startTime"> The start time of this indexer execution. </param>
        /// <param name="endTime"> The end time of this indexer execution, if the execution has already completed. </param>
        /// <param name="errors"> The item-level indexing errors. </param>
        /// <param name="warnings"> The item-level indexing warnings. </param>
        /// <param name="itemCount"> The number of items that were processed during this indexer execution. This includes both successfully processed items and items where indexing was attempted but failed. </param>
        /// <param name="failedItemCount"> The number of items that failed to be indexed during this indexer execution. </param>
        /// <param name="initialTrackingState"> Change tracking state with which an indexer execution started. </param>
        /// <param name="finalTrackingState"> Change tracking state with which an indexer execution finished. </param>
        /// <returns> A new <see cref="Models.IndexerExecutionResult"/> instance for mocking. </returns>
        public static IndexerExecutionResult IndexerExecutionResult(IndexerExecutionStatus status = default, string errorMessage = null, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, IEnumerable<ItemError> errors = null, IEnumerable<ItemWarning> warnings = null, int itemCount = default, int failedItemCount = default, string initialTrackingState = null, string finalTrackingState = null)
        {
            errors ??= new List<ItemError>();
            warnings ??= new List<ItemWarning>();

            return new IndexerExecutionResult(status, errorMessage, startTime, endTime, errors?.ToList(), warnings?.ToList(), itemCount, failedItemCount, initialTrackingState, finalTrackingState);
        }

        /// <summary> Initializes a new instance of ItemError. </summary>
        /// <param name="key"> The key of the item for which indexing failed. </param>
        /// <param name="errorMessage"> The message describing the error that occurred while processing the item. </param>
        /// <param name="statusCode"> The status code indicating why the indexing operation failed. Possible values include: 400 for a malformed input document, 404 for document not found, 409 for a version conflict, 422 when the index is temporarily unavailable, or 503 for when the service is too busy. </param>
        /// <param name="name"> The name of the source at which the error originated. For example, this could refer to a particular skill in the attached skillset. This may not be always available. </param>
        /// <param name="details"> Additional, verbose details about the error to assist in debugging the indexer. This may not be always available. </param>
        /// <param name="documentationLink"> A link to a troubleshooting guide for these classes of errors. This may not be always available. </param>
        /// <returns> A new <see cref="Models.ItemError"/> instance for mocking. </returns>
        public static ItemError ItemError(string key = null, string errorMessage = null, int statusCode = default, string name = null, string details = null, string documentationLink = null)
        {
            return new ItemError(key, errorMessage, statusCode, name, details, documentationLink);
        }

        /// <summary> Initializes a new instance of ItemWarning. </summary>
        /// <param name="key"> The key of the item which generated a warning. </param>
        /// <param name="message"> The message describing the warning that occurred while processing the item. </param>
        /// <param name="name"> The name of the source at which the warning originated. For example, this could refer to a particular skill in the attached skillset. This may not be always available. </param>
        /// <param name="details"> Additional, verbose details about the warning to assist in debugging the indexer. This may not be always available. </param>
        /// <param name="documentationLink"> A link to a troubleshooting guide for these classes of warnings. This may not be always available. </param>
        /// <returns> A new <see cref="Models.ItemWarning"/> instance for mocking. </returns>
        public static ItemWarning ItemWarning(string key = null, string message = null, string name = null, string details = null, string documentationLink = null)
        {
            return new ItemWarning(key, message, name, details, documentationLink);
        }

        /// <summary> Initializes a new instance of IndexerLimits. </summary>
        /// <param name="maxRunTime"> The maximum duration that the indexer is permitted to run for one execution. </param>
        /// <param name="maxDocumentExtractionSize"> The maximum size of a document, in bytes, which will be considered valid for indexing. </param>
        /// <param name="maxDocumentContentCharactersToExtract"> The maximum number of characters that will be extracted from a document picked up for indexing. </param>
        /// <returns> A new <see cref="Models.IndexerLimits"/> instance for mocking. </returns>
        public static IndexerLimits IndexerLimits(TimeSpan? maxRunTime = null, long? maxDocumentExtractionSize = null, long? maxDocumentContentCharactersToExtract = null)
        {
            return new IndexerLimits(maxRunTime, maxDocumentExtractionSize, maxDocumentContentCharactersToExtract);
        }

        /// <summary> Initializes a new instance of ListSkillsetsResult. </summary>
        /// <param name="skillsets"> The skillsets defined in the Search service. </param>
        /// <returns> A new <see cref="Models.ListSkillsetsResult"/> instance for mocking. </returns>
        public static ListSkillsetsResult ListSkillsetsResult(IEnumerable<Skillset> skillsets = null)
        {
            skillsets ??= new List<Skillset>();

            return new ListSkillsetsResult(skillsets?.ToList());
        }

        /// <summary> Initializes a new instance of SynonymMap. </summary>
        /// <param name="name"> The name of the synonym map. </param>
        /// <param name="format"> The format of the synonym map. Only the 'solr' format is currently supported. </param>
        /// <param name="synonyms"> A series of synonym rules in the specified synonym map format. The rules must be separated by newlines. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your data when you want full assurance that no one, not even Microsoft, can decrypt your data in Azure Cognitive Search. Once you have encrypted your data, it will always remain encrypted. Azure Cognitive Search will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your data will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="eTag"> The ETag of the synonym map. </param>
        /// <returns> A new <see cref="Models.SynonymMap"/> instance for mocking. </returns>
        public static SynonymMap SynonymMap(string name = null, SynonymMapFormat format = default, string synonyms = null, EncryptionKey encryptionKey = null, string eTag = null)
        {
            return new SynonymMap(name, format, synonyms, encryptionKey, eTag);
        }

        /// <summary> Initializes a new instance of ListSynonymMapsResult. </summary>
        /// <param name="synonymMaps"> The synonym maps in the Search service. </param>
        /// <returns> A new <see cref="Models.ListSynonymMapsResult"/> instance for mocking. </returns>
        public static ListSynonymMapsResult ListSynonymMapsResult(IEnumerable<SynonymMap> synonymMaps = null)
        {
            synonymMaps ??= new List<SynonymMap>();

            return new ListSynonymMapsResult(synonymMaps?.ToList());
        }

        /// <summary> Initializes a new instance of ListIndexesResult. </summary>
        /// <param name="indexes"> The indexes in the Search service. </param>
        /// <returns> A new <see cref="Models.ListIndexesResult"/> instance for mocking. </returns>
        public static ListIndexesResult ListIndexesResult(IEnumerable<Index> indexes = null)
        {
            indexes ??= new List<Index>();

            return new ListIndexesResult(indexes?.ToList());
        }

        /// <summary> Initializes a new instance of GetIndexStatisticsResult. </summary>
        /// <param name="documentCount"> The number of documents in the index. </param>
        /// <param name="storageSize"> The amount of storage in bytes consumed by the index. </param>
        /// <returns> A new <see cref="Models.GetIndexStatisticsResult"/> instance for mocking. </returns>
        public static GetIndexStatisticsResult GetIndexStatisticsResult(long documentCount = default, long storageSize = default)
        {
            return new GetIndexStatisticsResult(documentCount, storageSize);
        }

        /// <summary> Initializes a new instance of AnalyzeRequest. </summary>
        /// <param name="text"> The text to break into tokens. </param>
        /// <param name="analyzer"> The name of the analyzer to use to break the given text. If this parameter is not specified, you must specify a tokenizer instead. The tokenizer and analyzer parameters are mutually exclusive. </param>
        /// <param name="tokenizer"> The name of the tokenizer to use to break the given text. If this parameter is not specified, you must specify an analyzer instead. The tokenizer and analyzer parameters are mutually exclusive. </param>
        /// <param name="tokenFilters"> An optional list of token filters to use when breaking the given text. This parameter can only be set when using the tokenizer parameter. </param>
        /// <param name="charFilters"> An optional list of character filters to use when breaking the given text. This parameter can only be set when using the tokenizer parameter. </param>
        /// <returns> A new <see cref="Models.AnalyzeRequest"/> instance for mocking. </returns>
        public static AnalyzeRequest AnalyzeRequest(string text = null, AnalyzerName? analyzer = null, TokenizerName? tokenizer = null, IEnumerable<TokenFilterName> tokenFilters = null, IEnumerable<CharFilterName> charFilters = null)
        {
            tokenFilters ??= new List<TokenFilterName>();
            charFilters ??= new List<CharFilterName>();

            return new AnalyzeRequest(text, analyzer, tokenizer, tokenFilters?.ToList(), charFilters?.ToList());
        }

        /// <summary> Initializes a new instance of AnalyzeResult. </summary>
        /// <param name="tokens"> The list of tokens returned by the analyzer specified in the request. </param>
        /// <returns> A new <see cref="Models.AnalyzeResult"/> instance for mocking. </returns>
        public static AnalyzeResult AnalyzeResult(IEnumerable<TokenInfo> tokens = null)
        {
            tokens ??= new List<TokenInfo>();

            return new AnalyzeResult(tokens?.ToList());
        }

        /// <summary> Initializes a new instance of TokenInfo. </summary>
        /// <param name="token"> The token returned by the analyzer. </param>
        /// <param name="startOffset"> The index of the first character of the token in the input text. </param>
        /// <param name="endOffset"> The index of the last character of the token in the input text. </param>
        /// <param name="position"> The position of the token in the input text relative to other tokens. The first token in the input text has position 0, the next has position 1, and so on. Depending on the analyzer used, some tokens might have the same position, for example if they are synonyms of each other. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="token"/> is null. </exception>
        /// <returns> A new <see cref="Models.TokenInfo"/> instance for mocking. </returns>
        public static TokenInfo TokenInfo(string token = null, int startOffset = default, int endOffset = default, int position = default)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            return new TokenInfo(token, startOffset, endOffset, position);
        }

        /// <summary> Initializes a new instance of ServiceStatistics. </summary>
        /// <param name="counters"> Service level resource counters. </param>
        /// <param name="limits"> Service level general limits. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="counters"/> or <paramref name="limits"/> is null. </exception>
        /// <returns> A new <see cref="Models.ServiceStatistics"/> instance for mocking. </returns>
        public static ServiceStatistics ServiceStatistics(ServiceCounters counters = null, ServiceLimits limits = null)
        {
            if (counters == null)
            {
                throw new ArgumentNullException(nameof(counters));
            }
            if (limits == null)
            {
                throw new ArgumentNullException(nameof(limits));
            }

            return new ServiceStatistics(counters, limits);
        }

        /// <summary> Initializes a new instance of ServiceCounters. </summary>
        /// <param name="documentCounter"> Total number of documents across all indexes in the service. </param>
        /// <param name="indexCounter"> Total number of indexes. </param>
        /// <param name="indexerCounter"> Total number of indexers. </param>
        /// <param name="dataSourceCounter"> Total number of data sources. </param>
        /// <param name="storageSizeCounter"> Total size of used storage in bytes. </param>
        /// <param name="synonymMapCounter"> Total number of synonym maps. </param>
        /// <param name="skillsetCounter"> Total number of skillsets. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="documentCounter"/>, <paramref name="indexCounter"/>, <paramref name="indexerCounter"/>, <paramref name="dataSourceCounter"/>, <paramref name="storageSizeCounter"/>, <paramref name="synonymMapCounter"/> or <paramref name="skillsetCounter"/> is null. </exception>
        /// <returns> A new <see cref="Models.ServiceCounters"/> instance for mocking. </returns>
        public static ServiceCounters ServiceCounters(ResourceCounter documentCounter = null, ResourceCounter indexCounter = null, ResourceCounter indexerCounter = null, ResourceCounter dataSourceCounter = null, ResourceCounter storageSizeCounter = null, ResourceCounter synonymMapCounter = null, ResourceCounter skillsetCounter = null)
        {
            if (documentCounter == null)
            {
                throw new ArgumentNullException(nameof(documentCounter));
            }
            if (indexCounter == null)
            {
                throw new ArgumentNullException(nameof(indexCounter));
            }
            if (indexerCounter == null)
            {
                throw new ArgumentNullException(nameof(indexerCounter));
            }
            if (dataSourceCounter == null)
            {
                throw new ArgumentNullException(nameof(dataSourceCounter));
            }
            if (storageSizeCounter == null)
            {
                throw new ArgumentNullException(nameof(storageSizeCounter));
            }
            if (synonymMapCounter == null)
            {
                throw new ArgumentNullException(nameof(synonymMapCounter));
            }
            if (skillsetCounter == null)
            {
                throw new ArgumentNullException(nameof(skillsetCounter));
            }

            return new ServiceCounters(documentCounter, indexCounter, indexerCounter, dataSourceCounter, storageSizeCounter, synonymMapCounter, skillsetCounter);
        }

        /// <summary> Initializes a new instance of ResourceCounter. </summary>
        /// <param name="usage"> The resource usage amount. </param>
        /// <param name="quota"> The resource amount quota. </param>
        /// <returns> A new <see cref="Models.ResourceCounter"/> instance for mocking. </returns>
        public static ResourceCounter ResourceCounter(long usage = default, long? quota = null)
        {
            return new ResourceCounter(usage, quota);
        }

        /// <summary> Initializes a new instance of ServiceLimits. </summary>
        /// <param name="maxFieldsPerIndex"> The maximum allowed fields per index. </param>
        /// <param name="maxFieldNestingDepthPerIndex"> The maximum depth which you can nest sub-fields in an index, including the top-level complex field. For example, a/b/c has a nesting depth of 3. </param>
        /// <param name="maxComplexCollectionFieldsPerIndex"> The maximum number of fields of type Collection(Edm.ComplexType) allowed in an index. </param>
        /// <param name="maxComplexObjectsInCollectionsPerDocument"> The maximum number of objects in complex collections allowed per document. </param>
        /// <returns> A new <see cref="Models.ServiceLimits"/> instance for mocking. </returns>
        public static ServiceLimits ServiceLimits(int? maxFieldsPerIndex = null, int? maxFieldNestingDepthPerIndex = null, int? maxComplexCollectionFieldsPerIndex = null, int? maxComplexObjectsInCollectionsPerDocument = null)
        {
            return new ServiceLimits(maxFieldsPerIndex, maxFieldNestingDepthPerIndex, maxComplexCollectionFieldsPerIndex, maxComplexObjectsInCollectionsPerDocument);
        }
    }
}
