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
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        internal Datetimerfc1123Client(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new Datetimerfc1123RestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get null datetime value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset?>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Datetimerfc1123Client.GetNull");
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
            using var scope = _clientDiagnostics.CreateScope("Datetimerfc1123Client.GetNull");
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
            using var scope = _clientDiagnostics.CreateScope("Datetimerfc1123Client.GetInvalid");
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
            using var scope = _clientDiagnostics.CreateScope("Datetimerfc1123Client.GetInvalid");
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
            using var scope = _clientDiagnostics.CreateScope("Datetimerfc1123Client.GetOverflow");
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
            using var scope = _clientDiagnostics.CreateScope("Datetimerfc1123Client.GetOverflow");
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
            using var scope = _clientDiagnostics.CreateScope("Datetimerfc1123Client.GetUnderflow");
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
            using var scope = _clientDiagnostics.CreateScope("Datetimerfc1123Client.GetUnderflow");
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

        /// <summary> Put max datetime value Fri, 31 Dec 9999 23:59:59 GMT. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutUtcMaxDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Datetimerfc1123Client.PutUtcMaxDateTime");
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

        /// <summary> Put max datetime value Fri, 31 Dec 9999 23:59:59 GMT. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutUtcMaxDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Datetimerfc1123Client.PutUtcMaxDateTime");
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

        /// <summary> Get max datetime value fri, 31 dec 9999 23:59:59 gmt. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetUtcLowercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Datetimerfc1123Client.GetUtcLowercaseMaxDateTime");
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

        /// <summary> Get max datetime value fri, 31 dec 9999 23:59:59 gmt. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetUtcLowercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Datetimerfc1123Client.GetUtcLowercaseMaxDateTime");
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

        /// <summary> Get max datetime value FRI, 31 DEC 9999 23:59:59 GMT. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetUtcUppercaseMaxDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Datetimerfc1123Client.GetUtcUppercaseMaxDateTime");
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

        /// <summary> Get max datetime value FRI, 31 DEC 9999 23:59:59 GMT. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetUtcUppercaseMaxDateTime(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Datetimerfc1123Client.GetUtcUppercaseMaxDateTime");
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

        /// <summary> Put min datetime value Mon, 1 Jan 0001 00:00:00 GMT. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutUtcMinDateTimeAsync(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Datetimerfc1123Client.PutUtcMinDateTime");
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

        /// <summary> Put min datetime value Mon, 1 Jan 0001 00:00:00 GMT. </summary>
        /// <param name="datetimeBody"> datetime body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutUtcMinDateTime(DateTimeOffset datetimeBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Datetimerfc1123Client.PutUtcMinDateTime");
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

        /// <summary> Get min datetime value Mon, 1 Jan 0001 00:00:00 GMT. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetUtcMinDateTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Datetimerfc1123Client.GetUtcMinDateTime");
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

        /// <summary> Get min datetime value Mon, 1 Jan 0001 00:00:00 GMT. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetUtcMinDateTime(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Datetimerfc1123Client.GetUtcMinDateTime");
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
    }
}
