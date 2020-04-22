// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace body_datetime_rfc1123
{
    /// <summary> The Datetimerfc1123 service client. </summary>
    public partial class Datetimerfc1123Client
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal Datetimerfc1123RestClient RestClient { get; }
        /// <summary> Initializes a new instance of Datetimerfc1123Client for mocking. </summary>
        protected Datetimerfc1123Client()
        {
        }
        /// <summary> Initializes a new instance of Datetimerfc1123Client. </summary>
        internal Datetimerfc1123Client(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new Datetimerfc1123RestClient(clientDiagnostics, pipeline, host);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get null datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetNullAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get null datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetNull(CancellationToken cancellationToken = default)
        {
            return RestClient.GetNull(cancellationToken);
        }

        /// <summary> Get invalid datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetInvalidAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get invalid datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetInvalid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetInvalid(cancellationToken);
        }

        /// <summary> Get overflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetOverflowAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetOverflowAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get overflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetOverflow(CancellationToken cancellationToken = default)
        {
            return RestClient.GetOverflow(cancellationToken);
        }

        /// <summary> Get underflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetUnderflowAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetUnderflowAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get underflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetUnderflow(CancellationToken cancellationToken = default)
        {
            return RestClient.GetUnderflow(cancellationToken);
        }

        /// <summary> Put max datetime value Fri, 31 Dec 9999 23:59:59 GMT. </summary>
        /// <param name="datetimeBody"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutUtcMaxDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutUtcMaxDateTimeAsync(datetimeBody, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put max datetime value Fri, 31 Dec 9999 23:59:59 GMT. </summary>
        /// <param name="datetimeBody"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutUtcMaxDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutUtcMaxDateTime(datetimeBody, cancellationToken);
        }

        /// <summary> Get max datetime value fri, 31 dec 9999 23:59:59 gmt. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetUtcLowercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetUtcLowercaseMaxDateTimeAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get max datetime value fri, 31 dec 9999 23:59:59 gmt. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetUtcLowercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            return RestClient.GetUtcLowercaseMaxDateTime(cancellationToken);
        }

        /// <summary> Get max datetime value FRI, 31 DEC 9999 23:59:59 GMT. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetUtcUppercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetUtcUppercaseMaxDateTimeAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get max datetime value FRI, 31 DEC 9999 23:59:59 GMT. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetUtcUppercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            return RestClient.GetUtcUppercaseMaxDateTime(cancellationToken);
        }

        /// <summary> Put min datetime value Mon, 1 Jan 0001 00:00:00 GMT. </summary>
        /// <param name="datetimeBody"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutUtcMinDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutUtcMinDateTimeAsync(datetimeBody, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put min datetime value Mon, 1 Jan 0001 00:00:00 GMT. </summary>
        /// <param name="datetimeBody"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutUtcMinDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutUtcMinDateTime(datetimeBody, cancellationToken);
        }

        /// <summary> Get min datetime value Mon, 1 Jan 0001 00:00:00 GMT. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetUtcMinDateTimeAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetUtcMinDateTimeAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get min datetime value Mon, 1 Jan 0001 00:00:00 GMT. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetUtcMinDateTime(CancellationToken cancellationToken = default)
        {
            return RestClient.GetUtcMinDateTime(cancellationToken);
        }
    }
}
