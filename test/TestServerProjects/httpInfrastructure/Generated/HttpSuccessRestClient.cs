// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace httpInfrastructure
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
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public HttpSuccessRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
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
            request.Headers.Add("Accept", "application/json");
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
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet200Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/200", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<bool>> Get200Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        bool value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetBoolean();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<bool> Get200(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet200Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        bool value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetBoolean();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateOptions200Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Options;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/200", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Options 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<bool>> Options200Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateOptions200Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        bool value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetBoolean();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Options 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<bool> Options200(CancellationToken cancellationToken = default)
        {
            using var message = CreateOptions200Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        bool value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetBoolean();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePut200Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/200", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Put boolean value true returning 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Put200Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut200Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put boolean value true returning 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put200(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut200Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePatch200Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/200", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Patch true Boolean value in request returning 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Patch200Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch200Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Patch true Boolean value in request returning 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Patch200(CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch200Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePost200Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/200", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Post bollean value true in request that returns a 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Post200Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost200Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Post bollean value true in request that returns a 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post200(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost200Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDelete200Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/200", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Delete simple boolean value true returns 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Delete200Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete200Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Delete simple boolean value true returns 200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete200(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete200Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePut201Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/201", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Put true Boolean value in request returns 201. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Put201Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut201Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put true Boolean value in request returns 201. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put201(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut201Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePost201Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/201", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Post true Boolean value in request returns 201 (Created). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Post201Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost201Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Post true Boolean value in request returns 201 (Created). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post201(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost201Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePut202Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/202", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Put true Boolean value in request returns 202 (Accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Put202Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut202Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put true Boolean value in request returns 202 (Accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put202(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut202Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePatch202Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/202", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Patch true Boolean value in request returns 202. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Patch202Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch202Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Patch true Boolean value in request returns 202. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Patch202(CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch202Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePost202Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/202", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Post true Boolean value in request returns 202 (Accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Post202Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost202Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Post true Boolean value in request returns 202 (Accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post202(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost202Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDelete202Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/202", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Delete true Boolean value in request returns 202 (accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Delete202Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete202Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Delete true Boolean value in request returns 202 (accepted). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete202(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete202Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
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
            request.Headers.Add("Accept", "application/json");
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
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePut204Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/204", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Put true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Put204Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut204Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Put204(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut204Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePatch204Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/204", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Patch true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Patch204Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch204Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Patch true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Patch204(CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch204Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePost204Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/204", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Post true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Post204Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost204Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Post true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Post204(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost204Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDelete204Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/204", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Delete true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> Delete204Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete204Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Delete true Boolean value in request returns 204 (no content). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete204(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete204Request();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 204:
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
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 404 status code. </summary>
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

        /// <summary> Return 404 status code. </summary>
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
