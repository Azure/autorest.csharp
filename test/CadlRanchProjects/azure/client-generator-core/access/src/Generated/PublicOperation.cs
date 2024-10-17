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
using _Specs_.Azure.ClientGenerator.Core.Access.Models;

namespace _Specs_.Azure.ClientGenerator.Core.Access
{
    // Data plane generated sub-client.
    /// <summary> The PublicOperation sub-client. </summary>
    public partial class PublicOperation
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of PublicOperation for mocking. </summary>
        protected PublicOperation()
        {
        }

        /// <summary> Initializes a new instance of PublicOperation. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> Service host. </param>
        internal PublicOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
        }

        /// <summary> No decorator in public. </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <include file="Docs/PublicOperation.xml" path="doc/members/member[@name='NoDecoratorInPublicAsync(string,CancellationToken)']/*" />
        public virtual async Task<Response<NoDecoratorModelInPublic>> NoDecoratorInPublicAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(name, nameof(name));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await NoDecoratorInPublicAsync(name, context).ConfigureAwait(false);
            return Response.FromValue(NoDecoratorModelInPublic.FromResponse(response), response);
        }

        /// <summary> No decorator in public. </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <include file="Docs/PublicOperation.xml" path="doc/members/member[@name='NoDecoratorInPublic(string,CancellationToken)']/*" />
        public virtual Response<NoDecoratorModelInPublic> NoDecoratorInPublic(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(name, nameof(name));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = NoDecoratorInPublic(name, context);
            return Response.FromValue(NoDecoratorModelInPublic.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] No decorator in public.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="NoDecoratorInPublicAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PublicOperation.xml" path="doc/members/member[@name='NoDecoratorInPublicAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> NoDecoratorInPublicAsync(string name, RequestContext context)
        {
            Argument.AssertNotNull(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("PublicOperation.NoDecoratorInPublic");
            scope.Start();
            try
            {
                using HttpMessage message = CreateNoDecoratorInPublicRequest(name, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] No decorator in public.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="NoDecoratorInPublic(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PublicOperation.xml" path="doc/members/member[@name='NoDecoratorInPublic(string,RequestContext)']/*" />
        public virtual Response NoDecoratorInPublic(string name, RequestContext context)
        {
            Argument.AssertNotNull(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("PublicOperation.NoDecoratorInPublic");
            scope.Start();
            try
            {
                using HttpMessage message = CreateNoDecoratorInPublicRequest(name, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Public decorator in public. </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <include file="Docs/PublicOperation.xml" path="doc/members/member[@name='PublicDecoratorInPublicAsync(string,CancellationToken)']/*" />
        public virtual async Task<Response<PublicDecoratorModelInPublic>> PublicDecoratorInPublicAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(name, nameof(name));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await PublicDecoratorInPublicAsync(name, context).ConfigureAwait(false);
            return Response.FromValue(PublicDecoratorModelInPublic.FromResponse(response), response);
        }

        /// <summary> Public decorator in public. </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <include file="Docs/PublicOperation.xml" path="doc/members/member[@name='PublicDecoratorInPublic(string,CancellationToken)']/*" />
        public virtual Response<PublicDecoratorModelInPublic> PublicDecoratorInPublic(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(name, nameof(name));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = PublicDecoratorInPublic(name, context);
            return Response.FromValue(PublicDecoratorModelInPublic.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Public decorator in public.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="PublicDecoratorInPublicAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PublicOperation.xml" path="doc/members/member[@name='PublicDecoratorInPublicAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> PublicDecoratorInPublicAsync(string name, RequestContext context)
        {
            Argument.AssertNotNull(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("PublicOperation.PublicDecoratorInPublic");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePublicDecoratorInPublicRequest(name, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Public decorator in public.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="PublicDecoratorInPublic(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PublicOperation.xml" path="doc/members/member[@name='PublicDecoratorInPublic(string,RequestContext)']/*" />
        public virtual Response PublicDecoratorInPublic(string name, RequestContext context)
        {
            Argument.AssertNotNull(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("PublicOperation.PublicDecoratorInPublic");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePublicDecoratorInPublicRequest(name, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateNoDecoratorInPublicRequest(string name, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/client-generator-core/access/publicOperation/noDecoratorInPublic", false);
            uri.AppendQuery("name", name, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePublicDecoratorInPublicRequest(string name, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/client-generator-core/access/publicOperation/publicDecoratorInPublic", false);
            uri.AppendQuery("name", name, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
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
