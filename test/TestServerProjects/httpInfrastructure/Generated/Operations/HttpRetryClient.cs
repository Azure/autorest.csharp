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
        private HttpRetryRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of HttpRetryClient. </summary>
        internal HttpRetryClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new HttpRetryRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Return 408 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Head408Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Head408Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 408 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head408(CancellationToken cancellationToken = default)
        {
            return restClient.Head408(cancellationToken);
        }
        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Put500Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Put500Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put500(CancellationToken cancellationToken = default)
        {
            return restClient.Put500(cancellationToken);
        }
        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Patch500Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Patch500Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 500 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Patch500(CancellationToken cancellationToken = default)
        {
            return restClient.Patch500(cancellationToken);
        }
        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get502Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Get502Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get502(CancellationToken cancellationToken = default)
        {
            return restClient.Get502(cancellationToken);
        }
        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<bool>> Options502Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Options502Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 502 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<bool> Options502(CancellationToken cancellationToken = default)
        {
            return restClient.Options502(cancellationToken);
        }
        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Post503Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Post503Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post503(CancellationToken cancellationToken = default)
        {
            return restClient.Post503(cancellationToken);
        }
        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Delete503Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Delete503Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 503 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete503(CancellationToken cancellationToken = default)
        {
            return restClient.Delete503(cancellationToken);
        }
        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Put504Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Put504Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put504(CancellationToken cancellationToken = default)
        {
            return restClient.Put504(cancellationToken);
        }
        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Patch504Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Patch504Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 504 status code, then 200 after retry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Patch504(CancellationToken cancellationToken = default)
        {
            return restClient.Patch504(cancellationToken);
        }
    }
}
