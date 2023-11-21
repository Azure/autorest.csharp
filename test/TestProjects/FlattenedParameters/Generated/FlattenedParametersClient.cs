// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace FlattenedParameters
{
    /// <summary> The FlattenedParameters service client. </summary>
    public partial class FlattenedParametersClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal FlattenedParametersRestClient RestClient { get; }

        /// <summary> Initializes a new instance of FlattenedParametersClient for mocking. </summary>
        protected FlattenedParametersClient()
        {
        }

        /// <summary> Initializes a new instance of FlattenedParametersClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal FlattenedParametersClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new FlattenedParametersRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <param name="items"> The <see cref="IEnumerable{T}"/> where <c>T</c> is of type <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> OperationAsync(IEnumerable<string> items = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FlattenedParametersClient.Operation");
            scope.Start();
            try
            {
                return await RestClient.OperationAsync(items, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="items"> The <see cref="IEnumerable{T}"/> where <c>T</c> is of type <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Operation(IEnumerable<string> items = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FlattenedParametersClient.Operation");
            scope.Start();
            try
            {
                return RestClient.Operation(items, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="items"> The <see cref="IEnumerable{T}"/> where <c>T</c> is of type <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> OperationNotNullAsync(IEnumerable<string> items = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FlattenedParametersClient.OperationNotNull");
            scope.Start();
            try
            {
                return await RestClient.OperationNotNullAsync(items, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="items"> The <see cref="IEnumerable{T}"/> where <c>T</c> is of type <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response OperationNotNull(IEnumerable<string> items = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FlattenedParametersClient.OperationNotNull");
            scope.Start();
            try
            {
                return RestClient.OperationNotNull(items, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="required"> The <see cref="string"/> to use. </param>
        /// <param name="nonRequired"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> OperationNotRequiredAsync(string required = null, string nonRequired = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FlattenedParametersClient.OperationNotRequired");
            scope.Start();
            try
            {
                return await RestClient.OperationNotRequiredAsync(required, nonRequired, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="required"> The <see cref="string"/> to use. </param>
        /// <param name="nonRequired"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response OperationNotRequired(string required = null, string nonRequired = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FlattenedParametersClient.OperationNotRequired");
            scope.Start();
            try
            {
                return RestClient.OperationNotRequired(required, nonRequired, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="required"> The <see cref="string"/> to use. </param>
        /// <param name="nonRequired"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> OperationRequiredAsync(string required, string nonRequired = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FlattenedParametersClient.OperationRequired");
            scope.Start();
            try
            {
                return await RestClient.OperationRequiredAsync(required, nonRequired, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="required"> The <see cref="string"/> to use. </param>
        /// <param name="nonRequired"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response OperationRequired(string required, string nonRequired = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FlattenedParametersClient.OperationRequired");
            scope.Start();
            try
            {
                return RestClient.OperationRequired(required, nonRequired, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
