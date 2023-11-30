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
using _Specs_.Azure.ClientGenerator.Core.Usage.Models;

namespace _Specs_.Azure.ClientGenerator.Core.Usage
{
    // Data plane generated client.
    /// <summary> The Usage service client. </summary>
    public partial class UsageClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of UsageClient. </summary>
        public UsageClient() : this(new Uri("http://localhost:3000"), new UsageClientOptions())
        {
        }

        /// <summary> Initializes a new instance of UsageClient. </summary>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public UsageClient(Uri endpoint, UsageClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new UsageClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary>
        /// Expected body parameter:
        /// ```json
        /// {
        ///   "name": &lt;any string&gt;
        /// }
        /// ```
        /// </summary>
        /// <param name="body"> The <see cref="InputModel"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/UsageClient.xml" path="doc/members/member[@name='InputToInputOutputAsync(InputModel,CancellationToken)']/*" />
        public virtual async Task<Response> InputToInputOutputAsync(InputModel body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = body.ToRequestContent();
            Response response = await InputToInputOutputAsync(content, context).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Expected body parameter:
        /// ```json
        /// {
        ///   "name": &lt;any string&gt;
        /// }
        /// ```
        /// </summary>
        /// <param name="body"> The <see cref="InputModel"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/UsageClient.xml" path="doc/members/member[@name='InputToInputOutput(InputModel,CancellationToken)']/*" />
        public virtual Response InputToInputOutput(InputModel body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = body.ToRequestContent();
            Response response = InputToInputOutput(content, context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Expected body parameter:
        /// ```json
        /// {
        ///   "name": &lt;any string&gt;
        /// }
        /// ```
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="InputToInputOutputAsync(InputModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/UsageClient.xml" path="doc/members/member[@name='InputToInputOutputAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> InputToInputOutputAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("UsageClient.InputToInputOutput");
            scope.Start();
            try
            {
                using HttpMessage message = CreateInputToInputOutputRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Expected body parameter:
        /// ```json
        /// {
        ///   "name": &lt;any string&gt;
        /// }
        /// ```
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="InputToInputOutput(InputModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/UsageClient.xml" path="doc/members/member[@name='InputToInputOutput(RequestContent,RequestContext)']/*" />
        public virtual Response InputToInputOutput(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("UsageClient.InputToInputOutput");
            scope.Start();
            try
            {
                using HttpMessage message = CreateInputToInputOutputRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Expected response body:
        /// ```json
        /// {
        ///   "name": &lt;any string&gt;
        /// }
        /// ```
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/UsageClient.xml" path="doc/members/member[@name='OutputToInputOutputAsync(CancellationToken)']/*" />
        public virtual async Task<Response<OutputModel>> OutputToInputOutputAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await OutputToInputOutputAsync(context).ConfigureAwait(false);
            return Response.FromValue(OutputModel.FromResponse(response), response);
        }

        /// <summary>
        /// Expected response body:
        /// ```json
        /// {
        ///   "name": &lt;any string&gt;
        /// }
        /// ```
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/UsageClient.xml" path="doc/members/member[@name='OutputToInputOutput(CancellationToken)']/*" />
        public virtual Response<OutputModel> OutputToInputOutput(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = OutputToInputOutput(context);
            return Response.FromValue(OutputModel.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Expected response body:
        /// ```json
        /// {
        ///   "name": &lt;any string&gt;
        /// }
        /// ```
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="OutputToInputOutputAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/UsageClient.xml" path="doc/members/member[@name='OutputToInputOutputAsync(RequestContext)']/*" />
        public virtual async Task<Response> OutputToInputOutputAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("UsageClient.OutputToInputOutput");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOutputToInputOutputRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Expected response body:
        /// ```json
        /// {
        ///   "name": &lt;any string&gt;
        /// }
        /// ```
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="OutputToInputOutput(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/UsageClient.xml" path="doc/members/member[@name='OutputToInputOutput(RequestContext)']/*" />
        public virtual Response OutputToInputOutput(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("UsageClient.OutputToInputOutput");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOutputToInputOutputRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateInputToInputOutputRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/client-generator-core/usage/inputToInputOutput", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateOutputToInputOutputRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/client-generator-core/usage/outputToInputOutput", false);
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

        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
