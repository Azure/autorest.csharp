// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace httpInfrastructure
{
    internal partial class HttpRedirectsRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of HttpRedirectsRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public HttpRedirectsRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateHead300Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/300", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 300 status code and redirect to /http/success/200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<HttpRedirectsHead300Headers>> Head300Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead300Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HttpRedirectsHead300Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 300:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 300 status code and redirect to /http/success/200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<HttpRedirectsHead300Headers> Head300(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead300Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new HttpRedirectsHead300Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 300:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet300Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/300", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 300 status code and redirect to /http/success/200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<IReadOnlyList<string>, HttpRedirectsGet300Headers>> Get300Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet300Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HttpRedirectsGet300Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue((IReadOnlyList<string>)null, headers, message.Response);
                case 300:
                    {
                        IReadOnlyList<string> value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        List<string> array = new List<string>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetString());
                        }
                        value = array;
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 300 status code and redirect to /http/success/200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<IReadOnlyList<string>, HttpRedirectsGet300Headers> Get300(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet300Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new HttpRedirectsGet300Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue((IReadOnlyList<string>)null, headers, message.Response);
                case 300:
                    {
                        IReadOnlyList<string> value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        List<string> array = new List<string>();
                        foreach (var item in document.RootElement.EnumerateArray())
                        {
                            array.Add(item.GetString());
                        }
                        value = array;
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateHead301Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/301", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 301 status code and redirect to /http/success/200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<HttpRedirectsHead301Headers>> Head301Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead301Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HttpRedirectsHead301Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 301:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 301 status code and redirect to /http/success/200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<HttpRedirectsHead301Headers> Head301(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead301Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new HttpRedirectsHead301Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 301:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet301Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/301", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 301 status code and redirect to /http/success/200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<HttpRedirectsGet301Headers>> Get301Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet301Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HttpRedirectsGet301Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 301:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 301 status code and redirect to /http/success/200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<HttpRedirectsGet301Headers> Get301(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet301Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new HttpRedirectsGet301Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 301:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePut301Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/301", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Put true Boolean value in request returns 301.  This request should not be automatically redirected, but should return the received 301 to the caller for evaluation. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<HttpRedirectsPut301Headers>> Put301Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut301Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HttpRedirectsPut301Headers(message.Response);
            switch (message.Response.Status)
            {
                case 301:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put true Boolean value in request returns 301.  This request should not be automatically redirected, but should return the received 301 to the caller for evaluation. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<HttpRedirectsPut301Headers> Put301(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut301Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new HttpRedirectsPut301Headers(message.Response);
            switch (message.Response.Status)
            {
                case 301:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateHead302Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/302", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 302 status code and redirect to /http/success/200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<HttpRedirectsHead302Headers>> Head302Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead302Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HttpRedirectsHead302Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 302:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 302 status code and redirect to /http/success/200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<HttpRedirectsHead302Headers> Head302(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead302Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new HttpRedirectsHead302Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 302:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet302Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/302", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Return 302 status code and redirect to /http/success/200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<HttpRedirectsGet302Headers>> Get302Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet302Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HttpRedirectsGet302Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 302:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Return 302 status code and redirect to /http/success/200. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<HttpRedirectsGet302Headers> Get302(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet302Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new HttpRedirectsGet302Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 302:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePatch302Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/302", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Patch true Boolean value in request returns 302.  This request should not be automatically redirected, but should return the received 302 to the caller for evaluation. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<HttpRedirectsPatch302Headers>> Patch302Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch302Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HttpRedirectsPatch302Headers(message.Response);
            switch (message.Response.Status)
            {
                case 302:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Patch true Boolean value in request returns 302.  This request should not be automatically redirected, but should return the received 302 to the caller for evaluation. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<HttpRedirectsPatch302Headers> Patch302(CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch302Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new HttpRedirectsPatch302Headers(message.Response);
            switch (message.Response.Status)
            {
                case 302:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePost303Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/303", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Post true Boolean value in request returns 303.  This request should be automatically redirected usign a get, ultimately returning a 200 status code. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<HttpRedirectsPost303Headers>> Post303Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost303Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HttpRedirectsPost303Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 303:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Post true Boolean value in request returns 303.  This request should be automatically redirected usign a get, ultimately returning a 200 status code. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<HttpRedirectsPost303Headers> Post303(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost303Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new HttpRedirectsPost303Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 303:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateHead307Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/307", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Redirect with 307, resulting in a 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<HttpRedirectsHead307Headers>> Head307Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead307Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HttpRedirectsHead307Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 307:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Redirect with 307, resulting in a 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<HttpRedirectsHead307Headers> Head307(CancellationToken cancellationToken = default)
        {
            using var message = CreateHead307Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new HttpRedirectsHead307Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 307:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGet307Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/307", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Redirect get with 307, resulting in a 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<HttpRedirectsGet307Headers>> Get307Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet307Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HttpRedirectsGet307Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 307:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Redirect get with 307, resulting in a 200 success. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<HttpRedirectsGet307Headers> Get307(CancellationToken cancellationToken = default)
        {
            using var message = CreateGet307Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new HttpRedirectsGet307Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 307:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateOptions307Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Options;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/307", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> options redirected with 307, resulting in a 200 after redirect. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<HttpRedirectsOptions307Headers>> Options307Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateOptions307Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HttpRedirectsOptions307Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 307:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> options redirected with 307, resulting in a 200 after redirect. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<HttpRedirectsOptions307Headers> Options307(CancellationToken cancellationToken = default)
        {
            using var message = CreateOptions307Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new HttpRedirectsOptions307Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 307:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePut307Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/307", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Put redirected with 307, resulting in a 200 after redirect. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<HttpRedirectsPut307Headers>> Put307Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut307Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HttpRedirectsPut307Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 307:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put redirected with 307, resulting in a 200 after redirect. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<HttpRedirectsPut307Headers> Put307(CancellationToken cancellationToken = default)
        {
            using var message = CreatePut307Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new HttpRedirectsPut307Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 307:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePatch307Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/307", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Patch redirected with 307, resulting in a 200 after redirect. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<HttpRedirectsPatch307Headers>> Patch307Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch307Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HttpRedirectsPatch307Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 307:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Patch redirected with 307, resulting in a 200 after redirect. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<HttpRedirectsPatch307Headers> Patch307(CancellationToken cancellationToken = default)
        {
            using var message = CreatePatch307Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new HttpRedirectsPatch307Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 307:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePost307Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/307", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Post redirected with 307, resulting in a 200 after redirect. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<HttpRedirectsPost307Headers>> Post307Async(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost307Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HttpRedirectsPost307Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 307:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Post redirected with 307, resulting in a 200 after redirect. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<HttpRedirectsPost307Headers> Post307(CancellationToken cancellationToken = default)
        {
            using var message = CreatePost307Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new HttpRedirectsPost307Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 307:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDelete307Request()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/redirect/307", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Delete redirected with 307, resulting in a 200 after redirect. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<HttpRedirectsDelete307Headers>> Delete307Async(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete307Request();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HttpRedirectsDelete307Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 307:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Delete redirected with 307, resulting in a 200 after redirect. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<HttpRedirectsDelete307Headers> Delete307(CancellationToken cancellationToken = default)
        {
            using var message = CreateDelete307Request();
            _pipeline.Send(message, cancellationToken);
            var headers = new HttpRedirectsDelete307Headers(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 307:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
