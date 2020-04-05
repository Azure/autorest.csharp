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
using NameConflicts.Models;

namespace NameConflicts
{
    internal partial class ServiceRestClient
    {
        private string host;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;

        /// <summary> Initializes a new instance of ServiceRestClient. </summary>
        public ServiceRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        internal HttpMessage CreateOperationRequest(string request, string message, string scope, string uri, string pipeline, string clientDiagnostics, Class @class)
        {
            var message0 = _pipeline.CreateMessage();
            var request0 = message0.Request;
            request0.Method = RequestMethod.Patch;
            var uri0 = new RawRequestUriBuilder();
            uri0.AppendRaw(host, false);
            uri0.AppendPath("/originalOperation", false);
            uri0.AppendQuery("request", request, true);
            uri0.AppendQuery("message", message, true);
            uri0.AppendQuery("scope", scope, true);
            uri0.AppendQuery("uri", uri, true);
            uri0.AppendQuery("pipeline", pipeline, true);
            uri0.AppendQuery("clientDiagnostics", clientDiagnostics, true);
            request0.Uri = uri0;
            request0.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(@class);
            request0.Content = content;
            return message0;
        }

        /// <param name="request"> The String to use. </param>
        /// <param name="message"> The String to use. </param>
        /// <param name="scope"> The String to use. </param>
        /// <param name="uri"> The String to use. </param>
        /// <param name="pipeline"> The String to use. </param>
        /// <param name="clientDiagnostics"> The String to use. </param>
        /// <param name="class"> The Class to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Class>> OperationAsync(string request, string message, string scope, string uri, string pipeline, string clientDiagnostics, Class @class, CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }
            if (pipeline == null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }
            if (clientDiagnostics == null)
            {
                throw new ArgumentNullException(nameof(clientDiagnostics));
            }
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

            using var scope0 = _clientDiagnostics.CreateScope("ServiceClient.Operation");
            scope0.Start();
            try
            {
                using var message0 = CreateOperationRequest(request, message, scope, uri, pipeline, clientDiagnostics, @class);
                await _pipeline.SendAsync(message0, cancellationToken).ConfigureAwait(false);
                switch (message0.Response.Status)
                {
                    case 200:
                        {
                            Class value = default;
                            using var document = await JsonDocument.ParseAsync(message0.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            if (document.RootElement.ValueKind == JsonValueKind.Null)
                            {
                                value = null;
                            }
                            else
                            {
                                value = Class.DeserializeClass(document.RootElement);
                            }
                            return Response.FromValue(value, message0.Response);
                        }
                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message0.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        /// <param name="request"> The String to use. </param>
        /// <param name="message"> The String to use. </param>
        /// <param name="scope"> The String to use. </param>
        /// <param name="uri"> The String to use. </param>
        /// <param name="pipeline"> The String to use. </param>
        /// <param name="clientDiagnostics"> The String to use. </param>
        /// <param name="class"> The Class to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Class> Operation(string request, string message, string scope, string uri, string pipeline, string clientDiagnostics, Class @class, CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            if (scope == null)
            {
                throw new ArgumentNullException(nameof(scope));
            }
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }
            if (pipeline == null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }
            if (clientDiagnostics == null)
            {
                throw new ArgumentNullException(nameof(clientDiagnostics));
            }
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

            using var scope0 = _clientDiagnostics.CreateScope("ServiceClient.Operation");
            scope0.Start();
            try
            {
                using var message0 = CreateOperationRequest(request, message, scope, uri, pipeline, clientDiagnostics, @class);
                _pipeline.Send(message0, cancellationToken);
                switch (message0.Response.Status)
                {
                    case 200:
                        {
                            Class value = default;
                            using var document = JsonDocument.Parse(message0.Response.ContentStream);
                            if (document.RootElement.ValueKind == JsonValueKind.Null)
                            {
                                value = null;
                            }
                            else
                            {
                                value = Class.DeserializeClass(document.RootElement);
                            }
                            return Response.FromValue(value, message0.Response);
                        }
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(message0.Response);
                }
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }
    }
}
