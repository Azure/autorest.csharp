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
    // Data plane generated client.
    /// <summary> The PathItems service client. </summary>
    public partial class PathItemsClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly string _globalStringPath;
        private readonly Uri _endpoint;
        private readonly string _globalStringQuery;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of PathItemsClient for mocking. </summary>
        protected PathItemsClient()
        {
        }

        /// <summary> Initializes a new instance of PathItemsClient. </summary>
        /// <param name="globalStringPath"> A string value 'globalItemStringPath' that appears in the path. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="globalStringPath"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="globalStringPath"/> is an empty string, and was expected to be non-empty. </exception>
        public PathItemsClient(string globalStringPath, AzureKeyCredential credential) : this(globalStringPath, credential, new Uri("http://localhost:3000"), null, new AutoRestUrlTestServiceClientOptions())
        {
        }

        /// <summary> Initializes a new instance of PathItemsClient. </summary>
        /// <param name="globalStringPath"> A string value 'globalItemStringPath' that appears in the path. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="globalStringQuery"> should contain value null. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="globalStringPath"/>, <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="globalStringPath"/> is an empty string, and was expected to be non-empty. </exception>
        public PathItemsClient(string globalStringPath, AzureKeyCredential credential, Uri endpoint, string globalStringQuery, AutoRestUrlTestServiceClientOptions options)
        {
            Argument.AssertNotNullOrEmpty(globalStringPath, nameof(globalStringPath));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new AutoRestUrlTestServiceClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _globalStringPath = globalStringPath;
            _endpoint = endpoint;
            _globalStringQuery = globalStringQuery;
        }

        /// <summary>
        /// [Protocol Method] send globalStringPath='globalStringPath', pathItemStringPath='pathItemStringPath', localStringPath='localStringPath', globalStringQuery='globalStringQuery', pathItemStringQuery='pathItemStringQuery', localStringQuery='localStringQuery'
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="pathItemStringPath"> A string value 'pathItemStringPath' that appears in the path. </param>
        /// <param name="localStringPath"> should contain value 'localStringPath'. </param>
        /// <param name="pathItemStringQuery"> A string value 'pathItemStringQuery' that appears as a query parameter. </param>
        /// <param name="localStringQuery"> should contain value 'localStringQuery'. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathItemsClient.xml" path="doc/members/member[@name='GetAllWithValuesAsync(string,string,string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetAllWithValuesAsync(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(pathItemStringPath, nameof(pathItemStringPath));
            Argument.AssertNotNullOrEmpty(localStringPath, nameof(localStringPath));

            using var scope = ClientDiagnostics.CreateScope("PathItemsClient.GetAllWithValues");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAllWithValuesRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] send globalStringPath='globalStringPath', pathItemStringPath='pathItemStringPath', localStringPath='localStringPath', globalStringQuery='globalStringQuery', pathItemStringQuery='pathItemStringQuery', localStringQuery='localStringQuery'
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="pathItemStringPath"> A string value 'pathItemStringPath' that appears in the path. </param>
        /// <param name="localStringPath"> should contain value 'localStringPath'. </param>
        /// <param name="pathItemStringQuery"> A string value 'pathItemStringQuery' that appears as a query parameter. </param>
        /// <param name="localStringQuery"> should contain value 'localStringQuery'. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathItemsClient.xml" path="doc/members/member[@name='GetAllWithValues(string,string,string,string,RequestContext)']/*" />
        public virtual Response GetAllWithValues(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(pathItemStringPath, nameof(pathItemStringPath));
            Argument.AssertNotNullOrEmpty(localStringPath, nameof(localStringPath));

            using var scope = ClientDiagnostics.CreateScope("PathItemsClient.GetAllWithValues");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAllWithValuesRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] send globalStringPath='globalStringPath', pathItemStringPath='pathItemStringPath', localStringPath='localStringPath', globalStringQuery=null, pathItemStringQuery='pathItemStringQuery', localStringQuery='localStringQuery'
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="pathItemStringPath"> A string value 'pathItemStringPath' that appears in the path. </param>
        /// <param name="localStringPath"> should contain value 'localStringPath'. </param>
        /// <param name="pathItemStringQuery"> A string value 'pathItemStringQuery' that appears as a query parameter. </param>
        /// <param name="localStringQuery"> should contain value 'localStringQuery'. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathItemsClient.xml" path="doc/members/member[@name='GetGlobalQueryNullAsync(string,string,string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetGlobalQueryNullAsync(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(pathItemStringPath, nameof(pathItemStringPath));
            Argument.AssertNotNullOrEmpty(localStringPath, nameof(localStringPath));

            using var scope = ClientDiagnostics.CreateScope("PathItemsClient.GetGlobalQueryNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetGlobalQueryNullRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] send globalStringPath='globalStringPath', pathItemStringPath='pathItemStringPath', localStringPath='localStringPath', globalStringQuery=null, pathItemStringQuery='pathItemStringQuery', localStringQuery='localStringQuery'
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="pathItemStringPath"> A string value 'pathItemStringPath' that appears in the path. </param>
        /// <param name="localStringPath"> should contain value 'localStringPath'. </param>
        /// <param name="pathItemStringQuery"> A string value 'pathItemStringQuery' that appears as a query parameter. </param>
        /// <param name="localStringQuery"> should contain value 'localStringQuery'. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathItemsClient.xml" path="doc/members/member[@name='GetGlobalQueryNull(string,string,string,string,RequestContext)']/*" />
        public virtual Response GetGlobalQueryNull(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(pathItemStringPath, nameof(pathItemStringPath));
            Argument.AssertNotNullOrEmpty(localStringPath, nameof(localStringPath));

            using var scope = ClientDiagnostics.CreateScope("PathItemsClient.GetGlobalQueryNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetGlobalQueryNullRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] send globalStringPath=globalStringPath, pathItemStringPath='pathItemStringPath', localStringPath='localStringPath', globalStringQuery=null, pathItemStringQuery='pathItemStringQuery', localStringQuery=null
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="pathItemStringPath"> A string value 'pathItemStringPath' that appears in the path. </param>
        /// <param name="localStringPath"> should contain value 'localStringPath'. </param>
        /// <param name="pathItemStringQuery"> A string value 'pathItemStringQuery' that appears as a query parameter. </param>
        /// <param name="localStringQuery"> should contain null value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathItemsClient.xml" path="doc/members/member[@name='GetGlobalAndLocalQueryNullAsync(string,string,string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetGlobalAndLocalQueryNullAsync(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(pathItemStringPath, nameof(pathItemStringPath));
            Argument.AssertNotNullOrEmpty(localStringPath, nameof(localStringPath));

            using var scope = ClientDiagnostics.CreateScope("PathItemsClient.GetGlobalAndLocalQueryNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetGlobalAndLocalQueryNullRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] send globalStringPath=globalStringPath, pathItemStringPath='pathItemStringPath', localStringPath='localStringPath', globalStringQuery=null, pathItemStringQuery='pathItemStringQuery', localStringQuery=null
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="pathItemStringPath"> A string value 'pathItemStringPath' that appears in the path. </param>
        /// <param name="localStringPath"> should contain value 'localStringPath'. </param>
        /// <param name="pathItemStringQuery"> A string value 'pathItemStringQuery' that appears as a query parameter. </param>
        /// <param name="localStringQuery"> should contain null value. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathItemsClient.xml" path="doc/members/member[@name='GetGlobalAndLocalQueryNull(string,string,string,string,RequestContext)']/*" />
        public virtual Response GetGlobalAndLocalQueryNull(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(pathItemStringPath, nameof(pathItemStringPath));
            Argument.AssertNotNullOrEmpty(localStringPath, nameof(localStringPath));

            using var scope = ClientDiagnostics.CreateScope("PathItemsClient.GetGlobalAndLocalQueryNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetGlobalAndLocalQueryNullRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] send globalStringPath='globalStringPath', pathItemStringPath='pathItemStringPath', localStringPath='localStringPath', globalStringQuery='globalStringQuery', pathItemStringQuery=null, localStringQuery=null
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="pathItemStringPath"> A string value 'pathItemStringPath' that appears in the path. </param>
        /// <param name="localStringPath"> should contain value 'localStringPath'. </param>
        /// <param name="pathItemStringQuery"> should contain value null. </param>
        /// <param name="localStringQuery"> should contain value null. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathItemsClient.xml" path="doc/members/member[@name='GetLocalPathItemQueryNullAsync(string,string,string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetLocalPathItemQueryNullAsync(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(pathItemStringPath, nameof(pathItemStringPath));
            Argument.AssertNotNullOrEmpty(localStringPath, nameof(localStringPath));

            using var scope = ClientDiagnostics.CreateScope("PathItemsClient.GetLocalPathItemQueryNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetLocalPathItemQueryNullRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] send globalStringPath='globalStringPath', pathItemStringPath='pathItemStringPath', localStringPath='localStringPath', globalStringQuery='globalStringQuery', pathItemStringQuery=null, localStringQuery=null
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="pathItemStringPath"> A string value 'pathItemStringPath' that appears in the path. </param>
        /// <param name="localStringPath"> should contain value 'localStringPath'. </param>
        /// <param name="pathItemStringQuery"> should contain value null. </param>
        /// <param name="localStringQuery"> should contain value null. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/PathItemsClient.xml" path="doc/members/member[@name='GetLocalPathItemQueryNull(string,string,string,string,RequestContext)']/*" />
        public virtual Response GetLocalPathItemQueryNull(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(pathItemStringPath, nameof(pathItemStringPath));
            Argument.AssertNotNullOrEmpty(localStringPath, nameof(localStringPath));

            using var scope = ClientDiagnostics.CreateScope("PathItemsClient.GetLocalPathItemQueryNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetLocalPathItemQueryNullRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetAllWithValuesRequest(string pathItemStringPath, string localStringPath, string pathItemStringQuery, string localStringQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
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
            return message;
        }

        internal HttpMessage CreateGetGlobalQueryNullRequest(string pathItemStringPath, string localStringPath, string pathItemStringQuery, string localStringQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
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
            return message;
        }

        internal HttpMessage CreateGetGlobalAndLocalQueryNullRequest(string pathItemStringPath, string localStringPath, string pathItemStringQuery, string localStringQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
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
            return message;
        }

        internal HttpMessage CreateGetLocalPathItemQueryNullRequest(string pathItemStringPath, string localStringPath, string pathItemStringQuery, string localStringQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
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
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
