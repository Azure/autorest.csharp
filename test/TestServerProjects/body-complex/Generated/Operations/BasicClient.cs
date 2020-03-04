// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using body_complex.Models;

namespace body_complex
{
    public partial class BasicClient
    {
        private BasicRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of BasicClient. </summary>
        internal BasicClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000", string ApiVersion = "2016-02-29")
        {
            restClient = new BasicRestClient(clientDiagnostics, pipeline, host, ApiVersion);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get complex type {id: 2, name: &apos;abc&apos;, color: &apos;YELLOW&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Basic>> GetValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex type {id: 2, name: &apos;abc&apos;, color: &apos;YELLOW&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Basic> GetValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetValid(cancellationToken);
        }
        /// <summary> Please put {id: 2, name: &apos;abc&apos;, color: &apos;Magenta&apos;}. </summary>
        /// <param name="complexBody"> Please put {id: 2, name: &apos;abc&apos;, color: &apos;Magenta&apos;}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutValidAsync(Basic complexBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutValidAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Please put {id: 2, name: &apos;abc&apos;, color: &apos;Magenta&apos;}. </summary>
        /// <param name="complexBody"> Please put {id: 2, name: &apos;abc&apos;, color: &apos;Magenta&apos;}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutValid(Basic complexBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutValid(complexBody, cancellationToken);
        }
        /// <summary> Get a basic complex type that is invalid for the local strong type. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Basic>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetInvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get a basic complex type that is invalid for the local strong type. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Basic> GetInvalid(CancellationToken cancellationToken = default)
        {
            return restClient.GetInvalid(cancellationToken);
        }
        /// <summary> Get a basic complex type that is empty. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Basic>> GetEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get a basic complex type that is empty. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Basic> GetEmpty(CancellationToken cancellationToken = default)
        {
            return restClient.GetEmpty(cancellationToken);
        }
        /// <summary> Get a basic complex type whose properties are null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Basic>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get a basic complex type whose properties are null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Basic> GetNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetNull(cancellationToken);
        }
        /// <summary> Get a basic complex type while the server doesn&apos;t provide a response payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Basic>> GetNotProvidedAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetNotProvidedAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get a basic complex type while the server doesn&apos;t provide a response payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Basic> GetNotProvided(CancellationToken cancellationToken = default)
        {
            return restClient.GetNotProvided(cancellationToken);
        }
    }
}
