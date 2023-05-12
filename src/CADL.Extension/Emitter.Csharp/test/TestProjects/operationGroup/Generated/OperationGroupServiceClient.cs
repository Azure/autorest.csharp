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

namespace Azure.OperationGroupService
{
    // Data plane generated client.
    /// <summary> The OperationGroupService service client. </summary>
    public partial class OperationGroupServiceClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of OperationGroupServiceClient for mocking. </summary>
        protected OperationGroupServiceClient()
        {
        }

        /// <summary> Initializes a new instance of OperationGroupServiceClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public OperationGroupServiceClient(Uri endpoint) : this(endpoint, new OperationGroupServiceClientOptions())
        {
        }

        /// <summary> Initializes a new instance of OperationGroupServiceClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public OperationGroupServiceClient(Uri endpoint, OperationGroupServiceClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new OperationGroupServiceClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<string>> ZeroValueAsync(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("OperationGroupServiceClient.ZeroValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await ZeroAsync(context).ConfigureAwait(false);
                return Response.FromValue(string.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<string> ZeroValue(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("OperationGroupServiceClient.ZeroValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = Zero(context);
                return Response.FromValue(string.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/OperationGroupServiceClient.xml" path="doc/members/member[@name='ZeroAsync(RequestContext)']/*" />
        public virtual async Task<Response> ZeroAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("OperationGroupServiceClient.Zero");
            scope.Start();
            try
            {
                using HttpMessage message = CreateZeroRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/OperationGroupServiceClient.xml" path="doc/members/member[@name='Zero(RequestContext)']/*" />
        public virtual Response Zero(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("OperationGroupServiceClient.Zero");
            scope.Start();
            try
            {
                using HttpMessage message = CreateZeroRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<string>> OneValueAsync(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("OperationGroupServiceClient.OneValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await OneAsync(context).ConfigureAwait(false);
                return Response.FromValue(string.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<string> OneValue(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("OperationGroupServiceClient.OneValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = One(context);
                return Response.FromValue(string.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/OperationGroupServiceClient.xml" path="doc/members/member[@name='OneAsync(RequestContext)']/*" />
        public virtual async Task<Response> OneAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("OperationGroupServiceClient.One");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOneRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/OperationGroupServiceClient.xml" path="doc/members/member[@name='One(RequestContext)']/*" />
        public virtual Response One(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("OperationGroupServiceClient.One");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOneRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Beta _cachedBeta;
        private Gamma _cachedGamma;

        /// <summary> Initializes a new instance of Beta. </summary>
        public virtual Beta GetBetaClient()
        {
            return Volatile.Read(ref _cachedBeta) ?? Interlocked.CompareExchange(ref _cachedBeta, new Beta(ClientDiagnostics, _pipeline, _endpoint, _apiVersion), null) ?? _cachedBeta;
        }

        /// <summary> Initializes a new instance of Gamma. </summary>
        public virtual Gamma GetGammaClient()
        {
            return Volatile.Read(ref _cachedGamma) ?? Interlocked.CompareExchange(ref _cachedGamma, new Gamma(ClientDiagnostics, _pipeline, _endpoint, _apiVersion), null) ?? _cachedGamma;
        }

        internal HttpMessage CreateZeroRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/top", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateOneRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/Alpha", false);
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
