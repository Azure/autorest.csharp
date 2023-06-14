// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using body_complex.Models;

namespace body_complex
{
    /// <summary> The Flattencomplex service client. </summary>
    public partial class FlattencomplexClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal FlattencomplexRestClient RestClient { get; }

        /// <summary> Initializes a new instance of FlattencomplexClient for mocking. </summary>
        protected FlattencomplexClient()
        {
        }

        /// <summary> Initializes a new instance of FlattencomplexClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal FlattencomplexClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new FlattencomplexRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MyBaseType>> GetValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FlattencomplexClient.GetValid");
            scope.Start();
            try
            {
                return await RestClient.GetValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MyBaseType> GetValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FlattencomplexClient.GetValid");
            scope.Start();
            try
            {
                return RestClient.GetValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
