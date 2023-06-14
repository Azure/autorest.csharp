// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using HlcConstants.Models;

namespace HlcConstants
{
    /// <summary> The HlcConstants service client. </summary>
    public partial class HlcConstantsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal HlcConstantsRestClient RestClient { get; }

        /// <summary> Initializes a new instance of HlcConstantsClient for mocking. </summary>
        protected HlcConstantsClient()
        {
        }

        /// <summary> Initializes a new instance of HlcConstantsClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal HlcConstantsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new HlcConstantsRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <param name="value"> The RoundTripModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RoundTripModel>> MixedAsync(RoundTripModel value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HlcConstantsClient.Mixed");
            scope.Start();
            try
            {
                return await RestClient.MixedAsync(value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="value"> The RoundTripModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RoundTripModel> Mixed(RoundTripModel value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HlcConstantsClient.Mixed");
            scope.Start();
            try
            {
                return RestClient.Mixed(value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="value"> The RoundTripModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RoundTripModel>> PostSomethingAsync(RoundTripModel value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HlcConstantsClient.PostSomething");
            scope.Start();
            try
            {
                return await RestClient.PostSomethingAsync(value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="value"> The RoundTripModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RoundTripModel> PostSomething(RoundTripModel value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HlcConstantsClient.PostSomething");
            scope.Start();
            try
            {
                return RestClient.PostSomething(value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
