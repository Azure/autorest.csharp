// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace url_LowLevel
{
    /// <summary> The PathItemsRest service client. </summary>
    public partial class PathItemsRestClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;

        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly string _globalStringPath;
        private readonly Uri _endpoint;
        private readonly string _globalStringQuery;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline { get => _pipeline; }

        /// <summary> Initializes a new instance of PathItemsRestClient for mocking. </summary>
        protected PathItemsRestClient()
        {
        }

        /// <summary> Initializes a new instance of PathItemsRestClient. </summary>
        /// <param name="globalStringPath"> A string value &apos;globalItemStringPath&apos; that appears in the path. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="globalStringQuery"> should contain value null. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="globalStringPath"/> or <paramref name="credential"/> is null. </exception>
        public PathItemsRestClient(string globalStringPath, AzureKeyCredential credential, Uri endpoint = null, string globalStringQuery = null, AutoRestUrlTestServiceClientOptions options = null)
        {
            if (globalStringPath == null)
            {
                throw new ArgumentNullException(nameof(globalStringPath));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }
            endpoint ??= new Uri("http://localhost:3000");

            options ??= new AutoRestUrlTestServiceClientOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() }, new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _globalStringPath = globalStringPath;
            _endpoint = endpoint;
            _globalStringQuery = globalStringQuery;
        }

        /// <summary> send globalStringPath=&apos;globalStringPath&apos;, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=&apos;globalStringQuery&apos;, pathItemStringQuery=&apos;pathItemStringQuery&apos;, localStringQuery=&apos;localStringQuery&apos;. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="options"> The request options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
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
        public virtual async Task<Response> GetAllWithValuesAsync(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PathItemsRestClient.GetAllWithValues");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAllWithValuesRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery);
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> send globalStringPath=&apos;globalStringPath&apos;, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=&apos;globalStringQuery&apos;, pathItemStringQuery=&apos;pathItemStringQuery&apos;, localStringQuery=&apos;localStringQuery&apos;. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="options"> The request options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
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
        public virtual Response GetAllWithValues(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PathItemsRestClient.GetAllWithValues");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAllWithValuesRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery);
                return _pipeline.ProcessMessage(message, _clientDiagnostics, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> send globalStringPath=&apos;globalStringPath&apos;, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=null, pathItemStringQuery=&apos;pathItemStringQuery&apos;, localStringQuery=&apos;localStringQuery&apos;. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="options"> The request options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
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
        public virtual async Task<Response> GetGlobalQueryNullAsync(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PathItemsRestClient.GetGlobalQueryNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetGlobalQueryNullRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery);
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> send globalStringPath=&apos;globalStringPath&apos;, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=null, pathItemStringQuery=&apos;pathItemStringQuery&apos;, localStringQuery=&apos;localStringQuery&apos;. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="options"> The request options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
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
        public virtual Response GetGlobalQueryNull(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PathItemsRestClient.GetGlobalQueryNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetGlobalQueryNullRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery);
                return _pipeline.ProcessMessage(message, _clientDiagnostics, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> send globalStringPath=globalStringPath, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=null, pathItemStringQuery=&apos;pathItemStringQuery&apos;, localStringQuery=null. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringQuery"> should contain null value. </param>
        /// <param name="options"> The request options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
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
        public virtual async Task<Response> GetGlobalAndLocalQueryNullAsync(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PathItemsRestClient.GetGlobalAndLocalQueryNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetGlobalAndLocalQueryNullRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery);
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> send globalStringPath=globalStringPath, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=null, pathItemStringQuery=&apos;pathItemStringQuery&apos;, localStringQuery=null. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringQuery"> should contain null value. </param>
        /// <param name="options"> The request options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
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
        public virtual Response GetGlobalAndLocalQueryNull(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PathItemsRestClient.GetGlobalAndLocalQueryNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetGlobalAndLocalQueryNullRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery);
                return _pipeline.ProcessMessage(message, _clientDiagnostics, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> send globalStringPath=&apos;globalStringPath&apos;, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=&apos;globalStringQuery&apos;, pathItemStringQuery=null, localStringQuery=null. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="pathItemStringQuery"> should contain value null. </param>
        /// <param name="localStringQuery"> should contain value null. </param>
        /// <param name="options"> The request options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
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
        public virtual async Task<Response> GetLocalPathItemQueryNullAsync(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PathItemsRestClient.GetLocalPathItemQueryNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetLocalPathItemQueryNullRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery);
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> send globalStringPath=&apos;globalStringPath&apos;, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=&apos;globalStringQuery&apos;, pathItemStringQuery=null, localStringQuery=null. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="pathItemStringQuery"> should contain value null. </param>
        /// <param name="localStringQuery"> should contain value null. </param>
        /// <param name="options"> The request options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
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
        public virtual Response GetLocalPathItemQueryNull(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("PathItemsRestClient.GetLocalPathItemQueryNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetLocalPathItemQueryNullRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery);
                return _pipeline.ProcessMessage(message, _clientDiagnostics, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetAllWithValuesRequest(string pathItemStringPath, string localStringPath, string pathItemStringQuery, string localStringQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
            uri.AppendPath(_globalStringPath, true);
            uri.AppendPath("/pathItemStringPath/", false);
            uri.AppendPath(pathItemStringPath, true);
            uri.AppendPath("/localStringPath/", false);
            uri.AppendPath(localStringPath, true);
            uri.AppendPath("/globalStringQuery/pathItemStringQuery/localStringQuery", false);
            if (pathItemStringQuery != null)
            {
                uri.AppendQuery("pathItemStringQuery", pathItemStringQuery, true);
            }
            if (_globalStringQuery != null)
            {
                uri.AppendQuery("globalStringQuery", _globalStringQuery, true);
            }
            if (localStringQuery != null)
            {
                uri.AppendQuery("localStringQuery", localStringQuery, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreateGetGlobalQueryNullRequest(string pathItemStringPath, string localStringPath, string pathItemStringQuery, string localStringQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
            uri.AppendPath(_globalStringPath, true);
            uri.AppendPath("/pathItemStringPath/", false);
            uri.AppendPath(pathItemStringPath, true);
            uri.AppendPath("/localStringPath/", false);
            uri.AppendPath(localStringPath, true);
            uri.AppendPath("/null/pathItemStringQuery/localStringQuery", false);
            if (pathItemStringQuery != null)
            {
                uri.AppendQuery("pathItemStringQuery", pathItemStringQuery, true);
            }
            if (_globalStringQuery != null)
            {
                uri.AppendQuery("globalStringQuery", _globalStringQuery, true);
            }
            if (localStringQuery != null)
            {
                uri.AppendQuery("localStringQuery", localStringQuery, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreateGetGlobalAndLocalQueryNullRequest(string pathItemStringPath, string localStringPath, string pathItemStringQuery, string localStringQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
            uri.AppendPath(_globalStringPath, true);
            uri.AppendPath("/pathItemStringPath/", false);
            uri.AppendPath(pathItemStringPath, true);
            uri.AppendPath("/localStringPath/", false);
            uri.AppendPath(localStringPath, true);
            uri.AppendPath("/null/pathItemStringQuery/null", false);
            if (pathItemStringQuery != null)
            {
                uri.AppendQuery("pathItemStringQuery", pathItemStringQuery, true);
            }
            if (_globalStringQuery != null)
            {
                uri.AppendQuery("globalStringQuery", _globalStringQuery, true);
            }
            if (localStringQuery != null)
            {
                uri.AppendQuery("localStringQuery", localStringQuery, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreateGetLocalPathItemQueryNullRequest(string pathItemStringPath, string localStringPath, string pathItemStringQuery, string localStringQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
            uri.AppendPath(_globalStringPath, true);
            uri.AppendPath("/pathItemStringPath/", false);
            uri.AppendPath(pathItemStringPath, true);
            uri.AppendPath("/localStringPath/", false);
            uri.AppendPath(localStringPath, true);
            uri.AppendPath("/globalStringQuery/null/null", false);
            if (pathItemStringQuery != null)
            {
                uri.AppendQuery("pathItemStringQuery", pathItemStringQuery, true);
            }
            if (_globalStringQuery != null)
            {
                uri.AppendQuery("globalStringQuery", _globalStringQuery, true);
            }
            if (localStringQuery != null)
            {
                uri.AppendQuery("localStringQuery", localStringQuery, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
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
    }
}
