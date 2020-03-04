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
    public partial class SynonymMapsClient
    {
        private SynonymMapsRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of SynonymMapsClient. </summary>
        internal SynonymMapsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string searchServiceName, string searchDnsSuffix = "search.windows.net", string ApiVersion = "2019-05-06")
        {
            restClient = new SynonymMapsRestClient(clientDiagnostics, pipeline, searchServiceName, searchDnsSuffix, ApiVersion);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Creates a new synonym map or updates a synonym map if it already exists. </summary>
        /// <param name="synonymMapName"> The name of the synonym map to create or update. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="synonymMap"> The definition of the synonym map to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<SynonymMap>> CreateOrUpdateAsync(string synonymMapName, Guid? clientRequestId, string ifMatch, string ifNoneMatch, SynonymMap synonymMap, CancellationToken cancellationToken = default)
        {
            return await restClient.CreateOrUpdateAsync(synonymMapName, clientRequestId, ifMatch, ifNoneMatch, synonymMap, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Creates a new synonym map or updates a synonym map if it already exists. </summary>
        /// <param name="synonymMapName"> The name of the synonym map to create or update. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="synonymMap"> The definition of the synonym map to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SynonymMap> CreateOrUpdate(string synonymMapName, Guid? clientRequestId, string ifMatch, string ifNoneMatch, SynonymMap synonymMap, CancellationToken cancellationToken = default)
        {
            return restClient.CreateOrUpdate(synonymMapName, clientRequestId, ifMatch, ifNoneMatch, synonymMap, cancellationToken);
        }
        /// <summary> Deletes a synonym map. </summary>
        /// <param name="synonymMapName"> The name of the synonym map to create or update. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DeleteAsync(string synonymMapName, Guid? clientRequestId, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await restClient.DeleteAsync(synonymMapName, clientRequestId, ifMatch, ifNoneMatch, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Deletes a synonym map. </summary>
        /// <param name="synonymMapName"> The name of the synonym map to create or update. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete(string synonymMapName, Guid? clientRequestId, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return restClient.Delete(synonymMapName, clientRequestId, ifMatch, ifNoneMatch, cancellationToken);
        }
        /// <summary> Retrieves a synonym map definition. </summary>
        /// <param name="synonymMapName"> The name of the synonym map to create or update. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<SynonymMap>> GetAsync(string synonymMapName, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return await restClient.GetAsync(synonymMapName, clientRequestId, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Retrieves a synonym map definition. </summary>
        /// <param name="synonymMapName"> The name of the synonym map to create or update. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SynonymMap> Get(string synonymMapName, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return restClient.Get(synonymMapName, clientRequestId, cancellationToken);
        }
        /// <summary> Lists all synonym maps available for a search service. </summary>
        /// <param name="select"> Selects which top-level properties of the data sources to retrieve. Specified as a comma-separated list of JSON property names, or &apos;*&apos; for all properties. The default is all properties. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ListSynonymMapsResult>> ListAsync(string select, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return await restClient.ListAsync(select, clientRequestId, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Lists all synonym maps available for a search service. </summary>
        /// <param name="select"> Selects which top-level properties of the data sources to retrieve. Specified as a comma-separated list of JSON property names, or &apos;*&apos; for all properties. The default is all properties. </param>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ListSynonymMapsResult> List(string select, Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return restClient.List(select, clientRequestId, cancellationToken);
        }
        /// <summary> Creates a new synonym map. </summary>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="synonymMap"> The definition of the synonym map to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<SynonymMap>> CreateAsync(Guid? clientRequestId, SynonymMap synonymMap, CancellationToken cancellationToken = default)
        {
            return await restClient.CreateAsync(clientRequestId, synonymMap, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Creates a new synonym map. </summary>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="synonymMap"> The definition of the synonym map to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SynonymMap> Create(Guid? clientRequestId, SynonymMap synonymMap, CancellationToken cancellationToken = default)
        {
            return restClient.Create(clientRequestId, synonymMap, cancellationToken);
        }
    }
}
