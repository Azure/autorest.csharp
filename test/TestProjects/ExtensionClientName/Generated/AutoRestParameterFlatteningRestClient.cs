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
using ExtensionClientName.Models;

namespace ExtensionClientName
{
    internal partial class AutoRestParameterFlatteningRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of AutoRestParameterFlatteningRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public AutoRestParameterFlatteningRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateRenamedOperationRequest(string renamedPathParameter, string renamedQueryParameter, RenamedSchema renamedBodyParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/originalOperation/", false);
            uri.AppendPath(renamedPathParameter, true);
            uri.AppendQuery("originalQueryParameter", renamedQueryParameter, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(renamedBodyParameter);
            request.Content = content;
            return message;
        }

        /// <param name="renamedPathParameter"> The String to use. </param>
        /// <param name="renamedQueryParameter"> The String to use. </param>
        /// <param name="renamedBodyParameter"> The RenamedSchema to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="renamedPathParameter"/>, <paramref name="renamedQueryParameter"/> or <paramref name="renamedBodyParameter"/> is null. </exception>
        public async Task<ResponseWithHeaders<RenamedSchema, AutoRestParameterFlatteningRenamedOperationHeaders>> RenamedOperationAsync(string renamedPathParameter, string renamedQueryParameter, RenamedSchema renamedBodyParameter, CancellationToken cancellationToken = default)
        {
            if (renamedPathParameter == null)
            {
                throw new ArgumentNullException(nameof(renamedPathParameter));
            }
            if (renamedQueryParameter == null)
            {
                throw new ArgumentNullException(nameof(renamedQueryParameter));
            }
            if (renamedBodyParameter == null)
            {
                throw new ArgumentNullException(nameof(renamedBodyParameter));
            }

            using var message = CreateRenamedOperationRequest(renamedPathParameter, renamedQueryParameter, renamedBodyParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AutoRestParameterFlatteningRenamedOperationHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RenamedSchema value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RenamedSchema.DeserializeRenamedSchema(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="renamedPathParameter"> The String to use. </param>
        /// <param name="renamedQueryParameter"> The String to use. </param>
        /// <param name="renamedBodyParameter"> The RenamedSchema to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="renamedPathParameter"/>, <paramref name="renamedQueryParameter"/> or <paramref name="renamedBodyParameter"/> is null. </exception>
        public ResponseWithHeaders<RenamedSchema, AutoRestParameterFlatteningRenamedOperationHeaders> RenamedOperation(string renamedPathParameter, string renamedQueryParameter, RenamedSchema renamedBodyParameter, CancellationToken cancellationToken = default)
        {
            if (renamedPathParameter == null)
            {
                throw new ArgumentNullException(nameof(renamedPathParameter));
            }
            if (renamedQueryParameter == null)
            {
                throw new ArgumentNullException(nameof(renamedQueryParameter));
            }
            if (renamedBodyParameter == null)
            {
                throw new ArgumentNullException(nameof(renamedBodyParameter));
            }

            using var message = CreateRenamedOperationRequest(renamedPathParameter, renamedQueryParameter, renamedBodyParameter);
            _pipeline.Send(message, cancellationToken);
            var headers = new AutoRestParameterFlatteningRenamedOperationHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RenamedSchema value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RenamedSchema.DeserializeRenamedSchema(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
