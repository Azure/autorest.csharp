// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace CollapseRequestCondition_LowLevel
{
    /// <summary> The NonCollapse service client. </summary>
    public partial class NonCollapseClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of NonCollapseClient for mocking. </summary>
        protected NonCollapseClient()
        {
        }

        /// <summary> Initializes a new instance of NonCollapseClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public NonCollapseClient(AzureKeyCredential credential, Uri endpoint = null, CollapseRequestConditionsClientOptions options = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            endpoint ??= new Uri("http://localhost:3000");
            options ??= new CollapseRequestConditionsClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="ifMatch"> Specify an ETag value to operate only on blobs with a matching value. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        public virtual async Task<Response> IfMatchPutAsync(RequestContent content, ETag? ifMatch = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("NonCollapseClient.IfMatchPut");
            scope.Start();
            try
            {
                using HttpMessage message = CreateIfMatchPutRequest(content, ifMatch, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="ifMatch"> Specify an ETag value to operate only on blobs with a matching value. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        public virtual Response IfMatchPut(RequestContent content, ETag? ifMatch = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("NonCollapseClient.IfMatchPut");
            scope.Start();
            try
            {
                using HttpMessage message = CreateIfMatchPutRequest(content, ifMatch, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="ifNoneMatch"> Specify an ETag value to operate only on blobs without a matching value. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        public virtual async Task<Response> IfNoneMatchPutAsync(RequestContent content, ETag? ifNoneMatch = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("NonCollapseClient.IfNoneMatchPut");
            scope.Start();
            try
            {
                using HttpMessage message = CreateIfNoneMatchPutRequest(content, ifNoneMatch, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="ifNoneMatch"> Specify an ETag value to operate only on blobs without a matching value. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        public virtual Response IfNoneMatchPut(RequestContent content, ETag? ifNoneMatch = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("NonCollapseClient.IfNoneMatchPut");
            scope.Start();
            try
            {
                using HttpMessage message = CreateIfNoneMatchPutRequest(content, ifNoneMatch, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateIfMatchPutRequest(RequestContent content, ETag? ifMatch, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/NonCollapse/ifMatch", false);
            request.Uri = uri;
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch.Value);
            }
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateIfNoneMatchPutRequest(RequestContent content, ETag? ifNoneMatch, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/NonCollapse/ifNoneMatch", false);
            request.Uri = uri;
            if (ifNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", ifNoneMatch.Value);
            }
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
