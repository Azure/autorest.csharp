// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace ClientAndOperationGroup
{
    // Data plane generated client.
    /// <summary> The ClientAndOperationGroup service client. </summary>
    public partial class ClientAndOperationGroupClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ClientAndOperationGroupClient for mocking. </summary>
        protected ClientAndOperationGroupClient()
        {
        }

        /// <summary> Initializes a new instance of ClientAndOperationGroupClient. </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public ClientAndOperationGroupClient(Uri endpoint) : this(endpoint, new ClientAndOperationGroupClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ClientAndOperationGroupClient. </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public ClientAndOperationGroupClient(Uri endpoint, ClientAndOperationGroupClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ClientAndOperationGroupClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary>
        /// [Protocol Method] The Zero method
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
        /// <include file="Docs/ClientAndOperationGroupClient.xml" path="doc/members/member[@name='ZeroAsync(RequestContext)']/*" />
        public virtual async Task<Response> ZeroAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ClientAndOperationGroupClient.Zero");
            scope.Start();
            try
            {
                using HttpMessage message = CreateZeroRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] The Zero method
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
        /// <include file="Docs/ClientAndOperationGroupClient.xml" path="doc/members/member[@name='Zero(RequestContext)']/*" />
        public virtual Response Zero(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ClientAndOperationGroupClient.Zero");
            scope.Start();
            try
            {
                using HttpMessage message = CreateZeroRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] The One method
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
        /// <include file="Docs/ClientAndOperationGroupClient.xml" path="doc/members/member[@name='OneAsync(RequestContext)']/*" />
        public virtual async Task<Response> OneAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ClientAndOperationGroupClient.One");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOneRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] The One method
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
        /// <include file="Docs/ClientAndOperationGroupClient.xml" path="doc/members/member[@name='One(RequestContext)']/*" />
        public virtual Response One(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ClientAndOperationGroupClient.One");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOneRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Beta _cachedBeta;
        private Gamma _cachedGamma;

        /// <summary> Initializes a new instance of Beta. </summary>
        public virtual Beta GetBetaClient()
        {
            return Volatile.Read(ref _cachedBeta) ?? Interlocked.CompareExchange(ref _cachedBeta, new Beta(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedBeta;
        }

        /// <summary> Initializes a new instance of Gamma. </summary>
        public virtual Gamma GetGammaClient()
        {
            return Volatile.Read(ref _cachedGamma) ?? Interlocked.CompareExchange(ref _cachedGamma, new Gamma(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedGamma;
        }

        internal HttpMessage CreateZeroRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/top", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateOneRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/Alpha", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
