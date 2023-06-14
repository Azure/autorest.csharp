// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace azure_special_properties
{
    internal partial class SubscriptionInCredentialsRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _subscriptionId;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of SubscriptionInCredentialsRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="subscriptionId"> The subscription id, which appears in the path, always modeled in credentials. The value is always '1234-5678-9012-3456'. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/>, <paramref name="subscriptionId"/> or <paramref name="apiVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        public SubscriptionInCredentialsRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, Uri endpoint = null, string apiVersion = "2015-07-01-preview")
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _subscriptionId = subscriptionId ?? throw new ArgumentNullException(nameof(subscriptionId));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
            _apiVersion = apiVersion ?? throw new ArgumentNullException(nameof(apiVersion));
        }

        internal HttpMessage CreatePostMethodGlobalValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/subscriptionId/method/string/none/path/global/1234-5678-9012-3456/", false);
            uri.AppendPath(_subscriptionId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to '1234-5678-9012-3456' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostMethodGlobalValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePostMethodGlobalValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to '1234-5678-9012-3456' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostMethodGlobalValid(CancellationToken cancellationToken = default)
        {
            using var message = CreatePostMethodGlobalValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostMethodGlobalNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/subscriptionId/method/string/none/path/global/null/", false);
            uri.AppendPath(_subscriptionId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to null, and client-side validation should prevent you from making this call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostMethodGlobalNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePostMethodGlobalNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to null, and client-side validation should prevent you from making this call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostMethodGlobalNull(CancellationToken cancellationToken = default)
        {
            using var message = CreatePostMethodGlobalNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostMethodGlobalNotProvidedValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/subscriptionId/method/string/none/path/globalNotProvided/1234-5678-9012-3456/", false);
            uri.AppendPath(_subscriptionId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to '1234-5678-9012-3456' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostMethodGlobalNotProvidedValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePostMethodGlobalNotProvidedValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to '1234-5678-9012-3456' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostMethodGlobalNotProvidedValid(CancellationToken cancellationToken = default)
        {
            using var message = CreatePostMethodGlobalNotProvidedValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostPathGlobalValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/subscriptionId/path/string/none/path/global/1234-5678-9012-3456/", false);
            uri.AppendPath(_subscriptionId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to '1234-5678-9012-3456' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostPathGlobalValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePostPathGlobalValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to '1234-5678-9012-3456' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostPathGlobalValid(CancellationToken cancellationToken = default)
        {
            using var message = CreatePostPathGlobalValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostSwaggerGlobalValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/subscriptionId/swagger/string/none/path/global/1234-5678-9012-3456/", false);
            uri.AppendPath(_subscriptionId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to '1234-5678-9012-3456' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PostSwaggerGlobalValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePostSwaggerGlobalValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> POST method with subscriptionId modeled in credentials.  Set the credential subscriptionId to '1234-5678-9012-3456' to succeed. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PostSwaggerGlobalValid(CancellationToken cancellationToken = default)
        {
            using var message = CreatePostSwaggerGlobalValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
