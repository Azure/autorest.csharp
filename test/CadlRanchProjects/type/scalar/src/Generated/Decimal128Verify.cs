// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace _Type.Scalar
{
    // Data plane generated sub-client.
    /// <summary> Decimal128 type verification. </summary>
    public partial class Decimal128Verify
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Decimal128Verify for mocking. </summary>
        protected Decimal128Verify()
        {
        }

        /// <summary> Initializes a new instance of Decimal128Verify. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        internal Decimal128Verify(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
        }

        /// <summary> The PrepareVerify method. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/Decimal128Verify.xml" path="doc/members/member[@name='PrepareVerifyAsync(CancellationToken)']/*" />
        public virtual async Task<Response<IReadOnlyList<decimal>>> PrepareVerifyAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await PrepareVerifyAsync(context).ConfigureAwait(false);
            IReadOnlyList<decimal> value = default;
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            List<decimal> array = new List<decimal>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(item.GetDecimal());
            }
            value = array;
            return Response.FromValue(value, response);
        }

        /// <summary> The PrepareVerify method. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/Decimal128Verify.xml" path="doc/members/member[@name='PrepareVerify(CancellationToken)']/*" />
        public virtual Response<IReadOnlyList<decimal>> PrepareVerify(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = PrepareVerify(context);
            IReadOnlyList<decimal> value = default;
            using var document = JsonDocument.Parse(response.ContentStream);
            List<decimal> array = new List<decimal>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(item.GetDecimal());
            }
            value = array;
            return Response.FromValue(value, response);
        }

        /// <summary>
        /// [Protocol Method] The PrepareVerify method
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="PrepareVerifyAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Decimal128Verify.xml" path="doc/members/member[@name='PrepareVerifyAsync(RequestContext)']/*" />
        public virtual async Task<Response> PrepareVerifyAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("Decimal128Verify.PrepareVerify");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePrepareVerifyRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] The PrepareVerify method
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="PrepareVerify(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Decimal128Verify.xml" path="doc/members/member[@name='PrepareVerify(RequestContext)']/*" />
        public virtual Response PrepareVerify(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("Decimal128Verify.PrepareVerify");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePrepareVerifyRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The Verify method. </summary>
        /// <param name="body"> The <see cref="decimal"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/Decimal128Verify.xml" path="doc/members/member[@name='VerifyAsync(decimal,CancellationToken)']/*" />
        public virtual async Task<Response> VerifyAsync(decimal body, CancellationToken cancellationToken = default)
        {
            using RequestContent content = RequestContentHelper.FromObject(body);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await VerifyAsync(content, context).ConfigureAwait(false);
            return response;
        }

        /// <summary> The Verify method. </summary>
        /// <param name="body"> The <see cref="decimal"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/Decimal128Verify.xml" path="doc/members/member[@name='Verify(decimal,CancellationToken)']/*" />
        public virtual Response Verify(decimal body, CancellationToken cancellationToken = default)
        {
            using RequestContent content = RequestContentHelper.FromObject(body);
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Verify(content, context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] The Verify method
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="VerifyAsync(decimal,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Decimal128Verify.xml" path="doc/members/member[@name='VerifyAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> VerifyAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Decimal128Verify.Verify");
            scope.Start();
            try
            {
                using HttpMessage message = CreateVerifyRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] The Verify method
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Verify(decimal,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Decimal128Verify.xml" path="doc/members/member[@name='Verify(RequestContent,RequestContext)']/*" />
        public virtual Response Verify(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Decimal128Verify.Verify");
            scope.Start();
            try
            {
                using HttpMessage message = CreateVerifyRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreatePrepareVerifyRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/scalar/decimal128/prepare_verify", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateVerifyRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/scalar/decimal128/verify", false);
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
        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
