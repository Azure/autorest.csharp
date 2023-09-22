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
using _Specs_.Azure.ClientGenerator.Core.Access.Models;

namespace _Specs_.Azure.ClientGenerator.Core.Access
{
    // Data plane generated sub-client.
    /// <summary> The RelativeModelInOperation sub-client. </summary>
    public partial class RelativeModelInOperation
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of RelativeModelInOperation for mocking. </summary>
        protected RelativeModelInOperation()
        {
        }

        /// <summary> Initializes a new instance of RelativeModelInOperation. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="apiVersion"> The String to use. </param>
        internal RelativeModelInOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint, string apiVersion)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
        }

        /// <summary>
        /// Expected query parameter: name=&lt;any string&gt;
        /// Expected response body:
        /// ```json
        /// {
        ///   "name": &lt;any string&gt;,
        ///   "inner":
        ///   {
        ///     "name": &lt;any string&gt;
        ///   }
        /// }
        /// ```
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <include file="Docs/RelativeModelInOperation.xml" path="doc/members/member[@name='OperationAsync(string,CancellationToken)']/*" />
        internal virtual async Task<Response<OuterModel>> OperationAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(name, nameof(name));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await OperationAsync(name, context).ConfigureAwait(false);
            return Response.FromValue(OuterModel.FromResponse(response), response);
        }

        /// <summary>
        /// Expected query parameter: name=&lt;any string&gt;
        /// Expected response body:
        /// ```json
        /// {
        ///   "name": &lt;any string&gt;,
        ///   "inner":
        ///   {
        ///     "name": &lt;any string&gt;
        ///   }
        /// }
        /// ```
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <include file="Docs/RelativeModelInOperation.xml" path="doc/members/member[@name='Operation(string,CancellationToken)']/*" />
        internal virtual Response<OuterModel> Operation(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(name, nameof(name));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Operation(name, context);
            return Response.FromValue(OuterModel.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Expected query parameter: name=&lt;any string&gt;
        /// Expected response body:
        /// ```json
        /// {
        ///   "name": &lt;any string&gt;,
        ///   "inner":
        ///   {
        ///     "name": &lt;any string&gt;
        ///   }
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
        /// Please try the simpler <see cref="OperationAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RelativeModelInOperation.xml" path="doc/members/member[@name='OperationAsync(string,RequestContext)']/*" />
        internal virtual async Task<Response> OperationAsync(string name, RequestContext context)
        {
            Argument.AssertNotNull(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("RelativeModelInOperation.Operation");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOperationRequest(name, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Expected query parameter: name=&lt;any string&gt;
        /// Expected response body:
        /// ```json
        /// {
        ///   "name": &lt;any string&gt;,
        ///   "inner":
        ///   {
        ///     "name": &lt;any string&gt;
        ///   }
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
        /// Please try the simpler <see cref="Operation(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RelativeModelInOperation.xml" path="doc/members/member[@name='Operation(string,RequestContext)']/*" />
        internal virtual Response Operation(string name, RequestContext context)
        {
            Argument.AssertNotNull(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("RelativeModelInOperation.Operation");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOperationRequest(name, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Expected query parameter: kind=&lt;any string&gt;
        /// Expected response body:
        /// ```json
        /// {
        ///   "name": &lt;any string&gt;,
        ///   "kind": "real"
        /// }
        /// ```
        /// </summary>
        /// <param name="kind"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="kind"/> is null. </exception>
        /// <include file="Docs/RelativeModelInOperation.xml" path="doc/members/member[@name='DiscriminatorAsync(string,CancellationToken)']/*" />
        internal virtual async Task<Response<AbstractModel>> DiscriminatorAsync(string kind, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(kind, nameof(kind));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await DiscriminatorAsync(kind, context).ConfigureAwait(false);
            return Response.FromValue(AbstractModel.FromResponse(response), response);
        }

        /// <summary>
        /// Expected query parameter: kind=&lt;any string&gt;
        /// Expected response body:
        /// ```json
        /// {
        ///   "name": &lt;any string&gt;,
        ///   "kind": "real"
        /// }
        /// ```
        /// </summary>
        /// <param name="kind"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="kind"/> is null. </exception>
        /// <include file="Docs/RelativeModelInOperation.xml" path="doc/members/member[@name='Discriminator(string,CancellationToken)']/*" />
        internal virtual Response<AbstractModel> Discriminator(string kind, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(kind, nameof(kind));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Discriminator(kind, context);
            return Response.FromValue(AbstractModel.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Expected query parameter: kind=&lt;any string&gt;
        /// Expected response body:
        /// ```json
        /// {
        ///   "name": &lt;any string&gt;,
        ///   "kind": "real"
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
        /// Please try the simpler <see cref="DiscriminatorAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="kind"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="kind"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RelativeModelInOperation.xml" path="doc/members/member[@name='DiscriminatorAsync(string,RequestContext)']/*" />
        internal virtual async Task<Response> DiscriminatorAsync(string kind, RequestContext context)
        {
            Argument.AssertNotNull(kind, nameof(kind));

            using var scope = ClientDiagnostics.CreateScope("RelativeModelInOperation.Discriminator");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDiscriminatorRequest(kind, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Expected query parameter: kind=&lt;any string&gt;
        /// Expected response body:
        /// ```json
        /// {
        ///   "name": &lt;any string&gt;,
        ///   "kind": "real"
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
        /// Please try the simpler <see cref="Discriminator(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="kind"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="kind"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RelativeModelInOperation.xml" path="doc/members/member[@name='Discriminator(string,RequestContext)']/*" />
        internal virtual Response Discriminator(string kind, RequestContext context)
        {
            Argument.AssertNotNull(kind, nameof(kind));

            using var scope = ClientDiagnostics.CreateScope("RelativeModelInOperation.Discriminator");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDiscriminatorRequest(kind, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateOperationRequest(string name, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/client-generator-core/access/relativeModelInOperation/operation", false);
            uri.AppendQuery("name", name, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDiscriminatorRequest(string kind, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/client-generator-core/access/relativeModelInOperation/discriminator", false);
            uri.AppendQuery("kind", kind, true);
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
