// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using CognitiveSearch.Models;

namespace CognitiveSearch
{
    public partial class IndexesClient
    {
        private IndexesRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of IndexesClient. </summary>
        internal IndexesClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string searchServiceName, string searchDnsSuffix = "search.windows.net", string ApiVersion = "2019-05-06")
        {
            restClient = new IndexesRestClient(clientDiagnostics, pipeline, searchServiceName, searchDnsSuffix, ApiVersion);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Creates a new search index. </summary>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="index"> The definition of the index to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Models.Index>> CreateAsync(Guid? clientRequestId, Models.Index index, CancellationToken cancellationToken = default)
        {
            return await restClient.CreateAsync(clientRequestId, index, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Creates a new search index. </summary>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="index"> The definition of the index to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Models.Index> Create(Guid? clientRequestId, Models.Index index, CancellationToken cancellationToken = default)
        {
            return restClient.Create(clientRequestId, index, cancellationToken);
        }
        /// <summary> Lists all indexes available for a search service. </summary>
        /// <param name="select"> Selects which top-level properties of the data sources to retrieve. Specified as a comma-separated list of JSON property names, or &apos;*&apos; for all properties. The default is all properties. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ListIndexesResult>> ListAsync(string select, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return await restClient.ListAsync(select, clientRequestId, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Lists all indexes available for a search service. </summary>
        /// <param name="select"> Selects which top-level properties of the data sources to retrieve. Specified as a comma-separated list of JSON property names, or &apos;*&apos; for all properties. The default is all properties. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ListIndexesResult> List(string select, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return restClient.List(select, clientRequestId, cancellationToken);
        }
        /// <summary> Creates a new search index or updates an index if it already exists. </summary>
        /// <param name="indexName"> The definition of the index to create or update. </param>
        /// <param name="allowIndexDowntime"> Allows new analyzers, tokenizers, token filters, or char filters to be added to an index by taking the index offline for at least a few seconds. This temporarily causes indexing and query requests to fail. Performance and write availability of the index can be impaired for several minutes after the index is updated, or longer for very large indexes. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="index"> The definition of the index to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Models.Index>> CreateOrUpdateAsync(string indexName, bool? allowIndexDowntime, Guid? clientRequestId, string ifMatch, string ifNoneMatch, Models.Index index, CancellationToken cancellationToken = default)
        {
            return await restClient.CreateOrUpdateAsync(indexName, allowIndexDowntime, clientRequestId, ifMatch, ifNoneMatch, index, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Creates a new search index or updates an index if it already exists. </summary>
        /// <param name="indexName"> The definition of the index to create or update. </param>
        /// <param name="allowIndexDowntime"> Allows new analyzers, tokenizers, token filters, or char filters to be added to an index by taking the index offline for at least a few seconds. This temporarily causes indexing and query requests to fail. Performance and write availability of the index can be impaired for several minutes after the index is updated, or longer for very large indexes. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="index"> The definition of the index to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Models.Index> CreateOrUpdate(string indexName, bool? allowIndexDowntime, Guid? clientRequestId, string ifMatch, string ifNoneMatch, Models.Index index, CancellationToken cancellationToken = default)
        {
            return restClient.CreateOrUpdate(indexName, allowIndexDowntime, clientRequestId, ifMatch, ifNoneMatch, index, cancellationToken);
        }
        /// <summary> Deletes a search index and all the documents it contains. </summary>
        /// <param name="indexName"> The definition of the index to create or update. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DeleteAsync(string indexName, Guid? clientRequestId, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await restClient.DeleteAsync(indexName, clientRequestId, ifMatch, ifNoneMatch, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Deletes a search index and all the documents it contains. </summary>
        /// <param name="indexName"> The definition of the index to create or update. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete(string indexName, Guid? clientRequestId, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return restClient.Delete(indexName, clientRequestId, ifMatch, ifNoneMatch, cancellationToken);
        }
        /// <summary> Retrieves an index definition. </summary>
        /// <param name="indexName"> The definition of the index to create or update. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Models.Index>> GetAsync(string indexName, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return await restClient.GetAsync(indexName, clientRequestId, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Retrieves an index definition. </summary>
        /// <param name="indexName"> The definition of the index to create or update. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Models.Index> Get(string indexName, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return restClient.Get(indexName, clientRequestId, cancellationToken);
        }
        /// <summary> Returns statistics for the given index, including a document count and storage usage. </summary>
        /// <param name="indexName"> The definition of the index to create or update. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<GetIndexStatisticsResult>> GetStatisticsAsync(string indexName, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return await restClient.GetStatisticsAsync(indexName, clientRequestId, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Returns statistics for the given index, including a document count and storage usage. </summary>
        /// <param name="indexName"> The definition of the index to create or update. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<GetIndexStatisticsResult> GetStatistics(string indexName, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return restClient.GetStatistics(indexName, clientRequestId, cancellationToken);
        }
        /// <summary> Shows how an analyzer breaks text into tokens. </summary>
        /// <param name="indexName"> The definition of the index to create or update. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="requestTodo"> The text and analyzer or analysis components to test. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<AnalyzeResult>> AnalyzeAsync(string indexName, Guid? clientRequestId, AnalyzeRequest requestTodo, CancellationToken cancellationToken = default)
        {
            return await restClient.AnalyzeAsync(indexName, clientRequestId, requestTodo, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Shows how an analyzer breaks text into tokens. </summary>
        /// <param name="indexName"> The definition of the index to create or update. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="requestTodo"> The text and analyzer or analysis components to test. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<AnalyzeResult> Analyze(string indexName, Guid? clientRequestId, AnalyzeRequest requestTodo, CancellationToken cancellationToken = default)
        {
            return restClient.Analyze(indexName, clientRequestId, requestTodo, cancellationToken);
        }
    }
}
