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
using _Type.Property.Nullable.Models;

namespace _Type.Property.Nullable
{
    // Data plane generated sub-client.
    /// <summary> The CollectionsModel sub-client. </summary>
    public partial class CollectionsModel
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of CollectionsModel for mocking. </summary>
        protected CollectionsModel()
        {
        }

        /// <summary> Initializes a new instance of CollectionsModel. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="apiVersion"> The <see cref="string"/> to use. </param>
        internal CollectionsModel(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint, string apiVersion)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
        }

        /// <summary> Get models that will return all properties in the model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/CollectionsModel.xml" path="doc/members/member[@name='GetNonNullAsync(CancellationToken)']/*" />
        public virtual async Task<Response<CollectionsModelProperty>> GetNonNullAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetNonNullAsync(context).ConfigureAwait(false);
            return Response.FromValue(CollectionsModelProperty.FromResponse(response), response);
        }

        /// <summary> Get models that will return all properties in the model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/CollectionsModel.xml" path="doc/members/member[@name='GetNonNull(CancellationToken)']/*" />
        public virtual Response<CollectionsModelProperty> GetNonNull(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetNonNull(context);
            return Response.FromValue(CollectionsModelProperty.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Get models that will return all properties in the model
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetNonNullAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/CollectionsModel.xml" path="doc/members/member[@name='GetNonNullAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetNonNullAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("CollectionsModel.GetNonNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetNonNullRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get models that will return all properties in the model
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetNonNull(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/CollectionsModel.xml" path="doc/members/member[@name='GetNonNull(RequestContext)']/*" />
        public virtual Response GetNonNull(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("CollectionsModel.GetNonNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetNonNullRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get models that will return the default object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/CollectionsModel.xml" path="doc/members/member[@name='GetNullAsync(CancellationToken)']/*" />
        public virtual async Task<Response<CollectionsModelProperty>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetNullAsync(context).ConfigureAwait(false);
            return Response.FromValue(CollectionsModelProperty.FromResponse(response), response);
        }

        /// <summary> Get models that will return the default object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/CollectionsModel.xml" path="doc/members/member[@name='GetNull(CancellationToken)']/*" />
        public virtual Response<CollectionsModelProperty> GetNull(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetNull(context);
            return Response.FromValue(CollectionsModelProperty.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Get models that will return the default object
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetNullAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/CollectionsModel.xml" path="doc/members/member[@name='GetNullAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetNullAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("CollectionsModel.GetNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetNullRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get models that will return the default object
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetNull(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/CollectionsModel.xml" path="doc/members/member[@name='GetNull(RequestContext)']/*" />
        public virtual Response GetNull(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("CollectionsModel.GetNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetNullRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Put a body with all properties present.
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
        /// <include file="Docs/CollectionsModel.xml" path="doc/members/member[@name='PatchNonNullAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> PatchNonNullAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("CollectionsModel.PatchNonNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePatchNonNullRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Put a body with all properties present.
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
        /// <include file="Docs/CollectionsModel.xml" path="doc/members/member[@name='PatchNonNull(RequestContent,RequestContext)']/*" />
        public virtual Response PatchNonNull(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("CollectionsModel.PatchNonNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePatchNonNullRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Put a body with default properties.
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
        /// <include file="Docs/CollectionsModel.xml" path="doc/members/member[@name='PatchNullAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> PatchNullAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("CollectionsModel.PatchNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePatchNullRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Put a body with default properties.
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
        /// <include file="Docs/CollectionsModel.xml" path="doc/members/member[@name='PatchNull(RequestContent,RequestContext)']/*" />
        public virtual Response PatchNull(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("CollectionsModel.PatchNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePatchNullRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetNonNullRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/property/nullable/collections/model/non-null", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetNullRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/property/nullable/collections/model/null", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePatchNonNullRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/property/nullable/collections/model/non-null", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/merge-patch+json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreatePatchNullRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/property/nullable/collections/model/null", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/merge-patch+json");
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
