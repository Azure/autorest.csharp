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
    /// <summary> The HttpClientFailure service client. </summary>
    public partial class HttpClientFailureClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal HttpClientFailureRestClient RestClient { get; }

        /// <summary> Initializes a new instance of HttpClientFailureClient for mocking. </summary>
        protected HttpClientFailureClient()
        {
        }

        /// <summary> Initializes a new instance of HttpClientFailureClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal HttpClientFailureClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new HttpClientFailureRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Head400Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Head400");
            scope.Start();
            try
            {
                return await RestClient.Head400Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Head400(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Head400");
            scope.Start();
            try
            {
                return RestClient.Head400(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Get400Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Get400");
            scope.Start();
            try
            {
                return await RestClient.Get400Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Get400(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Get400");
            scope.Start();
            try
            {
                return RestClient.Get400(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Options400Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Options400");
            scope.Start();
            try
            {
                return await RestClient.Options400Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Options400(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Options400");
            scope.Start();
            try
            {
                return RestClient.Options400(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Put400Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Put400");
            scope.Start();
            try
            {
                return await RestClient.Put400Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Put400(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Put400");
            scope.Start();
            try
            {
                return RestClient.Put400(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Patch400Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Patch400");
            scope.Start();
            try
            {
                return await RestClient.Patch400Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Patch400(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Patch400");
            scope.Start();
            try
            {
                return RestClient.Patch400(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Post400Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Post400");
            scope.Start();
            try
            {
                return await RestClient.Post400Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Post400(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Post400");
            scope.Start();
            try
            {
                return RestClient.Post400(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Delete400Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Delete400");
            scope.Start();
            try
            {
                return await RestClient.Delete400Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete400(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Delete400");
            scope.Start();
            try
            {
                return RestClient.Delete400(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 401 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Head401Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Head401");
            scope.Start();
            try
            {
                return await RestClient.Head401Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 401 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Head401(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Head401");
            scope.Start();
            try
            {
                return RestClient.Head401(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 402 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Get402Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Get402");
            scope.Start();
            try
            {
                return await RestClient.Get402Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 402 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Get402(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Get402");
            scope.Start();
            try
            {
                return RestClient.Get402(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 403 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Options403Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Options403");
            scope.Start();
            try
            {
                return await RestClient.Options403Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 403 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Options403(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Options403");
            scope.Start();
            try
            {
                return RestClient.Options403(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 403 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Get403Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Get403");
            scope.Start();
            try
            {
                return await RestClient.Get403Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 403 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Get403(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Get403");
            scope.Start();
            try
            {
                return RestClient.Get403(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 404 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Put404Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Put404");
            scope.Start();
            try
            {
                return await RestClient.Put404Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 404 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Put404(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Put404");
            scope.Start();
            try
            {
                return RestClient.Put404(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 405 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Patch405Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Patch405");
            scope.Start();
            try
            {
                return await RestClient.Patch405Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 405 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Patch405(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Patch405");
            scope.Start();
            try
            {
                return RestClient.Patch405(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 406 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Post406Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Post406");
            scope.Start();
            try
            {
                return await RestClient.Post406Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 406 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Post406(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Post406");
            scope.Start();
            try
            {
                return RestClient.Post406(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 407 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Delete407Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Delete407");
            scope.Start();
            try
            {
                return await RestClient.Delete407Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 407 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete407(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Delete407");
            scope.Start();
            try
            {
                return RestClient.Delete407(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 409 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Put409Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Put409");
            scope.Start();
            try
            {
                return await RestClient.Put409Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 409 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Put409(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Put409");
            scope.Start();
            try
            {
                return RestClient.Put409(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 410 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Head410Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Head410");
            scope.Start();
            try
            {
                return await RestClient.Head410Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 410 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Head410(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Head410");
            scope.Start();
            try
            {
                return RestClient.Head410(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 411 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Get411Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Get411");
            scope.Start();
            try
            {
                return await RestClient.Get411Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 411 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Get411(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Get411");
            scope.Start();
            try
            {
                return RestClient.Get411(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 412 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Options412Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Options412");
            scope.Start();
            try
            {
                return await RestClient.Options412Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 412 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Options412(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Options412");
            scope.Start();
            try
            {
                return RestClient.Options412(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 412 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Get412Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Get412");
            scope.Start();
            try
            {
                return await RestClient.Get412Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 412 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Get412(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Get412");
            scope.Start();
            try
            {
                return RestClient.Get412(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 413 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Put413Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Put413");
            scope.Start();
            try
            {
                return await RestClient.Put413Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 413 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Put413(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Put413");
            scope.Start();
            try
            {
                return RestClient.Put413(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 414 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Patch414Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Patch414");
            scope.Start();
            try
            {
                return await RestClient.Patch414Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 414 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Patch414(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Patch414");
            scope.Start();
            try
            {
                return RestClient.Patch414(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 415 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Post415Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Post415");
            scope.Start();
            try
            {
                return await RestClient.Post415Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 415 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Post415(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Post415");
            scope.Start();
            try
            {
                return RestClient.Post415(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 416 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Get416Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Get416");
            scope.Start();
            try
            {
                return await RestClient.Get416Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 416 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Get416(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Get416");
            scope.Start();
            try
            {
                return RestClient.Get416(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 417 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Delete417Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Delete417");
            scope.Start();
            try
            {
                return await RestClient.Delete417Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 417 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete417(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Delete417");
            scope.Start();
            try
            {
                return RestClient.Delete417(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 429 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Head429Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Head429");
            scope.Start();
            try
            {
                return await RestClient.Head429Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 429 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Head429(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpClientFailureClient.Head429");
            scope.Start();
            try
            {
                return RestClient.Head429(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
