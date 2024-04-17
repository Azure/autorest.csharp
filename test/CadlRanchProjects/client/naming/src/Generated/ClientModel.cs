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
using Client.Naming.Models;

namespace Client.Naming
{
    // Data plane generated sub-client.
    /// <summary> The ClientModel sub-client. </summary>
    public partial class ClientModel
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ClientModel for mocking. </summary>
        protected ClientModel()
        {
        }

        /// <summary> Initializes a new instance of ClientModel. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        internal ClientModel(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
        }

        /// <summary> The Client method. </summary>
        /// <param name="clientModel"> The <see cref="Models.ClientModel"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientModel"/> is null. </exception>
        /// <include file="Docs/ClientModel.xml" path="doc/members/member[@name='ClientAsync(ClientModel,CancellationToken)']/*" />
        public virtual async Task<Response> ClientAsync(Models.ClientModel clientModel, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(clientModel, nameof(clientModel));

            using RequestContent content = clientModel.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await ClientAsync(content, context).ConfigureAwait(false);
            return response;
        }

        /// <summary> The Client method. </summary>
        /// <param name="clientModel"> The <see cref="Models.ClientModel"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientModel"/> is null. </exception>
        /// <include file="Docs/ClientModel.xml" path="doc/members/member[@name='Client(ClientModel,CancellationToken)']/*" />
        public virtual Response Client(Models.ClientModel clientModel, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(clientModel, nameof(clientModel));

            using RequestContent content = clientModel.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Client(content, context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] The Client method
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ClientAsync(Models.ClientModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ClientModel.xml" path="doc/members/member[@name='ClientAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> ClientAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ClientModel.Client");
            scope.Start();
            try
            {
                using HttpMessage message = CreateClientRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] The Client method
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Client(Models.ClientModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ClientModel.xml" path="doc/members/member[@name='Client(RequestContent,RequestContext)']/*" />
        public virtual Response Client(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ClientModel.Client");
            scope.Start();
            try
            {
                using HttpMessage message = CreateClientRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The Language method. </summary>
        /// <param name="csModel"> The <see cref="CSModel"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="csModel"/> is null. </exception>
        /// <include file="Docs/ClientModel.xml" path="doc/members/member[@name='LanguageAsync(CSModel,CancellationToken)']/*" />
        public virtual async Task<Response> LanguageAsync(CSModel csModel, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(csModel, nameof(csModel));

            using RequestContent content = csModel.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await LanguageAsync(content, context).ConfigureAwait(false);
            return response;
        }

        /// <summary> The Language method. </summary>
        /// <param name="csModel"> The <see cref="CSModel"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="csModel"/> is null. </exception>
        /// <include file="Docs/ClientModel.xml" path="doc/members/member[@name='Language(CSModel,CancellationToken)']/*" />
        public virtual Response Language(CSModel csModel, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(csModel, nameof(csModel));

            using RequestContent content = csModel.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Language(content, context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] The Language method
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="LanguageAsync(CSModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ClientModel.xml" path="doc/members/member[@name='LanguageAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> LanguageAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ClientModel.Language");
            scope.Start();
            try
            {
                using HttpMessage message = CreateLanguageRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] The Language method
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Language(CSModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ClientModel.xml" path="doc/members/member[@name='Language(RequestContent,RequestContext)']/*" />
        public virtual Response Language(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ClientModel.Language");
            scope.Start();
            try
            {
                using HttpMessage message = CreateLanguageRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateClientRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/client/naming/model/client", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateLanguageRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/client/naming/model/language", false);
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

        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
