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
using Versioning.Added.Models;

namespace Versioning.Added
{
    // Data plane generated client.
    /// <summary> Test for the `@added` decorator. </summary>
    public partial class AddedClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _version;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of AddedClient for mocking. </summary>
        protected AddedClient()
        {
        }

        /// <summary> Initializes a new instance of AddedClient. </summary>
        /// <param name="endpoint"> Need to be set as 'http://localhost:3000' in client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public AddedClient(Uri endpoint) : this(endpoint, new AddedClientOptions())
        {
        }

        /// <summary> Initializes a new instance of AddedClient. </summary>
        /// <param name="endpoint"> Need to be set as 'http://localhost:3000' in client. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public AddedClient(Uri endpoint, AddedClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new AddedClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _version = options.Version;
        }

        /// <summary> V 1. </summary>
        /// <param name="headerV2"> The <see cref="string"/> to use. </param>
        /// <param name="body"> The <see cref="ModelV1"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="headerV2"/> or <paramref name="body"/> is null. </exception>
        /// <include file="Docs/AddedClient.xml" path="doc/members/member[@name='V1Async(string,ModelV1,CancellationToken)']/*" />
        public virtual async Task<Response<ModelV1>> V1Async(string headerV2, ModelV1 body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(headerV2, nameof(headerV2));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await V1Async(headerV2, content, context).ConfigureAwait(false);
            return Response.FromValue(ModelV1.FromResponse(response), response);
        }

        /// <summary> V 1. </summary>
        /// <param name="headerV2"> The <see cref="string"/> to use. </param>
        /// <param name="body"> The <see cref="ModelV1"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="headerV2"/> or <paramref name="body"/> is null. </exception>
        /// <include file="Docs/AddedClient.xml" path="doc/members/member[@name='V1(string,ModelV1,CancellationToken)']/*" />
        public virtual Response<ModelV1> V1(string headerV2, ModelV1 body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(headerV2, nameof(headerV2));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = V1(headerV2, content, context);
            return Response.FromValue(ModelV1.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] V 1.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="V1Async(string,ModelV1,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="headerV2"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="headerV2"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AddedClient.xml" path="doc/members/member[@name='V1Async(string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> V1Async(string headerV2, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(headerV2, nameof(headerV2));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AddedClient.V1");
            scope.Start();
            try
            {
                using HttpMessage message = CreateV1Request(headerV2, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] V 1.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="V1(string,ModelV1,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="headerV2"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="headerV2"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AddedClient.xml" path="doc/members/member[@name='V1(string,RequestContent,RequestContext)']/*" />
        public virtual Response V1(string headerV2, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(headerV2, nameof(headerV2));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AddedClient.V1");
            scope.Start();
            try
            {
                using HttpMessage message = CreateV1Request(headerV2, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> V 2. </summary>
        /// <param name="body"> The <see cref="ModelV2"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/AddedClient.xml" path="doc/members/member[@name='V2Async(ModelV2,CancellationToken)']/*" />
        public virtual async Task<Response<ModelV2>> V2Async(ModelV2 body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await V2Async(content, context).ConfigureAwait(false);
            return Response.FromValue(ModelV2.FromResponse(response), response);
        }

        /// <summary> V 2. </summary>
        /// <param name="body"> The <see cref="ModelV2"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/AddedClient.xml" path="doc/members/member[@name='V2(ModelV2,CancellationToken)']/*" />
        public virtual Response<ModelV2> V2(ModelV2 body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = V2(content, context);
            return Response.FromValue(ModelV2.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] V 2.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="V2Async(ModelV2,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AddedClient.xml" path="doc/members/member[@name='V2Async(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> V2Async(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AddedClient.V2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateV2Request(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] V 2.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="V2(ModelV2,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AddedClient.xml" path="doc/members/member[@name='V2(RequestContent,RequestContext)']/*" />
        public virtual Response V2(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AddedClient.V2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateV2Request(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private InterfaceV2 _cachedInterfaceV2;

        /// <summary> Initializes a new instance of InterfaceV2. </summary>
        public virtual InterfaceV2 GetInterfaceV2Client()
        {
            return Volatile.Read(ref _cachedInterfaceV2) ?? Interlocked.CompareExchange(ref _cachedInterfaceV2, new InterfaceV2(ClientDiagnostics, _pipeline, _endpoint, _version), null) ?? _cachedInterfaceV2;
        }

        internal HttpMessage CreateV1Request(string headerV2, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/versioning/added/api-version:", false);
            uri.AppendRaw(_version, true);
            uri.AppendPath("/v1", false);
            request.Uri = uri;
            request.Headers.Add("header-v2", headerV2);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateV2Request(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/versioning/added/api-version:", false);
            uri.AppendRaw(_version, true);
            uri.AppendPath("/v2", false);
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

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
