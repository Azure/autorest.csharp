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
    /// <summary> The Date service client. </summary>
    public partial class DateClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal DateRestClient RestClient { get; }

        /// <summary> Initializes a new instance of DateClient for mocking. </summary>
        protected DateClient()
        {
        }

        /// <summary> Initializes a new instance of DateClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal DateClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new DateRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get null date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset?>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DateClient.GetNull");
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

        /// <summary> Get null date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset?> GetNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DateClient.GetNull");
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

        /// <summary> Get invalid date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetInvalidDateAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DateClient.GetInvalidDate");
            scope.Start();
            try
            {
                return await RestClient.GetInvalidDateAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get invalid date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetInvalidDate(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DateClient.GetInvalidDate");
            scope.Start();
            try
            {
                return RestClient.GetInvalidDate(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get overflow date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetOverflowDateAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DateClient.GetOverflowDate");
            scope.Start();
            try
            {
                return await RestClient.GetOverflowDateAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get overflow date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetOverflowDate(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DateClient.GetOverflowDate");
            scope.Start();
            try
            {
                return RestClient.GetOverflowDate(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get underflow date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetUnderflowDateAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DateClient.GetUnderflowDate");
            scope.Start();
            try
            {
                return await RestClient.GetUnderflowDateAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get underflow date value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetUnderflowDate(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DateClient.GetUnderflowDate");
            scope.Start();
            try
            {
                return RestClient.GetUnderflowDate(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put max date value 9999-12-31. </summary>
        /// <param name="dateBody"> date body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutMaxDateAsync(DateTimeOffset dateBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DateClient.PutMaxDate");
            scope.Start();
            try
            {
                return await RestClient.PutMaxDateAsync(dateBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put max date value 9999-12-31. </summary>
        /// <param name="dateBody"> date body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutMaxDate(DateTimeOffset dateBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DateClient.PutMaxDate");
            scope.Start();
            try
            {
                return RestClient.PutMaxDate(dateBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get max date value 9999-12-31. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetMaxDateAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DateClient.GetMaxDate");
            scope.Start();
            try
            {
                return await RestClient.GetMaxDateAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get max date value 9999-12-31. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetMaxDate(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DateClient.GetMaxDate");
            scope.Start();
            try
            {
                return RestClient.GetMaxDate(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put min date value 0000-01-01. </summary>
        /// <param name="dateBody"> date body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutMinDateAsync(DateTimeOffset dateBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DateClient.PutMinDate");
            scope.Start();
            try
            {
                return await RestClient.PutMinDateAsync(dateBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put min date value 0000-01-01. </summary>
        /// <param name="dateBody"> date body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutMinDate(DateTimeOffset dateBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DateClient.PutMinDate");
            scope.Start();
            try
            {
                return RestClient.PutMinDate(dateBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get min date value 0000-01-01. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetMinDateAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DateClient.GetMinDate");
            scope.Start();
            try
            {
                return await RestClient.GetMinDateAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get min date value 0000-01-01. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetMinDate(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DateClient.GetMinDate");
            scope.Start();
            try
            {
                return RestClient.GetMinDate(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
