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
    /// <summary> The SynonymMaps service client. </summary>
    public partial class SynonymMapsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal SynonymMapsRestClient RestClient { get; }

        /// <summary> Initializes a new instance of SynonymMapsClient for mocking. </summary>
        protected SynonymMapsClient()
        {
        }

        /// <summary> Initializes a new instance of SynonymMapsClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The endpoint URL of the search service. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/>, <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        internal SynonymMapsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint, string apiVersion = "2019-05-06-Preview")
        {
            RestClient = new SynonymMapsRestClient(clientDiagnostics, pipeline, endpoint, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Creates a new synonym map or updates a synonym map if it already exists. </summary>
        /// <param name="synonymMapName"> The name of the synonym map to create or update. </param>
        /// <param name="prefer"> For HTTP PUT requests, instructs the service to return the created/updated resource on success. </param>
        /// <param name="synonymMap"> The definition of the synonym map to create or update. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="accessCondition"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SynonymMap>> CreateOrUpdateAsync(string synonymMapName, Enum0 prefer, SynonymMap synonymMap, RequestOptions requestOptions = null, AccessCondition accessCondition = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SynonymMapsClient.CreateOrUpdate");
            scope.Start();
            try
            {
                return await RestClient.CreateOrUpdateAsync(synonymMapName, prefer, synonymMap, requestOptions, accessCondition, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new synonym map or updates a synonym map if it already exists. </summary>
        /// <param name="synonymMapName"> The name of the synonym map to create or update. </param>
        /// <param name="prefer"> For HTTP PUT requests, instructs the service to return the created/updated resource on success. </param>
        /// <param name="synonymMap"> The definition of the synonym map to create or update. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="accessCondition"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SynonymMap> CreateOrUpdate(string synonymMapName, Enum0 prefer, SynonymMap synonymMap, RequestOptions requestOptions = null, AccessCondition accessCondition = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SynonymMapsClient.CreateOrUpdate");
            scope.Start();
            try
            {
                return RestClient.CreateOrUpdate(synonymMapName, prefer, synonymMap, requestOptions, accessCondition, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a synonym map. </summary>
        /// <param name="synonymMapName"> The name of the synonym map to delete. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="accessCondition"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteAsync(string synonymMapName, RequestOptions requestOptions = null, AccessCondition accessCondition = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SynonymMapsClient.Delete");
            scope.Start();
            try
            {
                return await RestClient.DeleteAsync(synonymMapName, requestOptions, accessCondition, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a synonym map. </summary>
        /// <param name="synonymMapName"> The name of the synonym map to delete. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="accessCondition"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete(string synonymMapName, RequestOptions requestOptions = null, AccessCondition accessCondition = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SynonymMapsClient.Delete");
            scope.Start();
            try
            {
                return RestClient.Delete(synonymMapName, requestOptions, accessCondition, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves a synonym map definition. </summary>
        /// <param name="synonymMapName"> The name of the synonym map to retrieve. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SynonymMap>> GetAsync(string synonymMapName, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SynonymMapsClient.Get");
            scope.Start();
            try
            {
                return await RestClient.GetAsync(synonymMapName, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves a synonym map definition. </summary>
        /// <param name="synonymMapName"> The name of the synonym map to retrieve. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SynonymMap> Get(string synonymMapName, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SynonymMapsClient.Get");
            scope.Start();
            try
            {
                return RestClient.Get(synonymMapName, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all synonym maps available for a search service. </summary>
        /// <param name="select"> Selects which top-level properties of the synonym maps to retrieve. Specified as a comma-separated list of JSON property names, or '*' for all properties. The default is all properties. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ListSynonymMapsResult>> ListAsync(string select = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SynonymMapsClient.List");
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

        /// <summary> Lists all synonym maps available for a search service. </summary>
        /// <param name="select"> Selects which top-level properties of the synonym maps to retrieve. Specified as a comma-separated list of JSON property names, or '*' for all properties. The default is all properties. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ListSynonymMapsResult> List(string select = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SynonymMapsClient.List");
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

        /// <summary> Creates a new synonym map. </summary>
        /// <param name="synonymMap"> The definition of the synonym map to create. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SynonymMap>> CreateAsync(SynonymMap synonymMap, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SynonymMapsClient.Create");
            scope.Start();
            try
            {
                return await RestClient.CreateAsync(synonymMap, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new synonym map. </summary>
        /// <param name="synonymMap"> The definition of the synonym map to create. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SynonymMap> Create(SynonymMap synonymMap, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SynonymMapsClient.Create");
            scope.Start();
            try
            {
                return RestClient.Create(synonymMap, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
