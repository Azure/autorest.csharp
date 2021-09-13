// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace body_string_LowLevel
{
    /// <summary> The Enum service client. </summary>
    public partial class EnumClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline { get => _pipeline; }
        private HttpPipeline _pipeline;
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private Uri endpoint;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly EnumRestClient RestClient;

        /// <summary> Initializes a new instance of EnumClient for mocking. </summary>
        protected EnumClient()
        {
        }

        /// <summary> Initializes a new instance of EnumClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public EnumClient(AzureKeyCredential credential, Uri endpoint = null, AutoRestSwaggerBATServiceClientOptions options = null)
        {
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }
            endpoint ??= new Uri("http://localhost:3000");

            options ??= new AutoRestSwaggerBATServiceClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _keyCredential = credential;
            var authPolicy = new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader);
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() }, new HttpPipelinePolicy[] { authPolicy }, new ResponseClassifier());
            this.endpoint = endpoint;
            RestClient = new EnumRestClient(_clientDiagnostics, _pipeline, endpoint);
        }

        /// <summary> Get enum value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> GetNotExpandableAsync(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("EnumClient.GetNotExpandable");
            scope.Start();
            try
            {
                return await RestClient.GetNotExpandableAsync(options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get enum value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response GetNotExpandable(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("EnumClient.GetNotExpandable");
            scope.Start();
            try
            {
                return RestClient.GetNotExpandable(options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Sends value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> PutNotExpandableAsync(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("EnumClient.PutNotExpandable");
            scope.Start();
            try
            {
                return await RestClient.PutNotExpandableAsync(content, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Sends value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response PutNotExpandable(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("EnumClient.PutNotExpandable");
            scope.Start();
            try
            {
                return RestClient.PutNotExpandable(content, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get enum value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> GetReferencedAsync(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("EnumClient.GetReferenced");
            scope.Start();
            try
            {
                return await RestClient.GetReferencedAsync(options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get enum value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response GetReferenced(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("EnumClient.GetReferenced");
            scope.Start();
            try
            {
                return RestClient.GetReferenced(options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Sends value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> PutReferencedAsync(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("EnumClient.PutReferenced");
            scope.Start();
            try
            {
                return await RestClient.PutReferencedAsync(content, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Sends value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response PutReferenced(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("EnumClient.PutReferenced");
            scope.Start();
            try
            {
                return RestClient.PutReferenced(content, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get value &apos;green-color&apos; from the constant. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   ColorConstant: ColorConstant,
        ///   field1: string
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> GetReferencedConstantAsync(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("EnumClient.GetReferencedConstant");
            scope.Start();
            try
            {
                return await RestClient.GetReferencedConstantAsync(options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get value &apos;green-color&apos; from the constant. </summary>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   ColorConstant: ColorConstant,
        ///   field1: string
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response GetReferencedConstant(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("EnumClient.GetReferencedConstant");
            scope.Start();
            try
            {
                return RestClient.GetReferencedConstant(options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Sends value &apos;green-color&apos; from a constant. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   ColorConstant: ColorConstant (required),
        ///   field1: string
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> PutReferencedConstantAsync(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("EnumClient.PutReferencedConstant");
            scope.Start();
            try
            {
                return await RestClient.PutReferencedConstantAsync(content, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Sends value &apos;green-color&apos; from a constant. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   ColorConstant: ColorConstant (required),
        ///   field1: string
        /// }
        /// </code>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response PutReferencedConstant(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("EnumClient.PutReferencedConstant");
            scope.Start();
            try
            {
                return RestClient.PutReferencedConstant(content, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
