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
using Payload.MultiPart.Models;

namespace Payload.MultiPart
{
    // Data plane generated sub-client.
    /// <summary> The FormDataHttpPartsNonString sub-client. </summary>
    public partial class FormDataHttpPartsNonString
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of FormDataHttpPartsNonString for mocking. </summary>
        protected FormDataHttpPartsNonString()
        {
        }

        /// <summary> Initializes a new instance of FormDataHttpPartsNonString. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> Service host. </param>
        internal FormDataHttpPartsNonString(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
        }

        /// <summary> Test content-type: multipart/form-data for non string. </summary>
        /// <param name="body"> The <see cref="FloatRequest"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/FormDataHttpPartsNonString.xml" path="doc/members/member[@name='FloatAsync(FloatRequest,CancellationToken)']/*" />
        public virtual async Task<Response> FloatAsync(FloatRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using MultipartFormDataRequestContent content = body.ToMultipartRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await FloatAsync(content, content.ContentType, context).ConfigureAwait(false);
            return response;
        }

        /// <summary> Test content-type: multipart/form-data for non string. </summary>
        /// <param name="body"> The <see cref="FloatRequest"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/FormDataHttpPartsNonString.xml" path="doc/members/member[@name='Float(FloatRequest,CancellationToken)']/*" />
        public virtual Response Float(FloatRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using MultipartFormDataRequestContent content = body.ToMultipartRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Float(content, content.ContentType, context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Test content-type: multipart/form-data for non string
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="FloatAsync(FloatRequest,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> The <see cref="string"/> to use. Allowed values: "multipart/form-data". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FormDataHttpPartsNonString.xml" path="doc/members/member[@name='FloatAsync(RequestContent,string,RequestContext)']/*" />
        public virtual async Task<Response> FloatAsync(RequestContent content, string contentType, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("FormDataHttpPartsNonString.Float");
            scope.Start();
            try
            {
                using HttpMessage message = CreateFloatRequest(content, contentType, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Test content-type: multipart/form-data for non string
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Float(FloatRequest,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> The <see cref="string"/> to use. Allowed values: "multipart/form-data". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FormDataHttpPartsNonString.xml" path="doc/members/member[@name='Float(RequestContent,string,RequestContext)']/*" />
        public virtual Response Float(RequestContent content, string contentType, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("FormDataHttpPartsNonString.Float");
            scope.Start();
            try
            {
                using HttpMessage message = CreateFloatRequest(content, contentType, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateFloatRequest(RequestContent content, string contentType, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/multipart/form-data/non-string-float", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", contentType);
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
