// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Encode.Bytes
{
    // Data plane generated client.
    /// <summary> The Bytes service client. </summary>
    public partial class BytesClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of BytesClient. </summary>
        public BytesClient() : this(new Uri("http://localhost:3000"), new BytesClientOptions())
        {
        }

        /// <summary> Initializes a new instance of BytesClient. </summary>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public BytesClient(Uri endpoint, BytesClientOptions options)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            options ??= new BytesClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
        }

        private Query _cachedQuery;
        private Property _cachedProperty;
        private Header _cachedHeader;
        private RequestBody _cachedRequestBody;
        private ResponseBody _cachedResponseBody;

        /// <summary> Initializes a new instance of Query. </summary>
        public virtual Query GetQueryClient()
        {
            return Volatile.Read(ref _cachedQuery) ?? Interlocked.CompareExchange(ref _cachedQuery, new Query(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedQuery;
        }

        /// <summary> Initializes a new instance of Property. </summary>
        public virtual Property GetPropertyClient()
        {
            return Volatile.Read(ref _cachedProperty) ?? Interlocked.CompareExchange(ref _cachedProperty, new Property(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedProperty;
        }

        /// <summary> Initializes a new instance of Header. </summary>
        public virtual Header GetHeaderClient()
        {
            return Volatile.Read(ref _cachedHeader) ?? Interlocked.CompareExchange(ref _cachedHeader, new Header(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedHeader;
        }

        /// <summary> Initializes a new instance of RequestBody. </summary>
        public virtual RequestBody GetRequestBodyClient()
        {
            return Volatile.Read(ref _cachedRequestBody) ?? Interlocked.CompareExchange(ref _cachedRequestBody, new RequestBody(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedRequestBody;
        }

        /// <summary> Initializes a new instance of ResponseBody. </summary>
        public virtual ResponseBody GetResponseBodyClient()
        {
            return Volatile.Read(ref _cachedResponseBody) ?? Interlocked.CompareExchange(ref _cachedResponseBody, new ResponseBody(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedResponseBody;
        }
    }
}
