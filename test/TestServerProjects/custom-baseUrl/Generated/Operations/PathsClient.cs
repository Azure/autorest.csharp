// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace custom_baseUrl
{
    public partial class PathsClient
    {
        private PathsRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of PathsClient. </summary>
        internal PathsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "host")
        {
            restClient = new PathsRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get a 200 to test a valid base uri. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetEmptyAsync(string accountName, CancellationToken cancellationToken = default)
        {
            return await restClient.GetEmptyAsync(accountName, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get a 200 to test a valid base uri. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetEmpty(string accountName, CancellationToken cancellationToken = default)
        {
            return restClient.GetEmpty(accountName, cancellationToken);
        }
    }
}
