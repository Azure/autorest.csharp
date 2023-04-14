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
using non_string_enum.Models;

namespace non_string_enum
{
    internal partial class FloatRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of FloatRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public FloatRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreatePutRequest(FloatEnum? input)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/nonStringEnums/float/put", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (input != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteNumberValue(input.Value.ToSerialSingle());
                request.Content = content;
            }
            return message;
        }

        /// <summary> Put a float enum. </summary>
        /// <param name="input"> Input float enum. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<string>> PutAsync(FloatEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutRequest(input);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        string value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = document.RootElement.GetString();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Put a float enum. </summary>
        /// <param name="input"> Input float enum. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<string> Put(FloatEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var message = CreatePutRequest(input);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        string value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = document.RootElement.GetString();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/nonStringEnums/float/get", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a float enum. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<FloatEnum>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FloatEnum value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = new FloatEnum(document.RootElement.GetSingle());
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Get a float enum. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<FloatEnum> Get(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FloatEnum value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = new FloatEnum(document.RootElement.GetSingle());
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
