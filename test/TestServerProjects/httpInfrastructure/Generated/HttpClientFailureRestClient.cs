// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace httpInfrastructure
{
    internal partial class HttpClientFailureRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of HttpClientFailureRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public HttpClientFailureRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateHead400Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/400", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Head400Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead400Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head400(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead400Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet400Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/400", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Get400Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet400Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get400(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet400Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateOptions400Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Options;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/400", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Options400Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateOptions400Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Options400(CancellationToken cancellationToken = default)
        {
            using var message = CreateOptions400Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePut400Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/400", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Put400Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut400Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put400(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut400Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePatch400Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/400", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Patch400Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch400Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Patch400(CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch400Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePost400Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/400", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Post400Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost400Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post400(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost400Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDelete400Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/400", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Delete400Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete400Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 400 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete400(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete400Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateHead401Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/401", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 401 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Head401Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead401Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 401 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head401(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead401Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet402Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/402", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 402 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Get402Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet402Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 402 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get402(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet402Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateOptions403Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Options;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/403", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 403 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Options403Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateOptions403Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 403 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Options403(CancellationToken cancellationToken = default)
        {
            using var message = CreateOptions403Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet403Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/403", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 403 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Get403Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet403Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 403 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get403(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet403Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePut404Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/404", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Return 404 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Put404Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut404Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 404 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put404(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut404Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePatch405Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/405", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Return 405 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Patch405Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch405Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 405 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Patch405(CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch405Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePost406Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/406", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Return 406 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Post406Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost406Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 406 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post406(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost406Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDelete407Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/407", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Return 407 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Delete407Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete407Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 407 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete407(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete407Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePut409Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/409", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Return 409 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Put409Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut409Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 409 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put409(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut409Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateHead410Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/410", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 410 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Head410Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead410Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 410 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head410(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead410Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet411Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/411", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 411 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Get411Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet411Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 411 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get411(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet411Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateOptions412Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Options;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/412", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 412 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Options412Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateOptions412Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 412 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Options412(CancellationToken cancellationToken = default)
        {
            using var message = CreateOptions412Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet412Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/412", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 412 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Get412Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet412Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 412 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get412(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet412Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePut413Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/413", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Return 413 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Put413Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut413Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 413 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put413(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut413Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePatch414Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/414", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Return 414 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Patch414Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch414Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 414 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Patch414(CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch414Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePost415Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/415", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Return 415 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Post415Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost415Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 415 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post415(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost415Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet416Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/416", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 416 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Get416Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet416Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 416 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get416(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet416Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDelete417Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/417", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Return 417 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Delete417Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete417Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 417 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete417(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete417Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateHead429Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/failure/client/429", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 429 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Head429Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead429Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 429 status code - should be represented in the client as an error. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Head429(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead429Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
