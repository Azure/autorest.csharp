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
using Client.Naming.Models;

namespace Client.Naming
{
    // Data plane generated sub-client.
    /// <summary> The UnionEnum sub-client. </summary>
    public partial class UnionEnum
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of UnionEnum for mocking. </summary>
        protected UnionEnum()
        {
        }

        /// <summary> Initializes a new instance of UnionEnum. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        internal UnionEnum(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
        }

        /// <param name="body"> The <see cref="ClientExtensibleEnum"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/UnionEnum.xml" path="doc/members/member[@name='UnionEnumNameAsync(ClientExtensibleEnum,CancellationToken)']/*" />
        public virtual async Task<Response> UnionEnumNameAsync(ClientExtensibleEnum body, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = BinaryData.FromObjectAsJson(body.ToString());
            Response response = await UnionEnumNameAsync(content, context).ConfigureAwait(false);
            return response;
        }

        /// <param name="body"> The <see cref="ClientExtensibleEnum"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/UnionEnum.xml" path="doc/members/member[@name='UnionEnumName(ClientExtensibleEnum,CancellationToken)']/*" />
        public virtual Response UnionEnumName(ClientExtensibleEnum body, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = BinaryData.FromObjectAsJson(body.ToString());
            Response response = UnionEnumName(content, context);
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
        /// Please try the simpler <see cref="UnionEnumNameAsync(ClientExtensibleEnum,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/UnionEnum.xml" path="doc/members/member[@name='UnionEnumNameAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> UnionEnumNameAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("UnionEnum.UnionEnumName");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUnionEnumNameRequest(content, context);
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
        /// Please try the simpler <see cref="UnionEnumName(ClientExtensibleEnum,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/UnionEnum.xml" path="doc/members/member[@name='UnionEnumName(RequestContent,RequestContext)']/*" />
        public virtual Response UnionEnumName(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("UnionEnum.UnionEnumName");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUnionEnumNameRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="body"> The <see cref="ExtensibleEnum"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/UnionEnum.xml" path="doc/members/member[@name='UnionEnumMemberNameAsync(ExtensibleEnum,CancellationToken)']/*" />
        public virtual async Task<Response> UnionEnumMemberNameAsync(ExtensibleEnum body, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = BinaryData.FromObjectAsJson(body.ToString());
            Response response = await UnionEnumMemberNameAsync(content, context).ConfigureAwait(false);
            return response;
        }

        /// <param name="body"> The <see cref="ExtensibleEnum"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/UnionEnum.xml" path="doc/members/member[@name='UnionEnumMemberName(ExtensibleEnum,CancellationToken)']/*" />
        public virtual Response UnionEnumMemberName(ExtensibleEnum body, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = BinaryData.FromObjectAsJson(body.ToString());
            Response response = UnionEnumMemberName(content, context);
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
        /// Please try the simpler <see cref="UnionEnumMemberNameAsync(ExtensibleEnum,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/UnionEnum.xml" path="doc/members/member[@name='UnionEnumMemberNameAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> UnionEnumMemberNameAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("UnionEnum.UnionEnumMemberName");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUnionEnumMemberNameRequest(content, context);
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
        /// Please try the simpler <see cref="UnionEnumMemberName(ExtensibleEnum,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/UnionEnum.xml" path="doc/members/member[@name='UnionEnumMemberName(RequestContent,RequestContext)']/*" />
        public virtual Response UnionEnumMemberName(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("UnionEnum.UnionEnumMemberName");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUnionEnumMemberNameRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateUnionEnumNameRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/client/naming/union-enum/union-enum-name", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateUnionEnumMemberNameRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/client/naming/union-enum/union-enum-member-name", false);
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
