// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace body_date
{
    public partial class DateClient
    {
        internal DateRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of DateClient. </summary>
        internal DateClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new DateRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get null date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetNull(cancellationToken);
        }
        /// <summary> Get invalid date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetInvalidDateAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetInvalidDateAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get invalid date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetInvalidDate(CancellationToken cancellationToken = default)
        {
            return RestClient.GetInvalidDate(cancellationToken);
        }
        /// <summary> Get overflow date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetOverflowDateAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetOverflowDateAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get overflow date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetOverflowDate(CancellationToken cancellationToken = default)
        {
            return RestClient.GetOverflowDate(cancellationToken);
        }
        /// <summary> Get underflow date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetUnderflowDateAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetUnderflowDateAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get underflow date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetUnderflowDate(CancellationToken cancellationToken = default)
        {
            return RestClient.GetUnderflowDate(cancellationToken);
        }
        /// <summary> Put max date value 9999-12-31. </summary>
        /// <param name="dateBody"> The Date to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutMaxDateAsync(DateTimeOffset dateBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutMaxDateAsync(dateBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put max date value 9999-12-31. </summary>
        /// <param name="dateBody"> The Date to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutMaxDate(DateTimeOffset dateBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutMaxDate(dateBody, cancellationToken);
        }
        /// <summary> Get max date value 9999-12-31. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetMaxDateAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetMaxDateAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get max date value 9999-12-31. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetMaxDate(CancellationToken cancellationToken = default)
        {
            return RestClient.GetMaxDate(cancellationToken);
        }
        /// <summary> Put min date value 0000-01-01. </summary>
        /// <param name="dateBody"> The Date to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutMinDateAsync(DateTimeOffset dateBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutMinDateAsync(dateBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put min date value 0000-01-01. </summary>
        /// <param name="dateBody"> The Date to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutMinDate(DateTimeOffset dateBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutMinDate(dateBody, cancellationToken);
        }
        /// <summary> Get min date value 0000-01-01. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetMinDateAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetMinDateAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get min date value 0000-01-01. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetMinDate(CancellationToken cancellationToken = default)
        {
            return RestClient.GetMinDate(cancellationToken);
        }
    }
}
