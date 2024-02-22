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

namespace Projection.ProjectedName
{
    // Data plane generated client.
    /// <summary> Projection. </summary>
    public partial class ProjectedNameClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ProjectedNameClient. </summary>
        public ProjectedNameClient() : this(new Uri("http://localhost:3000"), new ProjectedNameClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ProjectedNameClient. </summary>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public ProjectedNameClient(Uri endpoint, ProjectedNameClientOptions options)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            options ??= new ProjectedNameClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
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
        /// <include file="Docs/ProjectedNameClient.xml" path="doc/members/member[@name='ClientNameAsync(RequestContext)']/*" />
        public virtual async Task<Response> ClientNameAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ProjectedNameClient.ClientName");
            scope.Start();
            try
            {
                using HttpMessage message = CreateClientNameRequest(context);
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
        /// <include file="Docs/ProjectedNameClient.xml" path="doc/members/member[@name='ClientName(RequestContext)']/*" />
        public virtual Response ClientName(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ProjectedNameClient.ClientName");
            scope.Start();
            try
            {
                using HttpMessage message = CreateClientNameRequest(context);
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
        /// <param name="clientName"> The <see cref="string"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientName"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ProjectedNameClient.xml" path="doc/members/member[@name='ParameterAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> ParameterAsync(string clientName, RequestContext context = null)
        {
            if (clientName == null)
            {
                throw new ArgumentNullException(nameof(clientName));
            }

            using var scope = ClientDiagnostics.CreateScope("ProjectedNameClient.Parameter");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParameterRequest(clientName, context);
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
        /// <param name="clientName"> The <see cref="string"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientName"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ProjectedNameClient.xml" path="doc/members/member[@name='Parameter(string,RequestContext)']/*" />
        public virtual Response Parameter(string clientName, RequestContext context = null)
        {
            if (clientName == null)
            {
                throw new ArgumentNullException(nameof(clientName));
            }

            using var scope = ClientDiagnostics.CreateScope("ProjectedNameClient.Parameter");
            scope.Start();
            try
            {
                using HttpMessage message = CreateParameterRequest(clientName, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Property _cachedProperty;
        private Model _cachedModel;

        /// <summary> Initializes a new instance of Property. </summary>
        public virtual Property GetPropertyClient()
        {
            return Volatile.Read(ref _cachedProperty) ?? Interlocked.CompareExchange(ref _cachedProperty, new Property(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedProperty;
        }

        /// <summary> Initializes a new instance of Model. </summary>
        public virtual Model GetModelClient()
        {
            return Volatile.Read(ref _cachedModel) ?? Interlocked.CompareExchange(ref _cachedModel, new Model(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedModel;
        }

        internal HttpMessage CreateClientNameRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/projection/projected-name/operation", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateParameterRequest(string clientName, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/projection/projected-name/parameter", false);
            uri.AppendQuery("default-name", clientName, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
