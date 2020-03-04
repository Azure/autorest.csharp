// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace body_duration
{
    public partial class DurationClient
    {
        private DurationRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of DurationClient. </summary>
        internal DurationClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new DurationRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get null duration value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<TimeSpan>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null duration value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<TimeSpan> GetNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetNull(cancellationToken);
        }
        /// <summary> Put a positive duration value. </summary>
        /// <param name="durationBody"> The Duration to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutPositiveDurationAsync(TimeSpan durationBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutPositiveDurationAsync(durationBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put a positive duration value. </summary>
        /// <param name="durationBody"> The Duration to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutPositiveDuration(TimeSpan durationBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutPositiveDuration(durationBody, cancellationToken);
        }
        /// <summary> Get a positive duration value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<TimeSpan>> GetPositiveDurationAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetPositiveDurationAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get a positive duration value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<TimeSpan> GetPositiveDuration(CancellationToken cancellationToken = default)
        {
            return restClient.GetPositiveDuration(cancellationToken);
        }
        /// <summary> Get an invalid duration value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<TimeSpan>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetInvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an invalid duration value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<TimeSpan> GetInvalid(CancellationToken cancellationToken = default)
        {
            return restClient.GetInvalid(cancellationToken);
        }
    }
}
