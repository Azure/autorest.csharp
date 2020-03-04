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
    public partial class IndexersClient
    {
        private IndexersRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of IndexersClient. </summary>
        internal IndexersClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string searchServiceName, string searchDnsSuffix = "search.windows.net", string ApiVersion = "2019-05-06")
        {
            restClient = new IndexersRestClient(clientDiagnostics, pipeline, searchServiceName, searchDnsSuffix, ApiVersion);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Resets the change tracking state associated with an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer to reset. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> ResetAsync(string indexerName, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return await restClient.ResetAsync(indexerName, clientRequestId, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Resets the change tracking state associated with an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer to reset. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Reset(string indexerName, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return restClient.Reset(indexerName, clientRequestId, cancellationToken);
        }
        /// <summary> Runs an indexer on-demand. </summary>
        /// <param name="indexerName"> The name of the indexer to reset. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> RunAsync(string indexerName, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return await restClient.RunAsync(indexerName, clientRequestId, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Runs an indexer on-demand. </summary>
        /// <param name="indexerName"> The name of the indexer to reset. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Run(string indexerName, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return restClient.Run(indexerName, clientRequestId, cancellationToken);
        }
        /// <summary> Creates a new indexer or updates an indexer if it already exists. </summary>
        /// <param name="indexerName"> The name of the indexer to reset. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="indexer"> The definition of the indexer to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Indexer>> CreateOrUpdateAsync(string indexerName, Guid? clientRequestId, string ifMatch, string ifNoneMatch, Indexer indexer, CancellationToken cancellationToken = default)
        {
            return await restClient.CreateOrUpdateAsync(indexerName, clientRequestId, ifMatch, ifNoneMatch, indexer, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Creates a new indexer or updates an indexer if it already exists. </summary>
        /// <param name="indexerName"> The name of the indexer to reset. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="indexer"> The definition of the indexer to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Indexer> CreateOrUpdate(string indexerName, Guid? clientRequestId, string ifMatch, string ifNoneMatch, Indexer indexer, CancellationToken cancellationToken = default)
        {
            return restClient.CreateOrUpdate(indexerName, clientRequestId, ifMatch, ifNoneMatch, indexer, cancellationToken);
        }
        /// <summary> Deletes an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer to reset. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DeleteAsync(string indexerName, Guid? clientRequestId, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await restClient.DeleteAsync(indexerName, clientRequestId, ifMatch, ifNoneMatch, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Deletes an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer to reset. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete(string indexerName, Guid? clientRequestId, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return restClient.Delete(indexerName, clientRequestId, ifMatch, ifNoneMatch, cancellationToken);
        }
        /// <summary> Retrieves an indexer definition. </summary>
        /// <param name="indexerName"> The name of the indexer to reset. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Indexer>> GetAsync(string indexerName, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return await restClient.GetAsync(indexerName, clientRequestId, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Retrieves an indexer definition. </summary>
        /// <param name="indexerName"> The name of the indexer to reset. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Indexer> Get(string indexerName, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return restClient.Get(indexerName, clientRequestId, cancellationToken);
        }
        /// <summary> Lists all indexers available for a search service. </summary>
        /// <param name="select"> Selects which top-level properties of the data sources to retrieve. Specified as a comma-separated list of JSON property names, or &apos;*&apos; for all properties. The default is all properties. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ListIndexersResult>> ListAsync(string select, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return await restClient.ListAsync(select, clientRequestId, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Lists all indexers available for a search service. </summary>
        /// <param name="select"> Selects which top-level properties of the data sources to retrieve. Specified as a comma-separated list of JSON property names, or &apos;*&apos; for all properties. The default is all properties. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ListIndexersResult> List(string select, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return restClient.List(select, clientRequestId, cancellationToken);
        }
        /// <summary> Creates a new indexer. </summary>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="indexer"> The definition of the indexer to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Indexer>> CreateAsync(Guid? clientRequestId, Indexer indexer, CancellationToken cancellationToken = default)
        {
            return await restClient.CreateAsync(clientRequestId, indexer, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Creates a new indexer. </summary>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="indexer"> The definition of the indexer to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Indexer> Create(Guid? clientRequestId, Indexer indexer, CancellationToken cancellationToken = default)
        {
            return restClient.Create(clientRequestId, indexer, cancellationToken);
        }
        /// <summary> Returns the current status and execution history of an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer to reset. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IndexerExecutionInfo>> GetStatusAsync(string indexerName, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return await restClient.GetStatusAsync(indexerName, clientRequestId, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Returns the current status and execution history of an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer to reset. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IndexerExecutionInfo> GetStatus(string indexerName, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return restClient.GetStatus(indexerName, clientRequestId, cancellationToken);
        }
    }
}
