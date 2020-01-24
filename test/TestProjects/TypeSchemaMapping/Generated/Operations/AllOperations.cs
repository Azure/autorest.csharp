// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.TypeSchemaMapping;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace TypeSchemaMapping
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
        internal HttpMessage CreateOperationRequest(CustomizedModel dody)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/Operation", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(dody);
            request.Content = content;
            return message;
        }
        /// <summary> MISSING·OPERATION-DESCRIPTION. </summary>
        /// <param name="dody"> The Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> OperationAsync(CustomizedModel dody, CancellationToken cancellationToken = default)
        {
            if (dody == null)
            {
                throw new ArgumentNullException(nameof(dody));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.Operation");
            scope.Start();
            try
            {
                using var message = CreateOperationRequest(dody);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
        /// <summary> MISSING·OPERATION-DESCRIPTION. </summary>
        /// <param name="dody"> The Model to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Operation(CustomizedModel dody, CancellationToken cancellationToken = default)
        {
            if (dody == null)
            {
                throw new ArgumentNullException(nameof(dody));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.Operation");
            scope.Start();
            try
            {
                using var message = CreateOperationRequest(dody);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
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
