// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Server.Path.Multiple
{
    // Data plane generated client.
    /// <summary> The Multiple service client. </summary>
    public partial class MultipleClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of MultipleClient for mocking. </summary>
        protected MultipleClient()
        {
        }

        /// <summary> Initializes a new instance of MultipleClient. </summary>
        /// <param name="endpoint"> Pass in http://localhost:3000 for endpoint. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public MultipleClient(Uri endpoint) : this(endpoint, new MultipleClientOptions())
        {
        }

        /// <summary> Initializes a new instance of MultipleClient. </summary>
        /// <param name="endpoint"> Pass in http://localhost:3000 for endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public MultipleClient(Uri endpoint, MultipleClientOptions options)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            options ??= new MultipleClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MultipleClient.xml" path="doc/members/member[@name='NoOperationParamsAsync(RequestContext)']/*" />
        public virtual async Task<Response> NoOperationParamsAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleClient.NoOperationParams");
            scope.Start();
            try
            {
                using HttpMessage message = CreateNoOperationParamsRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MultipleClient.xml" path="doc/members/member[@name='NoOperationParams(RequestContext)']/*" />
        public virtual Response NoOperationParams(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MultipleClient.NoOperationParams");
            scope.Start();
            try
            {
                using HttpMessage message = CreateNoOperationParamsRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="keyword"> The <see cref="string"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="keyword"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="keyword"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MultipleClient.xml" path="doc/members/member[@name='WithOperationPathParamAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> WithOperationPathParamAsync(string keyword, RequestContext context = null)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException(nameof(keyword));
            }
            if (keyword.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(keyword));
            }

            using var scope = ClientDiagnostics.CreateScope("MultipleClient.WithOperationPathParam");
            scope.Start();
            try
            {
                using HttpMessage message = CreateWithOperationPathParamRequest(keyword, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="keyword"> The <see cref="string"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="keyword"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="keyword"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MultipleClient.xml" path="doc/members/member[@name='WithOperationPathParam(string,RequestContext)']/*" />
        public virtual Response WithOperationPathParam(string keyword, RequestContext context = null)
        {
            if (keyword == null)
            {
                throw new ArgumentNullException(nameof(keyword));
            }
            if (keyword.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(keyword));
            }

            using var scope = ClientDiagnostics.CreateScope("MultipleClient.WithOperationPathParam");
            scope.Start();
            try
            {
                using HttpMessage message = CreateWithOperationPathParamRequest(keyword, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateNoOperationParamsRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/server/path/multiple/", false);
            uri.AppendRaw(_apiVersion, true);
            uri.AppendPath("/", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateWithOperationPathParamRequest(string keyword, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/server/path/multiple/", false);
            uri.AppendRaw(_apiVersion, true);
            uri.AppendPath("/", false);
            uri.AppendPath(keyword, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
