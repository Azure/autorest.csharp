// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace media_types_LowLevel
{
    /// <summary> The MediaTypes service client. </summary>
    public partial class MediaTypesClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        internal ClientDiagnostics ClientDiagnostics { get; }
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of MediaTypesClient for mocking. </summary>
        protected MediaTypesClient()
        {
        }

        /// <summary> Initializes a new instance of MediaTypesClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public MediaTypesClient(AzureKeyCredential credential, Uri endpoint = null, MediaTypesClientOptions options = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            endpoint ??= new Uri("http://localhost:3000");
            options ??= new MediaTypesClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary> Analyze body, that could be different media types. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;application/pdf&quot; | &quot;image/jpeg&quot; | &quot;image/png&quot; | &quot;image/tiff&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> AnalyzeBodyAsync(RequestContent content, ContentType contentType, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.AnalyzeBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeBodyRequest(content, contentType, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Analyze body, that could be different media types. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;application/pdf&quot; | &quot;image/jpeg&quot; | &quot;image/png&quot; | &quot;image/tiff&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
#pragma warning disable AZC0002
        public virtual Response AnalyzeBody(RequestContent content, ContentType contentType, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.AnalyzeBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeBodyRequest(content, contentType, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Analyze body, that could be different media types. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   source: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> AnalyzeBodyAsync(RequestContent content, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.AnalyzeBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeBodyRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Analyze body, that could be different media types. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   source: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response AnalyzeBody(RequestContent content, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.AnalyzeBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeBodyRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Analyze body, that could be different media types. Adds to AnalyzeBody by not having an accept type. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;application/pdf&quot; | &quot;image/jpeg&quot; | &quot;image/png&quot; | &quot;image/tiff&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> AnalyzeBodyNoAcceptHeaderAsync(RequestContent content, ContentType contentType, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.AnalyzeBodyNoAcceptHeader");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeBodyNoAcceptHeaderRequest(content, contentType, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Analyze body, that could be different media types. Adds to AnalyzeBody by not having an accept type. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;application/pdf&quot; | &quot;image/jpeg&quot; | &quot;image/png&quot; | &quot;image/tiff&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
#pragma warning disable AZC0002
        public virtual Response AnalyzeBodyNoAcceptHeader(RequestContent content, ContentType contentType, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.AnalyzeBodyNoAcceptHeader");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeBodyNoAcceptHeaderRequest(content, contentType, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Analyze body, that could be different media types. Adds to AnalyzeBody by not having an accept type. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   source: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> AnalyzeBodyNoAcceptHeaderAsync(RequestContent content, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.AnalyzeBodyNoAcceptHeader");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeBodyNoAcceptHeaderRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Analyze body, that could be different media types. Adds to AnalyzeBody by not having an accept type. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   source: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response AnalyzeBodyNoAcceptHeader(RequestContent content, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.AnalyzeBodyNoAcceptHeader");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeBodyNoAcceptHeaderRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Pass in contentType &apos;text/plain; charset=UTF-8&apos; to pass test. Value for input does not matter. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> ContentTypeWithEncodingAsync(RequestContent content, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.ContentTypeWithEncoding");
            scope.Start();
            try
            {
                using HttpMessage message = CreateContentTypeWithEncodingRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Pass in contentType &apos;text/plain; charset=UTF-8&apos; to pass test. Value for input does not matter. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
#pragma warning disable AZC0002
        public virtual Response ContentTypeWithEncoding(RequestContent content, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.ContentTypeWithEncoding");
            scope.Start();
            try
            {
                using HttpMessage message = CreateContentTypeWithEncodingRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Binary body with two content types. Pass in of {&apos;hello&apos;: &apos;world&apos;} for the application/json content type, and a byte stream of &apos;hello, world!&apos; for application/octet-stream. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;application/json&quot; | &quot;application/octet-stream&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
#pragma warning disable AZC0002
        public virtual async Task<Response> BinaryBodyWithTwoContentTypesAsync(RequestContent content, ContentType contentType, RequestContext context = null)
#pragma warning restore AZC0002
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.BinaryBodyWithTwoContentTypes");
            scope.Start();
            try
            {
                using HttpMessage message = CreateBinaryBodyWithTwoContentTypesRequest(content, contentType, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Binary body with two content types. Pass in of {&apos;hello&apos;: &apos;world&apos;} for the application/json content type, and a byte stream of &apos;hello, world!&apos; for application/octet-stream. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;application/json&quot; | &quot;application/octet-stream&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
#pragma warning disable AZC0002
        public virtual Response BinaryBodyWithTwoContentTypes(RequestContent content, ContentType contentType, RequestContext context = null)
#pragma warning restore AZC0002
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.BinaryBodyWithTwoContentTypes");
            scope.Start();
            try
            {
                using HttpMessage message = CreateBinaryBodyWithTwoContentTypesRequest(content, contentType, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Binary body with three content types. Pass in string &apos;hello, world&apos; with content type &apos;text/plain&apos;, {&apos;hello&apos;: world&apos;} with content type &apos;application/json&apos; and a byte string for &apos;application/octet-stream&apos;. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;application/json&quot; | &quot;application/octet-stream&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
#pragma warning disable AZC0002
        public virtual async Task<Response> BinaryBodyWithThreeContentTypesAsync(RequestContent content, ContentType contentType, RequestContext context = null)
#pragma warning restore AZC0002
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.BinaryBodyWithThreeContentTypes");
            scope.Start();
            try
            {
                using HttpMessage message = CreateBinaryBodyWithThreeContentTypesRequest(content, contentType, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Binary body with three content types. Pass in string &apos;hello, world&apos; with content type &apos;text/plain&apos;, {&apos;hello&apos;: world&apos;} with content type &apos;application/json&apos; and a byte string for &apos;application/octet-stream&apos;. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;application/json&quot; | &quot;application/octet-stream&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
#pragma warning disable AZC0002
        public virtual Response BinaryBodyWithThreeContentTypes(RequestContent content, ContentType contentType, RequestContext context = null)
#pragma warning restore AZC0002
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.BinaryBodyWithThreeContentTypes");
            scope.Start();
            try
            {
                using HttpMessage message = CreateBinaryBodyWithThreeContentTypesRequest(content, contentType, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Binary body with three content types. Pass in string &apos;hello, world&apos; with content type &apos;text/plain&apos;, {&apos;hello&apos;: world&apos;} with content type &apos;application/json&apos; and a byte string for &apos;application/octet-stream&apos;. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
#pragma warning disable AZC0002
        public virtual async Task<Response> BinaryBodyWithThreeContentTypesAsync(RequestContent content, RequestContext context = null)
#pragma warning restore AZC0002
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.BinaryBodyWithThreeContentTypes");
            scope.Start();
            try
            {
                using HttpMessage message = CreateBinaryBodyWithThreeContentTypesRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Binary body with three content types. Pass in string &apos;hello, world&apos; with content type &apos;text/plain&apos;, {&apos;hello&apos;: world&apos;} with content type &apos;application/json&apos; and a byte string for &apos;application/octet-stream&apos;. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
#pragma warning disable AZC0002
        public virtual Response BinaryBodyWithThreeContentTypes(RequestContent content, RequestContext context = null)
#pragma warning restore AZC0002
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.BinaryBodyWithThreeContentTypes");
            scope.Start();
            try
            {
                using HttpMessage message = CreateBinaryBodyWithThreeContentTypesRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateAnalyzeBodyRequest(RequestContent content, ContentType contentType, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/mediatypes/analyze", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", contentType.ToString());
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreateAnalyzeBodyRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/mediatypes/analyze", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreateAnalyzeBodyNoAcceptHeaderRequest(RequestContent content, ContentType contentType, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/mediatypes/analyzeNoAccept", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", contentType.ToString());
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier202.Instance;
            return message;
        }

        internal HttpMessage CreateAnalyzeBodyNoAcceptHeaderRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/mediatypes/analyzeNoAccept", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier202.Instance;
            return message;
        }

        internal HttpMessage CreateContentTypeWithEncodingRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/mediatypes/contentTypeWithEncoding", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "text/plain; charset=UTF-8");
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreateBinaryBodyWithTwoContentTypesRequest(RequestContent content, ContentType contentType, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/mediatypes/binaryBodyTwoContentTypes", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "text/plain");
            request.Headers.Add("Content-Type", contentType.ToString());
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreateBinaryBodyWithThreeContentTypesRequest(RequestContent content, ContentType contentType, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/mediatypes/binaryBodyThreeContentTypes", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "text/plain");
            request.Headers.Add("Content-Type", contentType.ToString());
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreateBinaryBodyWithThreeContentTypesRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/mediatypes/binaryBodyThreeContentTypes", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "text/plain");
            request.Headers.Add("Content-Type", "text/plain");
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        private sealed class ResponseClassifier200 : ResponseClassifier
        {
            private static ResponseClassifier _instance;
            public static ResponseClassifier Instance => _instance ??= new ResponseClassifier200();
            public override bool IsErrorResponse(HttpMessage message)
            {
                return message.Response.Status switch
                {
                    200 => false,
                    _ => true
                };
            }
        }
        private sealed class ResponseClassifier202 : ResponseClassifier
        {
            private static ResponseClassifier _instance;
            public static ResponseClassifier Instance => _instance ??= new ResponseClassifier202();
            public override bool IsErrorResponse(HttpMessage message)
            {
                return message.Response.Status switch
                {
                    202 => false,
                    _ => true
                };
            }
        }
    }
}
