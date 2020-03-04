// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace body_datetime
{
    public partial class DatetimeClient
    {
        internal DatetimeRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of DatetimeClient. </summary>
        internal DatetimeClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new DatetimeRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get null datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetNull(cancellationToken);
        }
        /// <summary> Get invalid datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetInvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get invalid datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetInvalid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetInvalid(cancellationToken);
        }
        /// <summary> Get overflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetOverflowAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetOverflowAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get overflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetOverflow(CancellationToken cancellationToken = default)
        {
            return RestClient.GetOverflow(cancellationToken);
        }
        /// <summary> Get underflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetUnderflowAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetUnderflowAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get underflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetUnderflow(CancellationToken cancellationToken = default)
        {
            return RestClient.GetUnderflow(cancellationToken);
        }
        /// <summary> Put max datetime value 9999-12-31T23:59:59.999Z. </summary>
        /// <param name="datetimeBody"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutUtcMaxDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutUtcMaxDateTimeAsync(datetimeBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put max datetime value 9999-12-31T23:59:59.999Z. </summary>
        /// <param name="datetimeBody"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutUtcMaxDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutUtcMaxDateTime(datetimeBody, cancellationToken);
        }
        /// <summary> Put max datetime value 9999-12-31T23:59:59.9999999Z. </summary>
        /// <param name="datetimeBody"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutUtcMaxDateTime7DigitsAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutUtcMaxDateTime7DigitsAsync(datetimeBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put max datetime value 9999-12-31T23:59:59.9999999Z. </summary>
        /// <param name="datetimeBody"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutUtcMaxDateTime7Digits(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutUtcMaxDateTime7Digits(datetimeBody, cancellationToken);
        }
        /// <summary> Get max datetime value 9999-12-31t23:59:59.999z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetUtcLowercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetUtcLowercaseMaxDateTimeAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get max datetime value 9999-12-31t23:59:59.999z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetUtcLowercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            return RestClient.GetUtcLowercaseMaxDateTime(cancellationToken);
        }
        /// <summary> Get max datetime value 9999-12-31T23:59:59.999Z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetUtcUppercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetUtcUppercaseMaxDateTimeAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get max datetime value 9999-12-31T23:59:59.999Z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetUtcUppercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            return RestClient.GetUtcUppercaseMaxDateTime(cancellationToken);
        }
        /// <summary> Get max datetime value 9999-12-31T23:59:59.9999999Z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetUtcUppercaseMaxDateTime7DigitsAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetUtcUppercaseMaxDateTime7DigitsAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get max datetime value 9999-12-31T23:59:59.9999999Z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetUtcUppercaseMaxDateTime7Digits(CancellationToken cancellationToken = default)
        {
            return RestClient.GetUtcUppercaseMaxDateTime7Digits(cancellationToken);
        }
        /// <summary> Put max datetime value with positive numoffset 9999-12-31t23:59:59.999+14:00. </summary>
        /// <param name="datetimeBody"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutLocalPositiveOffsetMaxDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutLocalPositiveOffsetMaxDateTimeAsync(datetimeBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put max datetime value with positive numoffset 9999-12-31t23:59:59.999+14:00. </summary>
        /// <param name="datetimeBody"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutLocalPositiveOffsetMaxDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutLocalPositiveOffsetMaxDateTime(datetimeBody, cancellationToken);
        }
        /// <summary> Get max datetime value with positive num offset 9999-12-31t23:59:59.999+14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetLocalPositiveOffsetLowercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetLocalPositiveOffsetLowercaseMaxDateTimeAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get max datetime value with positive num offset 9999-12-31t23:59:59.999+14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetLocalPositiveOffsetLowercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            return RestClient.GetLocalPositiveOffsetLowercaseMaxDateTime(cancellationToken);
        }
        /// <summary> Get max datetime value with positive num offset 9999-12-31T23:59:59.999+14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetLocalPositiveOffsetUppercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetLocalPositiveOffsetUppercaseMaxDateTimeAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get max datetime value with positive num offset 9999-12-31T23:59:59.999+14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetLocalPositiveOffsetUppercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            return RestClient.GetLocalPositiveOffsetUppercaseMaxDateTime(cancellationToken);
        }
        /// <summary> Put max datetime value with positive numoffset 9999-12-31t23:59:59.999-14:00. </summary>
        /// <param name="datetimeBody"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutLocalNegativeOffsetMaxDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutLocalNegativeOffsetMaxDateTimeAsync(datetimeBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put max datetime value with positive numoffset 9999-12-31t23:59:59.999-14:00. </summary>
        /// <param name="datetimeBody"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutLocalNegativeOffsetMaxDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutLocalNegativeOffsetMaxDateTime(datetimeBody, cancellationToken);
        }
        /// <summary> Get max datetime value with positive num offset 9999-12-31T23:59:59.999-14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetLocalNegativeOffsetUppercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetLocalNegativeOffsetUppercaseMaxDateTimeAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get max datetime value with positive num offset 9999-12-31T23:59:59.999-14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetLocalNegativeOffsetUppercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            return RestClient.GetLocalNegativeOffsetUppercaseMaxDateTime(cancellationToken);
        }
        /// <summary> Get max datetime value with positive num offset 9999-12-31t23:59:59.999-14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetLocalNegativeOffsetLowercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetLocalNegativeOffsetLowercaseMaxDateTimeAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get max datetime value with positive num offset 9999-12-31t23:59:59.999-14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetLocalNegativeOffsetLowercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            return RestClient.GetLocalNegativeOffsetLowercaseMaxDateTime(cancellationToken);
        }
        /// <summary> Put min datetime value 0001-01-01T00:00:00Z. </summary>
        /// <param name="datetimeBody"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutUtcMinDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutUtcMinDateTimeAsync(datetimeBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put min datetime value 0001-01-01T00:00:00Z. </summary>
        /// <param name="datetimeBody"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutUtcMinDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutUtcMinDateTime(datetimeBody, cancellationToken);
        }
        /// <summary> Get min datetime value 0001-01-01T00:00:00Z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetUtcMinDateTimeAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetUtcMinDateTimeAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get min datetime value 0001-01-01T00:00:00Z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetUtcMinDateTime(CancellationToken cancellationToken = default)
        {
            return RestClient.GetUtcMinDateTime(cancellationToken);
        }
        /// <summary> Put min datetime value 0001-01-01T00:00:00+14:00. </summary>
        /// <param name="datetimeBody"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutLocalPositiveOffsetMinDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutLocalPositiveOffsetMinDateTimeAsync(datetimeBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put min datetime value 0001-01-01T00:00:00+14:00. </summary>
        /// <param name="datetimeBody"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutLocalPositiveOffsetMinDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutLocalPositiveOffsetMinDateTime(datetimeBody, cancellationToken);
        }
        /// <summary> Get min datetime value 0001-01-01T00:00:00+14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetLocalPositiveOffsetMinDateTimeAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetLocalPositiveOffsetMinDateTimeAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get min datetime value 0001-01-01T00:00:00+14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetLocalPositiveOffsetMinDateTime(CancellationToken cancellationToken = default)
        {
            return RestClient.GetLocalPositiveOffsetMinDateTime(cancellationToken);
        }
        /// <summary> Put min datetime value 0001-01-01T00:00:00-14:00. </summary>
        /// <param name="datetimeBody"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutLocalNegativeOffsetMinDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutLocalNegativeOffsetMinDateTimeAsync(datetimeBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put min datetime value 0001-01-01T00:00:00-14:00. </summary>
        /// <param name="datetimeBody"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutLocalNegativeOffsetMinDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutLocalNegativeOffsetMinDateTime(datetimeBody, cancellationToken);
        }
        /// <summary> Get min datetime value 0001-01-01T00:00:00-14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DateTimeOffset>> GetLocalNegativeOffsetMinDateTimeAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetLocalNegativeOffsetMinDateTimeAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get min datetime value 0001-01-01T00:00:00-14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DateTimeOffset> GetLocalNegativeOffsetMinDateTime(CancellationToken cancellationToken = default)
        {
            return RestClient.GetLocalNegativeOffsetMinDateTime(cancellationToken);
        }
    }
}
