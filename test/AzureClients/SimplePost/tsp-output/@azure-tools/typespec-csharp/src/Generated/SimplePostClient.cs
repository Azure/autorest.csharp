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

namespace SimplePost
{
    // Data plane generated client.
    /// <summary> The SimplePost service client. </summary>
    public partial class SimplePostClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of SimplePostClient for mocking. </summary>
        protected SimplePostClient()
        {
        }

        /// <summary> Initializes a new instance of SimplePostClient. </summary>
        /// <param name="endpoint"> Service host. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public SimplePostClient(Uri endpoint) : this(endpoint, new SimplePostClientOptions())
        {
        }

        /// <summary> Initializes a new instance of SimplePostClient. </summary>
        /// <param name="endpoint"> Service host. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public SimplePostClient(Uri endpoint, SimplePostClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new SimplePostClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary> Create. </summary>
        /// <param name="content"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="content"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/SimplePostClient.xml" path="doc/members/member[@name='CreateAsync(string,CancellationToken)']/*" />
        public virtual async Task<Response<string>> CreateAsync(string content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(content, nameof(content));

            using RequestContent content0 = RequestContentHelper.FromObject(content);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await CreateAsync(content0, context).ConfigureAwait(false);
            return Response.FromValue(response.Content.ToObjectFromJson<string>(), response);
        }

        /// <summary> Create. </summary>
        /// <param name="content"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="content"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/SimplePostClient.xml" path="doc/members/member[@name='Create(string,CancellationToken)']/*" />
        public virtual Response<string> Create(string content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(content, nameof(content));

            using RequestContent content0 = RequestContentHelper.FromObject(content);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Create(content0, context);
            return Response.FromValue(response.Content.ToObjectFromJson<string>(), response);
        }

        /// <summary>
        /// [Protocol Method] Create.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/SimplePostClient.xml" path="doc/members/member[@name='CreateAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> CreateAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("SimplePostClient.Create");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Create.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Create(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/SimplePostClient.xml" path="doc/members/member[@name='Create(RequestContent,RequestContext)']/*" />
        public virtual Response Create(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("SimplePostClient.Create");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateCreateRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
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
