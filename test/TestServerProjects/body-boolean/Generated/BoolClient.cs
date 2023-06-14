// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace body_boolean
{
    /// <summary> The Bool service client. </summary>
    public partial class BoolClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal BoolRestClient RestClient { get; }

        /// <summary> Initializes a new instance of BoolClient for mocking. </summary>
        protected BoolClient()
        {
        }

        /// <summary> Initializes a new instance of BoolClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal BoolClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new BoolRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get true Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> GetTrueAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BoolClient.GetTrue");
            scope.Start();
            try
            {
                return await RestClient.GetTrueAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get true Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> GetTrue(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BoolClient.GetTrue");
            scope.Start();
            try
            {
                return RestClient.GetTrue(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set Boolean value true. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutTrueAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BoolClient.PutTrue");
            scope.Start();
            try
            {
                return await RestClient.PutTrueAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set Boolean value true. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutTrue(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BoolClient.PutTrue");
            scope.Start();
            try
            {
                return RestClient.PutTrue(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get false Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> GetFalseAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BoolClient.GetFalse");
            scope.Start();
            try
            {
                return await RestClient.GetFalseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get false Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> GetFalse(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BoolClient.GetFalse");
            scope.Start();
            try
            {
                return RestClient.GetFalse(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set Boolean value false. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutFalseAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BoolClient.PutFalse");
            scope.Start();
            try
            {
                return await RestClient.PutFalseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set Boolean value false. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutFalse(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BoolClient.PutFalse");
            scope.Start();
            try
            {
                return RestClient.PutFalse(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get null Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool?>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BoolClient.GetNull");
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

        /// <summary> Get null Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool?> GetNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BoolClient.GetNull");
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

        /// <summary> Get invalid Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BoolClient.GetInvalid");
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

        /// <summary> Get invalid Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> GetInvalid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BoolClient.GetInvalid");
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
