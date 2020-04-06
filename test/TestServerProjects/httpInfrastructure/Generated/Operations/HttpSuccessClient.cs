// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace httpInfrastructure
{
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
        internal HttpSuccessClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new HttpSuccessRestClient(clientDiagnostics, pipeline, host);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Return 200 status code if successful. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Head200Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Head200Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Return 200 status code if successful. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Head200(CancellationToken cancellationToken = default)
        {
            return RestClient.Head200(cancellationToken);
        }

        /// <summary> Get 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> Get200Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Get200Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Get200(CancellationToken cancellationToken = default)
        {
            return RestClient.Get200(cancellationToken);
        }

        /// <summary> Options 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> Options200Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Options200Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Options 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Options200(CancellationToken cancellationToken = default)
        {
            return RestClient.Options200(cancellationToken);
        }

        /// <summary> Put boolean value true returning 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Put200Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Put200Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put boolean value true returning 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Put200(CancellationToken cancellationToken = default)
        {
            return RestClient.Put200(cancellationToken);
        }

        /// <summary> Patch true Boolean value in request returning 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Patch200Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Patch200Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Patch true Boolean value in request returning 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Patch200(CancellationToken cancellationToken = default)
        {
            return RestClient.Patch200(cancellationToken);
        }

        /// <summary> Post bollean value true in request that returns a 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Post200Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Post200Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Post bollean value true in request that returns a 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Post200(CancellationToken cancellationToken = default)
        {
            return RestClient.Post200(cancellationToken);
        }

        /// <summary> Delete simple boolean value true returns 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Delete200Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Delete200Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Delete simple boolean value true returns 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete200(CancellationToken cancellationToken = default)
        {
            return RestClient.Delete200(cancellationToken);
        }

        /// <summary> Put true Boolean value in request returns 201. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Put201Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Put201Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put true Boolean value in request returns 201. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Put201(CancellationToken cancellationToken = default)
        {
            return RestClient.Put201(cancellationToken);
        }

        /// <summary> Post true Boolean value in request returns 201 (Created). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Post201Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Post201Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Post true Boolean value in request returns 201 (Created). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Post201(CancellationToken cancellationToken = default)
        {
            return RestClient.Post201(cancellationToken);
        }

        /// <summary> Put true Boolean value in request returns 202 (Accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Put202Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Put202Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put true Boolean value in request returns 202 (Accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Put202(CancellationToken cancellationToken = default)
        {
            return RestClient.Put202(cancellationToken);
        }

        /// <summary> Patch true Boolean value in request returns 202. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Patch202Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Patch202Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Patch true Boolean value in request returns 202. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Patch202(CancellationToken cancellationToken = default)
        {
            return RestClient.Patch202(cancellationToken);
        }

        /// <summary> Post true Boolean value in request returns 202 (Accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Post202Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Post202Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Post true Boolean value in request returns 202 (Accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Post202(CancellationToken cancellationToken = default)
        {
            return RestClient.Post202(cancellationToken);
        }

        /// <summary> Delete true Boolean value in request returns 202 (accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Delete202Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Delete202Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Delete true Boolean value in request returns 202 (accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete202(CancellationToken cancellationToken = default)
        {
            return RestClient.Delete202(cancellationToken);
        }

        /// <summary> Return 204 status code if successful. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Head204Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Head204Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Return 204 status code if successful. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Head204(CancellationToken cancellationToken = default)
        {
            return RestClient.Head204(cancellationToken);
        }

        /// <summary> Put true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Put204Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Put204Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Put204(CancellationToken cancellationToken = default)
        {
            return RestClient.Put204(cancellationToken);
        }

        /// <summary> Patch true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Patch204Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Patch204Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Patch true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Patch204(CancellationToken cancellationToken = default)
        {
            return RestClient.Patch204(cancellationToken);
        }

        /// <summary> Post true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Post204Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Post204Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Post true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Post204(CancellationToken cancellationToken = default)
        {
            return RestClient.Post204(cancellationToken);
        }

        /// <summary> Delete true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Delete204Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Delete204Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Delete true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete204(CancellationToken cancellationToken = default)
        {
            return RestClient.Delete204(cancellationToken);
        }

        /// <summary> Return 404 status code. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Head404Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Head404Async(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Return 404 status code. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Head404(CancellationToken cancellationToken = default)
        {
            return RestClient.Head404(cancellationToken);
        }
    }
}
