// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace MixApiVersion
{
    // Data plane generated client.
    /// <summary> This is a sample server Petstore server.  You can find out more about Swagger at [http://swagger.io](http://swagger.io) or on [irc.freenode.net, #swagger](http://swagger.io/irc/).  For this sample, you can use the api key `special-key` to test the authorization filters. </summary>
    public partial class MixApiVersionClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of MixApiVersionClient for mocking. </summary>
        protected MixApiVersionClient()
        {
        }

        /// <summary> Initializes a new instance of MixApiVersionClient. </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public MixApiVersionClient(Uri endpoint) : this(endpoint, new MixApiVersionClientOptions())
        {
        }

        /// <summary> Initializes a new instance of MixApiVersionClient. </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public MixApiVersionClient(Uri endpoint, MixApiVersionClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new MixApiVersionClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary> Initializes a new instance of Pets. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual Pets GetPetsClient(string apiVersion = "2022-11-30-preview")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new Pets(ClientDiagnostics, _pipeline, _endpoint, apiVersion);
        }

        /// <summary> Initializes a new instance of ListPetToysResponse. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual ListPetToysResponse GetListPetToysResponseClient(string apiVersion = "2022-11-30-preview")
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            return new ListPetToysResponse(ClientDiagnostics, _pipeline, _endpoint, apiVersion);
        }
    }
}
