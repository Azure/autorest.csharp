// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Parameters.BodyOptionality.Models;

namespace Parameters.BodyOptionality
{
    // Data plane generated client.
    /// <summary> Test describing optionality of the request body. </summary>
    public partial class BodyOptionalityClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of BodyOptionalityClient. </summary>
        public BodyOptionalityClient() : this(new Uri("http://localhost:3000"), new BodyOptionalityClientOptions())
        {
        }

        /// <summary> Initializes a new instance of BodyOptionalityClient. </summary>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public BodyOptionalityClient(Uri endpoint, BodyOptionalityClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new BodyOptionalityClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary> Required explicit. </summary>
        /// <param name="body"> The <see cref="BodyModel"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/BodyOptionalityClient.xml" path="doc/members/member[@name='RequiredExplicitAsync(BodyModel,CancellationToken)']/*" />
        public virtual async Task<Response> RequiredExplicitAsync(BodyModel body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await RequiredExplicitAsync(content, context).ConfigureAwait(false);
            return response;
        }

        /// <summary> Required explicit. </summary>
        /// <param name="body"> The <see cref="BodyModel"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/BodyOptionalityClient.xml" path="doc/members/member[@name='RequiredExplicit(BodyModel,CancellationToken)']/*" />
        public virtual Response RequiredExplicit(BodyModel body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = RequiredExplicit(content, context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Required explicit.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RequiredExplicitAsync(BodyModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/BodyOptionalityClient.xml" path="doc/members/member[@name='RequiredExplicitAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> RequiredExplicitAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("BodyOptionalityClient.RequiredExplicit");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRequiredExplicitRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Required explicit.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RequiredExplicit(BodyModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/BodyOptionalityClient.xml" path="doc/members/member[@name='RequiredExplicit(RequestContent,RequestContext)']/*" />
        public virtual Response RequiredExplicit(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("BodyOptionalityClient.RequiredExplicit");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRequiredExplicitRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Required implicit. </summary>
        /// <param name="name"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <include file="Docs/BodyOptionalityClient.xml" path="doc/members/member[@name='RequiredImplicitAsync(string,CancellationToken)']/*" />
        public virtual async Task<Response> RequiredImplicitAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(name, nameof(name));

            RequiredImplicitRequest requiredImplicitRequest = new RequiredImplicitRequest(name, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await RequiredImplicitAsync(requiredImplicitRequest.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <summary> Required implicit. </summary>
        /// <param name="name"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <include file="Docs/BodyOptionalityClient.xml" path="doc/members/member[@name='RequiredImplicit(string,CancellationToken)']/*" />
        public virtual Response RequiredImplicit(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(name, nameof(name));

            RequiredImplicitRequest requiredImplicitRequest = new RequiredImplicitRequest(name, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = RequiredImplicit(requiredImplicitRequest.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Required implicit.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RequiredImplicitAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/BodyOptionalityClient.xml" path="doc/members/member[@name='RequiredImplicitAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> RequiredImplicitAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("BodyOptionalityClient.RequiredImplicit");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRequiredImplicitRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Required implicit.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RequiredImplicit(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/BodyOptionalityClient.xml" path="doc/members/member[@name='RequiredImplicit(RequestContent,RequestContext)']/*" />
        public virtual Response RequiredImplicit(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("BodyOptionalityClient.RequiredImplicit");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRequiredImplicitRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private OptionalExplicit _cachedOptionalExplicit;

        /// <summary> Initializes a new instance of OptionalExplicit. </summary>
        public virtual OptionalExplicit GetOptionalExplicitClient()
        {
            return Volatile.Read(ref _cachedOptionalExplicit) ?? Interlocked.CompareExchange(ref _cachedOptionalExplicit, new OptionalExplicit(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedOptionalExplicit;
        }

        internal HttpMessage CreateRequiredExplicitRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/body-optionality/required-explicit", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateRequiredImplicitRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/body-optionality/required-implicit", false);
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
