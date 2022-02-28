// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using ApiVersion.Models;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace ApiVersion
{
    internal partial class ApiVersionRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of ApiVersionRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public ApiVersionRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null, string apiVersion = "1.0.0")
        {
            _endpoint = endpoint ?? new Uri("");
            _apiVersion = apiVersion ?? throw new ArgumentNullException(nameof(apiVersion));
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        internal HttpMessage CreateOperationRequest(Models.ApiVersion notApiVersionEnum)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/op", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            uri.AppendQuery("not-api-version-constant", "2.0", true);
            uri.AppendQuery("not-api-version-enum", notApiVersionEnum.ToString(), true);
            request.Uri = uri;
            return message;
        }

        /// <param name="notApiVersionEnum"> The ApiVersion to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> OperationAsync(Models.ApiVersion notApiVersionEnum, CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationRequest(notApiVersionEnum);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="notApiVersionEnum"> The ApiVersion to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Operation(Models.ApiVersion notApiVersionEnum, CancellationToken cancellationToken = default)
        {
            using var message = CreateOperationRequest(notApiVersionEnum);
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
