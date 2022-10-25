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
    // Data plane generated client. The RequestConditionCollapse service client.
    /// <summary> The RequestConditionCollapse service client. </summary>
    public partial class RequestConditionCollapseClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of RequestConditionCollapseClient for mocking. </summary>
        protected RequestConditionCollapseClient()
        {
        }

        /// <summary> Initializes a new instance of RequestConditionCollapseClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public RequestConditionCollapseClient(AzureKeyCredential credential) : this(credential, new Uri("http://localhost:3000"), new CollapseRequestConditionsClientOptions())
        {
        }

        /// <summary> Initializes a new instance of RequestConditionCollapseClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public RequestConditionCollapseClient(AzureKeyCredential credential, Uri endpoint, CollapseRequestConditionsClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new CollapseRequestConditionsClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RequestConditionCollapseClient.xml" path="doc/members/member[@name='CollapsePutAsync(RequestContent,RequestConditions,RequestContext)']/*" />
        public virtual async Task<Response> CollapsePutAsync(RequestContent content, RequestConditions requestConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("RequestConditionCollapseClient.CollapsePut");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCollapsePutRequest(content, requestConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RequestConditionCollapseClient.xml" path="doc/members/member[@name='CollapsePut(RequestContent,RequestConditions,RequestContext)']/*" />
        public virtual Response CollapsePut(RequestContent content, RequestConditions requestConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("RequestConditionCollapseClient.CollapsePut");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCollapsePutRequest(content, requestConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RequestConditionCollapseClient.xml" path="doc/members/member[@name='CollapseGetAsync(RequestConditions,RequestContext)']/*" />
        public virtual async Task<Response> CollapseGetAsync(RequestConditions requestConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("RequestConditionCollapseClient.CollapseGet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCollapseGetRequest(requestConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RequestConditionCollapseClient.xml" path="doc/members/member[@name='CollapseGet(RequestConditions,RequestContext)']/*" />
        public virtual Response CollapseGet(RequestConditions requestConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("RequestConditionCollapseClient.CollapseGet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCollapseGetRequest(requestConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RequestConditionCollapseClient.xml" path="doc/members/member[@name='MissIfNoneMatchGetAsync(RequestConditions,RequestContext)']/*" />
        public virtual async Task<Response> MissIfNoneMatchGetAsync(RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNull(requestConditions.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");

            using var scope = ClientDiagnostics.CreateScope("RequestConditionCollapseClient.MissIfNoneMatchGet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateMissIfNoneMatchGetRequest(requestConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RequestConditionCollapseClient.xml" path="doc/members/member[@name='MissIfNoneMatchGet(RequestConditions,RequestContext)']/*" />
        public virtual Response MissIfNoneMatchGet(RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNull(requestConditions.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");

            using var scope = ClientDiagnostics.CreateScope("RequestConditionCollapseClient.MissIfNoneMatchGet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateMissIfNoneMatchGetRequest(requestConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RequestConditionCollapseClient.xml" path="doc/members/member[@name='MissIfMatchGetAsync(RequestConditions,RequestContext)']/*" />
        public virtual async Task<Response> MissIfMatchGetAsync(RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNull(requestConditions.IfMatch, nameof(requestConditions), "Service does not support the If-Match header for this operation.");

            using var scope = ClientDiagnostics.CreateScope("RequestConditionCollapseClient.MissIfMatchGet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateMissIfMatchGetRequest(requestConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RequestConditionCollapseClient.xml" path="doc/members/member[@name='MissIfMatchGet(RequestConditions,RequestContext)']/*" />
        public virtual Response MissIfMatchGet(RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNull(requestConditions.IfMatch, nameof(requestConditions), "Service does not support the If-Match header for this operation.");

            using var scope = ClientDiagnostics.CreateScope("RequestConditionCollapseClient.MissIfMatchGet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateMissIfMatchGetRequest(requestConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RequestConditionCollapseClient.xml" path="doc/members/member[@name='MissIfModifiedSinceGetAsync(RequestConditions,RequestContext)']/*" />
        public virtual async Task<Response> MissIfModifiedSinceGetAsync(RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNull(requestConditions.IfModifiedSince, nameof(requestConditions), "Service does not support the If-Modified-Since header for this operation.");

            using var scope = ClientDiagnostics.CreateScope("RequestConditionCollapseClient.MissIfModifiedSinceGet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateMissIfModifiedSinceGetRequest(requestConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RequestConditionCollapseClient.xml" path="doc/members/member[@name='MissIfModifiedSinceGet(RequestConditions,RequestContext)']/*" />
        public virtual Response MissIfModifiedSinceGet(RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNull(requestConditions.IfModifiedSince, nameof(requestConditions), "Service does not support the If-Modified-Since header for this operation.");

            using var scope = ClientDiagnostics.CreateScope("RequestConditionCollapseClient.MissIfModifiedSinceGet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateMissIfModifiedSinceGetRequest(requestConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RequestConditionCollapseClient.xml" path="doc/members/member[@name='MissIfUnmodifiedSinceGetAsync(RequestConditions,RequestContext)']/*" />
        public virtual async Task<Response> MissIfUnmodifiedSinceGetAsync(RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNull(requestConditions.IfUnmodifiedSince, nameof(requestConditions), "Service does not support the If-Unmodified-Since header for this operation.");

            using var scope = ClientDiagnostics.CreateScope("RequestConditionCollapseClient.MissIfUnmodifiedSinceGet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateMissIfUnmodifiedSinceGetRequest(requestConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RequestConditionCollapseClient.xml" path="doc/members/member[@name='MissIfUnmodifiedSinceGet(RequestConditions,RequestContext)']/*" />
        public virtual Response MissIfUnmodifiedSinceGet(RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNull(requestConditions.IfUnmodifiedSince, nameof(requestConditions), "Service does not support the If-Unmodified-Since header for this operation.");

            using var scope = ClientDiagnostics.CreateScope("RequestConditionCollapseClient.MissIfUnmodifiedSinceGet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateMissIfUnmodifiedSinceGetRequest(requestConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RequestConditionCollapseClient.xml" path="doc/members/member[@name='MissIfMatchIfNoneMatchGetAsync(RequestConditions,RequestContext)']/*" />
        public virtual async Task<Response> MissIfMatchIfNoneMatchGetAsync(RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNull(requestConditions.IfMatch, nameof(requestConditions), "Service does not support the If-Match header for this operation.");
            Argument.AssertNull(requestConditions.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");

            using var scope = ClientDiagnostics.CreateScope("RequestConditionCollapseClient.MissIfMatchIfNoneMatchGet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateMissIfMatchIfNoneMatchGetRequest(requestConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RequestConditionCollapseClient.xml" path="doc/members/member[@name='MissIfMatchIfNoneMatchGet(RequestConditions,RequestContext)']/*" />
        public virtual Response MissIfMatchIfNoneMatchGet(RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNull(requestConditions.IfMatch, nameof(requestConditions), "Service does not support the If-Match header for this operation.");
            Argument.AssertNull(requestConditions.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");

            using var scope = ClientDiagnostics.CreateScope("RequestConditionCollapseClient.MissIfMatchIfNoneMatchGet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateMissIfMatchIfNoneMatchGetRequest(requestConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RequestConditionCollapseClient.xml" path="doc/members/member[@name='IfModifiedSinceGetAsync(RequestConditions,RequestContext)']/*" />
        public virtual async Task<Response> IfModifiedSinceGetAsync(RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNull(requestConditions.IfMatch, nameof(requestConditions), "Service does not support the If-Match header for this operation.");
            Argument.AssertNull(requestConditions.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            Argument.AssertNull(requestConditions.IfUnmodifiedSince, nameof(requestConditions), "Service does not support the If-Unmodified-Since header for this operation.");

            using var scope = ClientDiagnostics.CreateScope("RequestConditionCollapseClient.IfModifiedSinceGet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateIfModifiedSinceGetRequest(requestConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RequestConditionCollapseClient.xml" path="doc/members/member[@name='IfModifiedSinceGet(RequestConditions,RequestContext)']/*" />
        public virtual Response IfModifiedSinceGet(RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNull(requestConditions.IfMatch, nameof(requestConditions), "Service does not support the If-Match header for this operation.");
            Argument.AssertNull(requestConditions.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            Argument.AssertNull(requestConditions.IfUnmodifiedSince, nameof(requestConditions), "Service does not support the If-Unmodified-Since header for this operation.");

            using var scope = ClientDiagnostics.CreateScope("RequestConditionCollapseClient.IfModifiedSinceGet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateIfModifiedSinceGetRequest(requestConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RequestConditionCollapseClient.xml" path="doc/members/member[@name='IfUnmodifiedSinceGetAsync(RequestConditions,RequestContext)']/*" />
        public virtual async Task<Response> IfUnmodifiedSinceGetAsync(RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNull(requestConditions.IfMatch, nameof(requestConditions), "Service does not support the If-Match header for this operation.");
            Argument.AssertNull(requestConditions.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            Argument.AssertNull(requestConditions.IfModifiedSince, nameof(requestConditions), "Service does not support the If-Modified-Since header for this operation.");

            using var scope = ClientDiagnostics.CreateScope("RequestConditionCollapseClient.IfUnmodifiedSinceGet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateIfUnmodifiedSinceGetRequest(requestConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RequestConditionCollapseClient.xml" path="doc/members/member[@name='IfUnmodifiedSinceGet(RequestConditions,RequestContext)']/*" />
        public virtual Response IfUnmodifiedSinceGet(RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNull(requestConditions.IfMatch, nameof(requestConditions), "Service does not support the If-Match header for this operation.");
            Argument.AssertNull(requestConditions.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            Argument.AssertNull(requestConditions.IfModifiedSince, nameof(requestConditions), "Service does not support the If-Modified-Since header for this operation.");

            using var scope = ClientDiagnostics.CreateScope("RequestConditionCollapseClient.IfUnmodifiedSinceGet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateIfUnmodifiedSinceGetRequest(requestConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateCollapsePutRequest(RequestContent content, RequestConditions requestConditions, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/RequestConditionCollapse/", false);
            request.Uri = uri;
            if (requestConditions != null)
            {
                request.Headers.Add(requestConditions, "R");
            }
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateCollapseGetRequest(RequestConditions requestConditions, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/RequestConditionCollapse/", false);
            request.Uri = uri;
            if (requestConditions != null)
            {
                request.Headers.Add(requestConditions, "R");
            }
            return message;
        }

        internal HttpMessage CreateMissIfNoneMatchGetRequest(RequestConditions requestConditions, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/RequestConditionCollapse/missIfNoneMatch", false);
            request.Uri = uri;
            if (requestConditions != null)
            {
                request.Headers.Add(requestConditions, "R");
            }
            return message;
        }

        internal HttpMessage CreateMissIfMatchGetRequest(RequestConditions requestConditions, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/RequestConditionCollapse/missIfMatch", false);
            request.Uri = uri;
            if (requestConditions != null)
            {
                request.Headers.Add(requestConditions, "R");
            }
            return message;
        }

        internal HttpMessage CreateMissIfModifiedSinceGetRequest(RequestConditions requestConditions, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/RequestConditionCollapse/missIfModifiedSince", false);
            request.Uri = uri;
            if (requestConditions != null)
            {
                request.Headers.Add(requestConditions, "R");
            }
            return message;
        }

        internal HttpMessage CreateMissIfUnmodifiedSinceGetRequest(RequestConditions requestConditions, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/RequestConditionCollapse/missIfUnmodifiedSince", false);
            request.Uri = uri;
            if (requestConditions != null)
            {
                request.Headers.Add(requestConditions, "R");
            }
            return message;
        }

        internal HttpMessage CreateMissIfMatchIfNoneMatchGetRequest(RequestConditions requestConditions, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/RequestConditionCollapse/missIfMatchIfNoneMatch", false);
            request.Uri = uri;
            if (requestConditions != null)
            {
                request.Headers.Add(requestConditions, "R");
            }
            return message;
        }

        internal HttpMessage CreateIfModifiedSinceGetRequest(RequestConditions requestConditions, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/RequestConditionCollapse/ifModifiedSince", false);
            request.Uri = uri;
            if (requestConditions != null)
            {
                request.Headers.Add(requestConditions, "R");
            }
            return message;
        }

        internal HttpMessage CreateIfUnmodifiedSinceGetRequest(RequestConditions requestConditions, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/RequestConditionCollapse/ifUnmodifiedSince", false);
            request.Uri = uri;
            if (requestConditions != null)
            {
                request.Headers.Add(requestConditions, "R");
            }
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
