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

namespace body_byte
{
    internal partial class ByteRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of ByteRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public ByteRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateGetNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/byte/null", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null byte value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<byte[]>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        byte[] value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetBytesFromBase64("D");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null byte value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<byte[]> GetNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        byte[] value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetBytesFromBase64("D");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetEmptyRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/byte/empty", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get empty byte value ''. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<byte[]>> GetEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetEmptyRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        byte[] value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetBytesFromBase64("D");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get empty byte value ''. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<byte[]> GetEmpty(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetEmptyRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        byte[] value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetBytesFromBase64("D");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetNonAsciiRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/byte/nonAscii", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<byte[]>> GetNonAsciiAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNonAsciiRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        byte[] value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetBytesFromBase64("D");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<byte[]> GetNonAscii(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNonAsciiRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        byte[] value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetBytesFromBase64("D");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutNonAsciiRequest(byte[] byteBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/byte/nonAscii", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBase64StringValue(byteBody, "D");
            request.Content = content;
            return message;
        }

        /// <summary> Put non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6). </summary>
        /// <param name="byteBody"> Base64-encoded non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="byteBody"/> is null. </exception>
        public async Task<Response> PutNonAsciiAsync(byte[] byteBody, CancellationToken cancellationToken = default)
        {
            if (byteBody == null)
            {
                throw new ArgumentNullException(nameof(byteBody));
            }

            using var message = CreatePutNonAsciiRequest(byteBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6). </summary>
        /// <param name="byteBody"> Base64-encoded non-ascii byte string hex(FF FE FD FC FB FA F9 F8 F7 F6). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="byteBody"/> is null. </exception>
        public Response PutNonAscii(byte[] byteBody, CancellationToken cancellationToken = default)
        {
            if (byteBody == null)
            {
                throw new ArgumentNullException(nameof(byteBody));
            }

            using var message = CreatePutNonAsciiRequest(byteBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetInvalidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/byte/invalid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get invalid byte value ':::SWAGGER::::'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<byte[]>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetInvalidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        byte[] value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetBytesFromBase64("D");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get invalid byte value ':::SWAGGER::::'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<byte[]> GetInvalid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetInvalidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        byte[] value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetBytesFromBase64("D");
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
