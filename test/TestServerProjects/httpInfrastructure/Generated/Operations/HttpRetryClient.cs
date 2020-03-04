// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace httpInfrastructure
{
    public partial class HttpRetryClient
    {
        internal HttpRetryRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of HttpRetryClient. </summary>
        internal HttpRetryClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new HttpRetryRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Return 408 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Head408Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Head408Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 408 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head408(CancellationToken cancellationToken = default)
        {
            return RestClient.Head408(cancellationToken);
        }
        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Put500Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Put500Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put500(CancellationToken cancellationToken = default)
        {
            return RestClient.Put500(cancellationToken);
        }
        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Patch500Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Patch500Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Patch500(CancellationToken cancellationToken = default)
        {
            return RestClient.Patch500(cancellationToken);
        }
        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get502Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Get502Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get502(CancellationToken cancellationToken = default)
        {
            return RestClient.Get502(cancellationToken);
        }
        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<bool>> Options502Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Options502Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<bool> Options502(CancellationToken cancellationToken = default)
        {
            return RestClient.Options502(cancellationToken);
        }
        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Post503Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Post503Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post503(CancellationToken cancellationToken = default)
        {
            return RestClient.Post503(cancellationToken);
        }
        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Delete503Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Delete503Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete503(CancellationToken cancellationToken = default)
        {
            return RestClient.Delete503(cancellationToken);
        }
        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Put504Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Put504Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put504(CancellationToken cancellationToken = default)
        {
            return RestClient.Put504(cancellationToken);
        }
        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Patch504Async(CancellationToken cancellationToken = default)
        {
            return await RestClient.Patch504Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Patch504(CancellationToken cancellationToken = default)
        {
            return RestClient.Patch504(cancellationToken);
        }
    }
}
