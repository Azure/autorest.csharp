// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using extension_client_name.Models.V100;

namespace extension_client_name
{
    internal partial class AllOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
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
        internal HttpMessage CreateOriginalOperationRequest(string originalPathParameter, string originalQueryParameter, OriginalSchema renamedBodyParameter)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/originalOperation/", false);
            request.Uri.AppendPath(originalPathParameter, true);
            request.Headers.Add("Content-Type", "application/json");
            request.Uri.AppendQuery("originalQueryParameter", originalQueryParameter, true);
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(renamedBodyParameter);
            request.Content = content;
            return message;
        }
        public async ValueTask<ResponseWithHeaders<OriginalSchema, OriginalOperationHeaders>> OriginalOperationAsync(string originalPathParameter, string originalQueryParameter, OriginalSchema renamedBodyParameter, CancellationToken cancellationToken = default)
        {
            if (originalPathParameter == null)
            {
                throw new ArgumentNullException(nameof(originalPathParameter));
            }
            if (originalQueryParameter == null)
            {
                throw new ArgumentNullException(nameof(originalQueryParameter));
            }
            if (renamedBodyParameter == null)
            {
                throw new ArgumentNullException(nameof(renamedBodyParameter));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.OriginalOperation");
            scope.Start();
            try
            {
                using var message = CreateOriginalOperationRequest(originalPathParameter, originalQueryParameter, renamedBodyParameter);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OriginalSchema.DeserializeOriginalSchema(document.RootElement);
                            var headers = new OriginalOperationHeaders(message.Response);
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
    }
}
