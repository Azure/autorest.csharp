// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Parameters.CollectionFormat
{
    // Data plane generated client.
    /// <summary> The CollectionFormat service client. </summary>
    public partial class CollectionFormatClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of CollectionFormatClient. </summary>
        public CollectionFormatClient() : this(new CollectionFormatClientOptions())
        {
        }

        /// <summary> Initializes a new instance of CollectionFormatClient. </summary>
        /// <param name="options"> The options for configuring the client. </param>
        public CollectionFormatClient(CollectionFormatClientOptions options)
        {
            options ??= new CollectionFormatClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = options.Endpoint;
        }

        /// <summary> Initializes a new instance of Query. </summary>
        /// <param name="apiVersion"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual Query GetQueryClient(string apiVersion = "1.0.0")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new Query(ClientDiagnostics, _pipeline, _endpoint, apiVersion);
        }

        /// <summary> Initializes a new instance of Header. </summary>
        /// <param name="apiVersion"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual Header GetHeaderClient(string apiVersion = "1.0.0")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new Header(ClientDiagnostics, _pipeline, _endpoint, apiVersion);
        }
    }
}
