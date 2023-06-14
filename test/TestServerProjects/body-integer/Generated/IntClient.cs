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
    /// <summary> The Int service client. </summary>
    public partial class IntClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal IntRestClient RestClient { get; }

        /// <summary> Initializes a new instance of IntClient for mocking. </summary>
        protected IntClient()
        {
        }

        /// <summary> Initializes a new instance of IntClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal IntClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new IntRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get null Int value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<int?>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.GetNull");
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

        /// <summary> Get null Int value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<int?> GetNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.GetNull");
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

        /// <summary> Get invalid Int value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<int>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.GetInvalid");
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

        /// <summary> Get invalid Int value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<int> GetInvalid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.GetInvalid");
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

        /// <summary> Get overflow Int32 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<int>> GetOverflowInt32Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.GetOverflowInt32");
            scope.Start();
            try
            {
                return await RestClient.GetOverflowInt32Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get overflow Int32 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<int> GetOverflowInt32(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.GetOverflowInt32");
            scope.Start();
            try
            {
                return RestClient.GetOverflowInt32(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get underflow Int32 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<int>> GetUnderflowInt32Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.GetUnderflowInt32");
            scope.Start();
            try
            {
                return await RestClient.GetUnderflowInt32Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get underflow Int32 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<int> GetUnderflowInt32(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.GetUnderflowInt32");
            scope.Start();
            try
            {
                return RestClient.GetUnderflowInt32(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get overflow Int64 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<long>> GetOverflowInt64Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.GetOverflowInt64");
            scope.Start();
            try
            {
                return await RestClient.GetOverflowInt64Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get overflow Int64 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<long> GetOverflowInt64(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.GetOverflowInt64");
            scope.Start();
            try
            {
                return RestClient.GetOverflowInt64(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get underflow Int64 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<long>> GetUnderflowInt64Async(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.GetUnderflowInt64");
            scope.Start();
            try
            {
                return await RestClient.GetUnderflowInt64Async(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get underflow Int64 value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<long> GetUnderflowInt64(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.GetUnderflowInt64");
            scope.Start();
            try
            {
                return RestClient.GetUnderflowInt64(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put max int32 value. </summary>
        /// <param name="intBody"> int body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutMax32Async(int intBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.PutMax32");
            scope.Start();
            try
            {
                return await RestClient.PutMax32Async(intBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put max int32 value. </summary>
        /// <param name="intBody"> int body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutMax32(int intBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.PutMax32");
            scope.Start();
            try
            {
                return RestClient.PutMax32(intBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put max int64 value. </summary>
        /// <param name="intBody"> int body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutMax64Async(long intBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.PutMax64");
            scope.Start();
            try
            {
                return await RestClient.PutMax64Async(intBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put max int64 value. </summary>
        /// <param name="intBody"> int body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutMax64(long intBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.PutMax64");
            scope.Start();
            try
            {
                return RestClient.PutMax64(intBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put min int32 value. </summary>
        /// <param name="intBody"> int body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutMin32Async(int intBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.PutMin32");
            scope.Start();
            try
            {
                return await RestClient.PutMin32Async(intBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put min int32 value. </summary>
        /// <param name="intBody"> int body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutMin32(int intBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.PutMin32");
            scope.Start();
            try
            {
                return RestClient.PutMin32(intBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put min int64 value. </summary>
        /// <param name="intBody"> int body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutMin64Async(long intBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.PutMin64");
            scope.Start();
            try
            {
                return await RestClient.PutMin64Async(intBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put min int64 value. </summary>
        /// <param name="intBody"> int body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutMin64(long intBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.PutMin64");
            scope.Start();
            try
            {
                return RestClient.PutMin64(intBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get datetime encoded as Unix time value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetUnixTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.GetUnixTime");
            scope.Start();
            try
            {
                return await RestClient.GetUnixTimeAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get datetime encoded as Unix time value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetUnixTime(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.GetUnixTime");
            scope.Start();
            try
            {
                return RestClient.GetUnixTime(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put datetime encoded as Unix time. </summary>
        /// <param name="intBody"> int body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutUnixTimeDateAsync(DateTimeOffset intBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.PutUnixTimeDate");
            scope.Start();
            try
            {
                return await RestClient.PutUnixTimeDateAsync(intBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put datetime encoded as Unix time. </summary>
        /// <param name="intBody"> int body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutUnixTimeDate(DateTimeOffset intBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.PutUnixTimeDate");
            scope.Start();
            try
            {
                return RestClient.PutUnixTimeDate(intBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get invalid Unix time value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset>> GetInvalidUnixTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.GetInvalidUnixTime");
            scope.Start();
            try
            {
                return await RestClient.GetInvalidUnixTimeAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get invalid Unix time value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset> GetInvalidUnixTime(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.GetInvalidUnixTime");
            scope.Start();
            try
            {
                return RestClient.GetInvalidUnixTime(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get null Unix time value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DateTimeOffset?>> GetNullUnixTimeAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.GetNullUnixTime");
            scope.Start();
            try
            {
                return await RestClient.GetNullUnixTimeAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get null Unix time value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DateTimeOffset?> GetNullUnixTime(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IntClient.GetNullUnixTime");
            scope.Start();
            try
            {
                return RestClient.GetNullUnixTime(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
