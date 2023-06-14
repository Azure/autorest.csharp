// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace _Type.Property.Optional
{
    // Data plane generated client.
    /// <summary> The Optional service client. </summary>
    public partial class OptionalClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of OptionalClient. </summary>
        public OptionalClient() : this(new Uri("http://localhost:3000"), new OptionalClientOptions())
        {
        }

        /// <summary> Initializes a new instance of OptionalClient. </summary>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public OptionalClient(Uri endpoint, OptionalClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new OptionalClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary> Initializes a new instance of String. </summary>
        /// <param name="apiVersion"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual String GetStringClient(string apiVersion = "1.0.0")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new String(ClientDiagnostics, _pipeline, _endpoint, apiVersion);
        }

        /// <summary> Initializes a new instance of Bytes. </summary>
        /// <param name="apiVersion"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual Bytes GetBytesClient(string apiVersion = "1.0.0")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new Bytes(ClientDiagnostics, _pipeline, _endpoint, apiVersion);
        }

        /// <summary> Initializes a new instance of Datetime. </summary>
        /// <param name="apiVersion"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual Datetime GetDatetimeClient(string apiVersion = "1.0.0")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new Datetime(ClientDiagnostics, _pipeline, _endpoint, apiVersion);
        }

        /// <summary> Initializes a new instance of Duration. </summary>
        /// <param name="apiVersion"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual Duration GetDurationClient(string apiVersion = "1.0.0")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new Duration(ClientDiagnostics, _pipeline, _endpoint, apiVersion);
        }

        /// <summary> Initializes a new instance of CollectionsByte. </summary>
        /// <param name="apiVersion"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual CollectionsByte GetCollectionsByteClient(string apiVersion = "1.0.0")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new CollectionsByte(ClientDiagnostics, _pipeline, _endpoint, apiVersion);
        }

        /// <summary> Initializes a new instance of CollectionsModel. </summary>
        /// <param name="apiVersion"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual CollectionsModel GetCollectionsModelClient(string apiVersion = "1.0.0")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new CollectionsModel(ClientDiagnostics, _pipeline, _endpoint, apiVersion);
        }

        /// <summary> Initializes a new instance of RequiredAndOptional. </summary>
        /// <param name="apiVersion"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual RequiredAndOptional GetRequiredAndOptionalClient(string apiVersion = "1.0.0")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new RequiredAndOptional(ClientDiagnostics, _pipeline, _endpoint, apiVersion);
        }
    }
}
