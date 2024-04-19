// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Client.Structure.Service.Multiple.Client
{
    // Data plane generated client.
    /// <summary> The ClientA service client. </summary>
    public partial class ClientAClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _client;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ClientAClient for mocking. </summary>
        protected ClientAClient()
        {
        }

        /// <summary> Initializes a new instance of ClientAClient. </summary>
        /// <param name="endpoint"> Need to be set as 'http://localhost:3000' in client. </param>
        /// <param name="client"> Need to be set as 'default', 'multi-client', 'renamed-operation', 'two-operation-group' in client. Allowed values: "default" | "multi-client" | "renamed-operation" | "two-operation-group". </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="client"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="client"/> is an empty string, and was expected to be non-empty. </exception>
        public ClientAClient(Uri endpoint, string client) : this(endpoint, client, new ClientStructureServiceMultipleClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ClientAClient. </summary>
        /// <param name="endpoint"> Need to be set as 'http://localhost:3000' in client. </param>
        /// <param name="client"> Need to be set as 'default', 'multi-client', 'renamed-operation', 'two-operation-group' in client. Allowed values: "default" | "multi-client" | "renamed-operation" | "two-operation-group". </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="client"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="client"/> is an empty string, and was expected to be non-empty. </exception>
        public ClientAClient(Uri endpoint, string client, ClientStructureServiceMultipleClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNullOrEmpty(client, nameof(client));
            options ??= new ClientStructureServiceMultipleClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _client = client;
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Renamed one.
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
        /// <include file="Docs/ClientAClient.xml" path="doc/members/member[@name='RenamedOneAsync(RequestContext)']/*" />
        public virtual async Task<Response> RenamedOneAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ClientAClient.RenamedOne");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRenamedOneRequest(context);
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
        /// [Protocol Method] Renamed one.
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
        /// <include file="Docs/ClientAClient.xml" path="doc/members/member[@name='RenamedOne(RequestContext)']/*" />
        public virtual Response RenamedOne(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ClientAClient.RenamedOne");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRenamedOneRequest(context);
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
        /// [Protocol Method] Renamed three.
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
        /// <include file="Docs/ClientAClient.xml" path="doc/members/member[@name='RenamedThreeAsync(RequestContext)']/*" />
        public virtual async Task<Response> RenamedThreeAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ClientAClient.RenamedThree");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRenamedThreeRequest(context);
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
        /// [Protocol Method] Renamed three.
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
        /// <include file="Docs/ClientAClient.xml" path="doc/members/member[@name='RenamedThree(RequestContext)']/*" />
        public virtual Response RenamedThree(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ClientAClient.RenamedThree");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRenamedThreeRequest(context);
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
        /// [Protocol Method] Renamed five.
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
        /// <include file="Docs/ClientAClient.xml" path="doc/members/member[@name='RenamedFiveAsync(RequestContext)']/*" />
        public virtual async Task<Response> RenamedFiveAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ClientAClient.RenamedFive");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRenamedFiveRequest(context);
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
        /// [Protocol Method] Renamed five.
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
        /// <include file="Docs/ClientAClient.xml" path="doc/members/member[@name='RenamedFive(RequestContext)']/*" />
        public virtual Response RenamedFive(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ClientAClient.RenamedFive");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRenamedFiveRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateRenamedOneRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/client/structure/", false);
            uri.AppendRaw(_client, true);
            uri.AppendPath("/one", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateRenamedThreeRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/client/structure/", false);
            uri.AppendRaw(_client, true);
            uri.AppendPath("/three", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateRenamedFiveRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/client/structure/", false);
            uri.AppendRaw(_client, true);
            uri.AppendPath("/five", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
