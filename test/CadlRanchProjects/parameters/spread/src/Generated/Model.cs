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
using Parameters.Spread.Models;

namespace Parameters.Spread
{
    // Data plane generated sub-client.
    /// <summary> The Model sub-client. </summary>
    public partial class Model
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

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
        /// <param name="endpoint"> Service host. </param>
        internal Model(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
        }

        /// <summary> Spread as request body. </summary>
        /// <param name="name"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadAsRequestBodyAsync(string,CancellationToken)']/*" />
        public virtual async Task<Response> SpreadAsRequestBodyAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(name, nameof(name));

            BodyParameter bodyParameter = new BodyParameter(name, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await SpreadAsRequestBodyAsync(bodyParameter.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <summary> Spread as request body. </summary>
        /// <param name="name"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadAsRequestBody(string,CancellationToken)']/*" />
        public virtual Response SpreadAsRequestBody(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(name, nameof(name));

            BodyParameter bodyParameter = new BodyParameter(name, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = SpreadAsRequestBody(bodyParameter.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Spread as request body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAsRequestBodyAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
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
        /// [Protocol Method] Spread as request body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAsRequestBody(string,CancellationToken)"/> convenience overload with strongly typed models first.
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

        /// <summary> Spread composite request only with body. </summary>
        /// <param name="body"> The <see cref="BodyParameter"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadCompositeRequestOnlyWithBodyAsync(BodyParameter,CancellationToken)']/*" />
        public virtual async Task<Response> SpreadCompositeRequestOnlyWithBodyAsync(BodyParameter body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await SpreadCompositeRequestOnlyWithBodyAsync(content, context).ConfigureAwait(false);
            return response;
        }

        /// <summary> Spread composite request only with body. </summary>
        /// <param name="body"> The <see cref="BodyParameter"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadCompositeRequestOnlyWithBody(BodyParameter,CancellationToken)']/*" />
        public virtual Response SpreadCompositeRequestOnlyWithBody(BodyParameter body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = SpreadCompositeRequestOnlyWithBody(content, context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Spread composite request only with body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadCompositeRequestOnlyWithBodyAsync(BodyParameter,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadCompositeRequestOnlyWithBodyAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> SpreadCompositeRequestOnlyWithBodyAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Model.SpreadCompositeRequestOnlyWithBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadCompositeRequestOnlyWithBodyRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Spread composite request only with body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadCompositeRequestOnlyWithBody(BodyParameter,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadCompositeRequestOnlyWithBody(RequestContent,RequestContext)']/*" />
        public virtual Response SpreadCompositeRequestOnlyWithBody(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Model.SpreadCompositeRequestOnlyWithBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadCompositeRequestOnlyWithBodyRequest(content, context);
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
        /// [Protocol Method] Spread composite request without body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="testHeader"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadCompositeRequestWithoutBodyAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> SpreadCompositeRequestWithoutBodyAsync(string name, string testHeader, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));

            using var scope = ClientDiagnostics.CreateScope("Model.SpreadCompositeRequestWithoutBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadCompositeRequestWithoutBodyRequest(name, testHeader, context);
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
        /// [Protocol Method] Spread composite request without body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="testHeader"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadCompositeRequestWithoutBody(string,string,RequestContext)']/*" />
        public virtual Response SpreadCompositeRequestWithoutBody(string name, string testHeader, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));

            using var scope = ClientDiagnostics.CreateScope("Model.SpreadCompositeRequestWithoutBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadCompositeRequestWithoutBodyRequest(name, testHeader, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Spread composite request. </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="body"> The <see cref="BodyParameter"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="testHeader"/> or <paramref name="body"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadCompositeRequestAsync(string,string,BodyParameter,CancellationToken)']/*" />
        public virtual async Task<Response> SpreadCompositeRequestAsync(string name, string testHeader, BodyParameter body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await SpreadCompositeRequestAsync(name, testHeader, content, context).ConfigureAwait(false);
            return response;
        }

        /// <summary> Spread composite request. </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="body"> The <see cref="BodyParameter"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="testHeader"/> or <paramref name="body"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadCompositeRequest(string,string,BodyParameter,CancellationToken)']/*" />
        public virtual Response SpreadCompositeRequest(string name, string testHeader, BodyParameter body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = SpreadCompositeRequest(name, testHeader, content, context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Spread composite request.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadCompositeRequestAsync(string,string,BodyParameter,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="testHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadCompositeRequestAsync(string,string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> SpreadCompositeRequestAsync(string name, string testHeader, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Model.SpreadCompositeRequest");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadCompositeRequestRequest(name, testHeader, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Spread composite request.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadCompositeRequest(string,string,BodyParameter,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="testHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadCompositeRequest(string,string,RequestContent,RequestContext)']/*" />
        public virtual Response SpreadCompositeRequest(string name, string testHeader, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Model.SpreadCompositeRequest");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadCompositeRequestRequest(name, testHeader, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Spread composite request mix. </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="prop"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="testHeader"/> or <paramref name="prop"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadCompositeRequestMixAsync(string,string,string,CancellationToken)']/*" />
        public virtual async Task<Response> SpreadCompositeRequestMixAsync(string name, string testHeader, string prop, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));
            Argument.AssertNotNull(prop, nameof(prop));

            SpreadCompositeRequestMixRequest spreadCompositeRequestMixRequest = new SpreadCompositeRequestMixRequest(prop, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await SpreadCompositeRequestMixAsync(name, testHeader, spreadCompositeRequestMixRequest.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <summary> Spread composite request mix. </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="prop"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="testHeader"/> or <paramref name="prop"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadCompositeRequestMix(string,string,string,CancellationToken)']/*" />
        public virtual Response SpreadCompositeRequestMix(string name, string testHeader, string prop, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));
            Argument.AssertNotNull(prop, nameof(prop));

            SpreadCompositeRequestMixRequest spreadCompositeRequestMixRequest = new SpreadCompositeRequestMixRequest(prop, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = SpreadCompositeRequestMix(name, testHeader, spreadCompositeRequestMixRequest.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Spread composite request mix.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadCompositeRequestMixAsync(string,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="testHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadCompositeRequestMixAsync(string,string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> SpreadCompositeRequestMixAsync(string name, string testHeader, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Model.SpreadCompositeRequestMix");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadCompositeRequestMixRequest(name, testHeader, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Spread composite request mix.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadCompositeRequestMix(string,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="testHeader"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="testHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Model.xml" path="doc/members/member[@name='SpreadCompositeRequestMix(string,string,RequestContent,RequestContext)']/*" />
        public virtual Response SpreadCompositeRequestMix(string name, string testHeader, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(testHeader, nameof(testHeader));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Model.SpreadCompositeRequestMix");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadCompositeRequestMixRequest(name, testHeader, content, context);
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
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateSpreadCompositeRequestOnlyWithBodyRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/spread/model/composite-request-only-with-body", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateSpreadCompositeRequestWithoutBodyRequest(string name, string testHeader, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/spread/model/composite-request-without-body/", false);
            uri.AppendPath(name, true);
            request.Uri = uri;
            request.Headers.Add("test-header", testHeader);
            return message;
        }

        internal HttpMessage CreateSpreadCompositeRequestRequest(string name, string testHeader, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/spread/model/composite-request/", false);
            uri.AppendPath(name, true);
            request.Uri = uri;
            request.Headers.Add("test-header", testHeader);
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateSpreadCompositeRequestMixRequest(string name, string testHeader, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/spread/model/composite-request-mix/", false);
            uri.AppendPath(name, true);
            request.Uri = uri;
            request.Headers.Add("test-header", testHeader);
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
