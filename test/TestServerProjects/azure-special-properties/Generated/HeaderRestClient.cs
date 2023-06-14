// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using azure_special_properties.Models;

namespace azure_special_properties
{
    internal partial class HeaderRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of HeaderRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public HeaderRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateCustomNamedRequestIdRequest(string fooClientRequestId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/customNamedRequestId", false);
            request.Uri = uri;
            request.Headers.Add("foo-client-request-id", fooClientRequestId);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send foo-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request. </summary>
        /// <param name="fooClientRequestId"> The fooRequestId. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fooClientRequestId"/> is null. </exception>
        public async Task<ResponseWithHeaders<HeaderCustomNamedRequestIdHeaders>> CustomNamedRequestIdAsync(string fooClientRequestId, CancellationToken cancellationToken = default)
        {
            if (fooClientRequestId == null)
            {
                throw new ArgumentNullException(nameof(fooClientRequestId));
            }

            using var message = CreateCustomNamedRequestIdRequest(fooClientRequestId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HeaderCustomNamedRequestIdHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send foo-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request. </summary>
        /// <param name="fooClientRequestId"> The fooRequestId. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fooClientRequestId"/> is null. </exception>
        public ResponseWithHeaders<HeaderCustomNamedRequestIdHeaders> CustomNamedRequestId(string fooClientRequestId, CancellationToken cancellationToken = default)
        {
            if (fooClientRequestId == null)
            {
                throw new ArgumentNullException(nameof(fooClientRequestId));
            }

            using var message = CreateCustomNamedRequestIdRequest(fooClientRequestId);
            _pipeline.Send(message, cancellationToken);
            var headers = new HeaderCustomNamedRequestIdHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCustomNamedRequestIdParamGroupingRequest(HeaderCustomNamedRequestIdParamGroupingParameters headerCustomNamedRequestIdParamGroupingParameters)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/customNamedRequestIdParamGrouping", false);
            request.Uri = uri;
            request.Headers.Add("foo-client-request-id", headerCustomNamedRequestIdParamGroupingParameters.FooClientRequestId);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send foo-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request, via a parameter group. </summary>
        /// <param name="headerCustomNamedRequestIdParamGroupingParameters"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="headerCustomNamedRequestIdParamGroupingParameters"/> is null. </exception>
        public async Task<ResponseWithHeaders<HeaderCustomNamedRequestIdParamGroupingHeaders>> CustomNamedRequestIdParamGroupingAsync(HeaderCustomNamedRequestIdParamGroupingParameters headerCustomNamedRequestIdParamGroupingParameters, CancellationToken cancellationToken = default)
        {
            if (headerCustomNamedRequestIdParamGroupingParameters == null)
            {
                throw new ArgumentNullException(nameof(headerCustomNamedRequestIdParamGroupingParameters));
            }

            using var message = CreateCustomNamedRequestIdParamGroupingRequest(headerCustomNamedRequestIdParamGroupingParameters);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HeaderCustomNamedRequestIdParamGroupingHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send foo-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request, via a parameter group. </summary>
        /// <param name="headerCustomNamedRequestIdParamGroupingParameters"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="headerCustomNamedRequestIdParamGroupingParameters"/> is null. </exception>
        public ResponseWithHeaders<HeaderCustomNamedRequestIdParamGroupingHeaders> CustomNamedRequestIdParamGrouping(HeaderCustomNamedRequestIdParamGroupingParameters headerCustomNamedRequestIdParamGroupingParameters, CancellationToken cancellationToken = default)
        {
            if (headerCustomNamedRequestIdParamGroupingParameters == null)
            {
                throw new ArgumentNullException(nameof(headerCustomNamedRequestIdParamGroupingParameters));
            }

            using var message = CreateCustomNamedRequestIdParamGroupingRequest(headerCustomNamedRequestIdParamGroupingParameters);
            _pipeline.Send(message, cancellationToken);
            var headers = new HeaderCustomNamedRequestIdParamGroupingHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCustomNamedRequestIdHeadRequest(string fooClientRequestId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azurespecials/customNamedRequestIdHead", false);
            request.Uri = uri;
            request.Headers.Add("foo-client-request-id", fooClientRequestId);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Send foo-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request. </summary>
        /// <param name="fooClientRequestId"> The fooRequestId. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fooClientRequestId"/> is null. </exception>
        public async Task<ResponseWithHeaders<HeaderCustomNamedRequestIdHeadHeaders>> CustomNamedRequestIdHeadAsync(string fooClientRequestId, CancellationToken cancellationToken = default)
        {
            if (fooClientRequestId == null)
            {
                throw new ArgumentNullException(nameof(fooClientRequestId));
            }

            using var message = CreateCustomNamedRequestIdHeadRequest(fooClientRequestId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new HeaderCustomNamedRequestIdHeadHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 404:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Send foo-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request. </summary>
        /// <param name="fooClientRequestId"> The fooRequestId. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fooClientRequestId"/> is null. </exception>
        public ResponseWithHeaders<HeaderCustomNamedRequestIdHeadHeaders> CustomNamedRequestIdHead(string fooClientRequestId, CancellationToken cancellationToken = default)
        {
            if (fooClientRequestId == null)
            {
                throw new ArgumentNullException(nameof(fooClientRequestId));
            }

            using var message = CreateCustomNamedRequestIdHeadRequest(fooClientRequestId);
            _pipeline.Send(message, cancellationToken);
            var headers = new HeaderCustomNamedRequestIdHeadHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 404:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
