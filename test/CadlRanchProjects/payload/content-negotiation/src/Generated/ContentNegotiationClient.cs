// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Payload.ContentNegotiation
{
    // Data plane generated client.
    /// <summary> Test describing optionality of the request body. </summary>
    public partial class ContentNegotiationClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ContentNegotiationClient. </summary>
        public ContentNegotiationClient() : this(new Uri("http://localhost:3000"), new ContentNegotiationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ContentNegotiationClient. </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public ContentNegotiationClient(Uri endpoint, ContentNegotiationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ContentNegotiationClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
        }

        private SameBody _cachedSameBody;
        private DifferentBody _cachedDifferentBody;

        /// <summary> Initializes a new instance of SameBody. </summary>
        public virtual SameBody GetSameBodyClient()
        {
            return Volatile.Read(ref _cachedSameBody) ?? Interlocked.CompareExchange(ref _cachedSameBody, new SameBody(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedSameBody;
        }

        /// <summary> Initializes a new instance of DifferentBody. </summary>
        public virtual DifferentBody GetDifferentBodyClient()
        {
            return Volatile.Read(ref _cachedDifferentBody) ?? Interlocked.CompareExchange(ref _cachedDifferentBody, new DifferentBody(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedDifferentBody;
        }
    }
}
