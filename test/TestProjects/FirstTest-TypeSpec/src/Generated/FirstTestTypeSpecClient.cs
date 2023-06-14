// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using FirstTestTypeSpec.Models;

namespace FirstTestTypeSpec
{
    // Data plane generated client.
    /// <summary> This is a sample typespec project. </summary>
    public partial class FirstTestTypeSpecClient
    {
        private const string AuthorizationHeader = "x-ms-api-key";
        private readonly AzureKeyCredential _keyCredential;
        private static readonly string[] AuthorizationScopes = new string[] { "https://api.example.com/.default" };
        private readonly TokenCredential _tokenCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of FirstTestTypeSpecClient for mocking. </summary>
        protected FirstTestTypeSpecClient()
        {
        }

        /// <summary> Initializes a new instance of FirstTestTypeSpecClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public FirstTestTypeSpecClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, new FirstTestTypeSpecClientOptions())
        {
        }

        /// <summary> Initializes a new instance of FirstTestTypeSpecClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public FirstTestTypeSpecClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new FirstTestTypeSpecClientOptions())
        {
        }

        /// <summary> Initializes a new instance of FirstTestTypeSpecClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public FirstTestTypeSpecClient(Uri endpoint, AzureKeyCredential credential, FirstTestTypeSpecClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new FirstTestTypeSpecClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Initializes a new instance of FirstTestTypeSpecClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public FirstTestTypeSpecClient(Uri endpoint, TokenCredential credential, FirstTestTypeSpecClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new FirstTestTypeSpecClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> top level method. </summary>
        /// <param name="action"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='TopActionAsync(DateTimeOffset,CancellationToken)']/*" />
        public virtual async Task<Response<Thing>> TopActionAsync(DateTimeOffset action, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await TopActionAsync(action, context).ConfigureAwait(false);
            return Response.FromValue(Thing.FromResponse(response), response);
        }

