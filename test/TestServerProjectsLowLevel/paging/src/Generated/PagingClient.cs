// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace paging_LowLevel
{
    // Data plane generated client.
    /// <summary> The Paging service client. </summary>
    public partial class PagingClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of PagingClient for mocking. </summary>
        protected PagingClient()
        {
        }

        /// <summary> Initializes a new instance of PagingClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public PagingClient(AzureKeyCredential credential) : this(credential, new Uri("http://localhost:3000"), new PagingClientOptions())
        {
        }

        /// <summary> Initializes a new instance of PagingClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public PagingClient(AzureKeyCredential credential, Uri endpoint, PagingClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new PagingClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary>
        /// [Protocol Method] A paging operation that must return result of the default 'value' node.
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
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetNoItemNamePagesAsync(RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetNoItemNamePagesAsync(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetNoItemNamePagesRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetNoItemNamePagesNextPageRequest(nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetNoItemNamePages", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that must return result of the default 'value' node.
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
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetNoItemNamePages(RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetNoItemNamePages(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetNoItemNamePagesRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetNoItemNamePagesNextPageRequest(nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetNoItemNamePages", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that must ignore any kind of nextLink, and stop after page 1.
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
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetNullNextLinkNamePagesAsync(RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetNullNextLinkNamePagesAsync(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetNullNextLinkNamePagesRequest(context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetNullNextLinkNamePages", "values", null, context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that must ignore any kind of nextLink, and stop after page 1.
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
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetNullNextLinkNamePages(RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetNullNextLinkNamePages(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetNullNextLinkNamePagesRequest(context);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetNullNextLinkNamePages", "values", null, context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that finishes on the first call without a nextlink
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
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetSinglePagesAsync(RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetSinglePagesAsync(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSinglePagesRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSinglePagesNextPageRequest(nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetSinglePages", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that finishes on the first call without a nextlink
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
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetSinglePages(RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetSinglePages(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSinglePagesRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSinglePagesNextPageRequest(nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetSinglePages", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation whose first response's items list is empty, but still returns a next link. Second (and final) call, will give you an items list of 1.
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
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='FirstResponseEmptyAsync(RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> FirstResponseEmptyAsync(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateFirstResponseEmptyRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateFirstResponseEmptyNextPageRequest(nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.FirstResponseEmpty", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation whose first response's items list is empty, but still returns a next link. Second (and final) call, will give you an items list of 1.
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
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='FirstResponseEmpty(RequestContext)']/*" />
        public virtual Pageable<BinaryData> FirstResponseEmpty(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateFirstResponseEmptyRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateFirstResponseEmptyNextPageRequest(nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.FirstResponseEmpty", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that includes a nextLink that has 10 pages
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetMultiplePagesAsync(string,int?,int?,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetMultiplePagesAsync(string clientRequestId = null, int? maxresults = null, int? timeout = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultiplePagesRequest(clientRequestId, maxresults, timeout, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMultiplePagesNextPageRequest(nextLink, clientRequestId, maxresults, timeout, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetMultiplePages", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that includes a nextLink that has 10 pages
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetMultiplePages(string,int?,int?,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetMultiplePages(string clientRequestId = null, int? maxresults = null, int? timeout = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultiplePagesRequest(clientRequestId, maxresults, timeout, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMultiplePagesNextPageRequest(nextLink, clientRequestId, maxresults, timeout, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetMultiplePages", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that includes a next operation. It has a different query parameter from it's next operation nextOperationWithQueryParams. Returns a ProductResult
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="requiredQueryParameter"> A required integer query parameter. Put in value '100' to pass test. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetWithQueryParamsAsync(int,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetWithQueryParamsAsync(int requiredQueryParameter, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetWithQueryParamsRequest(requiredQueryParameter, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextOperationWithQueryParamsRequest(context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetWithQueryParams", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that includes a next operation. It has a different query parameter from it's next operation nextOperationWithQueryParams. Returns a ProductResult
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="requiredQueryParameter"> A required integer query parameter. Put in value '100' to pass test. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetWithQueryParams(int,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetWithQueryParams(int requiredQueryParameter, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetWithQueryParamsRequest(requiredQueryParameter, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextOperationWithQueryParamsRequest(context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetWithQueryParams", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Define `filter` as a query param for all calls. However, the returned next link will also include the `filter` as part of it. Make sure you don't end up duplicating the `filter` param in the url sent.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> OData filter options. Pass in 'foo'. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='DuplicateParamsAsync(string,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> DuplicateParamsAsync(string filter = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateDuplicateParamsRequest(filter, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateDuplicateParamsNextPageRequest(nextLink, filter, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.DuplicateParams", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Define `filter` as a query param for all calls. However, the returned next link will also include the `filter` as part of it. Make sure you don't end up duplicating the `filter` param in the url sent.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> OData filter options. Pass in 'foo'. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='DuplicateParams(string,RequestContext)']/*" />
        public virtual Pageable<BinaryData> DuplicateParams(string filter = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateDuplicateParamsRequest(filter, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateDuplicateParamsNextPageRequest(nextLink, filter, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.DuplicateParams", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Next operation for getWithQueryParams. Pass in next=True to pass test. Returns a ProductResult
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
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='NextOperationWithQueryParamsAsync(RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> NextOperationWithQueryParamsAsync(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateNextOperationWithQueryParamsRequest(context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.NextOperationWithQueryParams", "values", null, context);
        }

        /// <summary>
        /// [Protocol Method] Next operation for getWithQueryParams. Pass in next=True to pass test. Returns a ProductResult
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
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='NextOperationWithQueryParams(RequestContext)']/*" />
        public virtual Pageable<BinaryData> NextOperationWithQueryParams(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateNextOperationWithQueryParamsRequest(context);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.NextOperationWithQueryParams", "values", null, context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that includes a nextLink in odata format that has 10 pages
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetOdataMultiplePagesAsync(string,int?,int?,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetOdataMultiplePagesAsync(string clientRequestId = null, int? maxresults = null, int? timeout = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetOdataMultiplePagesRequest(clientRequestId, maxresults, timeout, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetOdataMultiplePagesNextPageRequest(nextLink, clientRequestId, maxresults, timeout, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetOdataMultiplePages", "values", "odata.nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that includes a nextLink in odata format that has 10 pages
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetOdataMultiplePages(string,int?,int?,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetOdataMultiplePages(string clientRequestId = null, int? maxresults = null, int? timeout = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetOdataMultiplePagesRequest(clientRequestId, maxresults, timeout, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetOdataMultiplePagesNextPageRequest(nextLink, clientRequestId, maxresults, timeout, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetOdataMultiplePages", "values", "odata.nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that includes a nextLink that has 10 pages
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="offset"> Offset of return value. </param>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetMultiplePagesWithOffsetAsync(int,string,int?,int?,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetMultiplePagesWithOffsetAsync(int offset, string clientRequestId = null, int? maxresults = null, int? timeout = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultiplePagesWithOffsetRequest(offset, clientRequestId, maxresults, timeout, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMultiplePagesWithOffsetNextPageRequest(nextLink, offset, clientRequestId, maxresults, timeout, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesWithOffset", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that includes a nextLink that has 10 pages
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="offset"> Offset of return value. </param>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetMultiplePagesWithOffset(int,string,int?,int?,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetMultiplePagesWithOffset(int offset, string clientRequestId = null, int? maxresults = null, int? timeout = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultiplePagesWithOffsetRequest(offset, clientRequestId, maxresults, timeout, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMultiplePagesWithOffsetNextPageRequest(nextLink, offset, clientRequestId, maxresults, timeout, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesWithOffset", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages
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
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetMultiplePagesRetryFirstAsync(RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetMultiplePagesRetryFirstAsync(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultiplePagesRetryFirstRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMultiplePagesRetryFirstNextPageRequest(nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesRetryFirst", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages
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
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetMultiplePagesRetryFirst(RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetMultiplePagesRetryFirst(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultiplePagesRetryFirstRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMultiplePagesRetryFirstNextPageRequest(nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesRetryFirst", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually.
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
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetMultiplePagesRetrySecondAsync(RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetMultiplePagesRetrySecondAsync(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultiplePagesRetrySecondRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMultiplePagesRetrySecondNextPageRequest(nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesRetrySecond", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually.
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
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetMultiplePagesRetrySecond(RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetMultiplePagesRetrySecond(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultiplePagesRetrySecondRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMultiplePagesRetrySecondNextPageRequest(nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesRetrySecond", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that receives a 400 on the first call
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
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetSinglePagesFailureAsync(RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetSinglePagesFailureAsync(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSinglePagesFailureRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSinglePagesFailureNextPageRequest(nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetSinglePagesFailure", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that receives a 400 on the first call
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
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetSinglePagesFailure(RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetSinglePagesFailure(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSinglePagesFailureRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSinglePagesFailureNextPageRequest(nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetSinglePagesFailure", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that receives a 400 on the second call
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
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetMultiplePagesFailureAsync(RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetMultiplePagesFailureAsync(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultiplePagesFailureRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMultiplePagesFailureNextPageRequest(nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesFailure", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that receives a 400 on the second call
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
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetMultiplePagesFailure(RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetMultiplePagesFailure(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultiplePagesFailureRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMultiplePagesFailureNextPageRequest(nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesFailure", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that receives an invalid nextLink
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
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetMultiplePagesFailureUriAsync(RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetMultiplePagesFailureUriAsync(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultiplePagesFailureUriRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMultiplePagesFailureUriNextPageRequest(nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesFailureUri", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that receives an invalid nextLink
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
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetMultiplePagesFailureUri(RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetMultiplePagesFailureUri(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultiplePagesFailureUriRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMultiplePagesFailureUriNextPageRequest(nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesFailureUri", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that doesn't return a full URL, just a fragment
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenant"/> or <paramref name="apiVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tenant"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetMultiplePagesFragmentNextLinkAsync(string,string,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetMultiplePagesFragmentNextLinkAsync(string tenant, string apiVersion, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(tenant, nameof(tenant));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultiplePagesFragmentNextLinkRequest(tenant, apiVersion, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextFragmentRequest(tenant, nextLink, apiVersion, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesFragmentNextLink", "values", "odata.nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that doesn't return a full URL, just a fragment
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenant"/> or <paramref name="apiVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tenant"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetMultiplePagesFragmentNextLink(string,string,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetMultiplePagesFragmentNextLink(string tenant, string apiVersion, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(tenant, nameof(tenant));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultiplePagesFragmentNextLinkRequest(tenant, apiVersion, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextFragmentRequest(tenant, nextLink, apiVersion, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesFragmentNextLink", "values", "odata.nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that doesn't return a full URL, just a fragment with parameters grouped
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenant"/> or <paramref name="apiVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tenant"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetMultiplePagesFragmentWithGroupingNextLinkAsync(string,string,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetMultiplePagesFragmentWithGroupingNextLinkAsync(string tenant, string apiVersion, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(tenant, nameof(tenant));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultiplePagesFragmentWithGroupingNextLinkRequest(tenant, apiVersion, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextFragmentWithGroupingRequest(tenant, nextLink, apiVersion, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesFragmentWithGroupingNextLink", "values", "odata.nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that doesn't return a full URL, just a fragment with parameters grouped
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenant"/> or <paramref name="apiVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tenant"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetMultiplePagesFragmentWithGroupingNextLink(string,string,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetMultiplePagesFragmentWithGroupingNextLink(string tenant, string apiVersion, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(tenant, nameof(tenant));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultiplePagesFragmentWithGroupingNextLinkRequest(tenant, apiVersion, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextFragmentWithGroupingRequest(tenant, nextLink, apiVersion, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesFragmentWithGroupingNextLink", "values", "odata.nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that doesn't return a full URL, just a fragment
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenant"/>, <paramref name="nextLink"/> or <paramref name="apiVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tenant"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='NextFragmentAsync(string,string,string,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> NextFragmentAsync(string tenant, string nextLink, string apiVersion, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(tenant, nameof(tenant));
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateNextFragmentRequest(tenant, nextLink, apiVersion, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextFragmentRequest(tenant, nextLink, apiVersion, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.NextFragment", "values", "odata.nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that doesn't return a full URL, just a fragment
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenant"/>, <paramref name="nextLink"/> or <paramref name="apiVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tenant"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='NextFragment(string,string,string,RequestContext)']/*" />
        public virtual Pageable<BinaryData> NextFragment(string tenant, string nextLink, string apiVersion, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(tenant, nameof(tenant));
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateNextFragmentRequest(tenant, nextLink, apiVersion, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextFragmentRequest(tenant, nextLink, apiVersion, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.NextFragment", "values", "odata.nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that doesn't return a full URL, just a fragment
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenant"/>, <paramref name="nextLink"/> or <paramref name="apiVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tenant"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='NextFragmentWithGroupingAsync(string,string,string,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> NextFragmentWithGroupingAsync(string tenant, string nextLink, string apiVersion, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(tenant, nameof(tenant));
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateNextFragmentWithGroupingRequest(tenant, nextLink, apiVersion, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextFragmentWithGroupingRequest(tenant, nextLink, apiVersion, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.NextFragmentWithGrouping", "values", "odata.nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that doesn't return a full URL, just a fragment
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenant"/>, <paramref name="nextLink"/> or <paramref name="apiVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tenant"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='NextFragmentWithGrouping(string,string,string,RequestContext)']/*" />
        public virtual Pageable<BinaryData> NextFragmentWithGrouping(string tenant, string nextLink, string apiVersion, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(tenant, nameof(tenant));
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateNextFragmentWithGroupingRequest(tenant, nextLink, apiVersion, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateNextFragmentWithGroupingRequest(tenant, nextLink, apiVersion, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.NextFragmentWithGrouping", "values", "odata.nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that returns a paging model whose item name is is overriden by x-ms-client-name 'indexes'.
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
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetPagingModelWithItemNameWithXMSClientNameAsync(RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetPagingModelWithItemNameWithXMSClientNameAsync(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetPagingModelWithItemNameWithXMSClientNameRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetPagingModelWithItemNameWithXMSClientNameNextPageRequest(nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetPagingModelWithItemNameWithXMSClientName", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A paging operation that returns a paging model whose item name is is overriden by x-ms-client-name 'indexes'.
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
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetPagingModelWithItemNameWithXMSClientName(RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetPagingModelWithItemNameWithXMSClientName(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetPagingModelWithItemNameWithXMSClientNameRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetPagingModelWithItemNameWithXMSClientNameNextPageRequest(nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "PagingClient.GetPagingModelWithItemNameWithXMSClientName", "values", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] A long-running paging operation that includes a nextLink that has 10 pages
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation{T}"/> from the service that will contain a <see cref="AsyncPageable{T}"/> containing a list of <see cref="BinaryData"/> objects once the asynchronous operation on the service has completed. Details of the body schema for the operation's final value are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetMultiplePagesLROAsync(WaitUntil,string,int?,int?,RequestContext)']/*" />
        public virtual async Task<Operation<AsyncPageable<BinaryData>>> GetMultiplePagesLROAsync(WaitUntil waitUntil, string clientRequestId = null, int? maxresults = null, int? timeout = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PagingClient.GetMultiplePagesLRO");
            scope.Start();
            try
            {
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMultiplePagesLRONextPageRequest(nextLink, clientRequestId, maxresults, timeout, context);
                using HttpMessage message = CreateGetMultiplePagesLRORequest(clientRequestId, maxresults, timeout, context);
                return await PageableHelpers.CreateAsyncPageable(waitUntil, message, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, OperationFinalStateVia.Location, "PagingClient.GetMultiplePagesLRO", "values", "nextLink", context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] A long-running paging operation that includes a nextLink that has 10 pages
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation{T}"/> from the service that will contain a <see cref="Pageable{T}"/> containing a list of <see cref="BinaryData"/> objects once the asynchronous operation on the service has completed. Details of the body schema for the operation's final value are in the Remarks section below. </returns>
        /// <include file="Docs/PagingClient.xml" path="doc/members/member[@name='GetMultiplePagesLRO(WaitUntil,string,int?,int?,RequestContext)']/*" />
        public virtual Operation<Pageable<BinaryData>> GetMultiplePagesLRO(WaitUntil waitUntil, string clientRequestId = null, int? maxresults = null, int? timeout = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("PagingClient.GetMultiplePagesLRO");
            scope.Start();
            try
            {
                HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMultiplePagesLRONextPageRequest(nextLink, clientRequestId, maxresults, timeout, context);
                using HttpMessage message = CreateGetMultiplePagesLRORequest(clientRequestId, maxresults, timeout, context);
                return PageableHelpers.CreatePageable(waitUntil, message, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, OperationFinalStateVia.Location, "PagingClient.GetMultiplePagesLRO", "values", "nextLink", context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetNoItemNamePagesRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/noitemname", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetNullNextLinkNamePagesRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/nullnextlink", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetSinglePagesRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/single", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateFirstResponseEmptyRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/firstResponseEmpty/1", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetMultiplePagesRequest(string clientRequestId, int? maxresults, int? timeout, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple", false);
            request.Uri = uri;
            if (clientRequestId != null)
            {
                request.Headers.Add("client-request-id", clientRequestId);
            }
            if (maxresults != null)
            {
                request.Headers.Add("maxresults", maxresults.Value);
            }
            if (timeout != null)
            {
                request.Headers.Add("timeout", timeout.Value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetWithQueryParamsRequest(int requiredQueryParameter, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/getWithQueryParams", false);
            uri.AppendQuery("requiredQueryParameter", requiredQueryParameter, true);
            uri.AppendQuery("queryConstant", true, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDuplicateParamsRequest(string filter, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/duplicateParams/1", false);
            if (filter != null)
            {
                uri.AppendQuery("$filter", filter, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateNextOperationWithQueryParamsRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/nextOperationWithQueryParams", false);
            uri.AppendQuery("queryConstant", true, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetOdataMultiplePagesRequest(string clientRequestId, int? maxresults, int? timeout, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/odata", false);
            request.Uri = uri;
            if (clientRequestId != null)
            {
                request.Headers.Add("client-request-id", clientRequestId);
            }
            if (maxresults != null)
            {
                request.Headers.Add("maxresults", maxresults.Value);
            }
            if (timeout != null)
            {
                request.Headers.Add("timeout", timeout.Value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetMultiplePagesWithOffsetRequest(int offset, string clientRequestId, int? maxresults, int? timeout, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/withpath/", false);
            uri.AppendPath(offset, true);
            request.Uri = uri;
            if (clientRequestId != null)
            {
                request.Headers.Add("client-request-id", clientRequestId);
            }
            if (maxresults != null)
            {
                request.Headers.Add("maxresults", maxresults.Value);
            }
            if (timeout != null)
            {
                request.Headers.Add("timeout", timeout.Value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetMultiplePagesRetryFirstRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/retryfirst", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetMultiplePagesRetrySecondRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/retrysecond", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetSinglePagesFailureRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/single/failure", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetMultiplePagesFailureRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/failure", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetMultiplePagesFailureUriRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/failureuri", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetMultiplePagesFragmentNextLinkRequest(string tenant, string apiVersion, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/fragment/", false);
            uri.AppendPath(tenant, true);
            uri.AppendQuery("api_version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetMultiplePagesFragmentWithGroupingNextLinkRequest(string tenant, string apiVersion, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/fragmentwithgrouping/", false);
            uri.AppendPath(tenant, true);
            uri.AppendQuery("api_version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetMultiplePagesLRORequest(string clientRequestId, int? maxresults, int? timeout, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/lro", false);
            request.Uri = uri;
            if (clientRequestId != null)
            {
                request.Headers.Add("client-request-id", clientRequestId);
            }
            if (maxresults != null)
            {
                request.Headers.Add("maxresults", maxresults.Value);
            }
            if (timeout != null)
            {
                request.Headers.Add("timeout", timeout.Value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateNextFragmentRequest(string tenant, string nextLink, string apiVersion, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/fragment/", false);
            uri.AppendPath(tenant, true);
            uri.AppendPath("/", false);
            uri.AppendRawNextLink(nextLink, false);
            uri.AppendQuery("api_version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateNextFragmentWithGroupingRequest(string tenant, string nextLink, string apiVersion, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/fragmentwithgrouping/", false);
            uri.AppendPath(tenant, true);
            uri.AppendPath("/", false);
            uri.AppendRawNextLink(nextLink, false);
            uri.AppendQuery("api_version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetPagingModelWithItemNameWithXMSClientNameRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/itemNameWithXMSClientName", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetNoItemNamePagesNextPageRequest(string nextLink, RequestContext context)
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

        internal HttpMessage CreateGetSinglePagesNextPageRequest(string nextLink, RequestContext context)
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

        internal HttpMessage CreateFirstResponseEmptyNextPageRequest(string nextLink, RequestContext context)
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

        internal HttpMessage CreateGetMultiplePagesNextPageRequest(string nextLink, string clientRequestId, int? maxresults, int? timeout, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            if (clientRequestId != null)
            {
                request.Headers.Add("client-request-id", clientRequestId);
            }
            if (maxresults != null)
            {
                request.Headers.Add("maxresults", maxresults.Value);
            }
            if (timeout != null)
            {
                request.Headers.Add("timeout", timeout.Value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDuplicateParamsNextPageRequest(string nextLink, string filter, RequestContext context)
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

        internal HttpMessage CreateGetOdataMultiplePagesNextPageRequest(string nextLink, string clientRequestId, int? maxresults, int? timeout, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            if (clientRequestId != null)
            {
                request.Headers.Add("client-request-id", clientRequestId);
            }
            if (maxresults != null)
            {
                request.Headers.Add("maxresults", maxresults.Value);
            }
            if (timeout != null)
            {
                request.Headers.Add("timeout", timeout.Value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetMultiplePagesWithOffsetNextPageRequest(string nextLink, int offset, string clientRequestId, int? maxresults, int? timeout, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            if (clientRequestId != null)
            {
                request.Headers.Add("client-request-id", clientRequestId);
            }
            if (maxresults != null)
            {
                request.Headers.Add("maxresults", maxresults.Value);
            }
            if (timeout != null)
            {
                request.Headers.Add("timeout", timeout.Value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetMultiplePagesRetryFirstNextPageRequest(string nextLink, RequestContext context)
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

        internal HttpMessage CreateGetMultiplePagesRetrySecondNextPageRequest(string nextLink, RequestContext context)
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

        internal HttpMessage CreateGetSinglePagesFailureNextPageRequest(string nextLink, RequestContext context)
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

        internal HttpMessage CreateGetMultiplePagesFailureNextPageRequest(string nextLink, RequestContext context)
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

        internal HttpMessage CreateGetMultiplePagesFailureUriNextPageRequest(string nextLink, RequestContext context)
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

        internal HttpMessage CreateGetPagingModelWithItemNameWithXMSClientNameNextPageRequest(string nextLink, RequestContext context)
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

        internal HttpMessage CreateGetMultiplePagesLRONextPageRequest(string nextLink, string clientRequestId, int? maxresults, int? timeout, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            if (clientRequestId != null)
            {
                request.Headers.Add("client-request-id", clientRequestId);
            }
            if (maxresults != null)
            {
                request.Headers.Add("maxresults", maxresults.Value);
            }
            if (timeout != null)
            {
                request.Headers.Add("timeout", timeout.Value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
        private static ResponseClassifier _responseClassifier202;
        private static ResponseClassifier ResponseClassifier202 => _responseClassifier202 ??= new StatusCodeClassifier(stackalloc ushort[] { 202 });
    }
}
