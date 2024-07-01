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
using _Specs_.Azure.Core.Traits.Models;

namespace _Specs_.Azure.Core.Traits
{
    // Data plane generated client.
    /// <summary> Illustrates Azure Core operation customizations by traits. </summary>
    public partial class TraitsClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of TraitsClient. </summary>
        public TraitsClient() : this(new Uri("http://localhost:3000"), new TraitsClientOptions())
        {
        }

        /// <summary> Initializes a new instance of TraitsClient. </summary>
        /// <param name="endpoint"> Service host. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public TraitsClient(Uri endpoint, TraitsClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new TraitsClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Get a resource, sending and receiving headers. </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="foo"> header in request. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="foo"/> is null. </exception>
        /// <include file="Docs/TraitsClient.xml" path="doc/members/member[@name='SmokeTestAsync(int,string,RequestConditions,CancellationToken)']/*" />
        public virtual async Task<Response<User>> SmokeTestAsync(int id, string foo, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(foo, nameof(foo));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await SmokeTestAsync(id, foo, requestConditions, context).ConfigureAwait(false);
            return Response.FromValue(User.FromResponse(response), response);
        }

        /// <summary> Get a resource, sending and receiving headers. </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="foo"> header in request. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="foo"/> is null. </exception>
        /// <include file="Docs/TraitsClient.xml" path="doc/members/member[@name='SmokeTest(int,string,RequestConditions,CancellationToken)']/*" />
        public virtual Response<User> SmokeTest(int id, string foo, RequestConditions requestConditions = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(foo, nameof(foo));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = SmokeTest(id, foo, requestConditions, context);
            return Response.FromValue(User.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Get a resource, sending and receiving headers.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SmokeTestAsync(int,string,RequestConditions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="foo"> header in request. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="foo"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/TraitsClient.xml" path="doc/members/member[@name='SmokeTestAsync(int,string,RequestConditions,RequestContext)']/*" />
        public virtual async Task<Response> SmokeTestAsync(int id, string foo, RequestConditions requestConditions, RequestContext context)
        {
            Argument.AssertNotNull(foo, nameof(foo));

            using var scope = ClientDiagnostics.CreateScope("TraitsClient.SmokeTest");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSmokeTestRequest(id, foo, requestConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get a resource, sending and receiving headers.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SmokeTest(int,string,RequestConditions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="foo"> header in request. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="foo"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/TraitsClient.xml" path="doc/members/member[@name='SmokeTest(int,string,RequestConditions,RequestContext)']/*" />
        public virtual Response SmokeTest(int id, string foo, RequestConditions requestConditions, RequestContext context)
        {
            Argument.AssertNotNull(foo, nameof(foo));

            using var scope = ClientDiagnostics.CreateScope("TraitsClient.SmokeTest");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSmokeTestRequest(id, foo, requestConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test for repeatable requests. </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="userActionParam"> The <see cref="UserActionParam"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userActionParam"/> is null. </exception>
        /// <include file="Docs/TraitsClient.xml" path="doc/members/member[@name='RepeatableActionAsync(int,UserActionParam,CancellationToken)']/*" />
        public virtual async Task<Response<UserActionResponse>> RepeatableActionAsync(int id, UserActionParam userActionParam, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(userActionParam, nameof(userActionParam));

            using RequestContent content = userActionParam.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await RepeatableActionAsync(id, content, context).ConfigureAwait(false);
            return Response.FromValue(UserActionResponse.FromResponse(response), response);
        }

        /// <summary> Test for repeatable requests. </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="userActionParam"> The <see cref="UserActionParam"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userActionParam"/> is null. </exception>
        /// <include file="Docs/TraitsClient.xml" path="doc/members/member[@name='RepeatableAction(int,UserActionParam,CancellationToken)']/*" />
        public virtual Response<UserActionResponse> RepeatableAction(int id, UserActionParam userActionParam, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(userActionParam, nameof(userActionParam));

            using RequestContent content = userActionParam.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = RepeatableAction(id, content, context);
            return Response.FromValue(UserActionResponse.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Test for repeatable requests
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RepeatableActionAsync(int,UserActionParam,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/TraitsClient.xml" path="doc/members/member[@name='RepeatableActionAsync(int,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> RepeatableActionAsync(int id, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TraitsClient.RepeatableAction");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRepeatableActionRequest(id, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Test for repeatable requests
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RepeatableAction(int,UserActionParam,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/TraitsClient.xml" path="doc/members/member[@name='RepeatableAction(int,RequestContent,RequestContext)']/*" />
        public virtual Response RepeatableAction(int id, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TraitsClient.RepeatableAction");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRepeatableActionRequest(id, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateSmokeTestRequest(int id, string foo, RequestConditions requestConditions, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/core/traits/user/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("foo", foo);
            request.Headers.Add("Accept", "application/json");
            if (requestConditions != null)
            {
                request.Headers.Add(requestConditions, "R");
            }
            return message;
        }

        internal HttpMessage CreateRepeatableActionRequest(int id, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/core/traits/user/", false);
            uri.AppendPath(id, true);
            uri.AppendPath(":repeatableAction", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Repeatability-Request-ID", Guid.NewGuid());
            request.Headers.Add("Repeatability-First-Sent", DateTimeOffset.Now, "R");
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
