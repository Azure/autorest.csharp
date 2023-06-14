// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using ApiVersion.Models;
using Azure;
using Azure.Core.Pipeline;

namespace ApiVersion
{
    /// <summary> The ApiVersion service client. </summary>
    public partial class ApiVersionClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal ApiVersionRestClient RestClient { get; }

        /// <summary> Initializes a new instance of ApiVersionClient for mocking. </summary>
        protected ApiVersionClient()
        {
        }

        /// <summary> Initializes a new instance of ApiVersionClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        internal ApiVersionClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null, string apiVersion = "1.0.0")
        {
            RestClient = new ApiVersionRestClient(clientDiagnostics, pipeline, endpoint, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <param name="notApiVersionEnum"> The ApiVersion to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> OperationAsync(Models.ApiVersion notApiVersionEnum, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApiVersionClient.Operation");
            scope.Start();
            try
            {
                return await RestClient.OperationAsync(notApiVersionEnum, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="notApiVersionEnum"> The ApiVersion to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Operation(Models.ApiVersion notApiVersionEnum, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ApiVersionClient.Operation");
            scope.Start();
            try
            {
                return RestClient.Operation(notApiVersionEnum, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
