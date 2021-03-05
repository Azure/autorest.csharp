// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using ExtensionClientName.Models;

namespace ExtensionClientName
{
    /// <summary> The AutoRestParameterFlattening service client. </summary>
    public partial class AutoRestParameterFlatteningClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal AutoRestParameterFlatteningRestClient RestClient { get; }

        /// <summary> Initializes a new instance of AutoRestParameterFlatteningClient for mocking. </summary>
        protected AutoRestParameterFlatteningClient()
        {
        }

        /// <summary> Initializes a new instance of AutoRestParameterFlatteningClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        internal AutoRestParameterFlatteningClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new AutoRestParameterFlatteningRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <param name="renamedPathParameter"> The String to use. </param>
        /// <param name="renamedQueryParameter"> The String to use. </param>
        /// <param name="renamedBodyParameter"> The RenamedSchema to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RenamedSchema>> RenamedOperationAsync(string renamedPathParameter, string renamedQueryParameter, RenamedSchema renamedBodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestParameterFlatteningClient.RenamedOperation");
            scope.Start();
            try
            {
                return await RestClient.RenamedOperationAsync(renamedPathParameter, renamedQueryParameter, renamedBodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="renamedPathParameter"> The String to use. </param>
        /// <param name="renamedQueryParameter"> The String to use. </param>
        /// <param name="renamedBodyParameter"> The RenamedSchema to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RenamedSchema> RenamedOperation(string renamedPathParameter, string renamedQueryParameter, RenamedSchema renamedBodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestParameterFlatteningClient.RenamedOperation");
            scope.Start();
            try
            {
                return RestClient.RenamedOperation(renamedPathParameter, renamedQueryParameter, renamedBodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
