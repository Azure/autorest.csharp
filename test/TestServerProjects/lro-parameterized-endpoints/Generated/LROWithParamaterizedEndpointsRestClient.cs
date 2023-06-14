// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace lro_parameterized_endpoints
{
    internal partial class LROWithParamaterizedEndpointsRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _host;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of LROWithParamaterizedEndpointsRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="host"> A string value that is used as a global part of the parameterized host. Pass in 'host:3000' to pass test. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/> or <paramref name="host"/> is null. </exception>
        public LROWithParamaterizedEndpointsRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "host")
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _host = host ?? throw new ArgumentNullException(nameof(host));
        }

        internal HttpMessage CreatePollWithParameterizedEndpointsRequest(string accountName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("http://", false);
            uri.AppendRaw(accountName, false);
            uri.AppendRaw(_host, false);
            uri.AppendPath("/lroParameterizedEndpoints", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Poll with method and client level parameters in endpoint. </summary>
        /// <param name="accountName"> Account Name. Pass in 'local' to pass test. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> is null. </exception>
        public async Task<ResponseWithHeaders<LROWithParamaterizedEndpointsPollWithParameterizedEndpointsHeaders>> PollWithParameterizedEndpointsAsync(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            using var message = CreatePollWithParameterizedEndpointsRequest(accountName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROWithParamaterizedEndpointsPollWithParameterizedEndpointsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Poll with method and client level parameters in endpoint. </summary>
        /// <param name="accountName"> Account Name. Pass in 'local' to pass test. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> is null. </exception>
        public ResponseWithHeaders<LROWithParamaterizedEndpointsPollWithParameterizedEndpointsHeaders> PollWithParameterizedEndpoints(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            using var message = CreatePollWithParameterizedEndpointsRequest(accountName);
            _pipeline.Send(message, cancellationToken);
            var headers = new LROWithParamaterizedEndpointsPollWithParameterizedEndpointsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePollWithConstantParameterizedEndpointsRequest(string accountName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("http://", false);
            uri.AppendRaw(accountName, false);
            uri.AppendRaw(_host, false);
            uri.AppendPath("/lroConstantParameterizedEndpoints/", false);
            uri.AppendPath("iAmConstant", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Poll with method and client level parameters in endpoint, with a constant value. </summary>
        /// <param name="accountName"> Account Name. Pass in 'local' to pass test. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> is null. </exception>
        public async Task<ResponseWithHeaders<LROWithParamaterizedEndpointsPollWithConstantParameterizedEndpointsHeaders>> PollWithConstantParameterizedEndpointsAsync(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            using var message = CreatePollWithConstantParameterizedEndpointsRequest(accountName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new LROWithParamaterizedEndpointsPollWithConstantParameterizedEndpointsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Poll with method and client level parameters in endpoint, with a constant value. </summary>
        /// <param name="accountName"> Account Name. Pass in 'local' to pass test. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> is null. </exception>
        public ResponseWithHeaders<LROWithParamaterizedEndpointsPollWithConstantParameterizedEndpointsHeaders> PollWithConstantParameterizedEndpoints(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            using var message = CreatePollWithConstantParameterizedEndpointsRequest(accountName);
            _pipeline.Send(message, cancellationToken);
            var headers = new LROWithParamaterizedEndpointsPollWithConstantParameterizedEndpointsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
