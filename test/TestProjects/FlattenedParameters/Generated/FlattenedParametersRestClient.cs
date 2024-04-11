// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using FlattenedParameters.Models;

namespace FlattenedParameters
{
    internal partial class FlattenedParametersRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of FlattenedParametersRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public FlattenedParametersRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateOperationRequest(IEnumerable<string> items)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/Operation/", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            var model = new PathsYkez7BOperationPatchRequestbodyContentApplicationJsonSchema()
            {
                Items = items?.ToList()
            };
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(model);
            request.Content = content;
            return message;
        }

        /// <param name="items"> The <see cref="IEnumerable{T}"/> where <c>T</c> is of type <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> OperationAsync(IEnumerable<string> items = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationRequest(items);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="items"> The <see cref="IEnumerable{T}"/> where <c>T</c> is of type <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Operation(IEnumerable<string> items = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationRequest(items);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateOperationNotNullRequest(IEnumerable<string> items)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/OperationNotNull/", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema pathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema = new PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema();
            if (items != null)
            {
                foreach (var value in items)
                {
                    pathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema.Items.Add(value);
                }
            }
            var model = pathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema;
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(model);
            request.Content = content;
            return message;
        }

        /// <param name="items"> The <see cref="IEnumerable{T}"/> where <c>T</c> is of type <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> OperationNotNullAsync(IEnumerable<string> items = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationNotNullRequest(items);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="items"> The <see cref="IEnumerable{T}"/> where <c>T</c> is of type <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response OperationNotNull(IEnumerable<string> items = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationNotNullRequest(items);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateOperationNotRequiredRequest(string required, string nonRequired)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/OperationNotRequired/", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            var model = new Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema()
            {
                Required = required,
                NonRequired = nonRequired
            };
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(model);
            request.Content = content;
            return message;
        }

        /// <param name="required"> The <see cref="string"/> to use. </param>
        /// <param name="nonRequired"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> OperationNotRequiredAsync(string required = null, string nonRequired = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationNotRequiredRequest(required, nonRequired);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="required"> The <see cref="string"/> to use. </param>
        /// <param name="nonRequired"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response OperationNotRequired(string required = null, string nonRequired = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationNotRequiredRequest(required, nonRequired);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateOperationRequiredRequest(string required, string nonRequired)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/OperationRequired/", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            var model = new Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema(required)
            {
                NonRequired = nonRequired
            };
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(model);
            request.Content = content;
            return message;
        }

        /// <param name="required"> The <see cref="string"/> to use. </param>
        /// <param name="nonRequired"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="required"/> is null. </exception>
        public async Task<Response> OperationRequiredAsync(string required, string nonRequired = null, CancellationToken cancellationToken = default)
        {
            if (required == null)
            {
                throw new ArgumentNullException(nameof(required));
            }

            using var message = CreateOperationRequiredRequest(required, nonRequired);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="required"> The <see cref="string"/> to use. </param>
        /// <param name="nonRequired"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="required"/> is null. </exception>
        public Response OperationRequired(string required, string nonRequired = null, CancellationToken cancellationToken = default)
        {
            if (required == null)
            {
                throw new ArgumentNullException(nameof(required));
            }

            using var message = CreateOperationRequiredRequest(required, nonRequired);
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
