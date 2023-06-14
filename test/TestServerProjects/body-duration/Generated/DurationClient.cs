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
    /// <summary> The Duration service client. </summary>
    public partial class DurationClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal DurationRestClient RestClient { get; }

        /// <summary> Initializes a new instance of DurationClient for mocking. </summary>
        protected DurationClient()
        {
        }

        /// <summary> Initializes a new instance of DurationClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal DurationClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new DurationRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get null duration value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TimeSpan?>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DurationClient.GetNull");
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

        /// <summary> Get null duration value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TimeSpan?> GetNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DurationClient.GetNull");
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

        /// <summary> Put a positive duration value. </summary>
        /// <param name="durationBody"> duration body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutPositiveDurationAsync(TimeSpan durationBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DurationClient.PutPositiveDuration");
            scope.Start();
            try
            {
                return await RestClient.PutPositiveDurationAsync(durationBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a positive duration value. </summary>
        /// <param name="durationBody"> duration body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutPositiveDuration(TimeSpan durationBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DurationClient.PutPositiveDuration");
            scope.Start();
            try
            {
                return RestClient.PutPositiveDuration(durationBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a positive duration value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TimeSpan>> GetPositiveDurationAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DurationClient.GetPositiveDuration");
            scope.Start();
            try
            {
                return await RestClient.GetPositiveDurationAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a positive duration value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TimeSpan> GetPositiveDuration(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DurationClient.GetPositiveDuration");
            scope.Start();
            try
            {
                return RestClient.GetPositiveDuration(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an invalid duration value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TimeSpan>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DurationClient.GetInvalid");
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

        /// <summary> Get an invalid duration value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TimeSpan> GetInvalid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DurationClient.GetInvalid");
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
    }
}
