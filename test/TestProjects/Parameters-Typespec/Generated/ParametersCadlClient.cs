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
using ParametersCadl.Models;

namespace ParametersCadl
{
    // Data plane generated client.
    /// <summary> The ParametersCadl service client. </summary>
    public partial class ParametersCadlClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ParametersCadlClient. </summary>
        public ParametersCadlClient() : this(new ParametersCadlClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ParametersCadlClient. </summary>
        /// <param name="options"> The options for configuring the client. </param>
        public ParametersCadlClient(ParametersCadlClientOptions options)
        {
            options ??= new ParametersCadlClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _apiVersion = options.Version;
        }

        /// <param name="start"> The Int32 to use. </param>
        /// <param name="end"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Result>> OperationAsync(int start, int? end = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await OperationAsync(start, end, context).ConfigureAwait(false);
            return Response.FromValue(Result.FromResponse(response), response);
        }

        /// <param name="start"> The Int32 to use. </param>
        /// <param name="end"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Result> Operation(int start, int? end = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Operation(start, end, context);
            return Response.FromValue(Result.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Operation(int,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="start"> The Int32 to use. </param>
        /// <param name="end"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/ParametersCadlClient.xml" path="doc/members/member[@name='OperationAsync(int,int?,global::Azure.RequestContext)']/*" />
        public virtual async Task<Response> OperationAsync(int start, int? end, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ParametersCadlClient.Operation");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOperationRequest(start, end, context);
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
        /// Please try the simpler <see cref="Operation(int,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="start"> The Int32 to use. </param>
        /// <param name="end"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/ParametersCadlClient.xml" path="doc/members/member[@name='Operation(int,int?,global::Azure.RequestContext)']/*" />
        public virtual Response Operation(int start, int? end, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ParametersCadlClient.Operation");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOperationRequest(start, end, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="end"> The Int32 to use. </param>
        /// <param name="start"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Result>> Operation2Async(int end, int? start = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await Operation2Async(end, start, context).ConfigureAwait(false);
            return Response.FromValue(Result.FromResponse(response), response);
        }

        /// <param name="end"> The Int32 to use. </param>
        /// <param name="start"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Result> Operation2(int end, int? start = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Operation2(end, start, context);
            return Response.FromValue(Result.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Operation2(int,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="end"> The Int32 to use. </param>
        /// <param name="start"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/ParametersCadlClient.xml" path="doc/members/member[@name='Operation2Async(int,int?,global::Azure.RequestContext)']/*" />
        public virtual async Task<Response> Operation2Async(int end, int? start, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ParametersCadlClient.Operation2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOperation2Request(end, start, context);
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
        /// Please try the simpler <see cref="Operation2(int,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="end"> The Int32 to use. </param>
        /// <param name="start"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/ParametersCadlClient.xml" path="doc/members/member[@name='Operation2(int,int?,global::Azure.RequestContext)']/*" />
        public virtual Response Operation2(int end, int? start, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ParametersCadlClient.Operation2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOperation2Request(end, start, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateOperationRequest(int start, int? end, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/parameterOrders", false);
            uri.AppendQuery("start", start, true);
            if (end != null)
            {
                uri.AppendQuery("end", end.Value, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateOperation2Request(int end, int? start, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.AppendPath("/parameterOrders", false);
            uri.AppendQuery("end", end, true);
            if (start != null)
            {
                uri.AppendQuery("start", start.Value, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
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
