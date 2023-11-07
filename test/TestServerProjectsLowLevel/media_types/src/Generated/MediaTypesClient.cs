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
    // Data plane generated client.
    /// <summary> The MediaTypes service client. </summary>
    public partial class MediaTypesClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of MediaTypesClient for mocking. </summary>
        protected MediaTypesClient()
        {
        }

        /// <summary> Initializes a new instance of MediaTypesClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public MediaTypesClient(AzureKeyCredential credential) : this(credential, new MediaTypesClientOptions())
        {
        }

        /// <summary> Initializes a new instance of MediaTypesClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public MediaTypesClient(AzureKeyCredential credential, MediaTypesClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new MediaTypesClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = options.Endpoint;
        }

        /// <summary>
        /// [Protocol Method] Analyze body, that could be different media types.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "application/pdf" | "image/jpeg" | "image/png" | "image/tiff". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MediaTypesClient.xml" path="doc/members/member[@name='AnalyzeBodyAsync(RequestContent,ContentType,RequestContext)']/*" />
        public virtual async Task<Response> AnalyzeBodyAsync(RequestContent content, ContentType contentType, RequestContext context = null)
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

        /// <summary>
        /// [Protocol Method] Analyze body, that could be different media types.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "application/pdf" | "image/jpeg" | "image/png" | "image/tiff". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MediaTypesClient.xml" path="doc/members/member[@name='AnalyzeBody(RequestContent,ContentType,RequestContext)']/*" />
        public virtual Response AnalyzeBody(RequestContent content, ContentType contentType, RequestContext context = null)
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

        /// <summary>
        /// [Protocol Method] Analyze body, that could be different media types. Adds to AnalyzeBody by not having an accept type.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "application/pdf" | "image/jpeg" | "image/png" | "image/tiff". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MediaTypesClient.xml" path="doc/members/member[@name='AnalyzeBodyNoAcceptHeaderAsync(RequestContent,ContentType,RequestContext)']/*" />
        public virtual async Task<Response> AnalyzeBodyNoAcceptHeaderAsync(RequestContent content, ContentType contentType, RequestContext context = null)
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

        /// <summary>
        /// [Protocol Method] Analyze body, that could be different media types. Adds to AnalyzeBody by not having an accept type.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "application/pdf" | "image/jpeg" | "image/png" | "image/tiff". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MediaTypesClient.xml" path="doc/members/member[@name='AnalyzeBodyNoAcceptHeader(RequestContent,ContentType,RequestContext)']/*" />
        public virtual Response AnalyzeBodyNoAcceptHeader(RequestContent content, ContentType contentType, RequestContext context = null)
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

        /// <summary>
        /// [Protocol Method] Pass in contentType 'text/plain; charset=UTF-8' to pass test. Value for input does not matter
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
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MediaTypesClient.xml" path="doc/members/member[@name='ContentTypeWithEncodingAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> ContentTypeWithEncodingAsync(RequestContent content, RequestContext context = null)
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

        /// <summary>
        /// [Protocol Method] Pass in contentType 'text/plain; charset=UTF-8' to pass test. Value for input does not matter
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
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MediaTypesClient.xml" path="doc/members/member[@name='ContentTypeWithEncoding(RequestContent,RequestContext)']/*" />
        public virtual Response ContentTypeWithEncoding(RequestContent content, RequestContext context = null)
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

        /// <summary>
        /// [Protocol Method] Binary body with two content types. Pass in of {'hello': 'world'} for the application/json content type, and a byte stream of 'hello, world!' for application/octet-stream.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "application/octet-stream". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MediaTypesClient.xml" path="doc/members/member[@name='BinaryBodyWithTwoContentTypesAsync(RequestContent,ContentType,RequestContext)']/*" />
        public virtual async Task<Response> BinaryBodyWithTwoContentTypesAsync(RequestContent content, ContentType contentType, RequestContext context = null)
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

        /// <summary>
        /// [Protocol Method] Binary body with two content types. Pass in of {'hello': 'world'} for the application/json content type, and a byte stream of 'hello, world!' for application/octet-stream.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "application/octet-stream". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MediaTypesClient.xml" path="doc/members/member[@name='BinaryBodyWithTwoContentTypes(RequestContent,ContentType,RequestContext)']/*" />
        public virtual Response BinaryBodyWithTwoContentTypes(RequestContent content, ContentType contentType, RequestContext context = null)
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

        /// <summary>
        /// [Protocol Method] Binary body with three content types. Pass in string 'hello, world' with content type 'text/plain', {'hello': world'} with content type 'application/json' and a byte string for 'application/octet-stream'.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "application/octet-stream" | "text/plain". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MediaTypesClient.xml" path="doc/members/member[@name='BinaryBodyWithThreeContentTypesAsync(RequestContent,ContentType,RequestContext)']/*" />
        public virtual async Task<Response> BinaryBodyWithThreeContentTypesAsync(RequestContent content, ContentType contentType, RequestContext context = null)
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

        /// <summary>
        /// [Protocol Method] Binary body with three content types. Pass in string 'hello, world' with content type 'text/plain', {'hello': world'} with content type 'application/json' and a byte string for 'application/octet-stream'.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "application/octet-stream" | "text/plain". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MediaTypesClient.xml" path="doc/members/member[@name='BinaryBodyWithThreeContentTypes(RequestContent,ContentType,RequestContext)']/*" />
        public virtual Response BinaryBodyWithThreeContentTypes(RequestContent content, ContentType contentType, RequestContext context = null)
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

        /// <summary>
        /// [Protocol Method] Body with three types. Can be stream, string, or JSON. Pass in string 'hello, world' with content type 'text/plain', {'hello': world'} with content type 'application/json' and a byte string for 'application/octet-stream'.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "application/octet-stream" | "text/plain". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MediaTypesClient.xml" path="doc/members/member[@name='BodyThreeTypesAsync(RequestContent,ContentType,RequestContext)']/*" />
        public virtual async Task<Response> BodyThreeTypesAsync(RequestContent content, ContentType contentType, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.BodyThreeTypes");
            scope.Start();
            try
            {
                using HttpMessage message = CreateBodyThreeTypesRequest(content, contentType, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Body with three types. Can be stream, string, or JSON. Pass in string 'hello, world' with content type 'text/plain', {'hello': world'} with content type 'application/json' and a byte string for 'application/octet-stream'.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "application/octet-stream" | "text/plain". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MediaTypesClient.xml" path="doc/members/member[@name='BodyThreeTypes(RequestContent,ContentType,RequestContext)']/*" />
        public virtual Response BodyThreeTypes(RequestContent content, ContentType contentType, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.BodyThreeTypes");
            scope.Start();
            try
            {
                using HttpMessage message = CreateBodyThreeTypesRequest(content, contentType, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Body that's either text/plain or application/json
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "text/plain". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MediaTypesClient.xml" path="doc/members/member[@name='PutTextAndJsonBodyAsync(RequestContent,ContentType,RequestContext)']/*" />
        public virtual async Task<Response> PutTextAndJsonBodyAsync(RequestContent content, ContentType contentType, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.PutTextAndJsonBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutTextAndJsonBodyRequest(content, contentType, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Body that's either text/plain or application/json
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: "application/json" | "text/plain". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MediaTypesClient.xml" path="doc/members/member[@name='PutTextAndJsonBody(RequestContent,ContentType,RequestContext)']/*" />
        public virtual Response PutTextAndJsonBody(RequestContent content, ContentType contentType, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("MediaTypesClient.PutTextAndJsonBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutTextAndJsonBodyRequest(content, contentType, context);
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
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/mediatypes/analyze", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", contentType.ToString());
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateAnalyzeBodyNoAcceptHeaderRequest(RequestContent content, ContentType contentType, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/mediatypes/analyzeNoAccept", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", contentType.ToString());
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateContentTypeWithEncodingRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/mediatypes/contentTypeWithEncoding", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "text/plain; charset=UTF-8");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateBinaryBodyWithTwoContentTypesRequest(RequestContent content, ContentType contentType, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/mediatypes/binaryBodyTwoContentTypes", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "text/plain");
            request.Headers.Add("Content-Type", contentType.ToString());
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateBinaryBodyWithThreeContentTypesRequest(RequestContent content, ContentType contentType, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/mediatypes/binaryBodyThreeContentTypes", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "text/plain");
            request.Headers.Add("Content-Type", contentType.ToString());
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateBodyThreeTypesRequest(RequestContent content, ContentType contentType, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/mediatypes/bodyThreeTypes", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "text/plain");
            request.Headers.Add("Content-Type", contentType.ToString());
            request.Content = content;
            return message;
        }

        internal HttpMessage CreatePutTextAndJsonBodyRequest(RequestContent content, ContentType contentType, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/mediatypes/textAndJson", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "text/plain");
            request.Headers.Add("Content-Type", contentType.ToString());
            request.Content = content;
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
        private static ResponseClassifier _responseClassifier202;
        private static ResponseClassifier ResponseClassifier202 => _responseClassifier202 ??= new StatusCodeClassifier(stackalloc ushort[] { 202 });
    }
}
