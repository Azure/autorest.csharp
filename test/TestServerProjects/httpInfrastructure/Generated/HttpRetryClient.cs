// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace httpInfrastructure
{
    /// <summary> The HttpRetry service client. </summary>
    public partial class HttpRetryClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal HttpRetryRestClient RestClient { get; }

        /// <summary> Initializes a new instance of HttpRetryClient for mocking. </summary>
        protected HttpRetryClient()
        {
        }

        /// <summary> Initializes a new instance of HttpRetryClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal HttpRetryClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new HttpRetryRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Return 408 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Head408Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpRetryClient.Head408");
            scope.Start();
            try
            {
                return await RestClient.Head408Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 408 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Head408(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpRetryClient.Head408");
            scope.Start();
            try
            {
                return RestClient.Head408(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Put500Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpRetryClient.Put500");
            scope.Start();
            try
            {
                return await RestClient.Put500Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Put500(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpRetryClient.Put500");
            scope.Start();
            try
            {
                return RestClient.Put500(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Patch500Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpRetryClient.Patch500");
            scope.Start();
            try
            {
                return await RestClient.Patch500Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Patch500(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpRetryClient.Patch500");
            scope.Start();
            try
            {
                return RestClient.Patch500(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Get502Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpRetryClient.Get502");
            scope.Start();
            try
            {
                return await RestClient.Get502Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Get502(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpRetryClient.Get502");
            scope.Start();
            try
            {
                return RestClient.Get502(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> Options502Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpRetryClient.Options502");
            scope.Start();
            try
            {
                return await RestClient.Options502Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Options502(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpRetryClient.Options502");
            scope.Start();
            try
            {
                return RestClient.Options502(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Post503Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpRetryClient.Post503");
            scope.Start();
            try
            {
                return await RestClient.Post503Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Post503(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpRetryClient.Post503");
            scope.Start();
            try
            {
                return RestClient.Post503(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Delete503Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpRetryClient.Delete503");
            scope.Start();
            try
            {
                return await RestClient.Delete503Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete503(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpRetryClient.Delete503");
            scope.Start();
            try
            {
                return RestClient.Delete503(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Put504Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpRetryClient.Put504");
            scope.Start();
            try
            {
                return await RestClient.Put504Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Put504(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpRetryClient.Put504");
            scope.Start();
            try
            {
                return RestClient.Put504(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Patch504Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpRetryClient.Patch504");
            scope.Start();
            try
            {
                return await RestClient.Patch504Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Patch504(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpRetryClient.Patch504");
            scope.Start();
            try
            {
                return RestClient.Patch504(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
