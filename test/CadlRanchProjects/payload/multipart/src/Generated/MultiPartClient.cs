// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Payload.MultiPart
{
    // Data plane generated client.
    /// <summary> The MultiPart service client. </summary>
    public partial class MultiPartClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of MultiPartClient. </summary>
        public MultiPartClient() : this(new Uri("http://localhost:3000"), new MultiPartClientOptions())
        {
        }

        /// <summary> Initializes a new instance of MultiPartClient. </summary>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public MultiPartClient(Uri endpoint, MultiPartClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new MultiPartClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
        }

        private FormData _cachedFormData;

        /// <summary> Initializes a new instance of FormData. </summary>
        public virtual FormData GetFormDataClient()
        {
            return Volatile.Read(ref _cachedFormData) ?? Interlocked.CompareExchange(ref _cachedFormData, new FormData(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedFormData;
        }
    }
}
