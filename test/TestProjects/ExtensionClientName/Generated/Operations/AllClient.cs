// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using ExtensionClientName.Models;

namespace ExtensionClientName
{
    public partial class AllClient
    {
        private AllRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of AllClient. </summary>
        internal AllClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new AllRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <param name="renamedPathParameter"> The String to use. </param>
        /// <param name="renamedQueryParameter"> The String to use. </param>
        /// <param name="renamedBodyParameter"> The RenamedSchema to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<RenamedSchema>> RenamedOperationAsync(string renamedPathParameter, string renamedQueryParameter, RenamedSchema renamedBodyParameter, CancellationToken cancellationToken = default)
        {
            return await restClient.RenamedOperationAsync(renamedPathParameter, renamedQueryParameter, renamedBodyParameter, cancellationToken).ConfigureAwait(false);
        }
        /// <param name="renamedPathParameter"> The String to use. </param>
        /// <param name="renamedQueryParameter"> The String to use. </param>
        /// <param name="renamedBodyParameter"> The RenamedSchema to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<RenamedSchema> RenamedOperation(string renamedPathParameter, string renamedQueryParameter, RenamedSchema renamedBodyParameter, CancellationToken cancellationToken = default)
        {
            return restClient.RenamedOperation(renamedPathParameter, renamedQueryParameter, renamedBodyParameter, cancellationToken);
        }
    }
}
