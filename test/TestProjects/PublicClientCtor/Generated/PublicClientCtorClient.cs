// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using PublicClientCtor.Models;

namespace PublicClientCtor
{
    /// <summary> The PublicClientCtor service client. </summary>
    public partial class PublicClientCtorClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal PublicClientCtorRestClient RestClient { get; }

        /// <summary> Initializes a new instance of PublicClientCtorClient for mocking. </summary>
        protected PublicClientCtorClient()
        {
        }

        /// <summary> Initializes a new instance of PublicClientCtorClient. </summary>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="param1"> Tesing Param1. </param>
        /// <param name="param2"> Testing Param2. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PublicClientCtorClient(Uri endpoint, AzureKeyCredential credential, string param1 = "value1", string param2 = null, PublicClientCtorClientOptions options = null)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            options ??= new PublicClientCtorClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "fake-key"));
            RestClient = new PublicClientCtorRestClient(_clientDiagnostics, _pipeline, endpoint, param1, param2, options.Version);
        }

        /// <summary> Initializes a new instance of PublicClientCtorClient. </summary>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="param1"> Tesing Param1. </param>
        /// <param name="param2"> Testing Param2. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PublicClientCtorClient(Uri endpoint, TokenCredential credential, string param1 = "value1", string param2 = null, PublicClientCtorClientOptions options = null)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            options ??= new PublicClientCtorClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://fakeendpoint.azure.com/.default", "https://dummyendpoint.azure.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes));
            RestClient = new PublicClientCtorRestClient(_clientDiagnostics, _pipeline, endpoint, param1, param2, options.Version);
        }

        /// <summary> Initializes a new instance of PublicClientCtorClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="param1"> Tesing Param1. </param>
        /// <param name="param2"> Testing Param2. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/>, <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        internal PublicClientCtorClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint, string param1 = "value1", string param2 = null, string apiVersion = "1.0.0")
        {
            RestClient = new PublicClientCtorRestClient(clientDiagnostics, pipeline, endpoint, param1, param2, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <param name="value"> The TestModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> OperationAsync(TestModel value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PublicClientCtorClient.Operation");
            scope.Start();
            try
            {
                return await RestClient.OperationAsync(value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="value"> The TestModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Operation(TestModel value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PublicClientCtorClient.Operation");
            scope.Start();
            try
            {
                return RestClient.Operation(value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
