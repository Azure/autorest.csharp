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
using _Type.Union.Models;

namespace _Type.Union
{
    // Data plane generated sub-client.
    /// <summary> Describe union of a string and an array of strings. </summary>
    public partial class StringAndArray
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of StringAndArray for mocking. </summary>
        protected StringAndArray()
        {
        }

        /// <summary> Initializes a new instance of StringAndArray. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        internal StringAndArray(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
        }

        /// <summary> Get. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/StringAndArray.xml" path="doc/members/member[@name='GetStringAndArrayAsync(CancellationToken)']/*" />
        public virtual async Task<Response<GetResponse2>> GetStringAndArrayAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetStringAndArrayAsync(context).ConfigureAwait(false);
            return Response.FromValue(GetResponse2.FromResponse(response), response);
        }

        /// <summary> Get. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/StringAndArray.xml" path="doc/members/member[@name='GetStringAndArray(CancellationToken)']/*" />
        public virtual Response<GetResponse2> GetStringAndArray(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetStringAndArray(context);
            return Response.FromValue(GetResponse2.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Get.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetStringAndArrayAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/StringAndArray.xml" path="doc/members/member[@name='GetStringAndArrayAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetStringAndArrayAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("StringAndArray.GetStringAndArray");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetStringAndArrayRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetStringAndArray(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/StringAndArray.xml" path="doc/members/member[@name='GetStringAndArray(RequestContext)']/*" />
        public virtual Response GetStringAndArray(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("StringAndArray.GetStringAndArray");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetStringAndArrayRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send. </summary>
        /// <param name="prop"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="prop"/> is null. </exception>
        /// <include file="Docs/StringAndArray.xml" path="doc/members/member[@name='SendAsync(StringAndArrayCases,CancellationToken)']/*" />
        public virtual async Task<Response> SendAsync(StringAndArrayCases prop, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(prop, nameof(prop));

            SendRequest2 sendRequest2 = new SendRequest2(prop, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await SendAsync(sendRequest2.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <summary> Send. </summary>
        /// <param name="prop"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="prop"/> is null. </exception>
        /// <include file="Docs/StringAndArray.xml" path="doc/members/member[@name='Send(StringAndArrayCases,CancellationToken)']/*" />
        public virtual Response Send(StringAndArrayCases prop, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(prop, nameof(prop));

            SendRequest2 sendRequest2 = new SendRequest2(prop, null);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Send(sendRequest2.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Send.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SendAsync(StringAndArrayCases,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/StringAndArray.xml" path="doc/members/member[@name='SendAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> SendAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("StringAndArray.Send");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Send(StringAndArrayCases,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/StringAndArray.xml" path="doc/members/member[@name='Send(RequestContent,RequestContext)']/*" />
        public virtual Response Send(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("StringAndArray.Send");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetStringAndArrayRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/union/string-and-array", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateSendRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/union/string-and-array", false);
            request.Uri = uri;
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
        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
