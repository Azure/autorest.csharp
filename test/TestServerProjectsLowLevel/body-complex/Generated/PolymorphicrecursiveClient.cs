// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

#pragma warning disable AZC0007

namespace body_complex_LowLevel
{
    /// <summary> The Polymorphicrecursive service client. </summary>
    public partial class PolymorphicrecursiveClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline { get; }
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private Uri endpoint;
        private readonly string apiVersion;

        /// <summary> Initializes a new instance of PolymorphicrecursiveClient for mocking. </summary>
        protected PolymorphicrecursiveClient()
        {
        }

        /// <summary> Initializes a new instance of PolymorphicrecursiveClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PolymorphicrecursiveClient(AzureKeyCredential credential, Uri endpoint = null, AutoRestComplexTestServiceClientOptions options = null)
        {
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }
            endpoint ??= new Uri("http://localhost:3000");

            options ??= new AutoRestComplexTestServiceClientOptions();
            Pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, AuthorizationHeader));
            this.endpoint = endpoint;
            apiVersion = options.Version;
        }

        /// <summary> Get complex types that are polymorphic and have recursive references. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetValidAsync(CancellationToken cancellationToken = default)
        {
            Request req = CreateGetValidRequest();
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get complex types that are polymorphic and have recursive references. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetValid(CancellationToken cancellationToken = default)
        {
            Request req = CreateGetValidRequest();
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="GetValid"/> and <see cref="GetValidAsync"/> operations. </summary>
        private Request CreateGetValidRequest()
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/complex/polymorphicrecursive/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return request;
        }

        /// <summary> Put complex types that are polymorphic and have recursive references. </summary>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutValidAsync(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreatePutValidRequest(requestBody);
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put complex types that are polymorphic and have recursive references. </summary>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutValid(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreatePutValidRequest(requestBody);
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="PutValid"/> and <see cref="PutValidAsync"/> operations. </summary>
        /// <param name="requestBody"> The request body. </param>
        private Request CreatePutValidRequest(RequestContent requestBody)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/complex/polymorphicrecursive/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = requestBody;
            return request;
        }
    }
}
