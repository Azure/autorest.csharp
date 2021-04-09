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

namespace Accessibility_LowLevel
{
    /// <summary> The Accessibility service client. </summary>
    public partial class AccessibilityClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline { get; }
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private Uri endpoint;
        private readonly string apiVersion;

        /// <summary> Initializes a new instance of AccessibilityClient for mocking. </summary>
        protected AccessibilityClient()
        {
        }

        /// <summary> Initializes a new instance of AccessibilityClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public AccessibilityClient(AzureKeyCredential credential, Uri endpoint = null, AccessibilityClientOptions options = null)
        {
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }
            endpoint ??= new Uri("http://localhost:3000");

            options ??= new AccessibilityClientOptions();
            Pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, AuthorizationHeader));
            this.endpoint = endpoint;
            apiVersion = options.Version;
        }

        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> OperationAsync(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreateOperationRequest(requestBody);
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Operation(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreateOperationRequest(requestBody);
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="Operation"/> and <see cref="OperationAsync"/> operations. </summary>
        /// <param name="requestBody"> The request body. </param>
        private Request CreateOperationRequest(RequestContent requestBody)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/Operation/", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            request.Content = requestBody;
            return request;
        }

        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual async Task<Response> OperationInternalAsync(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreateOperationInternalRequest(requestBody);
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <param name="requestBody"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        internal virtual Response OperationInternal(RequestContent requestBody, CancellationToken cancellationToken = default)
        {
            Request req = CreateOperationInternalRequest(requestBody);
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary> Create Request for <see cref="OperationInternal"/> and <see cref="OperationInternalAsync"/> operations. </summary>
        /// <param name="requestBody"> The request body. </param>
        internal Request CreateOperationInternalRequest(RequestContent requestBody)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/OperationInternal/", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            request.Content = requestBody;
            return request;
        }
    }
}
