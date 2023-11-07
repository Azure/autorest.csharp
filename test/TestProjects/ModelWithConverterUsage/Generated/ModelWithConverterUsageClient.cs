// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using ModelWithConverterUsage.Models;

namespace ModelWithConverterUsage
{
    /// <summary> The ModelWithConverterUsage service client. </summary>
    public partial class ModelWithConverterUsageClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal ModelWithConverterUsageRestClient RestClient { get; }

        /// <summary> Initializes a new instance of ModelWithConverterUsageClient for mocking. </summary>
        protected ModelWithConverterUsageClient()
        {
        }

        /// <summary> Initializes a new instance of ModelWithConverterUsageClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/> or <paramref name="endpoint"/> is null. </exception>
        internal ModelWithConverterUsageClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            RestClient = new ModelWithConverterUsageRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <param name="value"> The ModelClass to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ModelClass>> OperationModelAsync(ModelClass value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelWithConverterUsageClient.OperationModel");
            scope.Start();
            try
            {
                return await RestClient.OperationModelAsync(value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="value"> The ModelClass to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ModelClass> OperationModel(ModelClass value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelWithConverterUsageClient.OperationModel");
            scope.Start();
            try
            {
                return RestClient.OperationModel(value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="body"> The ModelStruct to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ModelStruct>> OperationStructAsync(ModelStruct? body = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelWithConverterUsageClient.OperationStruct");
            scope.Start();
            try
            {
                return await RestClient.OperationStructAsync(body, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="body"> The ModelStruct to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ModelStruct> OperationStruct(ModelStruct? body = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelWithConverterUsageClient.OperationStruct");
            scope.Start();
            try
            {
                return RestClient.OperationStruct(body, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
