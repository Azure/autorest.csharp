// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Parameters.Spread.Models;

namespace Parameters.Spread
{
    // Data plane generated sub-client.
    /// <summary> The Model sub-client. </summary>
    public partial class Model
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Model for mocking. </summary>
        protected Model()
        {
        }

        /// <summary> Initializes a new instance of Model. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="apiVersion"> The String to use. </param>
        internal Model(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint, string apiVersion)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
        }

        /// <param name="bodyParameter"> This is a simple model. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bodyParameter"/> is null. </exception>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadAsRequestBodyAsync(BodyParameter,CancellationToken)']/*" />
        public virtual async Task<Response> SpreadAsRequestBodyAsync(BodyParameter bodyParameter, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(bodyParameter, nameof(bodyParameter));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await SpreadAsRequestBodyAsync(bodyParameter.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <param name="bodyParameter"> This is a simple model. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bodyParameter"/> is null. </exception>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadAsRequestBody(BodyParameter,CancellationToken)']/*" />
        public virtual Response SpreadAsRequestBody(BodyParameter bodyParameter, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(bodyParameter, nameof(bodyParameter));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = SpreadAsRequestBody(bodyParameter.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAsRequestBodyAsync(BodyParameter,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadAsRequestBodyAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> SpreadAsRequestBodyAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Model.SpreadAsRequestBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadAsRequestBodyRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAsRequestBody(BodyParameter,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadAsRequestBody(RequestContent,RequestContext)']/*" />
        public virtual Response SpreadAsRequestBody(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Model.SpreadAsRequestBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadAsRequestBodyRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateSpreadAsRequestBodyRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/spread/model/request-body", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        private static RequestContext DefaultRequestContext = new RequestContext();
        internal static RequestContext FromCancellationToken(CancellationToken cancellationToken = default)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                return DefaultRequestContext;
            }

            return new RequestContext() { CancellationToken = cancellationToken };
        }

        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
