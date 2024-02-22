// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AuthoringTypeSpec
{
    // Data plane generated client.
    /// <summary> The AuthoringTypeSpec service client. </summary>
    public partial class AuthoringTypeSpecClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of AuthoringTypeSpecClient for mocking. </summary>
        protected AuthoringTypeSpecClient()
        {
        }

        /// <summary> Initializes a new instance of AuthoringTypeSpecClient. </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public AuthoringTypeSpecClient(Uri endpoint) : this(endpoint, new AuthoringTypeSpecClientOptions())
        {
        }

        /// <summary> Initializes a new instance of AuthoringTypeSpecClient. </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public AuthoringTypeSpecClient(Uri endpoint, AuthoringTypeSpecClientOptions options)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            options ??= new AuthoringTypeSpecClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary> Initializes a new instance of Projects. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual Projects GetProjectsClient(string apiVersion = "2022-05-15-preview")
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }

            return new Projects(ClientDiagnostics, _pipeline, _endpoint, apiVersion);
        }

        /// <summary> Initializes a new instance of Deployments. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual Deployments GetDeploymentsClient(string apiVersion = "2022-05-15-preview")
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }

            return new Deployments(ClientDiagnostics, _pipeline, _endpoint, apiVersion);
        }

        /// <summary> Initializes a new instance of Jobs. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual Jobs GetJobsClient(string apiVersion = "2022-05-15-preview")
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }

            return new Jobs(ClientDiagnostics, _pipeline, _endpoint, apiVersion);
        }

        /// <summary> Initializes a new instance of Global. </summary>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public virtual Global GetGlobalClient(string apiVersion = "2022-05-15-preview")
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }

            return new Global(ClientDiagnostics, _pipeline, _endpoint, apiVersion);
        }
    }
}
