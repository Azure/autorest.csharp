// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using CognitiveSearch.Models;

namespace CognitiveSearch
{
    /// <summary> The Documents service client. </summary>
    public partial class DocumentsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal DocumentsRestClient RestClient { get; }

        /// <summary> Initializes a new instance of DocumentsClient for mocking. </summary>
        protected DocumentsClient()
        {
        }

        /// <summary> Initializes a new instance of DocumentsClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The endpoint URL of the search service. </param>
        /// <param name="indexName"> The name of the index. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/>, <paramref name="endpoint"/>, <paramref name="indexName"/> or <paramref name="apiVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="indexName"/> is an empty string, and was expected to be non-empty. </exception>
        internal DocumentsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint, string indexName, string apiVersion = "2019-05-06-Preview")
        {
            RestClient = new DocumentsRestClient(clientDiagnostics, pipeline, endpoint, indexName, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Queries the number of documents in the index. </summary>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<long>> CountAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DocumentsClient.Count");
            scope.Start();
            try
            {
                return await RestClient.CountAsync(requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Queries the number of documents in the index. </summary>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<long> Count(RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DocumentsClient.Count");
            scope.Start();
            try
            {
                return RestClient.Count(requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Searches for documents in the index. </summary>
        /// <param name="searchText"> A full-text search query expression; Use "*" or omit this parameter to match all documents. </param>
        /// <param name="searchOptions"> Parameter group. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SearchDocumentsResult>> SearchGetAsync(string searchText = null, SearchOptions searchOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DocumentsClient.SearchGet");
            scope.Start();
            try
            {
                return await RestClient.SearchGetAsync(searchText, searchOptions, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Searches for documents in the index. </summary>
        /// <param name="searchText"> A full-text search query expression; Use "*" or omit this parameter to match all documents. </param>
        /// <param name="searchOptions"> Parameter group. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SearchDocumentsResult> SearchGet(string searchText = null, SearchOptions searchOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DocumentsClient.SearchGet");
            scope.Start();
            try
            {
                return RestClient.SearchGet(searchText, searchOptions, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Searches for documents in the index. </summary>
        /// <param name="searchRequest"> The definition of the Search request. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SearchDocumentsResult>> SearchPostAsync(SearchRequest searchRequest, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DocumentsClient.SearchPost");
            scope.Start();
            try
            {
                return await RestClient.SearchPostAsync(searchRequest, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Searches for documents in the index. </summary>
        /// <param name="searchRequest"> The definition of the Search request. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SearchDocumentsResult> SearchPost(SearchRequest searchRequest, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DocumentsClient.SearchPost");
            scope.Start();
            try
            {
                return RestClient.SearchPost(searchRequest, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves a document from the index. </summary>
        /// <param name="key"> The key of the document to retrieve. </param>
        /// <param name="selectedFields"> List of field names to retrieve for the document; Any field not retrieved will be missing from the returned document. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<object>> GetAsync(string key, IEnumerable<string> selectedFields = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DocumentsClient.Get");
            scope.Start();
            try
            {
                return await RestClient.GetAsync(key, selectedFields, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves a document from the index. </summary>
        /// <param name="key"> The key of the document to retrieve. </param>
        /// <param name="selectedFields"> List of field names to retrieve for the document; Any field not retrieved will be missing from the returned document. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<object> Get(string key, IEnumerable<string> selectedFields = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DocumentsClient.Get");
            scope.Start();
            try
            {
                return RestClient.Get(key, selectedFields, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Suggests documents in the index that match the given partial query text. </summary>
        /// <param name="searchText"> The search text to use to suggest documents. Must be at least 1 character, and no more than 100 characters. </param>
        /// <param name="suggesterName"> The name of the suggester as specified in the suggesters collection that's part of the index definition. </param>
        /// <param name="suggestOptions"> Parameter group. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SuggestDocumentsResult>> SuggestGetAsync(string searchText, string suggesterName, SuggestOptions suggestOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DocumentsClient.SuggestGet");
            scope.Start();
            try
            {
                return await RestClient.SuggestGetAsync(searchText, suggesterName, suggestOptions, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Suggests documents in the index that match the given partial query text. </summary>
        /// <param name="searchText"> The search text to use to suggest documents. Must be at least 1 character, and no more than 100 characters. </param>
        /// <param name="suggesterName"> The name of the suggester as specified in the suggesters collection that's part of the index definition. </param>
        /// <param name="suggestOptions"> Parameter group. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SuggestDocumentsResult> SuggestGet(string searchText, string suggesterName, SuggestOptions suggestOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DocumentsClient.SuggestGet");
            scope.Start();
            try
            {
                return RestClient.SuggestGet(searchText, suggesterName, suggestOptions, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Suggests documents in the index that match the given partial query text. </summary>
        /// <param name="suggestRequest"> The Suggest request. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SuggestDocumentsResult>> SuggestPostAsync(SuggestRequest suggestRequest, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DocumentsClient.SuggestPost");
            scope.Start();
            try
            {
                return await RestClient.SuggestPostAsync(suggestRequest, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Suggests documents in the index that match the given partial query text. </summary>
        /// <param name="suggestRequest"> The Suggest request. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SuggestDocumentsResult> SuggestPost(SuggestRequest suggestRequest, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DocumentsClient.SuggestPost");
            scope.Start();
            try
            {
                return RestClient.SuggestPost(suggestRequest, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Sends a batch of document write actions to the index. </summary>
        /// <param name="batch"> The batch of index actions. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IndexDocumentsResult>> IndexAsync(IndexBatch batch, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DocumentsClient.Index");
            scope.Start();
            try
            {
                return await RestClient.IndexAsync(batch, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Sends a batch of document write actions to the index. </summary>
        /// <param name="batch"> The batch of index actions. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IndexDocumentsResult> Index(IndexBatch batch, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DocumentsClient.Index");
            scope.Start();
            try
            {
                return RestClient.Index(batch, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Autocompletes incomplete query terms based on input text and matching terms in the index. </summary>
        /// <param name="searchText"> The incomplete term which should be auto-completed. </param>
        /// <param name="suggesterName"> The name of the suggester as specified in the suggesters collection that's part of the index definition. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="autocompleteOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AutocompleteResult>> AutocompleteGetAsync(string searchText, string suggesterName, RequestOptions requestOptions = null, AutocompleteOptions autocompleteOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DocumentsClient.AutocompleteGet");
            scope.Start();
            try
            {
                return await RestClient.AutocompleteGetAsync(searchText, suggesterName, requestOptions, autocompleteOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Autocompletes incomplete query terms based on input text and matching terms in the index. </summary>
        /// <param name="searchText"> The incomplete term which should be auto-completed. </param>
        /// <param name="suggesterName"> The name of the suggester as specified in the suggesters collection that's part of the index definition. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="autocompleteOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AutocompleteResult> AutocompleteGet(string searchText, string suggesterName, RequestOptions requestOptions = null, AutocompleteOptions autocompleteOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DocumentsClient.AutocompleteGet");
            scope.Start();
            try
            {
                return RestClient.AutocompleteGet(searchText, suggesterName, requestOptions, autocompleteOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Autocompletes incomplete query terms based on input text and matching terms in the index. </summary>
        /// <param name="autocompleteRequest"> The definition of the Autocomplete request. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AutocompleteResult>> AutocompletePostAsync(AutocompleteRequest autocompleteRequest, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DocumentsClient.AutocompletePost");
            scope.Start();
            try
            {
                return await RestClient.AutocompletePostAsync(autocompleteRequest, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Autocompletes incomplete query terms based on input text and matching terms in the index. </summary>
        /// <param name="autocompleteRequest"> The definition of the Autocomplete request. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AutocompleteResult> AutocompletePost(AutocompleteRequest autocompleteRequest, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DocumentsClient.AutocompletePost");
            scope.Start();
            try
            {
                return RestClient.AutocompletePost(autocompleteRequest, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
