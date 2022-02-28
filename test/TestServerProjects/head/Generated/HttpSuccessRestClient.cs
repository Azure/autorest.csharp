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

namespace head
{
    internal partial class HttpSuccessRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of HttpSuccessRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        public HttpSuccessRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        internal HttpMessage CreateHead200Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/200", false);
            request.Uri = uri;
            return message;
        }

        /// <summary> Return 200 status code if successful. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Head200Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead200Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 404:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 200 status code if successful. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head200(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead200Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 404:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateHead204Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/204", false);
            request.Uri = uri;
            return message;
        }

        /// <summary> Return 204 status code if successful. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Head204Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead204Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 204:
                case 404:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 204 status code if successful. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head204(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead204Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 204:
                case 404:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateHead404Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/404", false);
            request.Uri = uri;
            return message;
        }

        /// <summary> Return 404 status code if successful. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Head404Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead404Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 204:
                case 404:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 404 status code if successful. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head404(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead404Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 204:
                case 404:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
