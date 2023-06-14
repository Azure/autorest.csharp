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
    /// <summary> The HttpSuccess service client. </summary>
    public partial class HttpSuccessClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal HttpSuccessRestClient RestClient { get; }

        /// <summary> Initializes a new instance of HttpSuccessClient for mocking. </summary>
        protected HttpSuccessClient()
        {
        }

        /// <summary> Initializes a new instance of HttpSuccessClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal HttpSuccessClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new HttpSuccessRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Return 200 status code if successful. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Head200Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Head200");
            scope.Start();
            try
            {
                return await RestClient.Head200Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 200 status code if successful. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Head200(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Head200");
            scope.Start();
            try
            {
                return RestClient.Head200(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> Get200Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Get200");
            scope.Start();
            try
            {
                return await RestClient.Get200Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Get200(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Get200");
            scope.Start();
            try
            {
                return RestClient.Get200(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Options 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> Options200Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Options200");
            scope.Start();
            try
            {
                return await RestClient.Options200Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Options 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Options200(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Options200");
            scope.Start();
            try
            {
                return RestClient.Options200(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put boolean value true returning 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Put200Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Put200");
            scope.Start();
            try
            {
                return await RestClient.Put200Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put boolean value true returning 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Put200(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Put200");
            scope.Start();
            try
            {
                return RestClient.Put200(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Patch true Boolean value in request returning 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Patch200Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Patch200");
            scope.Start();
            try
            {
                return await RestClient.Patch200Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Patch true Boolean value in request returning 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Patch200(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Patch200");
            scope.Start();
            try
            {
                return RestClient.Patch200(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Post bollean value true in request that returns a 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Post200Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Post200");
            scope.Start();
            try
            {
                return await RestClient.Post200Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Post bollean value true in request that returns a 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Post200(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Post200");
            scope.Start();
            try
            {
                return RestClient.Post200(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete simple boolean value true returns 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Delete200Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Delete200");
            scope.Start();
            try
            {
                return await RestClient.Delete200Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete simple boolean value true returns 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete200(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Delete200");
            scope.Start();
            try
            {
                return RestClient.Delete200(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put true Boolean value in request returns 201. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Put201Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Put201");
            scope.Start();
            try
            {
                return await RestClient.Put201Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put true Boolean value in request returns 201. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Put201(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Put201");
            scope.Start();
            try
            {
                return RestClient.Put201(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Post true Boolean value in request returns 201 (Created). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Post201Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Post201");
            scope.Start();
            try
            {
                return await RestClient.Post201Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Post true Boolean value in request returns 201 (Created). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Post201(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Post201");
            scope.Start();
            try
            {
                return RestClient.Post201(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put true Boolean value in request returns 202 (Accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Put202Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Put202");
            scope.Start();
            try
            {
                return await RestClient.Put202Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put true Boolean value in request returns 202 (Accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Put202(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Put202");
            scope.Start();
            try
            {
                return RestClient.Put202(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Patch true Boolean value in request returns 202. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Patch202Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Patch202");
            scope.Start();
            try
            {
                return await RestClient.Patch202Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Patch true Boolean value in request returns 202. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Patch202(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Patch202");
            scope.Start();
            try
            {
                return RestClient.Patch202(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Post true Boolean value in request returns 202 (Accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Post202Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Post202");
            scope.Start();
            try
            {
                return await RestClient.Post202Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Post true Boolean value in request returns 202 (Accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Post202(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Post202");
            scope.Start();
            try
            {
                return RestClient.Post202(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete true Boolean value in request returns 202 (accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Delete202Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Delete202");
            scope.Start();
            try
            {
                return await RestClient.Delete202Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete true Boolean value in request returns 202 (accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete202(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Delete202");
            scope.Start();
            try
            {
                return RestClient.Delete202(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 204 status code if successful. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Head204Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Head204");
            scope.Start();
            try
            {
                return await RestClient.Head204Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 204 status code if successful. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Head204(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Head204");
            scope.Start();
            try
            {
                return RestClient.Head204(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Put204Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Put204");
            scope.Start();
            try
            {
                return await RestClient.Put204Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Put204(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Put204");
            scope.Start();
            try
            {
                return RestClient.Put204(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Patch true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Patch204Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Patch204");
            scope.Start();
            try
            {
                return await RestClient.Patch204Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Patch true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Patch204(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Patch204");
            scope.Start();
            try
            {
                return RestClient.Patch204(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Post true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Post204Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Post204");
            scope.Start();
            try
            {
                return await RestClient.Post204Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Post true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Post204(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Post204");
            scope.Start();
            try
            {
                return RestClient.Post204(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Delete204Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Delete204");
            scope.Start();
            try
            {
                return await RestClient.Delete204Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete204(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Delete204");
            scope.Start();
            try
            {
                return RestClient.Delete204(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 404 status code. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Head404Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Head404");
            scope.Start();
            try
            {
                return await RestClient.Head404Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 404 status code. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Head404(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HttpSuccessClient.Head404");
            scope.Start();
            try
            {
                return RestClient.Head404(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
