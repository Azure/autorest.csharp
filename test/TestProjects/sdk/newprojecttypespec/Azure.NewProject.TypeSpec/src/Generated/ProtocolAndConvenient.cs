// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.NewProject.TypeSpec.Models;

namespace Azure.NewProject.TypeSpec
{
    // Data plane generated sub-client.
    /// <summary> The ProtocolAndConvenient sub-client. </summary>
    public partial class ProtocolAndConvenient
    {
        private const string AuthorizationHeader = "x-ms-api-key";
        private readonly AzureKeyCredential _keyCredential;
        private static readonly string[] AuthorizationScopes = new string[] { "https://api.example.com/.default" };
        private readonly TokenCredential _tokenCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ProtocolAndConvenient for mocking. </summary>
        protected ProtocolAndConvenient()
        {
        }

        /// <summary> Initializes a new instance of ProtocolAndConvenient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        internal ProtocolAndConvenient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, TokenCredential tokenCredential, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
        }

        /// <summary> When set protocol false and convenient true, then the protocol method should be internal. </summary>
        /// <param name="body"> The <see cref="Thing"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <remarks> Internal protocol. </remarks>
        public virtual async Task<Response<Thing>> InternalProtocolAsync(Thing body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await InternalProtocolAsync(content, context).ConfigureAwait(false);
            return Response.FromValue(Thing.FromResponse(response), response);
        }

        /// <summary> When set protocol false and convenient true, then the protocol method should be internal. </summary>
        /// <param name="body"> The <see cref="Thing"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <remarks> Internal protocol. </remarks>
        public virtual Response<Thing> InternalProtocol(Thing body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using RequestContent content = body.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = InternalProtocol(content, context);
            return Response.FromValue(Thing.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] When set protocol false and convenient true, then the protocol method should be internal
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
        internal virtual async Task<Response> InternalProtocolAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ProtocolAndConvenient.InternalProtocol");
            scope.Start();
            try
            {
                using HttpMessage message = CreateInternalProtocolRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] When set protocol false and convenient true, then the protocol method should be internal
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
        internal virtual Response InternalProtocol(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ProtocolAndConvenient.InternalProtocol");
            scope.Start();
            try
            {
                using HttpMessage message = CreateInternalProtocolRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> When set protocol false and convenient true, the convenient method should be generated even it has the same signature as protocol one. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Still convenient. </remarks>
        public virtual async Task<Response> StillConvenientValueAsync(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("ProtocolAndConvenient.StillConvenientValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await StillConvenientAsync(context).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> When set protocol false and convenient true, the convenient method should be generated even it has the same signature as protocol one. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Still convenient. </remarks>
        public virtual Response StillConvenientValue(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("ProtocolAndConvenient.StillConvenientValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = StillConvenient(context);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] When set protocol false and convenient true, the convenient method should be generated even it has the same signature as protocol one
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual async Task<Response> StillConvenientAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ProtocolAndConvenient.StillConvenient");
            scope.Start();
            try
            {
                using HttpMessage message = CreateStillConvenientRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] When set protocol false and convenient true, the convenient method should be generated even it has the same signature as protocol one
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual Response StillConvenient(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ProtocolAndConvenient.StillConvenient");
            scope.Start();
            try
            {
                using HttpMessage message = CreateStillConvenientRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateInternalProtocolRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/internalProtocol", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateStillConvenientRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/stillConvenient", false);
            request.Uri = uri;
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
