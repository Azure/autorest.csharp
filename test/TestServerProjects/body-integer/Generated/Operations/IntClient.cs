// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace body_integer
{
    public partial class IntClient
    {
        private IntRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of IntClient. </summary>
        internal IntClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new IntRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get null Int value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<int>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null Int value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<int> GetNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetNull(cancellationToken);
        }
        /// <summary> Get invalid Int value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<int>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetInvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get invalid Int value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<int> GetInvalid(CancellationToken cancellationToken = default)
        {
            return restClient.GetInvalid(cancellationToken);
        }
        /// <summary> Get overflow Int32 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<int>> GetOverflowInt32Async(CancellationToken cancellationToken = default)
        {
            return await restClient.GetOverflowInt32Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get overflow Int32 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<int> GetOverflowInt32(CancellationToken cancellationToken = default)
        {
            return restClient.GetOverflowInt32(cancellationToken);
        }
        /// <summary> Get underflow Int32 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<int>> GetUnderflowInt32Async(CancellationToken cancellationToken = default)
        {
            return await restClient.GetUnderflowInt32Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get underflow Int32 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<int> GetUnderflowInt32(CancellationToken cancellationToken = default)
        {
            return restClient.GetUnderflowInt32(cancellationToken);
        }
        /// <summary> Get overflow Int64 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<long>> GetOverflowInt64Async(CancellationToken cancellationToken = default)
        {
            return await restClient.GetOverflowInt64Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get overflow Int64 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<long> GetOverflowInt64(CancellationToken cancellationToken = default)
        {
            return restClient.GetOverflowInt64(cancellationToken);
        }
        /// <summary> Get underflow Int64 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<long>> GetUnderflowInt64Async(CancellationToken cancellationToken = default)
        {
            return await restClient.GetUnderflowInt64Async(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get underflow Int64 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<long> GetUnderflowInt64(CancellationToken cancellationToken = default)
        {
            return restClient.GetUnderflowInt64(cancellationToken);
        }
        /// <summary> Put max int32 value. </summary>
        /// <param name="intBody"> The Integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutMax32Async(int intBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutMax32Async(intBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put max int32 value. </summary>
        /// <param name="intBody"> The Integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutMax32(int intBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutMax32(intBody, cancellationToken);
        }
        /// <summary> Put max int64 value. </summary>
        /// <param name="intBody"> The Integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutMax64Async(long intBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutMax64Async(intBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put max int64 value. </summary>
        /// <param name="intBody"> The Integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutMax64(long intBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutMax64(intBody, cancellationToken);
        }
        /// <summary> Put min int32 value. </summary>
        /// <param name="intBody"> The Integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutMin32Async(int intBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutMin32Async(intBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put min int32 value. </summary>
        /// <param name="intBody"> The Integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutMin32(int intBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutMin32(intBody, cancellationToken);
        }
        /// <summary> Put min int64 value. </summary>
        /// <param name="intBody"> The Integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutMin64Async(long intBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutMin64Async(intBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put min int64 value. </summary>
        /// <param name="intBody"> The Integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutMin64(long intBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutMin64(intBody, cancellationToken);
        }
        /// <summary> Get datetime encoded as Unix time value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetUnixTimeAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetUnixTimeAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get datetime encoded as Unix time value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetUnixTime(CancellationToken cancellationToken = default)
        {
            return restClient.GetUnixTime(cancellationToken);
        }
        /// <summary> Put datetime encoded as Unix time. </summary>
        /// <param name="intBody"> The Unixtime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutUnixTimeDateAsync(DateTimeOffset intBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutUnixTimeDateAsync(intBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put datetime encoded as Unix time. </summary>
        /// <param name="intBody"> The Unixtime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutUnixTimeDate(DateTimeOffset intBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutUnixTimeDate(intBody, cancellationToken);
        }
        /// <summary> Get invalid Unix time value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetInvalidUnixTimeAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetInvalidUnixTimeAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get invalid Unix time value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetInvalidUnixTime(CancellationToken cancellationToken = default)
        {
            return restClient.GetInvalidUnixTime(cancellationToken);
        }
        /// <summary> Get null Unix time value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetNullUnixTimeAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetNullUnixTimeAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null Unix time value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetNullUnixTime(CancellationToken cancellationToken = default)
        {
            return restClient.GetNullUnixTime(cancellationToken);
        }
    }
}
