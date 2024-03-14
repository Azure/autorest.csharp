// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace ParametersCadl
{
    // Data plane generated client.
    /// <summary> The ParametersCadl service client. </summary>
    public partial class ParametersCadlClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ParametersCadlClient for mocking. </summary>
        protected ParametersCadlClient()
        {
        }

        /// <summary> Initializes a new instance of ParametersCadlClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public ParametersCadlClient(Uri endpoint) : this(endpoint, new ParametersCadlClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ParametersCadlClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public ParametersCadlClient(Uri endpoint, ParametersCadlClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ParametersCadlClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary> Initializes a new instance of ParameterOrders. </summary>
        /// <param name="apiVersion"> The <see cref="string"/> to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual ParameterOrders GetParameterOrdersClient(string apiVersion = "2022-05-15-preview")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new ParameterOrders(ClientDiagnostics, _pipeline, _endpoint, apiVersion);
        }
    }
}
