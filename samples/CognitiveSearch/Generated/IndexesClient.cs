// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using CognitiveSearch.Models;

namespace CognitiveSearch
{
    /// <summary> The Indexes service client. </summary>
    public partial class IndexesClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal IndexesRestClient RestClient { get; }

        /// <summary> Initializes a new instance of IndexesClient for mocking. </summary>
        protected IndexesClient()
        {
        }

        /// <summary> Initializes a new instance of IndexesClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The endpoint URL of the search service. </param>
        /// <param name="apiVersion"> Api Version. </param>
        internal IndexesClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint, string apiVersion = "2019-05-06-Preview")
        {
            RestClient = new IndexesRestClient(clientDiagnostics, pipeline, endpoint, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Creates a new search index. </summary>
        /// <param name="index"> The definition of the index to create. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Models.Index>> CreateAsync(Models.Index index, Models.RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexesClient.Create");
            scope.Start();
            try
            {
                return await RestClient.CreateAsync(index, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new search index. </summary>
        /// <param name="index"> The definition of the index to create. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Models.Index> Create(Models.Index index, Models.RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexesClient.Create");
            scope.Start();
            try
            {
                return RestClient.Create(index, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all indexes available for a search service. </summary>
        /// <param name="select"> Selects which top-level properties of the index definitions to retrieve. Specified as a comma-separated list of JSON property names, or &apos;*&apos; for all properties. The default is all properties. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ListIndexesResult>> ListAsync(string select = null, Models.RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexesClient.List");
            scope.Start();
            try
            {
                return await RestClient.ListAsync(select, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all indexes available for a search service. </summary>
        /// <param name="select"> Selects which top-level properties of the index definitions to retrieve. Specified as a comma-separated list of JSON property names, or &apos;*&apos; for all properties. The default is all properties. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ListIndexesResult> List(string select = null, Models.RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexesClient.List");
            scope.Start();
            try
            {
                return RestClient.List(select, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new search index or updates an index if it already exists. </summary>
        /// <param name="indexName"> The definition of the index to create or update. </param>
        /// <param name="prefer"> For HTTP PUT requests, instructs the service to return the created/updated resource on success. </param>
        /// <param name="index"> The definition of the index to create or update. </param>
        /// <param name="allowIndexDowntime"> Allows new analyzers, tokenizers, token filters, or char filters to be added to an index by taking the index offline for at least a few seconds. This temporarily causes indexing and query requests to fail. Performance and write availability of the index can be impaired for several minutes after the index is updated, or longer for very large indexes. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="accessCondition"> Parameter group. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Models.Index>> CreateOrUpdateAsync(string indexName, Enum0 prefer, Models.Index index, bool? allowIndexDowntime = null, Models.RequestOptions requestOptions = null, AccessCondition accessCondition = null, MatchConditions matchConditions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexesClient.CreateOrUpdate");
            scope.Start();
            try
            {
                return await RestClient.CreateOrUpdateAsync(indexName, prefer, index, allowIndexDowntime, requestOptions, accessCondition, matchConditions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new search index or updates an index if it already exists. </summary>
        /// <param name="indexName"> The definition of the index to create or update. </param>
        /// <param name="prefer"> For HTTP PUT requests, instructs the service to return the created/updated resource on success. </param>
        /// <param name="index"> The definition of the index to create or update. </param>
        /// <param name="allowIndexDowntime"> Allows new analyzers, tokenizers, token filters, or char filters to be added to an index by taking the index offline for at least a few seconds. This temporarily causes indexing and query requests to fail. Performance and write availability of the index can be impaired for several minutes after the index is updated, or longer for very large indexes. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="accessCondition"> Parameter group. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Models.Index> CreateOrUpdate(string indexName, Enum0 prefer, Models.Index index, bool? allowIndexDowntime = null, Models.RequestOptions requestOptions = null, AccessCondition accessCondition = null, MatchConditions matchConditions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexesClient.CreateOrUpdate");
            scope.Start();
            try
            {
                return RestClient.CreateOrUpdate(indexName, prefer, index, allowIndexDowntime, requestOptions, accessCondition, matchConditions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a search index and all the documents it contains. </summary>
        /// <param name="indexName"> The name of the index to delete. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="accessCondition"> Parameter group. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteAsync(string indexName, Models.RequestOptions requestOptions = null, AccessCondition accessCondition = null, MatchConditions matchConditions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexesClient.Delete");
            scope.Start();
            try
            {
                return await RestClient.DeleteAsync(indexName, requestOptions, accessCondition, matchConditions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a search index and all the documents it contains. </summary>
        /// <param name="indexName"> The name of the index to delete. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="accessCondition"> Parameter group. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete(string indexName, Models.RequestOptions requestOptions = null, AccessCondition accessCondition = null, MatchConditions matchConditions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexesClient.Delete");
            scope.Start();
            try
            {
                return RestClient.Delete(indexName, requestOptions, accessCondition, matchConditions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves an index definition. </summary>
        /// <param name="indexName"> The name of the index to retrieve. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Models.Index>> GetAsync(string indexName, Models.RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexesClient.Get");
            scope.Start();
            try
            {
                return await RestClient.GetAsync(indexName, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves an index definition. </summary>
        /// <param name="indexName"> The name of the index to retrieve. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Models.Index> Get(string indexName, Models.RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexesClient.Get");
            scope.Start();
            try
            {
                return RestClient.Get(indexName, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns statistics for the given index, including a document count and storage usage. </summary>
        /// <param name="indexName"> The name of the index for which to retrieve statistics. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<GetIndexStatisticsResult>> GetStatisticsAsync(string indexName, Models.RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexesClient.GetStatistics");
            scope.Start();
            try
            {
                return await RestClient.GetStatisticsAsync(indexName, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns statistics for the given index, including a document count and storage usage. </summary>
        /// <param name="indexName"> The name of the index for which to retrieve statistics. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<GetIndexStatisticsResult> GetStatistics(string indexName, Models.RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexesClient.GetStatistics");
            scope.Start();
            try
            {
                return RestClient.GetStatistics(indexName, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Shows how an analyzer breaks text into tokens. </summary>
        /// <param name="indexName"> The name of the index for which to test an analyzer. </param>
        /// <param name="request"> The text and analyzer or analysis components to test. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AnalyzeResult>> AnalyzeAsync(string indexName, AnalyzeRequest request, Models.RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexesClient.Analyze");
            scope.Start();
            try
            {
                return await RestClient.AnalyzeAsync(indexName, request, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Shows how an analyzer breaks text into tokens. </summary>
        /// <param name="indexName"> The name of the index for which to test an analyzer. </param>
        /// <param name="request"> The text and analyzer or analysis components to test. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AnalyzeResult> Analyze(string indexName, AnalyzeRequest request, Models.RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexesClient.Analyze");
            scope.Start();
            try
            {
                return RestClient.Analyze(indexName, request, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
