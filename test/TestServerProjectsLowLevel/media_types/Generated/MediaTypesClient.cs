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
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline { get => _pipeline; }
        private HttpPipeline _pipeline;
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private Uri endpoint;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly MediaTypesRestClient RestClient;

        /// <summary> Initializes a new instance of MediaTypesClient for mocking. </summary>
        protected MediaTypesClient()
        {
        }

        /// <summary> Initializes a new instance of MediaTypesClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public MediaTypesClient(AzureKeyCredential credential, Uri endpoint = null, MediaTypesClientOptions options = null)
        {
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }
            endpoint ??= new Uri("http://localhost:3000");

            options ??= new MediaTypesClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _keyCredential = credential;
            var authPolicy = new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader);
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() }, new HttpPipelinePolicy[] { authPolicy }, new ResponseClassifier());
            this.endpoint = endpoint;
            RestClient = new MediaTypesRestClient(_clientDiagnostics, _pipeline, endpoint);
        }

        /// <summary> Analyze body, that could be different media types. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> AnalyzeBodyAsync(RequestContent content, ContentType contentType, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("MediaTypesClient.AnalyzeBody");
            scope.Start();
            try
            {
                return await RestClient.AnalyzeBodyAsync(content, contentType, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Analyze body, that could be different media types. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual Response AnalyzeBody(RequestContent content, ContentType contentType, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("MediaTypesClient.AnalyzeBody");
            scope.Start();
            try
            {
                return RestClient.AnalyzeBody(content, contentType, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Analyze body, that could be different media types. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   source: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> AnalyzeBodyAsync(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("MediaTypesClient.AnalyzeBody");
            scope.Start();
            try
            {
                return await RestClient.AnalyzeBodyAsync(content, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Analyze body, that could be different media types. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   source: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response AnalyzeBody(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("MediaTypesClient.AnalyzeBody");
            scope.Start();
            try
            {
                return RestClient.AnalyzeBody(content, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Analyze body, that could be different media types. Adds to AnalyzeBody by not having an accept type. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> AnalyzeBodyNoAcceptHeaderAsync(RequestContent content, ContentType contentType, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("MediaTypesClient.AnalyzeBodyNoAcceptHeader");
            scope.Start();
            try
            {
                return await RestClient.AnalyzeBodyNoAcceptHeaderAsync(content, contentType, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Analyze body, that could be different media types. Adds to AnalyzeBody by not having an accept type. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual Response AnalyzeBodyNoAcceptHeader(RequestContent content, ContentType contentType, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("MediaTypesClient.AnalyzeBodyNoAcceptHeader");
            scope.Start();
            try
            {
                return RestClient.AnalyzeBodyNoAcceptHeader(content, contentType, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Analyze body, that could be different media types. Adds to AnalyzeBody by not having an accept type. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   source: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> AnalyzeBodyNoAcceptHeaderAsync(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("MediaTypesClient.AnalyzeBodyNoAcceptHeader");
            scope.Start();
            try
            {
                return await RestClient.AnalyzeBodyNoAcceptHeaderAsync(content, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Analyze body, that could be different media types. Adds to AnalyzeBody by not having an accept type. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   source: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response AnalyzeBodyNoAcceptHeader(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("MediaTypesClient.AnalyzeBodyNoAcceptHeader");
            scope.Start();
            try
            {
                return RestClient.AnalyzeBodyNoAcceptHeader(content, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Pass in contentType &apos;text/plain; encoding=UTF-8&apos; to pass test. Value for input does not matter. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> ContentTypeWithEncodingAsync(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("MediaTypesClient.ContentTypeWithEncoding");
            scope.Start();
            try
            {
                return await RestClient.ContentTypeWithEncodingAsync(content, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Pass in contentType &apos;text/plain; encoding=UTF-8&apos; to pass test. Value for input does not matter. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual Response ContentTypeWithEncoding(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("MediaTypesClient.ContentTypeWithEncoding");
            scope.Start();
            try
            {
                return RestClient.ContentTypeWithEncoding(content, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
