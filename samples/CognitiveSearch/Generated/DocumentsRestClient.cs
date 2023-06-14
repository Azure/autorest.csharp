// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using CognitiveSearch.Models;

namespace CognitiveSearch
{
    internal partial class DocumentsRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _endpoint;
        private readonly string _indexName;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of DocumentsRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The endpoint URL of the search service. </param>
        /// <param name="indexName"> The name of the index. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/>, <paramref name="endpoint"/>, <paramref name="indexName"/> or <paramref name="apiVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="indexName"/> is an empty string, and was expected to be non-empty. </exception>
        public DocumentsRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint, string indexName, string apiVersion = "2019-05-06-Preview")
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            _indexName = indexName ?? throw new ArgumentNullException(nameof(indexName));
            _apiVersion = apiVersion ?? throw new ArgumentNullException(nameof(apiVersion));
        }

        internal HttpMessage CreateCountRequest(RequestOptions requestOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/indexes('", false);
            uri.AppendRaw(_indexName, true);
            uri.AppendRaw("')", false);
            uri.AppendPath("/docs/$count", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Queries the number of documents in the index. </summary>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<long>> CountAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateCountRequest(requestOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        long value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetInt64();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Queries the number of documents in the index. </summary>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<long> Count(RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateCountRequest(requestOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        long value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetInt64();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateSearchGetRequest(string searchText, SearchOptions searchOptions, RequestOptions requestOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/indexes('", false);
            uri.AppendRaw(_indexName, true);
            uri.AppendRaw("')", false);
            uri.AppendPath("/docs", false);
            if (searchText != null)
            {
                uri.AppendQuery("search", searchText, true);
            }
            if (searchOptions?.IncludeTotalResultCount != null)
            {
                uri.AppendQuery("$count", searchOptions.IncludeTotalResultCount.Value, true);
            }
            if (searchOptions?.Facets != null && Optional.IsCollectionDefined(searchOptions?.Facets))
            {
                foreach (var param in searchOptions.Facets)
                {
                    uri.AppendQuery("facet", param, true);
                }
            }
            if (searchOptions?.Filter != null)
            {
                uri.AppendQuery("$filter", searchOptions.Filter, true);
            }
            if (searchOptions?.HighlightFields != null && Optional.IsCollectionDefined(searchOptions?.HighlightFields))
            {
                uri.AppendQueryDelimited("highlight", searchOptions.HighlightFields, ",", true);
            }
            if (searchOptions?.HighlightPostTag != null)
            {
                uri.AppendQuery("highlightPostTag", searchOptions.HighlightPostTag, true);
            }
            if (searchOptions?.HighlightPreTag != null)
            {
                uri.AppendQuery("highlightPreTag", searchOptions.HighlightPreTag, true);
            }
            if (searchOptions?.MinimumCoverage != null)
            {
                uri.AppendQuery("minimumCoverage", searchOptions.MinimumCoverage.Value, true);
            }
            if (searchOptions?.OrderBy != null && Optional.IsCollectionDefined(searchOptions?.OrderBy))
            {
                uri.AppendQueryDelimited("$orderby", searchOptions.OrderBy, ",", true);
            }
            if (searchOptions?.QueryType != null)
            {
                uri.AppendQuery("queryType", searchOptions.QueryType.Value.ToSerialString(), true);
            }
            if (searchOptions?.ScoringParameters != null && Optional.IsCollectionDefined(searchOptions?.ScoringParameters))
            {
                foreach (var param in searchOptions.ScoringParameters)
                {
                    uri.AppendQuery("scoringParameter", param, true);
                }
            }
            if (searchOptions?.ScoringProfile != null)
            {
                uri.AppendQuery("scoringProfile", searchOptions.ScoringProfile, true);
            }
            if (searchOptions?.SearchFields != null && Optional.IsCollectionDefined(searchOptions?.SearchFields))
            {
                uri.AppendQueryDelimited("searchFields", searchOptions.SearchFields, ",", true);
            }
            if (searchOptions?.SearchMode != null)
            {
                uri.AppendQuery("searchMode", searchOptions.SearchMode.Value.ToSerialString(), true);
            }
            if (searchOptions?.Select != null && Optional.IsCollectionDefined(searchOptions?.Select))
            {
                uri.AppendQueryDelimited("$select", searchOptions.Select, ",", true);
            }
            if (searchOptions?.Skip != null)
            {
                uri.AppendQuery("$skip", searchOptions.Skip.Value, true);
            }
            if (searchOptions?.Top != null)
            {
                uri.AppendQuery("$top", searchOptions.Top.Value, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Searches for documents in the index. </summary>
        /// <param name="searchText"> A full-text search query expression; Use "*" or omit this parameter to match all documents. </param>
        /// <param name="searchOptions"> Parameter group. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<SearchDocumentsResult>> SearchGetAsync(string searchText = null, SearchOptions searchOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateSearchGetRequest(searchText, searchOptions, requestOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SearchDocumentsResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SearchDocumentsResult.DeserializeSearchDocumentsResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Searches for documents in the index. </summary>
        /// <param name="searchText"> A full-text search query expression; Use "*" or omit this parameter to match all documents. </param>
        /// <param name="searchOptions"> Parameter group. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SearchDocumentsResult> SearchGet(string searchText = null, SearchOptions searchOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateSearchGetRequest(searchText, searchOptions, requestOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SearchDocumentsResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SearchDocumentsResult.DeserializeSearchDocumentsResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateSearchPostRequest(SearchRequest searchRequest, RequestOptions requestOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/indexes('", false);
            uri.AppendRaw(_indexName, true);
            uri.AppendRaw("')", false);
            uri.AppendPath("/docs/search.post.search", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(searchRequest);
            request.Content = content;
            return message;
        }

        /// <summary> Searches for documents in the index. </summary>
        /// <param name="searchRequest"> The definition of the Search request. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="searchRequest"/> is null. </exception>
        public async Task<Response<SearchDocumentsResult>> SearchPostAsync(SearchRequest searchRequest, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (searchRequest == null)
            {
                throw new ArgumentNullException(nameof(searchRequest));
            }

            using var message = CreateSearchPostRequest(searchRequest, requestOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SearchDocumentsResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SearchDocumentsResult.DeserializeSearchDocumentsResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Searches for documents in the index. </summary>
        /// <param name="searchRequest"> The definition of the Search request. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="searchRequest"/> is null. </exception>
        public Response<SearchDocumentsResult> SearchPost(SearchRequest searchRequest, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (searchRequest == null)
            {
                throw new ArgumentNullException(nameof(searchRequest));
            }

            using var message = CreateSearchPostRequest(searchRequest, requestOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SearchDocumentsResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SearchDocumentsResult.DeserializeSearchDocumentsResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequest(string key, IEnumerable<string> selectedFields, RequestOptions requestOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/indexes('", false);
            uri.AppendRaw(_indexName, true);
            uri.AppendRaw("')", false);
            uri.AppendPath("/docs('", false);
            uri.AppendPath(key, true);
            uri.AppendPath("')", false);
            if (selectedFields != null && Optional.IsCollectionDefined(selectedFields))
            {
                uri.AppendQueryDelimited("$select", selectedFields, ",", true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Retrieves a document from the index. </summary>
        /// <param name="key"> The key of the document to retrieve. </param>
        /// <param name="selectedFields"> List of field names to retrieve for the document; Any field not retrieved will be missing from the returned document. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public async Task<Response<object>> GetAsync(string key, IEnumerable<string> selectedFields = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var message = CreateGetRequest(key, selectedFields, requestOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        object value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetObject();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Retrieves a document from the index. </summary>
        /// <param name="key"> The key of the document to retrieve. </param>
        /// <param name="selectedFields"> List of field names to retrieve for the document; Any field not retrieved will be missing from the returned document. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public Response<object> Get(string key, IEnumerable<string> selectedFields = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var message = CreateGetRequest(key, selectedFields, requestOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        object value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetObject();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateSuggestGetRequest(string searchText, string suggesterName, SuggestOptions suggestOptions, RequestOptions requestOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/indexes('", false);
            uri.AppendRaw(_indexName, true);
            uri.AppendRaw("')", false);
            uri.AppendPath("/docs/search.suggest", false);
            uri.AppendQuery("search", searchText, true);
            uri.AppendQuery("suggesterName", suggesterName, true);
            if (suggestOptions?.Filter != null)
            {
                uri.AppendQuery("$filter", suggestOptions.Filter, true);
            }
            if (suggestOptions?.UseFuzzyMatching != null)
            {
                uri.AppendQuery("fuzzy", suggestOptions.UseFuzzyMatching.Value, true);
            }
            if (suggestOptions?.HighlightPostTag != null)
            {
                uri.AppendQuery("highlightPostTag", suggestOptions.HighlightPostTag, true);
            }
            if (suggestOptions?.HighlightPreTag != null)
            {
                uri.AppendQuery("highlightPreTag", suggestOptions.HighlightPreTag, true);
            }
            if (suggestOptions?.MinimumCoverage != null)
            {
                uri.AppendQuery("minimumCoverage", suggestOptions.MinimumCoverage.Value, true);
            }
            if (suggestOptions?.OrderBy != null && Optional.IsCollectionDefined(suggestOptions?.OrderBy))
            {
                uri.AppendQueryDelimited("$orderby", suggestOptions.OrderBy, ",", true);
            }
            if (suggestOptions?.SearchFields != null && Optional.IsCollectionDefined(suggestOptions?.SearchFields))
            {
                uri.AppendQueryDelimited("searchFields", suggestOptions.SearchFields, ",", true);
            }
            if (suggestOptions?.Select != null && Optional.IsCollectionDefined(suggestOptions?.Select))
            {
                uri.AppendQueryDelimited("$select", suggestOptions.Select, ",", true);
            }
            if (suggestOptions?.Top != null)
            {
                uri.AppendQuery("$top", suggestOptions.Top.Value, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Suggests documents in the index that match the given partial query text. </summary>
        /// <param name="searchText"> The search text to use to suggest documents. Must be at least 1 character, and no more than 100 characters. </param>
        /// <param name="suggesterName"> The name of the suggester as specified in the suggesters collection that's part of the index definition. </param>
        /// <param name="suggestOptions"> Parameter group. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="searchText"/> or <paramref name="suggesterName"/> is null. </exception>
        public async Task<Response<SuggestDocumentsResult>> SuggestGetAsync(string searchText, string suggesterName, SuggestOptions suggestOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (searchText == null)
            {
                throw new ArgumentNullException(nameof(searchText));
            }
            if (suggesterName == null)
            {
                throw new ArgumentNullException(nameof(suggesterName));
            }

            using var message = CreateSuggestGetRequest(searchText, suggesterName, suggestOptions, requestOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SuggestDocumentsResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SuggestDocumentsResult.DeserializeSuggestDocumentsResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Suggests documents in the index that match the given partial query text. </summary>
        /// <param name="searchText"> The search text to use to suggest documents. Must be at least 1 character, and no more than 100 characters. </param>
        /// <param name="suggesterName"> The name of the suggester as specified in the suggesters collection that's part of the index definition. </param>
        /// <param name="suggestOptions"> Parameter group. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="searchText"/> or <paramref name="suggesterName"/> is null. </exception>
        public Response<SuggestDocumentsResult> SuggestGet(string searchText, string suggesterName, SuggestOptions suggestOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (searchText == null)
            {
                throw new ArgumentNullException(nameof(searchText));
            }
            if (suggesterName == null)
            {
                throw new ArgumentNullException(nameof(suggesterName));
            }

            using var message = CreateSuggestGetRequest(searchText, suggesterName, suggestOptions, requestOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SuggestDocumentsResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SuggestDocumentsResult.DeserializeSuggestDocumentsResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateSuggestPostRequest(SuggestRequest suggestRequest, RequestOptions requestOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/indexes('", false);
            uri.AppendRaw(_indexName, true);
            uri.AppendRaw("')", false);
            uri.AppendPath("/docs/search.post.suggest", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(suggestRequest);
            request.Content = content;
            return message;
        }

        /// <summary> Suggests documents in the index that match the given partial query text. </summary>
        /// <param name="suggestRequest"> The Suggest request. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="suggestRequest"/> is null. </exception>
        public async Task<Response<SuggestDocumentsResult>> SuggestPostAsync(SuggestRequest suggestRequest, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (suggestRequest == null)
            {
                throw new ArgumentNullException(nameof(suggestRequest));
            }

            using var message = CreateSuggestPostRequest(suggestRequest, requestOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SuggestDocumentsResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SuggestDocumentsResult.DeserializeSuggestDocumentsResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Suggests documents in the index that match the given partial query text. </summary>
        /// <param name="suggestRequest"> The Suggest request. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="suggestRequest"/> is null. </exception>
        public Response<SuggestDocumentsResult> SuggestPost(SuggestRequest suggestRequest, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (suggestRequest == null)
            {
                throw new ArgumentNullException(nameof(suggestRequest));
            }

            using var message = CreateSuggestPostRequest(suggestRequest, requestOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SuggestDocumentsResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SuggestDocumentsResult.DeserializeSuggestDocumentsResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateIndexRequest(IndexBatch batch, RequestOptions requestOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/indexes('", false);
            uri.AppendRaw(_indexName, true);
            uri.AppendRaw("')", false);
            uri.AppendPath("/docs/search.index", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(batch);
            request.Content = content;
            return message;
        }

        /// <summary> Sends a batch of document write actions to the index. </summary>
        /// <param name="batch"> The batch of index actions. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="batch"/> is null. </exception>
        public async Task<Response<IndexDocumentsResult>> IndexAsync(IndexBatch batch, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (batch == null)
            {
                throw new ArgumentNullException(nameof(batch));
            }

            using var message = CreateIndexRequest(batch, requestOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 207:
                    {
                        IndexDocumentsResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = IndexDocumentsResult.DeserializeIndexDocumentsResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Sends a batch of document write actions to the index. </summary>
        /// <param name="batch"> The batch of index actions. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="batch"/> is null. </exception>
        public Response<IndexDocumentsResult> Index(IndexBatch batch, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (batch == null)
            {
                throw new ArgumentNullException(nameof(batch));
            }

            using var message = CreateIndexRequest(batch, requestOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 207:
                    {
                        IndexDocumentsResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = IndexDocumentsResult.DeserializeIndexDocumentsResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateAutocompleteGetRequest(string searchText, string suggesterName, RequestOptions requestOptions, AutocompleteOptions autocompleteOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/indexes('", false);
            uri.AppendRaw(_indexName, true);
            uri.AppendRaw("')", false);
            uri.AppendPath("/docs/search.autocomplete", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            uri.AppendQuery("search", searchText, true);
            uri.AppendQuery("suggesterName", suggesterName, true);
            if (autocompleteOptions?.AutocompleteMode != null)
            {
                uri.AppendQuery("autocompleteMode", autocompleteOptions.AutocompleteMode.Value.ToSerialString(), true);
            }
            if (autocompleteOptions?.Filter != null)
            {
                uri.AppendQuery("$filter", autocompleteOptions.Filter, true);
            }
            if (autocompleteOptions?.UseFuzzyMatching != null)
            {
                uri.AppendQuery("fuzzy", autocompleteOptions.UseFuzzyMatching.Value, true);
            }
            if (autocompleteOptions?.HighlightPostTag != null)
            {
                uri.AppendQuery("highlightPostTag", autocompleteOptions.HighlightPostTag, true);
            }
            if (autocompleteOptions?.HighlightPreTag != null)
            {
                uri.AppendQuery("highlightPreTag", autocompleteOptions.HighlightPreTag, true);
            }
            if (autocompleteOptions?.MinimumCoverage != null)
            {
                uri.AppendQuery("minimumCoverage", autocompleteOptions.MinimumCoverage.Value, true);
            }
            if (autocompleteOptions?.SearchFields != null && Optional.IsCollectionDefined(autocompleteOptions?.SearchFields))
            {
                uri.AppendQueryDelimited("searchFields", autocompleteOptions.SearchFields, ",", true);
            }
            if (autocompleteOptions?.Top != null)
            {
                uri.AppendQuery("$top", autocompleteOptions.Top.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Autocompletes incomplete query terms based on input text and matching terms in the index. </summary>
        /// <param name="searchText"> The incomplete term which should be auto-completed. </param>
        /// <param name="suggesterName"> The name of the suggester as specified in the suggesters collection that's part of the index definition. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="autocompleteOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="searchText"/> or <paramref name="suggesterName"/> is null. </exception>
        public async Task<Response<AutocompleteResult>> AutocompleteGetAsync(string searchText, string suggesterName, RequestOptions requestOptions = null, AutocompleteOptions autocompleteOptions = null, CancellationToken cancellationToken = default)
        {
            if (searchText == null)
            {
                throw new ArgumentNullException(nameof(searchText));
            }
            if (suggesterName == null)
            {
                throw new ArgumentNullException(nameof(suggesterName));
            }

            using var message = CreateAutocompleteGetRequest(searchText, suggesterName, requestOptions, autocompleteOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AutocompleteResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = AutocompleteResult.DeserializeAutocompleteResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Autocompletes incomplete query terms based on input text and matching terms in the index. </summary>
        /// <param name="searchText"> The incomplete term which should be auto-completed. </param>
        /// <param name="suggesterName"> The name of the suggester as specified in the suggesters collection that's part of the index definition. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="autocompleteOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="searchText"/> or <paramref name="suggesterName"/> is null. </exception>
        public Response<AutocompleteResult> AutocompleteGet(string searchText, string suggesterName, RequestOptions requestOptions = null, AutocompleteOptions autocompleteOptions = null, CancellationToken cancellationToken = default)
        {
            if (searchText == null)
            {
                throw new ArgumentNullException(nameof(searchText));
            }
            if (suggesterName == null)
            {
                throw new ArgumentNullException(nameof(suggesterName));
            }

            using var message = CreateAutocompleteGetRequest(searchText, suggesterName, requestOptions, autocompleteOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AutocompleteResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = AutocompleteResult.DeserializeAutocompleteResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateAutocompletePostRequest(AutocompleteRequest autocompleteRequest, RequestOptions requestOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/indexes('", false);
            uri.AppendRaw(_indexName, true);
            uri.AppendRaw("')", false);
            uri.AppendPath("/docs/search.post.autocomplete", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(autocompleteRequest);
            request.Content = content;
            return message;
        }

        /// <summary> Autocompletes incomplete query terms based on input text and matching terms in the index. </summary>
        /// <param name="autocompleteRequest"> The definition of the Autocomplete request. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="autocompleteRequest"/> is null. </exception>
        public async Task<Response<AutocompleteResult>> AutocompletePostAsync(AutocompleteRequest autocompleteRequest, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (autocompleteRequest == null)
            {
                throw new ArgumentNullException(nameof(autocompleteRequest));
            }

            using var message = CreateAutocompletePostRequest(autocompleteRequest, requestOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AutocompleteResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = AutocompleteResult.DeserializeAutocompleteResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Autocompletes incomplete query terms based on input text and matching terms in the index. </summary>
        /// <param name="autocompleteRequest"> The definition of the Autocomplete request. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="autocompleteRequest"/> is null. </exception>
        public Response<AutocompleteResult> AutocompletePost(AutocompleteRequest autocompleteRequest, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            if (autocompleteRequest == null)
            {
                throw new ArgumentNullException(nameof(autocompleteRequest));
            }

            using var message = CreateAutocompletePostRequest(autocompleteRequest, requestOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AutocompleteResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = AutocompleteResult.DeserializeAutocompleteResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
