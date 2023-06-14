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
using body_string.Models;

namespace body_string
{
    internal partial class EnumRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of EnumRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public EnumRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateGetNotExpandableRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/string/enum/notExpandable", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get enum value 'red color' from enumeration of 'red color', 'green-color', 'blue_color'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<Colors>> GetNotExpandableAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNotExpandableRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Colors value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetString().ToColors();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get enum value 'red color' from enumeration of 'red color', 'green-color', 'blue_color'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Colors> GetNotExpandable(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNotExpandableRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Colors value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetString().ToColors();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutNotExpandableRequest(Colors stringBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/string/enum/notExpandable", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(stringBody.ToSerialString());
            request.Content = content;
            return message;
        }

        /// <summary> Sends value 'red color' from enumeration of 'red color', 'green-color', 'blue_color'. </summary>
        /// <param name="stringBody"> string body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutNotExpandableAsync(Colors stringBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNotExpandableRequest(stringBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Sends value 'red color' from enumeration of 'red color', 'green-color', 'blue_color'. </summary>
        /// <param name="stringBody"> string body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNotExpandable(Colors stringBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutNotExpandableRequest(stringBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetReferencedRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/string/enum/Referenced", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get enum value 'red color' from enumeration of 'red color', 'green-color', 'blue_color'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<Colors>> GetReferencedAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetReferencedRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Colors value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetString().ToColors();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get enum value 'red color' from enumeration of 'red color', 'green-color', 'blue_color'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Colors> GetReferenced(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetReferencedRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Colors value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetString().ToColors();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutReferencedRequest(Colors enumStringBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/string/enum/Referenced", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStringValue(enumStringBody.ToSerialString());
            request.Content = content;
            return message;
        }

        /// <summary> Sends value 'red color' from enumeration of 'red color', 'green-color', 'blue_color'. </summary>
        /// <param name="enumStringBody"> enum string body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> PutReferencedAsync(Colors enumStringBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutReferencedRequest(enumStringBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Sends value 'red color' from enumeration of 'red color', 'green-color', 'blue_color'. </summary>
        /// <param name="enumStringBody"> enum string body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutReferenced(Colors enumStringBody, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutReferencedRequest(enumStringBody);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetReferencedConstantRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/string/enum/ReferencedConstant", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get value 'green-color' from the constant. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<RefColorConstant>> GetReferencedConstantAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetReferencedConstantRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RefColorConstant value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RefColorConstant.DeserializeRefColorConstant(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get value 'green-color' from the constant. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<RefColorConstant> GetReferencedConstant(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetReferencedConstantRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RefColorConstant value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RefColorConstant.DeserializeRefColorConstant(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutReferencedConstantRequest(RefColorConstant enumStringBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/string/enum/ReferencedConstant", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(enumStringBody);
            request.Content = content;
            return message;
        }

        /// <summary> Sends value 'green-color' from a constant. </summary>
        /// <param name="enumStringBody"> enum string body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="enumStringBody"/> is null. </exception>
        public async Task<Response> PutReferencedConstantAsync(RefColorConstant enumStringBody, CancellationToken cancellationToken = default)
        {
            if (enumStringBody == null)
            {
                throw new ArgumentNullException(nameof(enumStringBody));
            }

            using var message = CreatePutReferencedConstantRequest(enumStringBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Sends value 'green-color' from a constant. </summary>
        /// <param name="enumStringBody"> enum string body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="enumStringBody"/> is null. </exception>
        public Response PutReferencedConstant(RefColorConstant enumStringBody, CancellationToken cancellationToken = default)
        {
            if (enumStringBody == null)
            {
                throw new ArgumentNullException(nameof(enumStringBody));
            }

            using var message = CreatePutReferencedConstantRequest(enumStringBody);
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