        /// <summary> top level method. </summary>
        /// <param name="action"> The DateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='TopAction(DateTimeOffset,CancellationToken)']/*" />
        public virtual Response<Thing> TopAction(DateTimeOffset action, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = TopAction(action, context);
            return Response.FromValue(Thing.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] top level method
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="TopActionAsync(DateTimeOffset,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="action"> The DateTime to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='TopActionAsync(DateTimeOffset,RequestContext)']/*" />
        public virtual async Task<Response> TopActionAsync(DateTimeOffset action, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.TopAction");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTopActionRequest(action, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] top level method
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="TopAction(DateTimeOffset,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="action"> The DateTime to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='TopAction(DateTimeOffset,RequestContext)']/*" />
        public virtual Response TopAction(DateTimeOffset action, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.TopAction");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTopActionRequest(action, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] top level method2
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
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='TopAction2Async(RequestContext)']/*" />
        public virtual async Task<Response> TopAction2Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.TopAction2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTopAction2Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] top level method2
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
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='TopAction2(RequestContext)']/*" />
        public virtual Response TopAction2(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.TopAction2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTopAction2Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] top level patch
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
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='PatchActionAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> PatchActionAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.PatchAction");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePatchActionRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] top level patch
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
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='PatchAction(RequestContent,RequestContext)']/*" />
        public virtual Response PatchAction(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.PatchAction");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePatchActionRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> body parameter without body decorator. </summary>
        /// <param name="thing"> A model with a few properties of literal types. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="thing"/> is null. </exception>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='AnonymousBodyAsync(Thing,CancellationToken)']/*" />
        public virtual async Task<Response<Thing>> AnonymousBodyAsync(Thing thing, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(thing, nameof(thing));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await AnonymousBodyAsync(thing.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(Thing.FromResponse(response), response);
        }

        /// <summary> body parameter without body decorator. </summary>
        /// <param name="thing"> A model with a few properties of literal types. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="thing"/> is null. </exception>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='AnonymousBody(Thing,CancellationToken)']/*" />
        public virtual Response<Thing> AnonymousBody(Thing thing, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(thing, nameof(thing));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = AnonymousBody(thing.ToRequestContent(), context);
            return Response.FromValue(Thing.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] body parameter without body decorator
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="AnonymousBodyAsync(Thing,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='AnonymousBodyAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> AnonymousBodyAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.AnonymousBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnonymousBodyRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] body parameter without body decorator
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="AnonymousBody(Thing,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='AnonymousBody(RequestContent,RequestContext)']/*" />
        public virtual Response AnonymousBody(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.AnonymousBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnonymousBodyRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Model can have its friendly name. </summary>
        /// <param name="notFriend"> this is not a friendly model but with a friendly name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="notFriend"/> is null. </exception>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='FriendlyModelAsync(Friend,CancellationToken)']/*" />
        public virtual async Task<Response<Friend>> FriendlyModelAsync(Friend notFriend, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(notFriend, nameof(notFriend));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await FriendlyModelAsync(notFriend.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(Friend.FromResponse(response), response);
        }

        /// <summary> Model can have its friendly name. </summary>
        /// <param name="notFriend"> this is not a friendly model but with a friendly name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="notFriend"/> is null. </exception>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='FriendlyModel(Friend,CancellationToken)']/*" />
        public virtual Response<Friend> FriendlyModel(Friend notFriend, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(notFriend, nameof(notFriend));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = FriendlyModel(notFriend.ToRequestContent(), context);
            return Response.FromValue(Friend.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Model can have its friendly name
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="FriendlyModelAsync(Friend,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='FriendlyModelAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> FriendlyModelAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.FriendlyModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateFriendlyModelRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Model can have its friendly name
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="FriendlyModel(Friend,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='FriendlyModel(RequestContent,RequestContext)']/*" />
        public virtual Response FriendlyModel(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.FriendlyModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateFriendlyModelRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
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
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="repeatabilityFirstSent"> The DateTime to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='AddTimeHeaderAsync(DateTimeOffset?,RequestContext)']/*" />
        public virtual async Task<Response> AddTimeHeaderAsync(DateTimeOffset? repeatabilityFirstSent = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.AddTimeHeader");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAddTimeHeaderRequest(repeatabilityFirstSent, context);
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
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="repeatabilityFirstSent"> The DateTime to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='AddTimeHeader(DateTimeOffset?,RequestContext)']/*" />
        public virtual Response AddTimeHeader(DateTimeOffset? repeatabilityFirstSent = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.AddTimeHeader");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAddTimeHeaderRequest(repeatabilityFirstSent, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> paramete has string format. </summary>
        /// <param name="subscriptionId"> The Guid to use. </param>
        /// <param name="body"> The ModelWithFormat to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='StringFormatAsync(Guid,ModelWithFormat,CancellationToken)']/*" />
        public virtual async Task<Response> StringFormatAsync(Guid subscriptionId, ModelWithFormat body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await StringFormatAsync(subscriptionId, body.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <summary> paramete has string format. </summary>
        /// <param name="subscriptionId"> The Guid to use. </param>
        /// <param name="body"> The ModelWithFormat to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='StringFormat(Guid,ModelWithFormat,CancellationToken)']/*" />
        public virtual Response StringFormat(Guid subscriptionId, ModelWithFormat body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = StringFormat(subscriptionId, body.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] paramete has string format.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="StringFormatAsync(Guid,ModelWithFormat,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionId"> The Guid to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='StringFormatAsync(Guid,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> StringFormatAsync(Guid subscriptionId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.StringFormat");
            scope.Start();
            try
            {
                using HttpMessage message = CreateStringFormatRequest(subscriptionId, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] paramete has string format.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="StringFormat(Guid,ModelWithFormat,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionId"> The Guid to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='StringFormat(Guid,RequestContent,RequestContext)']/*" />
        public virtual Response StringFormat(Guid subscriptionId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.StringFormat");
            scope.Start();
            try
            {
                using HttpMessage message = CreateStringFormatRequest(subscriptionId, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Return hi
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="headParameter"> The String to use. </param>
        /// <param name="queryParameter"> The String to use. </param>
        /// <param name="optionalQuery"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="headParameter"/> or <paramref name="queryParameter"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='SayHiAsync(string,string,string,RequestContext)']/*" />
        public virtual async Task<Response> SayHiAsync(string headParameter, string queryParameter, string optionalQuery = null, RequestContext context = null)
        {
            Argument.AssertNotNull(headParameter, nameof(headParameter));
            Argument.AssertNotNull(queryParameter, nameof(queryParameter));

            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.SayHi");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSayHiRequest(headParameter, queryParameter, optionalQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Return hi
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="headParameter"> The String to use. </param>
        /// <param name="queryParameter"> The String to use. </param>
        /// <param name="optionalQuery"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="headParameter"/> or <paramref name="queryParameter"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='SayHi(string,string,string,RequestContext)']/*" />
        public virtual Response SayHi(string headParameter, string queryParameter, string optionalQuery = null, RequestContext context = null)
        {
            Argument.AssertNotNull(headParameter, nameof(headParameter));
            Argument.AssertNotNull(queryParameter, nameof(queryParameter));

            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.SayHi");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSayHiRequest(headParameter, queryParameter, optionalQuery, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return hi again. </summary>
        /// <param name="p2"> The String to use. </param>
        /// <param name="p1"> The String to use. </param>
        /// <param name="action"> The RoundTripModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="p2"/>, <paramref name="p1"/> or <paramref name="action"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="p2"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='HelloAgainAsync(string,string,RoundTripModel,CancellationToken)']/*" />
        public virtual async Task<Response<RoundTripModel>> HelloAgainAsync(string p2, string p1, RoundTripModel action, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(p2, nameof(p2));
            Argument.AssertNotNull(p1, nameof(p1));
            Argument.AssertNotNull(action, nameof(action));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await HelloAgainAsync(p2, p1, action.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(RoundTripModel.FromResponse(response), response);
        }

        /// <summary> Return hi again. </summary>
        /// <param name="p2"> The String to use. </param>
        /// <param name="p1"> The String to use. </param>
        /// <param name="action"> The RoundTripModel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="p2"/>, <paramref name="p1"/> or <paramref name="action"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="p2"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='HelloAgain(string,string,RoundTripModel,CancellationToken)']/*" />
        public virtual Response<RoundTripModel> HelloAgain(string p2, string p1, RoundTripModel action, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(p2, nameof(p2));
            Argument.AssertNotNull(p1, nameof(p1));
            Argument.AssertNotNull(action, nameof(action));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = HelloAgain(p2, p1, action.ToRequestContent(), context);
            return Response.FromValue(RoundTripModel.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Return hi again
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="HelloAgainAsync(string,string,RoundTripModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="p2"> The String to use. </param>
        /// <param name="p1"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="p2"/>, <paramref name="p1"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="p2"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='HelloAgainAsync(string,string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> HelloAgainAsync(string p2, string p1, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(p2, nameof(p2));
            Argument.AssertNotNull(p1, nameof(p1));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.HelloAgain");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHelloAgainRequest(p2, p1, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Return hi again
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="HelloAgain(string,string,RoundTripModel,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="p2"> The String to use. </param>
        /// <param name="p1"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="p2"/>, <paramref name="p1"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="p2"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='HelloAgain(string,string,RequestContent,RequestContext)']/*" />
        public virtual Response HelloAgain(string p2, string p1, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(p2, nameof(p2));
            Argument.AssertNotNull(p1, nameof(p1));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.HelloAgain");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHelloAgainRequest(p2, p1, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Return hi again
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="p2"> The String to use. </param>
        /// <param name="p1"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="p2"/>, <paramref name="p1"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="p2"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='NoContentTypeAsync(string,string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> NoContentTypeAsync(string p2, string p1, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(p2, nameof(p2));
            Argument.AssertNotNull(p1, nameof(p1));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.NoContentType");
            scope.Start();
            try
            {
                using HttpMessage message = CreateNoContentTypeRequest(p2, p1, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Return hi again
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="p2"> The String to use. </param>
        /// <param name="p1"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="p2"/>, <paramref name="p1"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="p2"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='NoContentType(string,string,RequestContent,RequestContext)']/*" />
        public virtual Response NoContentType(string p2, string p1, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(p2, nameof(p2));
            Argument.AssertNotNull(p1, nameof(p1));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.NoContentType");
            scope.Start();
            try
            {
                using HttpMessage message = CreateNoContentTypeRequest(p2, p1, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return hi in demo2. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='HelloDemo2Async(CancellationToken)']/*" />
        public virtual async Task<Response<Thing>> HelloDemo2Async(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await HelloDemo2Async(context).ConfigureAwait(false);
            return Response.FromValue(Thing.FromResponse(response), response);
        }

        /// <summary> Return hi in demo2. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='HelloDemo2(CancellationToken)']/*" />
        public virtual Response<Thing> HelloDemo2(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = HelloDemo2(context);
            return Response.FromValue(Thing.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Return hi in demo2
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="HelloDemo2Async(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='HelloDemo2Async(RequestContext)']/*" />
        public virtual async Task<Response> HelloDemo2Async(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.HelloDemo2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHelloDemo2Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Return hi in demo2
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="HelloDemo2(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='HelloDemo2(RequestContext)']/*" />
        public virtual Response HelloDemo2(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.HelloDemo2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHelloDemo2Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create with literal value. </summary>
        /// <param name="body"> The Thing to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='CreateLiteralAsync(Thing,CancellationToken)']/*" />
        public virtual async Task<Response<Thing>> CreateLiteralAsync(Thing body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await CreateLiteralAsync(body.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(Thing.FromResponse(response), response);
        }

        /// <summary> Create with literal value. </summary>
        /// <param name="body"> The Thing to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='CreateLiteral(Thing,CancellationToken)']/*" />
        public virtual Response<Thing> CreateLiteral(Thing body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = CreateLiteral(body.ToRequestContent(), context);
            return Response.FromValue(Thing.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Create with literal value
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateLiteralAsync(Thing,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='CreateLiteralAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> CreateLiteralAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.CreateLiteral");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateLiteralRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Create with literal value
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateLiteral(Thing,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='CreateLiteral(RequestContent,RequestContext)']/*" />
        public virtual Response CreateLiteral(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.CreateLiteral");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateLiteralRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send literal parameters. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='HelloLiteralAsync(CancellationToken)']/*" />
        public virtual async Task<Response<Thing>> HelloLiteralAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await HelloLiteralAsync(context).ConfigureAwait(false);
            return Response.FromValue(Thing.FromResponse(response), response);
        }

        /// <summary> Send literal parameters. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='HelloLiteral(CancellationToken)']/*" />
        public virtual Response<Thing> HelloLiteral(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = HelloLiteral(context);
            return Response.FromValue(Thing.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Send literal parameters
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="HelloLiteralAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='HelloLiteralAsync(RequestContext)']/*" />
        public virtual async Task<Response> HelloLiteralAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.HelloLiteral");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHelloLiteralRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Send literal parameters
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="HelloLiteral(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='HelloLiteral(RequestContext)']/*" />
        public virtual Response HelloLiteral(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.HelloLiteral");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHelloLiteralRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] get extensible enum
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
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='GetUnknownValueAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetUnknownValueAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.GetUnknownValue");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetUnknownValueRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] get extensible enum
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
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='GetUnknownValue(RequestContext)']/*" />
        public virtual Response GetUnknownValue(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.GetUnknownValue");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetUnknownValueRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> When set protocol false and convenient true, then the protocol method should be internal. </summary>
        /// <param name="body"> The Thing to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='InternalProtocolAsync(Thing,CancellationToken)']/*" />
        public virtual async Task<Response<Thing>> InternalProtocolAsync(Thing body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await InternalProtocolAsync(body.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(Thing.FromResponse(response), response);
        }

        /// <summary> When set protocol false and convenient true, then the protocol method should be internal. </summary>
        /// <param name="body"> The Thing to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='InternalProtocol(Thing,CancellationToken)']/*" />
        public virtual Response<Thing> InternalProtocol(Thing body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = InternalProtocol(body.ToRequestContent(), context);
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
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="InternalProtocolAsync(Thing,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='InternalProtocolAsync(RequestContent,RequestContext)']/*" />
        internal virtual async Task<Response> InternalProtocolAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.InternalProtocol");
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
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="InternalProtocol(Thing,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='InternalProtocol(RequestContent,RequestContext)']/*" />
        internal virtual Response InternalProtocol(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.InternalProtocol");
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
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='StillConvenientAsync(CancellationToken)']/*" />
        public virtual async Task<Response> StillConvenientAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await StillConvenientAsync(context).ConfigureAwait(false);
            return response;
        }

        /// <summary> When set protocol false and convenient true, the convenient method should be generated even it has the same signature as protocol one. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='StillConvenient(CancellationToken)']/*" />
        public virtual Response StillConvenient(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = StillConvenient(context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] When set protocol false and convenient true, the convenient method should be generated even it has the same signature as protocol one
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="StillConvenientAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='StillConvenientAsync(RequestContext)']/*" />
        internal virtual async Task<Response> StillConvenientAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.StillConvenient");
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
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="StillConvenient(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/FirstTestTypeSpecClient.xml" path="doc/members/member[@name='StillConvenient(RequestContext)']/*" />
        internal virtual Response StillConvenient(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("FirstTestTypeSpecClient.StillConvenient");
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

        internal HttpMessage CreateTopActionRequest(DateTimeOffset action, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/top/", false);
            uri.AppendPath(action, "O", true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateTopAction2Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/top2", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePatchActionRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/patch", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateAnonymousBodyRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/anonymousBody", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateFriendlyModelRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/friendlyName", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateAddTimeHeaderRequest(DateTimeOffset? repeatabilityFirstSent, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (repeatabilityFirstSent != null)
            {
                request.Headers.Add("Repeatability-First-Sent", repeatabilityFirstSent.Value, "O");
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateStringFormatRequest(Guid subscriptionId, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/stringFormat/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateSayHiRequest(string headParameter, string queryParameter, string optionalQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/hello", false);
            uri.AppendQuery("queryParameter", queryParameter, true);
            if (optionalQuery != null)
            {
                uri.AppendQuery("optionalQuery", optionalQuery, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("head-parameter", headParameter);
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateHelloAgainRequest(string p2, string p1, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/againHi/", false);
            uri.AppendPath(p2, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("p1", p1);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("content-type", "text/plain");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateNoContentTypeRequest(string p2, string p1, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/noContentType/", false);
            uri.AppendPath(p2, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("p1", p1);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateHelloDemo2Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/demoHi", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateCreateLiteralRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/literal", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateHelloLiteralRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/helloLiteral/", false);
            uri.AppendPath(123, true);
            uri.AppendQuery("p3", true, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("p1", "test");
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetUnknownValueRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/unknown-value", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateInternalProtocolRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/internalProtocol", false);
            uri.AppendQuery("api-version", _apiVersion, true);
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
        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
