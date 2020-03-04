// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace body_boolean
{
    public partial class BoolClient
    {
        private BoolRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of BoolClient. </summary>
        internal BoolClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new BoolRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get true Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<bool>> GetTrueAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetTrueAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get true Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<bool> GetTrue(CancellationToken cancellationToken = default)
        {
            return restClient.GetTrue(cancellationToken);
        }
        /// <summary> Set Boolean value true. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutTrueAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.PutTrueAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set Boolean value true. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutTrue(CancellationToken cancellationToken = default)
        {
            return restClient.PutTrue(cancellationToken);
        }
        /// <summary> Get false Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<bool>> GetFalseAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetFalseAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get false Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<bool> GetFalse(CancellationToken cancellationToken = default)
        {
            return restClient.GetFalse(cancellationToken);
        }
        /// <summary> Set Boolean value false. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutFalseAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.PutFalseAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set Boolean value false. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutFalse(CancellationToken cancellationToken = default)
        {
            return restClient.PutFalse(cancellationToken);
        }
        /// <summary> Get null Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<bool>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<bool> GetNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetNull(cancellationToken);
        }
        /// <summary> Get invalid Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<bool>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetInvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get invalid Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<bool> GetInvalid(CancellationToken cancellationToken = default)
        {
            return restClient.GetInvalid(cancellationToken);
        }
    }
}
