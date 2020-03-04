// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace httpInfrastructure
{
    public partial class HttpSuccessClient
    {
        private HttpSuccessRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of HttpSuccessClient. </summary>
        internal HttpSuccessClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new HttpSuccessRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Return 200 status code if successful. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Head200Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Head200Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 200 status code if successful. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head200(CancellationToken cancellationToken = default)
        {
            return restClient.Head200(cancellationToken);
        }
        /// <summary> Get 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<bool>> Get200Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<bool> Get200(CancellationToken cancellationToken = default)
        {
            return restClient.Get200(cancellationToken);
        }
        /// <summary> Options 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<bool>> Options200Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Options200Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Options 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<bool> Options200(CancellationToken cancellationToken = default)
        {
            return restClient.Options200(cancellationToken);
        }
        /// <summary> Put boolean value true returning 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Put200Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Put200Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put boolean value true returning 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put200(CancellationToken cancellationToken = default)
        {
            return restClient.Put200(cancellationToken);
        }
        /// <summary> Patch true Boolean value in request returning 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Patch200Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Patch200Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Patch true Boolean value in request returning 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Patch200(CancellationToken cancellationToken = default)
        {
            return restClient.Patch200(cancellationToken);
        }
        /// <summary> Post bollean value true in request that returns a 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Post200Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Post200Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Post bollean value true in request that returns a 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post200(CancellationToken cancellationToken = default)
        {
            return restClient.Post200(cancellationToken);
        }
        /// <summary> Delete simple boolean value true returns 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Delete200Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Delete200Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Delete simple boolean value true returns 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete200(CancellationToken cancellationToken = default)
        {
            return restClient.Delete200(cancellationToken);
        }
        /// <summary> Put true Boolean value in request returns 201. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Put201Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Put201Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put true Boolean value in request returns 201. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put201(CancellationToken cancellationToken = default)
        {
            return restClient.Put201(cancellationToken);
        }
        /// <summary> Post true Boolean value in request returns 201 (Created). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Post201Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Post201Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Post true Boolean value in request returns 201 (Created). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post201(CancellationToken cancellationToken = default)
        {
            return restClient.Post201(cancellationToken);
        }
        /// <summary> Put true Boolean value in request returns 202 (Accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Put202Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Put202Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put true Boolean value in request returns 202 (Accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put202(CancellationToken cancellationToken = default)
        {
            return restClient.Put202(cancellationToken);
        }
        /// <summary> Patch true Boolean value in request returns 202. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Patch202Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Patch202Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Patch true Boolean value in request returns 202. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Patch202(CancellationToken cancellationToken = default)
        {
            return restClient.Patch202(cancellationToken);
        }
        /// <summary> Post true Boolean value in request returns 202 (Accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Post202Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Post202Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Post true Boolean value in request returns 202 (Accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post202(CancellationToken cancellationToken = default)
        {
            return restClient.Post202(cancellationToken);
        }
        /// <summary> Delete true Boolean value in request returns 202 (accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Delete202Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Delete202Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Delete true Boolean value in request returns 202 (accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete202(CancellationToken cancellationToken = default)
        {
            return restClient.Delete202(cancellationToken);
        }
        /// <summary> Return 204 status code if successful. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Head204Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Head204Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 204 status code if successful. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head204(CancellationToken cancellationToken = default)
        {
            return restClient.Head204(cancellationToken);
        }
        /// <summary> Put true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Put204Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Put204Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put204(CancellationToken cancellationToken = default)
        {
            return restClient.Put204(cancellationToken);
        }
        /// <summary> Patch true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Patch204Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Patch204Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Patch true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Patch204(CancellationToken cancellationToken = default)
        {
            return restClient.Patch204(cancellationToken);
        }
        /// <summary> Post true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Post204Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Post204Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Post true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post204(CancellationToken cancellationToken = default)
        {
            return restClient.Post204(cancellationToken);
        }
        /// <summary> Delete true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Delete204Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Delete204Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Delete true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete204(CancellationToken cancellationToken = default)
        {
            return restClient.Delete204(cancellationToken);
        }
        /// <summary> Return 404 status code. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Head404Async(CancellationToken cancellationToken = default)
        {
            return await restClient.Head404Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Return 404 status code. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head404(CancellationToken cancellationToken = default)
        {
            return restClient.Head404(cancellationToken);
        }
    }
}
