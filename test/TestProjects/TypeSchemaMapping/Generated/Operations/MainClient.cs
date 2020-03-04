// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using TypeSchemaMapping;

namespace CustomNamespace
{
    internal partial class MainClient
    {
        internal AllRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of MainClient. </summary>
        internal MainClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new AllRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <param name="body"> The Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<CustomizedModel>> OperationAsync(CustomizedModel body, CancellationToken cancellationToken = default)
        {
            return await RestClient.OperationAsync(body, cancellationToken).ConfigureAwait(false);
        }
        /// <param name="body"> The Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<CustomizedModel> Operation(CustomizedModel body, CancellationToken cancellationToken = default)
        {
            return RestClient.Operation(body, cancellationToken);
        }
    }
}
