// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace SingleTopLevelClientWithOperations_LowLevel
{
    // Data plane generated client.
    /// <summary> The TopLevelClientWithOperation service client. </summary>
    public partial class TopLevelClientWithOperationClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of TopLevelClientWithOperationClient for mocking. </summary>
        protected TopLevelClientWithOperationClient()
        {
        }

        /// <summary> Initializes a new instance of TopLevelClientWithOperationClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public TopLevelClientWithOperationClient(AzureKeyCredential credential) : this(credential, new Uri("http://localhost:3000"), new TopLevelClientWithOperationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of TopLevelClientWithOperationClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public TopLevelClientWithOperationClient(AzureKeyCredential credential, Uri endpoint, TopLevelClientWithOperationClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new TopLevelClientWithOperationClientOptions();

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
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/TopLevelClientWithOperationClient.xml" path="doc/members/member[@name='OperationAsync(RequestContext)']/*" />
        public virtual async Task<Response> OperationAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("TopLevelClientWithOperationClient.Operation");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOperationRequest(context);
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
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/TopLevelClientWithOperationClient.xml" path="doc/members/member[@name='Operation(RequestContext)']/*" />
        public virtual Response Operation(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("TopLevelClientWithOperationClient.Operation");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOperationRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Operation defined in resource client, but must be promoted to the top level client because it doesn't have a parameter with `x-ms-resource-identifier: true`.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/TopLevelClientWithOperationClient.xml" path="doc/members/member[@name='GetAllAsync(string,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetAllAsync(string filter, RequestContext context = null)
        {
            Argument.AssertNotNull(filter, nameof(filter));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetAllRequest(filter, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetAllNextPageRequest(nextLink, filter, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "TopLevelClientWithOperationClient.GetAll", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Operation defined in resource client, but must be promoted to the top level client because it doesn't have a parameter with `x-ms-resource-identifier: true`.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/TopLevelClientWithOperationClient.xml" path="doc/members/member[@name='GetAll(string,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetAll(string filter, RequestContext context = null)
        {
            Argument.AssertNotNull(filter, nameof(filter));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetAllRequest(filter, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetAllNextPageRequest(nextLink, filter, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "TopLevelClientWithOperationClient.GetAll", "value", "nextLink", context);
        }

        private Client1 _cachedClient1;
        private Client2 _cachedClient2;

        /// <summary> Initializes a new instance of Client1. </summary>
        public virtual Client1 GetClient1Client()
        {
            return Volatile.Read(ref _cachedClient1) ?? Interlocked.CompareExchange(ref _cachedClient1, new Client1(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedClient1;
        }

        /// <summary> Initializes a new instance of Client2. </summary>
        public virtual Client2 GetClient2Client()
        {
            return Volatile.Read(ref _cachedClient2) ?? Interlocked.CompareExchange(ref _cachedClient2, new Client2(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedClient2;
        }

        /// <summary> Initializes a new instance of Client4. </summary>
        /// <param name="clientParameter"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientParameter"/> is null. </exception>
        public virtual Client4 GetClient4(string clientParameter)
        {
            Argument.AssertNotNull(clientParameter, nameof(clientParameter));

            return new Client4(ClientDiagnostics, _pipeline, _keyCredential, clientParameter, _endpoint);
        }

        internal HttpMessage CreateOperationRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/client3", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetAllRequest(string filter, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/client4", false);
            uri.AppendQuery("filter", filter, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetAllNextPageRequest(string nextLink, string filter, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
