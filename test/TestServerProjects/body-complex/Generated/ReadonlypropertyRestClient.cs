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
using body_complex.Models;

namespace body_complex
{
    internal partial class ReadonlypropertyRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of ReadonlypropertyRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public ReadonlypropertyRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateGetValidRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/readonlyproperty/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get complex types that have readonly properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ReadonlyObj>> GetValidAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetValidRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ReadonlyObj value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ReadonlyObj.DeserializeReadonlyObj(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get complex types that have readonly properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ReadonlyObj> GetValid(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetValidRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ReadonlyObj value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ReadonlyObj.DeserializeReadonlyObj(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutValidRequest(ReadonlyObj complexBody)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/complex/readonlyproperty/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(complexBody);
            request.Content = content;
            return message;
        }

        /// <summary> Put complex types that have readonly properties. </summary>
        /// <param name="complexBody"> The ReadonlyObj to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="complexBody"/> is null. </exception>
        public async Task<Response> PutValidAsync(ReadonlyObj complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var message = CreatePutValidRequest(complexBody);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put complex types that have readonly properties. </summary>
        /// <param name="complexBody"> The ReadonlyObj to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="complexBody"/> is null. </exception>
        public Response PutValid(ReadonlyObj complexBody, CancellationToken cancellationToken = default)
        {
            if (complexBody == null)
            {
                throw new ArgumentNullException(nameof(complexBody));
            }

            using var message = CreatePutValidRequest(complexBody);
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
