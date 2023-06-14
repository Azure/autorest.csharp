// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using ModelShapes.Models;

namespace ModelShapes
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

        /// <param name="value"> The InputModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> InputAsync(InputModel value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SchemaMappingClient.Input");
            scope.Start();
            try
            {
                return await RestClient.InputAsync(value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="value"> The InputModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Input(InputModel value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SchemaMappingClient.Input");
            scope.Start();
            try
            {
                return RestClient.Input(value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="value"> The MixedModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MixedModel>> MixedAsync(MixedModel value, CancellationToken cancellationToken = default)
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

        /// <param name="value"> The MixedModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MixedModel> Mixed(MixedModel value, CancellationToken cancellationToken = default)
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

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<OutputModel>> OutputAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SchemaMappingClient.Output");
            scope.Start();
            try
            {
                return await RestClient.OutputAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<OutputModel> Output(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SchemaMappingClient.Output");
            scope.Start();
            try
            {
                return RestClient.Output(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="value"> The MixedModelWithReadonlyProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MixedModelWithReadonlyProperty>> MixedreadonlyAsync(MixedModelWithReadonlyProperty value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SchemaMappingClient.Mixedreadonly");
            scope.Start();
            try
            {
                return await RestClient.MixedreadonlyAsync(value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="value"> The MixedModelWithReadonlyProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MixedModelWithReadonlyProperty> Mixedreadonly(MixedModelWithReadonlyProperty value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SchemaMappingClient.Mixedreadonly");
            scope.Start();
            try
            {
                return RestClient.Mixedreadonly(value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="code"> The String to use. </param>
        /// <param name="status"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> FlattenedParameterOperationAsync(string code = null, string status = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SchemaMappingClient.FlattenedParameterOperation");
            scope.Start();
            try
            {
                return await RestClient.FlattenedParameterOperationAsync(code, status, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="code"> The String to use. </param>
        /// <param name="status"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response FlattenedParameterOperation(string code = null, string status = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SchemaMappingClient.FlattenedParameterOperation");
            scope.Start();
            try
            {
                return RestClient.FlattenedParameterOperation(code, status, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
