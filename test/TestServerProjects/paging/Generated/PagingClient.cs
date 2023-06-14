// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using paging.Models;

namespace paging
{
    /// <summary> The Paging service client. </summary>
    public partial class PagingClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal PagingRestClient RestClient { get; }

        /// <summary> Initializes a new instance of PagingClient for mocking. </summary>
        protected PagingClient()
        {
        }

        /// <summary> Initializes a new instance of PagingClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal PagingClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new PagingRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> A paging operation that must return result of the default 'value' node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Product> GetNoItemNamePagesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetNoItemNamePagesRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetNoItemNamePagesNextPageRequest(nextLink);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetNoItemNamePages", "value", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that must return result of the default 'value' node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Product> GetNoItemNamePages(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetNoItemNamePagesRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetNoItemNamePagesNextPageRequest(nextLink);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetNoItemNamePages", "value", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that must ignore any kind of nextLink, and stop after page 1. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Product> GetNullNextLinkNamePagesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetNullNextLinkNamePagesRequest();
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetNullNextLinkNamePages", "values", null, cancellationToken);
        }

        /// <summary> A paging operation that must ignore any kind of nextLink, and stop after page 1. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Product> GetNullNextLinkNamePages(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetNullNextLinkNamePagesRequest();
            return PageableHelpers.CreatePageable(FirstPageRequest, null, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetNullNextLinkNamePages", "values", null, cancellationToken);
        }

        /// <summary> A paging operation that finishes on the first call without a nextlink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Product> GetSinglePagesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetSinglePagesRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetSinglePagesNextPageRequest(nextLink);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetSinglePages", "values", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that finishes on the first call without a nextlink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Product> GetSinglePages(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetSinglePagesRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetSinglePagesNextPageRequest(nextLink);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetSinglePages", "values", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation whose first response's items list is empty, but still returns a next link. Second (and final) call, will give you an items list of 1. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Product> FirstResponseEmptyAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateFirstResponseEmptyRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateFirstResponseEmptyNextPageRequest(nextLink);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.FirstResponseEmpty", "value", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation whose first response's items list is empty, but still returns a next link. Second (and final) call, will give you an items list of 1. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Product> FirstResponseEmpty(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateFirstResponseEmptyRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateFirstResponseEmptyNextPageRequest(nextLink);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.FirstResponseEmpty", "value", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="pagingGetMultiplePagesOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Product> GetMultiplePagesAsync(string clientRequestId = null, PagingGetMultiplePagesOptions pagingGetMultiplePagesOptions = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetMultiplePagesRequest(clientRequestId, pagingGetMultiplePagesOptions);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetMultiplePagesNextPageRequest(nextLink, clientRequestId, pagingGetMultiplePagesOptions);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetMultiplePages", "values", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="pagingGetMultiplePagesOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Product> GetMultiplePages(string clientRequestId = null, PagingGetMultiplePagesOptions pagingGetMultiplePagesOptions = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetMultiplePagesRequest(clientRequestId, pagingGetMultiplePagesOptions);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetMultiplePagesNextPageRequest(nextLink, clientRequestId, pagingGetMultiplePagesOptions);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetMultiplePages", "values", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that includes a next operation. It has a different query parameter from it's next operation nextOperationWithQueryParams. Returns a ProductResult. </summary>
        /// <param name="requiredQueryParameter"> A required integer query parameter. Put in value '100' to pass test. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Product> GetWithQueryParamsAsync(int requiredQueryParameter, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetWithQueryParamsRequest(requiredQueryParameter);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateNextOperationWithQueryParamsRequest();
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetWithQueryParams", "values", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that includes a next operation. It has a different query parameter from it's next operation nextOperationWithQueryParams. Returns a ProductResult. </summary>
        /// <param name="requiredQueryParameter"> A required integer query parameter. Put in value '100' to pass test. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Product> GetWithQueryParams(int requiredQueryParameter, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetWithQueryParamsRequest(requiredQueryParameter);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateNextOperationWithQueryParamsRequest();
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetWithQueryParams", "values", "nextLink", cancellationToken);
        }

        /// <summary> Define `filter` as a query param for all calls. However, the returned next link will also include the `filter` as part of it. Make sure you don't end up duplicating the `filter` param in the url sent. </summary>
        /// <param name="filter"> OData filter options. Pass in 'foo'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Product> DuplicateParamsAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateDuplicateParamsRequest(filter);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateDuplicateParamsNextPageRequest(nextLink, filter);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.DuplicateParams", "values", "nextLink", cancellationToken);
        }

        /// <summary> Define `filter` as a query param for all calls. However, the returned next link will also include the `filter` as part of it. Make sure you don't end up duplicating the `filter` param in the url sent. </summary>
        /// <param name="filter"> OData filter options. Pass in 'foo'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Product> DuplicateParams(string filter = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateDuplicateParamsRequest(filter);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateDuplicateParamsNextPageRequest(nextLink, filter);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.DuplicateParams", "values", "nextLink", cancellationToken);
        }

        /// <summary> Next operation for getWithQueryParams. Pass in next=True to pass test. Returns a ProductResult. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Product> NextOperationWithQueryParamsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateNextOperationWithQueryParamsRequest();
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.NextOperationWithQueryParams", "values", null, cancellationToken);
        }

        /// <summary> Next operation for getWithQueryParams. Pass in next=True to pass test. Returns a ProductResult. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Product> NextOperationWithQueryParams(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateNextOperationWithQueryParamsRequest();
            return PageableHelpers.CreatePageable(FirstPageRequest, null, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.NextOperationWithQueryParams", "values", null, cancellationToken);
        }

        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="pagingGetOdataMultiplePagesOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Product> GetOdataMultiplePagesAsync(string clientRequestId = null, PagingGetOdataMultiplePagesOptions pagingGetOdataMultiplePagesOptions = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetOdataMultiplePagesRequest(clientRequestId, pagingGetOdataMultiplePagesOptions);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetOdataMultiplePagesNextPageRequest(nextLink, clientRequestId, pagingGetOdataMultiplePagesOptions);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetOdataMultiplePages", "values", "odata.nextLink", cancellationToken);
        }

        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="pagingGetOdataMultiplePagesOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Product> GetOdataMultiplePages(string clientRequestId = null, PagingGetOdataMultiplePagesOptions pagingGetOdataMultiplePagesOptions = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetOdataMultiplePagesRequest(clientRequestId, pagingGetOdataMultiplePagesOptions);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetOdataMultiplePagesNextPageRequest(nextLink, clientRequestId, pagingGetOdataMultiplePagesOptions);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetOdataMultiplePages", "values", "odata.nextLink", cancellationToken);
        }

        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="pagingGetMultiplePagesWithOffsetOptions"> Parameter group. </param>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pagingGetMultiplePagesWithOffsetOptions"/> is null. </exception>
        public virtual AsyncPageable<Product> GetMultiplePagesWithOffsetAsync(PagingGetMultiplePagesWithOffsetOptions pagingGetMultiplePagesWithOffsetOptions, string clientRequestId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(pagingGetMultiplePagesWithOffsetOptions, nameof(pagingGetMultiplePagesWithOffsetOptions));

            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetMultiplePagesWithOffsetRequest(pagingGetMultiplePagesWithOffsetOptions, clientRequestId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetMultiplePagesWithOffsetNextPageRequest(nextLink, pagingGetMultiplePagesWithOffsetOptions, clientRequestId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesWithOffset", "values", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="pagingGetMultiplePagesWithOffsetOptions"> Parameter group. </param>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pagingGetMultiplePagesWithOffsetOptions"/> is null. </exception>
        public virtual Pageable<Product> GetMultiplePagesWithOffset(PagingGetMultiplePagesWithOffsetOptions pagingGetMultiplePagesWithOffsetOptions, string clientRequestId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(pagingGetMultiplePagesWithOffsetOptions, nameof(pagingGetMultiplePagesWithOffsetOptions));

            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetMultiplePagesWithOffsetRequest(pagingGetMultiplePagesWithOffsetOptions, clientRequestId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetMultiplePagesWithOffsetNextPageRequest(nextLink, pagingGetMultiplePagesWithOffsetOptions, clientRequestId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesWithOffset", "values", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Product> GetMultiplePagesRetryFirstAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetMultiplePagesRetryFirstRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetMultiplePagesRetryFirstNextPageRequest(nextLink);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesRetryFirst", "values", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Product> GetMultiplePagesRetryFirst(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetMultiplePagesRetryFirstRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetMultiplePagesRetryFirstNextPageRequest(nextLink);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesRetryFirst", "values", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Product> GetMultiplePagesRetrySecondAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetMultiplePagesRetrySecondRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetMultiplePagesRetrySecondNextPageRequest(nextLink);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesRetrySecond", "values", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Product> GetMultiplePagesRetrySecond(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetMultiplePagesRetrySecondRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetMultiplePagesRetrySecondNextPageRequest(nextLink);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesRetrySecond", "values", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that receives a 400 on the first call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Product> GetSinglePagesFailureAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetSinglePagesFailureRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetSinglePagesFailureNextPageRequest(nextLink);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetSinglePagesFailure", "values", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that receives a 400 on the first call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Product> GetSinglePagesFailure(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetSinglePagesFailureRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetSinglePagesFailureNextPageRequest(nextLink);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetSinglePagesFailure", "values", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that receives a 400 on the second call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Product> GetMultiplePagesFailureAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetMultiplePagesFailureRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetMultiplePagesFailureNextPageRequest(nextLink);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesFailure", "values", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that receives a 400 on the second call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Product> GetMultiplePagesFailure(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetMultiplePagesFailureRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetMultiplePagesFailureNextPageRequest(nextLink);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesFailure", "values", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that receives an invalid nextLink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Product> GetMultiplePagesFailureUriAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetMultiplePagesFailureUriRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetMultiplePagesFailureUriNextPageRequest(nextLink);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesFailureUri", "values", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that receives an invalid nextLink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Product> GetMultiplePagesFailureUri(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetMultiplePagesFailureUriRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetMultiplePagesFailureUriNextPageRequest(nextLink);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesFailureUri", "values", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that doesn't return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> or <paramref name="tenant"/> is null. </exception>
        public virtual AsyncPageable<Product> GetMultiplePagesFragmentNextLinkAsync(string apiVersion, string tenant, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));
            Argument.AssertNotNullOrEmpty(tenant, nameof(tenant));

            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetMultiplePagesFragmentNextLinkRequest(apiVersion, tenant);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateNextFragmentRequest(apiVersion, tenant, nextLink);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesFragmentNextLink", "values", "odata.nextLink", cancellationToken);
        }

        /// <summary> A paging operation that doesn't return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> or <paramref name="tenant"/> is null. </exception>
        public virtual Pageable<Product> GetMultiplePagesFragmentNextLink(string apiVersion, string tenant, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));
            Argument.AssertNotNullOrEmpty(tenant, nameof(tenant));

            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetMultiplePagesFragmentNextLinkRequest(apiVersion, tenant);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateNextFragmentRequest(apiVersion, tenant, nextLink);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesFragmentNextLink", "values", "odata.nextLink", cancellationToken);
        }

        /// <summary> A paging operation that doesn't return a full URL, just a fragment with parameters grouped. </summary>
        /// <param name="customParameterGroup"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="customParameterGroup"/> is null. </exception>
        public virtual AsyncPageable<Product> GetMultiplePagesFragmentWithGroupingNextLinkAsync(CustomParameterGroup customParameterGroup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(customParameterGroup, nameof(customParameterGroup));

            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetMultiplePagesFragmentWithGroupingNextLinkRequest(customParameterGroup);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateNextFragmentWithGroupingRequest(nextLink, customParameterGroup);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesFragmentWithGroupingNextLink", "values", "odata.nextLink", cancellationToken);
        }

        /// <summary> A paging operation that doesn't return a full URL, just a fragment with parameters grouped. </summary>
        /// <param name="customParameterGroup"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="customParameterGroup"/> is null. </exception>
        public virtual Pageable<Product> GetMultiplePagesFragmentWithGroupingNextLink(CustomParameterGroup customParameterGroup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(customParameterGroup, nameof(customParameterGroup));

            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetMultiplePagesFragmentWithGroupingNextLinkRequest(customParameterGroup);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateNextFragmentWithGroupingRequest(nextLink, customParameterGroup);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetMultiplePagesFragmentWithGroupingNextLink", "values", "odata.nextLink", cancellationToken);
        }

        /// <summary> A paging operation that doesn't return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/>, <paramref name="tenant"/> or <paramref name="nextLink"/> is null. </exception>
        public virtual AsyncPageable<Product> NextFragmentAsync(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));
            Argument.AssertNotNullOrEmpty(tenant, nameof(tenant));
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateNextFragmentRequest(apiVersion, tenant, nextLink);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateNextFragmentRequest(apiVersion, tenant, nextLink);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.NextFragment", "values", "odata.nextLink", cancellationToken);
        }

        /// <summary> A paging operation that doesn't return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/>, <paramref name="tenant"/> or <paramref name="nextLink"/> is null. </exception>
        public virtual Pageable<Product> NextFragment(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));
            Argument.AssertNotNullOrEmpty(tenant, nameof(tenant));
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateNextFragmentRequest(apiVersion, tenant, nextLink);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateNextFragmentRequest(apiVersion, tenant, nextLink);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.NextFragment", "values", "odata.nextLink", cancellationToken);
        }

        /// <summary> A paging operation that doesn't return a full URL, just a fragment. </summary>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="customParameterGroup"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="customParameterGroup"/> is null. </exception>
        public virtual AsyncPageable<Product> NextFragmentWithGroupingAsync(string nextLink, CustomParameterGroup customParameterGroup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNull(customParameterGroup, nameof(customParameterGroup));

            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateNextFragmentWithGroupingRequest(nextLink, customParameterGroup);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateNextFragmentWithGroupingRequest(nextLink, customParameterGroup);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.NextFragmentWithGrouping", "values", "odata.nextLink", cancellationToken);
        }

        /// <summary> A paging operation that doesn't return a full URL, just a fragment. </summary>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="customParameterGroup"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="customParameterGroup"/> is null. </exception>
        public virtual Pageable<Product> NextFragmentWithGrouping(string nextLink, CustomParameterGroup customParameterGroup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNull(customParameterGroup, nameof(customParameterGroup));

            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateNextFragmentWithGroupingRequest(nextLink, customParameterGroup);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateNextFragmentWithGroupingRequest(nextLink, customParameterGroup);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.NextFragmentWithGrouping", "values", "odata.nextLink", cancellationToken);
        }

        /// <summary> A paging operation that returns a paging model whose item name is is overriden by x-ms-client-name 'indexes'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Product> GetPagingModelWithItemNameWithXMSClientNameAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetPagingModelWithItemNameWithXMSClientNameRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetPagingModelWithItemNameWithXMSClientNameNextPageRequest(nextLink);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetPagingModelWithItemNameWithXMSClientName", "values", "nextLink", cancellationToken);
        }

        /// <summary> A paging operation that returns a paging model whose item name is is overriden by x-ms-client-name 'indexes'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Product> GetPagingModelWithItemNameWithXMSClientName(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateGetPagingModelWithItemNameWithXMSClientNameRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateGetPagingModelWithItemNameWithXMSClientNameNextPageRequest(nextLink);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingClient.GetPagingModelWithItemNameWithXMSClientName", "values", "nextLink", cancellationToken);
        }

        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="pagingGetMultiplePagesLroOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<PagingGetMultiplePagesLROOperation> StartGetMultiplePagesLROAsync(string clientRequestId = null, PagingGetMultiplePagesLroOptions pagingGetMultiplePagesLroOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PagingClient.StartGetMultiplePagesLRO");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.GetMultiplePagesLROAsync(clientRequestId, pagingGetMultiplePagesLroOptions, cancellationToken).ConfigureAwait(false);
                return new PagingGetMultiplePagesLROOperation(_clientDiagnostics, _pipeline, RestClient.CreateGetMultiplePagesLRORequest(clientRequestId, pagingGetMultiplePagesLroOptions).Request, originalResponse, (_, nextLink) => RestClient.CreateGetMultiplePagesLRONextPageRequest(nextLink, clientRequestId, pagingGetMultiplePagesLroOptions));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="pagingGetMultiplePagesLroOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual PagingGetMultiplePagesLROOperation StartGetMultiplePagesLRO(string clientRequestId = null, PagingGetMultiplePagesLroOptions pagingGetMultiplePagesLroOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PagingClient.StartGetMultiplePagesLRO");
            scope.Start();
            try
            {
                var originalResponse = RestClient.GetMultiplePagesLRO(clientRequestId, pagingGetMultiplePagesLroOptions, cancellationToken);
                return new PagingGetMultiplePagesLROOperation(_clientDiagnostics, _pipeline, RestClient.CreateGetMultiplePagesLRORequest(clientRequestId, pagingGetMultiplePagesLroOptions).Request, originalResponse, (_, nextLink) => RestClient.CreateGetMultiplePagesLRONextPageRequest(nextLink, clientRequestId, pagingGetMultiplePagesLroOptions));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
