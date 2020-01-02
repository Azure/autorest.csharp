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
        private string Host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        public AllOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string Host = "http://localhost:3000")
        {
            if (Host == null)
            {
                throw new ArgumentNullException(nameof(Host));
            }

            this.Host = Host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        public async ValueTask<ResponseWithHeaders<OriginalSchema, OriginalOperationHeaders>> OriginalOperationAsync(string OriginalPathParameter, string OriginalQueryParameter, OriginalSchema RenamedBodyParameter, CancellationToken cancellationToken = default)
        {
            if (OriginalPathParameter == null)
            {
                throw new ArgumentNullException(nameof(OriginalPathParameter));
            }
            if (OriginalQueryParameter == null)
            {
                throw new ArgumentNullException(nameof(OriginalQueryParameter));
            }
            if (RenamedBodyParameter == null)
            {
                throw new ArgumentNullException(nameof(RenamedBodyParameter));
            }

            using var scope = clientDiagnostics.CreateScope("extension_client_name.OriginalOperation");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Patch;
                request.Uri.Reset(new Uri($"{Host}"));
                request.Uri.AppendPath("/originalOperation/", false);
                request.Uri.AppendPath(OriginalPathParameter, true);
                request.Headers.Add("Content-Type", "application/json");
                request.Uri.AppendQuery("originalQueryParameter", OriginalQueryParameter, true);
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(RenamedBodyParameter);
                request.Content = content;
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
                        throw new Exception();
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
