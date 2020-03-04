// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace httpInfrastructure
{
    public partial class HttpClientFailureClient
    {
        private HttpClientFailureRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of HttpClientFailureClient. </summary>
        internal HttpClientFailureClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new HttpClientFailureRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Head400Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Head400Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head400(CancellationToken cancellationToken = default)
        {
            return restClient.Head400(cancellationToken);
        }
        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get400Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Get400Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get400(CancellationToken cancellationToken = default)
        {
            return restClient.Get400(cancellationToken);
        }
        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Options400Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Options400Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Options400(CancellationToken cancellationToken = default)
        {
            return restClient.Options400(cancellationToken);
        }
        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Put400Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Put400Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put400(CancellationToken cancellationToken = default)
        {
            return restClient.Put400(cancellationToken);
        }
        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Patch400Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Patch400Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Patch400(CancellationToken cancellationToken = default)
        {
            return restClient.Patch400(cancellationToken);
        }
        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Post400Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Post400Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post400(CancellationToken cancellationToken = default)
        {
            return restClient.Post400(cancellationToken);
        }
        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Delete400Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Delete400Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete400(CancellationToken cancellationToken = default)
        {
            return restClient.Delete400(cancellationToken);
        }
        /// <summary> Return 401 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Head401Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Head401Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 401 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head401(CancellationToken cancellationToken = default)
        {
            return restClient.Head401(cancellationToken);
        }
        /// <summary> Return 402 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get402Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Get402Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 402 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get402(CancellationToken cancellationToken = default)
        {
            return restClient.Get402(cancellationToken);
        }
        /// <summary> Return 403 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Options403Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Options403Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 403 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Options403(CancellationToken cancellationToken = default)
        {
            return restClient.Options403(cancellationToken);
        }
        /// <summary> Return 403 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get403Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Get403Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 403 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get403(CancellationToken cancellationToken = default)
        {
            return restClient.Get403(cancellationToken);
        }
        /// <summary> Return 404 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Put404Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Put404Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 404 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put404(CancellationToken cancellationToken = default)
        {
            return restClient.Put404(cancellationToken);
        }
        /// <summary> Return 405 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Patch405Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Patch405Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 405 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Patch405(CancellationToken cancellationToken = default)
        {
            return restClient.Patch405(cancellationToken);
        }
        /// <summary> Return 406 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Post406Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Post406Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 406 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post406(CancellationToken cancellationToken = default)
        {
            return restClient.Post406(cancellationToken);
        }
        /// <summary> Return 407 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Delete407Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Delete407Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 407 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete407(CancellationToken cancellationToken = default)
        {
            return restClient.Delete407(cancellationToken);
        }
        /// <summary> Return 409 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Put409Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Put409Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 409 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put409(CancellationToken cancellationToken = default)
        {
            return restClient.Put409(cancellationToken);
        }
        /// <summary> Return 410 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Head410Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Head410Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 410 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head410(CancellationToken cancellationToken = default)
        {
            return restClient.Head410(cancellationToken);
        }
        /// <summary> Return 411 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get411Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Get411Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 411 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get411(CancellationToken cancellationToken = default)
        {
            return restClient.Get411(cancellationToken);
        }
        /// <summary> Return 412 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Options412Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Options412Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 412 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Options412(CancellationToken cancellationToken = default)
        {
            return restClient.Options412(cancellationToken);
        }
        /// <summary> Return 412 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get412Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Get412Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 412 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get412(CancellationToken cancellationToken = default)
        {
            return restClient.Get412(cancellationToken);
        }
        /// <summary> Return 413 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Put413Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Put413Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 413 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put413(CancellationToken cancellationToken = default)
        {
            return restClient.Put413(cancellationToken);
        }
        /// <summary> Return 414 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Patch414Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Patch414Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 414 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Patch414(CancellationToken cancellationToken = default)
        {
            return restClient.Patch414(cancellationToken);
        }
        /// <summary> Return 415 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Post415Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Post415Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 415 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post415(CancellationToken cancellationToken = default)
        {
            return restClient.Post415(cancellationToken);
        }
        /// <summary> Return 416 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get416Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Get416Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 416 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get416(CancellationToken cancellationToken = default)
        {
            return restClient.Get416(cancellationToken);
        }
        /// <summary> Return 417 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Delete417Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Delete417Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 417 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete417(CancellationToken cancellationToken = default)
        {
            return restClient.Delete417(cancellationToken);
        }
        /// <summary> Return 429 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Head429Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Head429Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 429 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head429(CancellationToken cancellationToken = default)
        {
            return restClient.Head429(cancellationToken);
        }
    }
}
