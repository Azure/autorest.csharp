// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace SingleTopLevelClientWithoutOperations_LowLevel
{
    /// <summary> Data plane generated client for TopLevelClientWithoutOperation. </summary>
    public partial class TopLevelClientWithoutOperationClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of TopLevelClientWithoutOperationClient for mocking. </summary>
        protected TopLevelClientWithoutOperationClient()
        {
        }

        /// <summary> Initializes a new instance of TopLevelClientWithoutOperationClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public TopLevelClientWithoutOperationClient(AzureKeyCredential credential) : this(credential, new Uri("http://localhost:3000"), new TopLevelClientWithoutOperationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of TopLevelClientWithoutOperationClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public TopLevelClientWithoutOperationClient(AzureKeyCredential credential, Uri endpoint, TopLevelClientWithoutOperationClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new TopLevelClientWithoutOperationClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        private Client5 _cachedClient5;
        private Client6 _cachedClient6;
        private Client7 _cachedClient7;

        /// <summary> Initializes a new instance of Client5. </summary>
        public virtual Client5 GetClient5Client()
        {
            return Volatile.Read(ref _cachedClient5) ?? Interlocked.CompareExchange(ref _cachedClient5, new Client5(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedClient5;
        }

        /// <summary> Initializes a new instance of Client6. </summary>
        public virtual Client6 GetClient6Client()
        {
            return Volatile.Read(ref _cachedClient6) ?? Interlocked.CompareExchange(ref _cachedClient6, new Client6(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedClient6;
        }

        /// <summary> Initializes a new instance of Client7. </summary>
        public virtual Client7 GetClient7Client()
        {
            return Volatile.Read(ref _cachedClient7) ?? Interlocked.CompareExchange(ref _cachedClient7, new Client7(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedClient7;
        }
    }
}
