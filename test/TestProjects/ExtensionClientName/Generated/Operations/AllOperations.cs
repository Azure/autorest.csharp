// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using ExtensionClientName.Models;

namespace ExtensionClientName
{
    internal partial class AllOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of AllOperations. </summary>
        public AllOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateRenamedOperationRequest(string renamedPathParameter, string renamedQueryParameter, RenamedSchema renamedBodyParameter)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Patch;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/originalOperation/", false);
            uri.AppendPath(renamedPathParameter, true);
            uri.AppendQuery("originalQueryParameter", renamedQueryParameter, true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(renamedBodyParameter);
            request.Content = content;
            return message;
        }
        /// <param name="renamedPathParameter"> The string to use. </param>
        /// <param name="renamedQueryParameter"> The string to use. </param>
        /// <param name="renamedBodyParameter"> The RenamedSchema to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<RenamedSchema, RenamedOperationHeaders>> RenamedOperationAsync(string renamedPathParameter, string renamedQueryParameter, RenamedSchema renamedBodyParameter, CancellationToken cancellationToken = default)
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

            using var scope = clientDiagnostics.CreateScope("AllOperations.RenamedOperation");
            scope.Start();
            try
            {
                using var message = CreateRenamedOperationRequest(renamedPathParameter, renamedQueryParameter, renamedBodyParameter);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = RenamedSchema.DeserializeRenamedSchema(document.RootElement);
                            var headers = new RenamedOperationHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <param name="renamedPathParameter"> The string to use. </param>
        /// <param name="renamedQueryParameter"> The string to use. </param>
        /// <param name="renamedBodyParameter"> The RenamedSchema to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<RenamedSchema, RenamedOperationHeaders> RenamedOperation(string renamedPathParameter, string renamedQueryParameter, RenamedSchema renamedBodyParameter, CancellationToken cancellationToken = default)
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

            using var scope = clientDiagnostics.CreateScope("AllOperations.RenamedOperation");
            scope.Start();
            try
            {
                using var message = CreateRenamedOperationRequest(renamedPathParameter, renamedQueryParameter, renamedBodyParameter);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = RenamedSchema.DeserializeRenamedSchema(document.RootElement);
                            var headers = new RenamedOperationHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
