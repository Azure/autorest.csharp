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

namespace httpInfrastructure
{
    internal partial class HttpServerFailureRestClient
    {
        private Uri endpoint;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;

        /// <summary> Initializes a new instance of HttpServerFailureRestClient. </summary>
        public HttpServerFailureRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            endpoint ??= new Uri("http://localhost:3000");

            this.endpoint = endpoint;
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        internal HttpMessage CreateHead501Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/http/failure/server/501", false);
            request.Uri = uri;
            return message;
        }

        /// <summary> Return 501 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Head501Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead501Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Return 501 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head501(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead501Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet501Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/http/failure/server/501", false);
            request.Uri = uri;
            return message;
        }

        /// <summary> Return 501 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get501Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet501Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Return 501 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get501(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet501Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePost505Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/http/failure/server/505", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Return 505 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Post505Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost505Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Return 505 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post505(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost505Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDelete505Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/http/failure/server/505", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Return 505 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Delete505Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete505Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Return 505 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete505(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete505Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
