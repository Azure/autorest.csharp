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

namespace Payload.ContentNegotiation
{
    // Data plane generated sub-client.
    /// <summary> The SameBody sub-client. </summary>
    public partial class SameBody
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of SameBody for mocking. </summary>
        protected SameBody()
        {
        }

        /// <summary> Initializes a new instance of SameBody. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        internal SameBody(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
        }

        /// <summary> Get avatar as png. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/SameBody.xml" path="doc/members/member[@name='GetAvatarAsPngAsync(CancellationToken)']/*" />
        public virtual async Task<Response<BinaryData>> GetAvatarAsPngAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetAvatarAsPngAsync(context).ConfigureAwait(false);
            return Response.FromValue(response.Content, response);
        }

        /// <summary> Get avatar as png. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/SameBody.xml" path="doc/members/member[@name='GetAvatarAsPng(CancellationToken)']/*" />
        public virtual Response<BinaryData> GetAvatarAsPng(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetAvatarAsPng(context);
            return Response.FromValue(response.Content, response);
        }

        /// <summary>
        /// [Protocol Method] Get avatar as png.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetAvatarAsPngAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/SameBody.xml" path="doc/members/member[@name='GetAvatarAsPngAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetAvatarAsPngAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("SameBody.GetAvatarAsPng");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAvatarAsPngRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get avatar as png.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetAvatarAsPng(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/SameBody.xml" path="doc/members/member[@name='GetAvatarAsPng(RequestContext)']/*" />
        public virtual Response GetAvatarAsPng(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("SameBody.GetAvatarAsPng");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAvatarAsPngRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get avatar as jpeg. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/SameBody.xml" path="doc/members/member[@name='GetAvatarAsJpegAsync(CancellationToken)']/*" />
        public virtual async Task<Response<BinaryData>> GetAvatarAsJpegAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetAvatarAsJpegAsync(context).ConfigureAwait(false);
            return Response.FromValue(response.Content, response);
        }

        /// <summary> Get avatar as jpeg. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/SameBody.xml" path="doc/members/member[@name='GetAvatarAsJpeg(CancellationToken)']/*" />
        public virtual Response<BinaryData> GetAvatarAsJpeg(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetAvatarAsJpeg(context);
            return Response.FromValue(response.Content, response);
        }

        /// <summary>
        /// [Protocol Method] Get avatar as jpeg.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetAvatarAsJpegAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/SameBody.xml" path="doc/members/member[@name='GetAvatarAsJpegAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetAvatarAsJpegAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("SameBody.GetAvatarAsJpeg");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAvatarAsJpegRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get avatar as jpeg.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetAvatarAsJpeg(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/SameBody.xml" path="doc/members/member[@name='GetAvatarAsJpeg(RequestContext)']/*" />
        public virtual Response GetAvatarAsJpeg(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("SameBody.GetAvatarAsJpeg");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAvatarAsJpegRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetAvatarAsPngRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/content-negotiation/same-body", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "image/png");
            return message;
        }

        internal HttpMessage CreateGetAvatarAsJpegRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/content-negotiation/same-body", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "image/jpeg");
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
