// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace custom_baseUrl_paging_LowLevel
{
    // Data plane generated client.
    /// <summary> The Paging service client. </summary>
    public partial class PagingClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly string _host;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of PagingClient for mocking. </summary>
        protected PagingClient()
        {
        }

        /// <summary> Initializes a new instance of PagingClient. </summary>
        /// <param name="host"> A string value that is used as a global part of the parameterized host. The default value is "host". </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="host"/> or <paramref name="credential"/> is null. </exception>
        public PagingClient(string host, AzureKeyCredential credential) : this(host, credential, new PagingClientOptions())
        {
        }

        /// <summary> Initializes a new instance of PagingClient. </summary>
        /// <param name="host"> A string value that is used as a global part of the parameterized host. The default value is "host". </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="host"/> or <paramref name="credential"/> is null. </exception>
        public PagingClient(string host, AzureKeyCredential credential, PagingClientOptions options)
        {
            Argument.AssertNotNull(host, nameof(host));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new PagingClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _host = host;
        }

        /// <summary>
        /// [Protocol Method] A paging operation that combines custom url, paging and partial URL and expect to concat after host
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetPagesPartialUrlAsync(string,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetPagesPartialUrlAsync(string accountName, RequestContext context)
        {
            Argument.AssertNotNull(accountName, nameof(accountName));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetPagesPartialUrlRequest(accountName, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetPagesPartialUrlNextPageRequest(nextLink, accountName, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, (e, o) => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetPagesPartialUrl", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that combines custom url, paging and partial URL and expect to concat after host
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetPagesPartialUrl(string,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetPagesPartialUrl(string accountName, RequestContext context)
        {
            Argument.AssertNotNull(accountName, nameof(accountName));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetPagesPartialUrlRequest(accountName, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetPagesPartialUrlNextPageRequest(nextLink, accountName, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, (e, o) => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetPagesPartialUrl", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that combines custom url, paging and partial URL with next operation
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetPagesPartialUrlOperationAsync(string,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetPagesPartialUrlOperationAsync(string accountName, RequestContext context)
        {
            Argument.AssertNotNull(accountName, nameof(accountName));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetPagesPartialUrlOperationRequest(accountName, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetPagesPartialUrlOperationNextRequest(accountName, nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, (e, o) => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetPagesPartialUrlOperation", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that combines custom url, paging and partial URL with next operation
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetPagesPartialUrlOperation(string,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetPagesPartialUrlOperation(string accountName, RequestContext context)
        {
            Argument.AssertNotNull(accountName, nameof(accountName));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetPagesPartialUrlOperationRequest(accountName, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetPagesPartialUrlOperationNextRequest(accountName, nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, (e, o) => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetPagesPartialUrlOperation", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that combines custom url, paging and partial URL
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="nextLink"> Next link for the list operation. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> or <paramref name="nextLink"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetPagesPartialUrlOperationNextAsync(string,string,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetPagesPartialUrlOperationNextAsync(string accountName, string nextLink, RequestContext context)
        {
            Argument.AssertNotNull(accountName, nameof(accountName));
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetPagesPartialUrlOperationNextRequest(accountName, nextLink, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetPagesPartialUrlOperationNextRequest(accountName, nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, (e, o) => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetPagesPartialUrlOperationNext", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that combines custom url, paging and partial URL
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="nextLink"> Next link for the list operation. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> or <paramref name="nextLink"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetPagesPartialUrlOperationNext(string,string,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetPagesPartialUrlOperationNext(string accountName, string nextLink, RequestContext context)
        {
            Argument.AssertNotNull(accountName, nameof(accountName));
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetPagesPartialUrlOperationNextRequest(accountName, nextLink, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetPagesPartialUrlOperationNextRequest(accountName, nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, (e, o) => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetPagesPartialUrlOperationNext", "values", "nextLink", context);
        }

        internal HttpMessage CreateGetPagesPartialUrlRequest(string accountName, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("http://", false);
            uri.AppendRaw(accountName, false);
            uri.AppendRaw(_host, false);
            uri.AppendPath("/paging/customurl/partialnextlink", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetPagesPartialUrlOperationRequest(string accountName, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("http://", false);
            uri.AppendRaw(accountName, false);
            uri.AppendRaw(_host, false);
            uri.AppendPath("/paging/customurl/partialnextlinkop", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetPagesPartialUrlOperationNextRequest(string accountName, string nextLink, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("http://", false);
            uri.AppendRaw(accountName, false);
            uri.AppendRaw(_host, false);
            uri.AppendPath("/paging/customurl/", false);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetPagesPartialUrlNextPageRequest(string nextLink, string accountName, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("http://", false);
            uri.AppendRaw(accountName, false);
            uri.AppendRaw(_host, false);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
