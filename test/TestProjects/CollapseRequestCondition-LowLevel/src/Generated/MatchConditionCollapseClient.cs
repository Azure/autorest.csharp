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
    // Data plane generated client.
    /// <summary> The MatchConditionCollapse service client. </summary>
    public partial class MatchConditionCollapseClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of MatchConditionCollapseClient for mocking. </summary>
        protected MatchConditionCollapseClient()
        {
        }

        /// <summary> Initializes a new instance of MatchConditionCollapseClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public MatchConditionCollapseClient(AzureKeyCredential credential) : this(new Uri("http://localhost:3000"), credential, new CollapseRequestConditionsClientOptions())
        {
        }

        /// <summary> Initializes a new instance of MatchConditionCollapseClient. </summary>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public MatchConditionCollapseClient(Uri endpoint, AzureKeyCredential credential, CollapseRequestConditionsClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new CollapseRequestConditionsClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="otherHeader"> other header. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MatchConditionCollapseClient.xml" path="doc/members/member[@name='CollapseGetWithHeadAsync(string,MatchConditions,RequestContext)']/*" />
        public virtual async Task<Response> CollapseGetWithHeadAsync(string otherHeader = null, MatchConditions matchConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MatchConditionCollapseClient.CollapseGetWithHead");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCollapseGetWithHeadRequest(otherHeader, matchConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="otherHeader"> other header. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MatchConditionCollapseClient.xml" path="doc/members/member[@name='CollapseGetWithHead(string,MatchConditions,RequestContext)']/*" />
        public virtual Response CollapseGetWithHead(string otherHeader = null, MatchConditions matchConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MatchConditionCollapseClient.CollapseGetWithHead");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCollapseGetWithHeadRequest(otherHeader, matchConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MatchConditionCollapseClient.xml" path="doc/members/member[@name='CollapsePutAsync(RequestContent,MatchConditions,RequestContext)']/*" />
        public virtual async Task<Response> CollapsePutAsync(RequestContent content, MatchConditions matchConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MatchConditionCollapseClient.CollapsePut");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCollapsePutRequest(content, matchConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MatchConditionCollapseClient.xml" path="doc/members/member[@name='CollapsePut(RequestContent,MatchConditions,RequestContext)']/*" />
        public virtual Response CollapsePut(RequestContent content, MatchConditions matchConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MatchConditionCollapseClient.CollapsePut");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCollapsePutRequest(content, matchConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MatchConditionCollapseClient.xml" path="doc/members/member[@name='CollapseGetAsync(MatchConditions,RequestContext)']/*" />
        public virtual async Task<Response> CollapseGetAsync(MatchConditions matchConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MatchConditionCollapseClient.CollapseGet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCollapseGetRequest(matchConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/MatchConditionCollapseClient.xml" path="doc/members/member[@name='CollapseGet(MatchConditions,RequestContext)']/*" />
        public virtual Response CollapseGet(MatchConditions matchConditions = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MatchConditionCollapseClient.CollapseGet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCollapseGetRequest(matchConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal RequestUriBuilder CreateCollapseGetWithHeadRequestUri(string otherHeader, MatchConditions matchConditions, RequestContext context)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/MatchConditionCollapse/withHead", false);
            return uri;
        }

        internal HttpMessage CreateCollapseGetWithHeadRequest(string otherHeader, MatchConditions matchConditions, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/MatchConditionCollapse/withHead", false);
            request.Uri = uri;
            if (otherHeader != null)
            {
                request.Headers.Add("otherHeader", otherHeader);
            }
            if (matchConditions != null)
            {
                request.Headers.Add(matchConditions);
            }
            return message;
        }

        internal RequestUriBuilder CreateCollapsePutRequestUri(RequestContent content, MatchConditions matchConditions, RequestContext context)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/MatchConditionCollapse/", false);
            return uri;
        }

        internal HttpMessage CreateCollapsePutRequest(RequestContent content, MatchConditions matchConditions, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/MatchConditionCollapse/", false);
            request.Uri = uri;
            if (matchConditions != null)
            {
                request.Headers.Add(matchConditions);
            }
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal RequestUriBuilder CreateCollapseGetRequestUri(MatchConditions matchConditions, RequestContext context)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/MatchConditionCollapse/", false);
            return uri;
        }

        internal HttpMessage CreateCollapseGetRequest(MatchConditions matchConditions, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/MatchConditionCollapse/", false);
            request.Uri = uri;
            if (matchConditions != null)
            {
                request.Headers.Add(matchConditions);
            }
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
