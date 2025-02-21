// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace body_boolean
{
    internal partial class BoolRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of BoolRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public BoolRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateGetTrueRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/bool/true", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get true Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<bool>> GetTrueAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetTrueRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        bool value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetBoolean();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get true Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<bool> GetTrue(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetTrueRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        bool value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
                        value = document.RootElement.GetBoolean();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutTrueRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/bool/true", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(true);
            request.Content = content;
            return message;
        }

        /// <summary> Set Boolean value true. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutTrueAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutTrueRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Set Boolean value true. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutTrue(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutTrueRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetFalseRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/bool/false", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get false Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<bool>> GetFalseAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetFalseRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        bool value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetBoolean();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get false Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<bool> GetFalse(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetFalseRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        bool value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
                        value = document.RootElement.GetBoolean();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutFalseRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/bool/false", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteBooleanValue(false);
            request.Content = content;
            return message;
        }

        /// <summary> Set Boolean value false. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutFalseAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutFalseRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Set Boolean value false. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutFalse(CancellationToken cancellationToken = default)
        {
            using var message = CreatePutFalseRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetNullRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/bool/null", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get null Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<bool?>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNullRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        bool? value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = document.RootElement.GetBoolean();
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get null Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<bool?> GetNull(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNullRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        bool? value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = document.RootElement.GetBoolean();
                        }
                        return Response.FromValue(value, message.Response);
                    }
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
            uri.AppendPath("/bool/invalid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get invalid Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<bool>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetInvalidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        bool value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetBoolean();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get invalid Boolean value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<bool> GetInvalid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetInvalidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        bool value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
                        value = document.RootElement.GetBoolean();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
