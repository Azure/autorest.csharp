// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace httpInfrastructure
{
    public partial class HttpFailureClient
    {
        internal HttpFailureRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of HttpFailureClient. </summary>
        internal HttpFailureClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new HttpFailureRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get empty error form server. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<bool>> GetEmptyErrorAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetEmptyErrorAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get empty error form server. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<bool> GetEmptyError(CancellationToken cancellationToken = default)
        {
            return RestClient.GetEmptyError(cancellationToken);
        }
        /// <summary> Get empty error form server. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<bool>> GetNoModelErrorAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetNoModelErrorAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get empty error form server. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<bool> GetNoModelError(CancellationToken cancellationToken = default)
        {
            return RestClient.GetNoModelError(cancellationToken);
        }
        /// <summary> Get empty response from server. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<bool>> GetNoModelEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetNoModelEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get empty response from server. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<bool> GetNoModelEmpty(CancellationToken cancellationToken = default)
        {
            return RestClient.GetNoModelEmpty(cancellationToken);
        }
    }
}
