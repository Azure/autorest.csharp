// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace httpInfrastructure
{
    public partial class HttpServerFailureClient
    {
        private HttpServerFailureRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of HttpServerFailureClient. </summary>
        internal HttpServerFailureClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new HttpServerFailureRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Return 501 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Head501Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Head501Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 501 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head501(CancellationToken cancellationToken = default)
        {
            return restClient.Head501(cancellationToken);
        }
        /// <summary> Return 501 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get501Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Get501Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 501 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get501(CancellationToken cancellationToken = default)
        {
            return restClient.Get501(cancellationToken);
        }
        /// <summary> Return 505 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Post505Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Post505Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 505 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post505(CancellationToken cancellationToken = default)
        {
            return restClient.Post505(cancellationToken);
        }
        /// <summary> Return 505 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Delete505Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Delete505Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 505 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete505(CancellationToken cancellationToken = default)
        {
            return restClient.Delete505(cancellationToken);
        }
    }
}
