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
    public partial class ReadonlypropertyClient
    {
        private ReadonlypropertyRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of ReadonlypropertyClient. </summary>
        internal ReadonlypropertyClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new ReadonlypropertyRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get complex types that have readonly properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ReadonlyObj>> GetValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types that have readonly properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ReadonlyObj> GetValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetValid(cancellationToken);
        }
        /// <summary> Put complex types that have readonly properties. </summary>
        /// <param name="complexBody"> The ReadonlyObj to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutValidAsync(ReadonlyObj complexBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutValidAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types that have readonly properties. </summary>
        /// <param name="complexBody"> The ReadonlyObj to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutValid(ReadonlyObj complexBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutValid(complexBody, cancellationToken);
        }
    }
}
