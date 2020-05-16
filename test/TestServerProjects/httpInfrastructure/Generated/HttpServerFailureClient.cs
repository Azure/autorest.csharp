// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace httpInfrastructure
{
    /// <summary> The HttpServerFailure service client. </summary>
    public partial class HttpServerFailureClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal HttpServerFailureRestClient RestClient { get; }
        /// <summary> Initializes a new instance of HttpServerFailureClient for mocking. </summary>
        protected HttpServerFailureClient()
        {
        }
        /// <summary> Initializes a new instance of HttpServerFailureClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        internal HttpServerFailureClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new HttpServerFailureRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Return 501 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Head501Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpServerFailureClient.Head501");
            scope.Start();
            try
            {
                return await RestClient.Head501Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 501 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Head501(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpServerFailureClient.Head501");
            scope.Start();
            try
            {
                return RestClient.Head501(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 501 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Get501Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpServerFailureClient.Get501");
            scope.Start();
            try
            {
                return await RestClient.Get501Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 501 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Get501(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpServerFailureClient.Get501");
            scope.Start();
            try
            {
                return RestClient.Get501(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 505 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Post505Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpServerFailureClient.Post505");
            scope.Start();
            try
            {
                return await RestClient.Post505Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 505 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Post505(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpServerFailureClient.Post505");
            scope.Start();
            try
            {
                return RestClient.Post505(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 505 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Delete505Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpServerFailureClient.Delete505");
            scope.Start();
            try
            {
                return await RestClient.Delete505Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 505 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete505(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpServerFailureClient.Delete505");
            scope.Start();
            try
            {
                return RestClient.Delete505(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
