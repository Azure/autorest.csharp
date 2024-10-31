// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace SpecialHeaders.ConditionalRequest
{
    // Data plane generated client.
    /// <summary> Illustrates conditional request headers. </summary>
    public partial class ConditionalRequestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ConditionalRequestClient. </summary>
        public ConditionalRequestClient() : this(new Uri("http://localhost:3000"), new ConditionalRequestClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ConditionalRequestClient. </summary>
        /// <param name="endpoint"> Service host. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public ConditionalRequestClient(Uri endpoint, ConditionalRequestClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ConditionalRequestClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Check when only If-Match in header is defined.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConditionalRequestClient.xml" path="doc/members/member[@name='PostIfMatchAsync(ETag?,RequestContext)']/*" />
        public virtual async Task<Response> PostIfMatchAsync(ETag? ifMatch = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConditionalRequestClient.PostIfMatch");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostIfMatchRequest(ifMatch, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Check when only If-Match in header is defined.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> The request should only proceed if an entity matches this string. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConditionalRequestClient.xml" path="doc/members/member[@name='PostIfMatch(ETag?,RequestContext)']/*" />
        public virtual Response PostIfMatch(ETag? ifMatch = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConditionalRequestClient.PostIfMatch");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostIfMatchRequest(ifMatch, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Check when only If-None-Match in header is defined.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifNoneMatch"> The request should only proceed if no entity matches this string. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConditionalRequestClient.xml" path="doc/members/member[@name='PostIfNoneMatchAsync(ETag?,RequestContext)']/*" />
        public virtual async Task<Response> PostIfNoneMatchAsync(ETag? ifNoneMatch = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConditionalRequestClient.PostIfNoneMatch");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostIfNoneMatchRequest(ifNoneMatch, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Check when only If-None-Match in header is defined.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifNoneMatch"> The request should only proceed if no entity matches this string. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConditionalRequestClient.xml" path="doc/members/member[@name='PostIfNoneMatch(ETag?,RequestContext)']/*" />
        public virtual Response PostIfNoneMatch(ETag? ifNoneMatch = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ConditionalRequestClient.PostIfNoneMatch");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostIfNoneMatchRequest(ifNoneMatch, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Check when only If-Modified-Since in header is defined.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConditionalRequestClient.xml" path="doc/members/member[@name='HeadIfModifiedSinceAsync(RequestConditions,RequestContext)']/*" />
        public virtual async Task<Response> HeadIfModifiedSinceAsync(RequestConditions requestConditions = null, RequestContext context = null)
        {
            if (requestConditions?.IfMatch is not null)
            {
                throw new ArgumentNullException(nameof(requestConditions), "Service does not support the If-Match header for this operation.");
            }
            if (requestConditions?.IfNoneMatch is not null)
            {
                throw new ArgumentNullException(nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            }
            if (requestConditions?.IfUnmodifiedSince is not null)
            {
                throw new ArgumentNullException(nameof(requestConditions), "Service does not support the If-Unmodified-Since header for this operation.");
            }

            using var scope = ClientDiagnostics.CreateScope("ConditionalRequestClient.HeadIfModifiedSince");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHeadIfModifiedSinceRequest(requestConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Check when only If-Modified-Since in header is defined.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConditionalRequestClient.xml" path="doc/members/member[@name='HeadIfModifiedSince(RequestConditions,RequestContext)']/*" />
        public virtual Response HeadIfModifiedSince(RequestConditions requestConditions = null, RequestContext context = null)
        {
            if (requestConditions?.IfMatch is not null)
            {
                throw new ArgumentNullException(nameof(requestConditions), "Service does not support the If-Match header for this operation.");
            }
            if (requestConditions?.IfNoneMatch is not null)
            {
                throw new ArgumentNullException(nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            }
            if (requestConditions?.IfUnmodifiedSince is not null)
            {
                throw new ArgumentNullException(nameof(requestConditions), "Service does not support the If-Unmodified-Since header for this operation.");
            }

            using var scope = ClientDiagnostics.CreateScope("ConditionalRequestClient.HeadIfModifiedSince");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHeadIfModifiedSinceRequest(requestConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Check when only If-Unmodified-Since in header is defined.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConditionalRequestClient.xml" path="doc/members/member[@name='PostIfUnmodifiedSinceAsync(RequestConditions,RequestContext)']/*" />
        public virtual async Task<Response> PostIfUnmodifiedSinceAsync(RequestConditions requestConditions = null, RequestContext context = null)
        {
            if (requestConditions?.IfMatch is not null)
            {
                throw new ArgumentNullException(nameof(requestConditions), "Service does not support the If-Match header for this operation.");
            }
            if (requestConditions?.IfNoneMatch is not null)
            {
                throw new ArgumentNullException(nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            }
            if (requestConditions?.IfModifiedSince is not null)
            {
                throw new ArgumentNullException(nameof(requestConditions), "Service does not support the If-Modified-Since header for this operation.");
            }

            using var scope = ClientDiagnostics.CreateScope("ConditionalRequestClient.PostIfUnmodifiedSince");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostIfUnmodifiedSinceRequest(requestConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Check when only If-Unmodified-Since in header is defined.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ConditionalRequestClient.xml" path="doc/members/member[@name='PostIfUnmodifiedSince(RequestConditions,RequestContext)']/*" />
        public virtual Response PostIfUnmodifiedSince(RequestConditions requestConditions = null, RequestContext context = null)
        {
            if (requestConditions?.IfMatch is not null)
            {
                throw new ArgumentNullException(nameof(requestConditions), "Service does not support the If-Match header for this operation.");
            }
            if (requestConditions?.IfNoneMatch is not null)
            {
                throw new ArgumentNullException(nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            }
            if (requestConditions?.IfModifiedSince is not null)
            {
                throw new ArgumentNullException(nameof(requestConditions), "Service does not support the If-Modified-Since header for this operation.");
            }

            using var scope = ClientDiagnostics.CreateScope("ConditionalRequestClient.PostIfUnmodifiedSince");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostIfUnmodifiedSinceRequest(requestConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreatePostIfMatchRequest(ETag? ifMatch, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/special-headers/conditional-request/if-match", false);
            request.Uri = uri;
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch.Value);
            }
            return message;
        }

        internal HttpMessage CreatePostIfNoneMatchRequest(ETag? ifNoneMatch, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/special-headers/conditional-request/if-none-match", false);
            request.Uri = uri;
            if (ifNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", ifNoneMatch.Value);
            }
            return message;
        }

        internal HttpMessage CreateHeadIfModifiedSinceRequest(RequestConditions requestConditions, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/special-headers/conditional-request/if-modified-since", false);
            request.Uri = uri;
            if (requestConditions != null)
            {
                request.Headers.Add(requestConditions, "R");
            }
            return message;
        }

        internal HttpMessage CreatePostIfUnmodifiedSinceRequest(RequestConditions requestConditions, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/special-headers/conditional-request/if-unmodified-since", false);
            request.Uri = uri;
            if (requestConditions != null)
            {
                request.Headers.Add(requestConditions, "R");
            }
            return message;
        }

        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
