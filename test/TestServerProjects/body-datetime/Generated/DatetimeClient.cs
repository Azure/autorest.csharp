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
    /// <summary> The Datetime service client. </summary>
    public partial class DatetimeClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal DatetimeRestClient RestClient { get; }

        /// <summary> Initializes a new instance of DatetimeClient for mocking. </summary>
        protected DatetimeClient()
        {
        }

        /// <summary> Initializes a new instance of DatetimeClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal DatetimeClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new DatetimeRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get null datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset?>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetNull");
            scope.Start();
            try
            {
                return await RestClient.GetNullAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get null datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset?> GetNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetNull");
            scope.Start();
            try
            {
                return RestClient.GetNull(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get invalid datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetInvalid");
            scope.Start();
            try
            {
                return await RestClient.GetInvalidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get invalid datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetInvalid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetInvalid");
            scope.Start();
            try
            {
                return RestClient.GetInvalid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get overflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetOverflowAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetOverflow");
            scope.Start();
            try
            {
                return await RestClient.GetOverflowAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get overflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetOverflow(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetOverflow");
            scope.Start();
            try
            {
                return RestClient.GetOverflow(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get underflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetUnderflowAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetUnderflow");
            scope.Start();
            try
            {
                return await RestClient.GetUnderflowAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get underflow datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetUnderflow(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetUnderflow");
            scope.Start();
            try
            {
                return RestClient.GetUnderflow(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put max datetime value 9999-12-31T23:59:59.999Z. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutUtcMaxDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.PutUtcMaxDateTime");
            scope.Start();
            try
            {
                return await RestClient.PutUtcMaxDateTimeAsync(datetimeBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put max datetime value 9999-12-31T23:59:59.999Z. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutUtcMaxDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.PutUtcMaxDateTime");
            scope.Start();
            try
            {
                return RestClient.PutUtcMaxDateTime(datetimeBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put max datetime value 9999-12-31T23:59:59.9999999Z. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> This is against the recommendation that asks for 3 digits, but allow to test what happens in that scenario. </remarks>
        public virtual async Task<Response> PutUtcMaxDateTime7DigitsAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.PutUtcMaxDateTime7Digits");
            scope.Start();
            try
            {
                return await RestClient.PutUtcMaxDateTime7DigitsAsync(datetimeBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put max datetime value 9999-12-31T23:59:59.9999999Z. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> This is against the recommendation that asks for 3 digits, but allow to test what happens in that scenario. </remarks>
        public virtual Response PutUtcMaxDateTime7Digits(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.PutUtcMaxDateTime7Digits");
            scope.Start();
            try
            {
                return RestClient.PutUtcMaxDateTime7Digits(datetimeBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get max datetime value 9999-12-31t23:59:59.999z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetUtcLowercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetUtcLowercaseMaxDateTime");
            scope.Start();
            try
            {
                return await RestClient.GetUtcLowercaseMaxDateTimeAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get max datetime value 9999-12-31t23:59:59.999z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetUtcLowercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetUtcLowercaseMaxDateTime");
            scope.Start();
            try
            {
                return RestClient.GetUtcLowercaseMaxDateTime(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get max datetime value 9999-12-31T23:59:59.999Z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetUtcUppercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetUtcUppercaseMaxDateTime");
            scope.Start();
            try
            {
                return await RestClient.GetUtcUppercaseMaxDateTimeAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get max datetime value 9999-12-31T23:59:59.999Z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetUtcUppercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetUtcUppercaseMaxDateTime");
            scope.Start();
            try
            {
                return RestClient.GetUtcUppercaseMaxDateTime(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get max datetime value 9999-12-31T23:59:59.9999999Z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> This is against the recommendation that asks for 3 digits, but allow to test what happens in that scenario. </remarks>
        public virtual async Task<Response<DateTimeOffset>> GetUtcUppercaseMaxDateTime7DigitsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetUtcUppercaseMaxDateTime7Digits");
            scope.Start();
            try
            {
                return await RestClient.GetUtcUppercaseMaxDateTime7DigitsAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get max datetime value 9999-12-31T23:59:59.9999999Z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> This is against the recommendation that asks for 3 digits, but allow to test what happens in that scenario. </remarks>
        public virtual Response<DateTimeOffset> GetUtcUppercaseMaxDateTime7Digits(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetUtcUppercaseMaxDateTime7Digits");
            scope.Start();
            try
            {
                return RestClient.GetUtcUppercaseMaxDateTime7Digits(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put max datetime value with positive numoffset 9999-12-31t23:59:59.999+14:00. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutLocalPositiveOffsetMaxDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.PutLocalPositiveOffsetMaxDateTime");
            scope.Start();
            try
            {
                return await RestClient.PutLocalPositiveOffsetMaxDateTimeAsync(datetimeBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put max datetime value with positive numoffset 9999-12-31t23:59:59.999+14:00. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutLocalPositiveOffsetMaxDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.PutLocalPositiveOffsetMaxDateTime");
            scope.Start();
            try
            {
                return RestClient.PutLocalPositiveOffsetMaxDateTime(datetimeBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get max datetime value with positive num offset 9999-12-31t23:59:59.999+14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetLocalPositiveOffsetLowercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetLocalPositiveOffsetLowercaseMaxDateTime");
            scope.Start();
            try
            {
                return await RestClient.GetLocalPositiveOffsetLowercaseMaxDateTimeAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get max datetime value with positive num offset 9999-12-31t23:59:59.999+14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetLocalPositiveOffsetLowercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetLocalPositiveOffsetLowercaseMaxDateTime");
            scope.Start();
            try
            {
                return RestClient.GetLocalPositiveOffsetLowercaseMaxDateTime(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get max datetime value with positive num offset 9999-12-31T23:59:59.999+14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetLocalPositiveOffsetUppercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetLocalPositiveOffsetUppercaseMaxDateTime");
            scope.Start();
            try
            {
                return await RestClient.GetLocalPositiveOffsetUppercaseMaxDateTimeAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get max datetime value with positive num offset 9999-12-31T23:59:59.999+14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetLocalPositiveOffsetUppercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetLocalPositiveOffsetUppercaseMaxDateTime");
            scope.Start();
            try
            {
                return RestClient.GetLocalPositiveOffsetUppercaseMaxDateTime(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put max datetime value with positive numoffset 9999-12-31t23:59:59.999-14:00. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutLocalNegativeOffsetMaxDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.PutLocalNegativeOffsetMaxDateTime");
            scope.Start();
            try
            {
                return await RestClient.PutLocalNegativeOffsetMaxDateTimeAsync(datetimeBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put max datetime value with positive numoffset 9999-12-31t23:59:59.999-14:00. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutLocalNegativeOffsetMaxDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.PutLocalNegativeOffsetMaxDateTime");
            scope.Start();
            try
            {
                return RestClient.PutLocalNegativeOffsetMaxDateTime(datetimeBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get max datetime value with positive num offset 9999-12-31T23:59:59.999-14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetLocalNegativeOffsetUppercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetLocalNegativeOffsetUppercaseMaxDateTime");
            scope.Start();
            try
            {
                return await RestClient.GetLocalNegativeOffsetUppercaseMaxDateTimeAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get max datetime value with positive num offset 9999-12-31T23:59:59.999-14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetLocalNegativeOffsetUppercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetLocalNegativeOffsetUppercaseMaxDateTime");
            scope.Start();
            try
            {
                return RestClient.GetLocalNegativeOffsetUppercaseMaxDateTime(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get max datetime value with positive num offset 9999-12-31t23:59:59.999-14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetLocalNegativeOffsetLowercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetLocalNegativeOffsetLowercaseMaxDateTime");
            scope.Start();
            try
            {
                return await RestClient.GetLocalNegativeOffsetLowercaseMaxDateTimeAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get max datetime value with positive num offset 9999-12-31t23:59:59.999-14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetLocalNegativeOffsetLowercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetLocalNegativeOffsetLowercaseMaxDateTime");
            scope.Start();
            try
            {
                return RestClient.GetLocalNegativeOffsetLowercaseMaxDateTime(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put min datetime value 0001-01-01T00:00:00Z. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutUtcMinDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.PutUtcMinDateTime");
            scope.Start();
            try
            {
                return await RestClient.PutUtcMinDateTimeAsync(datetimeBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put min datetime value 0001-01-01T00:00:00Z. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutUtcMinDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.PutUtcMinDateTime");
            scope.Start();
            try
            {
                return RestClient.PutUtcMinDateTime(datetimeBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get min datetime value 0001-01-01T00:00:00Z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetUtcMinDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetUtcMinDateTime");
            scope.Start();
            try
            {
                return await RestClient.GetUtcMinDateTimeAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get min datetime value 0001-01-01T00:00:00Z. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetUtcMinDateTime(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetUtcMinDateTime");
            scope.Start();
            try
            {
                return RestClient.GetUtcMinDateTime(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put min datetime value 0001-01-01T00:00:00+14:00. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutLocalPositiveOffsetMinDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.PutLocalPositiveOffsetMinDateTime");
            scope.Start();
            try
            {
                return await RestClient.PutLocalPositiveOffsetMinDateTimeAsync(datetimeBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put min datetime value 0001-01-01T00:00:00+14:00. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutLocalPositiveOffsetMinDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.PutLocalPositiveOffsetMinDateTime");
            scope.Start();
            try
            {
                return RestClient.PutLocalPositiveOffsetMinDateTime(datetimeBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get min datetime value 0001-01-01T00:00:00+14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetLocalPositiveOffsetMinDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetLocalPositiveOffsetMinDateTime");
            scope.Start();
            try
            {
                return await RestClient.GetLocalPositiveOffsetMinDateTimeAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get min datetime value 0001-01-01T00:00:00+14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetLocalPositiveOffsetMinDateTime(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetLocalPositiveOffsetMinDateTime");
            scope.Start();
            try
            {
                return RestClient.GetLocalPositiveOffsetMinDateTime(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put min datetime value 0001-01-01T00:00:00-14:00. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutLocalNegativeOffsetMinDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.PutLocalNegativeOffsetMinDateTime");
            scope.Start();
            try
            {
                return await RestClient.PutLocalNegativeOffsetMinDateTimeAsync(datetimeBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put min datetime value 0001-01-01T00:00:00-14:00. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutLocalNegativeOffsetMinDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.PutLocalNegativeOffsetMinDateTime");
            scope.Start();
            try
            {
                return RestClient.PutLocalNegativeOffsetMinDateTime(datetimeBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get min datetime value 0001-01-01T00:00:00-14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetLocalNegativeOffsetMinDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetLocalNegativeOffsetMinDateTime");
            scope.Start();
            try
            {
                return await RestClient.GetLocalNegativeOffsetMinDateTimeAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get min datetime value 0001-01-01T00:00:00-14:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetLocalNegativeOffsetMinDateTime(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetLocalNegativeOffsetMinDateTime");
            scope.Start();
            try
            {
                return RestClient.GetLocalNegativeOffsetMinDateTime(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get min datetime value 0001-01-01T00:00:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetLocalNoOffsetMinDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetLocalNoOffsetMinDateTime");
            scope.Start();
            try
            {
                return await RestClient.GetLocalNoOffsetMinDateTimeAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get min datetime value 0001-01-01T00:00:00. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetLocalNoOffsetMinDateTime(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DatetimeClient.GetLocalNoOffsetMinDateTime");
            scope.Start();
            try
            {
                return RestClient.GetLocalNoOffsetMinDateTime(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
