// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Inheritance.Models;

namespace Inheritance
{
    /// <summary> The SchemaMapping service client. </summary>
    public partial class SchemaMappingClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal SchemaMappingRestClient RestClient { get; }

        /// <summary> Initializes a new instance of SchemaMappingClient for mocking. </summary>
        protected SchemaMappingClient()
        {
        }

        /// <summary> Initializes a new instance of SchemaMappingClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal SchemaMappingClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new SchemaMappingRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <param name="value"> The BaseClass to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<BaseClass>> MixedAsync(BaseClass value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SchemaMappingClient.Mixed");
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

        /// <param name="value"> The BaseClass to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BaseClass> Mixed(BaseClass value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SchemaMappingClient.Mixed");
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
    }
}
