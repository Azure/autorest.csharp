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
using _Type.Union.Models;

namespace _Type.Union
{
    // Data plane generated client.
    /// <summary> Test for type of union. </summary>
    public partial class UnionClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of UnionClient. </summary>
        public UnionClient() : this(new Uri("http://localhost:3000"), new UnionClientOptions())
        {
        }

        /// <summary> Initializes a new instance of UnionClient. </summary>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public UnionClient(Uri endpoint, UnionClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new UnionClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <param name="input"> The ModelWithSimpleUnionProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/UnionClient.xml" path="doc/members/member[@name='SendIntAsync(ModelWithSimpleUnionProperty,CancellationToken)']/*" />
        internal virtual async Task<Response> SendIntAsync(ModelWithSimpleUnionProperty input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await SendIntAsync(input.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <param name="input"> The ModelWithSimpleUnionProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/UnionClient.xml" path="doc/members/member[@name='SendInt(ModelWithSimpleUnionProperty,CancellationToken)']/*" />
        internal virtual Response SendInt(ModelWithSimpleUnionProperty input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = SendInt(input.ToRequestContent(), context);
            return response;
        }

        // The convenience method of this operation is made internal because this operation directly or indirectly uses a low confident type, for instance, unions, literal types with number values, etc.
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
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/UnionClient.xml" path="doc/members/member[@name='SendIntAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> SendIntAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("UnionClient.SendInt");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendIntRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method of this operation is made internal because this operation directly or indirectly uses a low confident type, for instance, unions, literal types with number values, etc.
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
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/UnionClient.xml" path="doc/members/member[@name='SendInt(RequestContent,RequestContext)']/*" />
        public virtual Response SendInt(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("UnionClient.SendInt");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendIntRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="input"> The ModelWithSimpleUnionProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/UnionClient.xml" path="doc/members/member[@name='SendIntArrayAsync(ModelWithSimpleUnionProperty,CancellationToken)']/*" />
        internal virtual async Task<Response> SendIntArrayAsync(ModelWithSimpleUnionProperty input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await SendIntArrayAsync(input.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <param name="input"> The ModelWithSimpleUnionProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/UnionClient.xml" path="doc/members/member[@name='SendIntArray(ModelWithSimpleUnionProperty,CancellationToken)']/*" />
        internal virtual Response SendIntArray(ModelWithSimpleUnionProperty input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = SendIntArray(input.ToRequestContent(), context);
            return response;
        }

        // The convenience method of this operation is made internal because this operation directly or indirectly uses a low confident type, for instance, unions, literal types with number values, etc.
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
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/UnionClient.xml" path="doc/members/member[@name='SendIntArrayAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> SendIntArrayAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("UnionClient.SendIntArray");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendIntArrayRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method of this operation is made internal because this operation directly or indirectly uses a low confident type, for instance, unions, literal types with number values, etc.
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
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/UnionClient.xml" path="doc/members/member[@name='SendIntArray(RequestContent,RequestContext)']/*" />
        public virtual Response SendIntArray(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("UnionClient.SendIntArray");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendIntArrayRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="input"> The ModelWithNamedUnionProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/UnionClient.xml" path="doc/members/member[@name='SendFirstNamedUnionValueAsync(ModelWithNamedUnionProperty,CancellationToken)']/*" />
        internal virtual async Task<Response> SendFirstNamedUnionValueAsync(ModelWithNamedUnionProperty input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await SendFirstNamedUnionValueAsync(input.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <param name="input"> The ModelWithNamedUnionProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/UnionClient.xml" path="doc/members/member[@name='SendFirstNamedUnionValue(ModelWithNamedUnionProperty,CancellationToken)']/*" />
        internal virtual Response SendFirstNamedUnionValue(ModelWithNamedUnionProperty input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = SendFirstNamedUnionValue(input.ToRequestContent(), context);
            return response;
        }

        // The convenience method of this operation is made internal because this operation directly or indirectly uses a low confident type, for instance, unions, literal types with number values, etc.
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
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/UnionClient.xml" path="doc/members/member[@name='SendFirstNamedUnionValueAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> SendFirstNamedUnionValueAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("UnionClient.SendFirstNamedUnionValue");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendFirstNamedUnionValueRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method of this operation is made internal because this operation directly or indirectly uses a low confident type, for instance, unions, literal types with number values, etc.
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
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/UnionClient.xml" path="doc/members/member[@name='SendFirstNamedUnionValue(RequestContent,RequestContext)']/*" />
        public virtual Response SendFirstNamedUnionValue(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("UnionClient.SendFirstNamedUnionValue");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendFirstNamedUnionValueRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="input"> The ModelWithNamedUnionProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/UnionClient.xml" path="doc/members/member[@name='SendSecondNamedUnionValueAsync(ModelWithNamedUnionProperty,CancellationToken)']/*" />
        internal virtual async Task<Response> SendSecondNamedUnionValueAsync(ModelWithNamedUnionProperty input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await SendSecondNamedUnionValueAsync(input.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <param name="input"> The ModelWithNamedUnionProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <include file="Docs/UnionClient.xml" path="doc/members/member[@name='SendSecondNamedUnionValue(ModelWithNamedUnionProperty,CancellationToken)']/*" />
        internal virtual Response SendSecondNamedUnionValue(ModelWithNamedUnionProperty input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = SendSecondNamedUnionValue(input.ToRequestContent(), context);
            return response;
        }

        // The convenience method of this operation is made internal because this operation directly or indirectly uses a low confident type, for instance, unions, literal types with number values, etc.
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
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/UnionClient.xml" path="doc/members/member[@name='SendSecondNamedUnionValueAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> SendSecondNamedUnionValueAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("UnionClient.SendSecondNamedUnionValue");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendSecondNamedUnionValueRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method of this operation is made internal because this operation directly or indirectly uses a low confident type, for instance, unions, literal types with number values, etc.
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
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/UnionClient.xml" path="doc/members/member[@name='SendSecondNamedUnionValue(RequestContent,RequestContext)']/*" />
        public virtual Response SendSecondNamedUnionValue(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("UnionClient.SendSecondNamedUnionValue");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendSecondNamedUnionValueRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateSendIntRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/union/int", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateSendIntArrayRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/union/int-array", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateSendFirstNamedUnionValueRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/union/model1", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateSendSecondNamedUnionValueRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/union/model2", false);
            uri.AppendQuery("api-version", _apiVersion, true);
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
