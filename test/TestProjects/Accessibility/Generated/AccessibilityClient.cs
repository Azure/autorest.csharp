// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace Accessibility
{
    /// <summary> The Accessibility service client. </summary>
    public partial class AccessibilityClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal AccessibilityRestClient RestClient { get; }

        /// <summary> Initializes a new instance of AccessibilityClient for mocking. </summary>
        protected AccessibilityClient()
        {
        }

        /// <summary> Initializes a new instance of AccessibilityClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal AccessibilityClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new AccessibilityRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <param name="body"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> OperationAsync(string body = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AccessibilityClient.Operation");
            scope.Start();
            try
            {
                return await RestClient.OperationAsync(body, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="body"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Operation(string body = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AccessibilityClient.Operation");
            scope.Start();
            try
            {
                return RestClient.Operation(body, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="body"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual async Task<Response> OperationInternalAsync(string body = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AccessibilityClient.OperationInternal");
            scope.Start();
            try
            {
                return await RestClient.OperationInternalAsync(body, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="body"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual Response OperationInternal(string body = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AccessibilityClient.OperationInternal");
            scope.Start();
            try
            {
                return RestClient.OperationInternal(body, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
