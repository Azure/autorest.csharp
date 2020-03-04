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
    public partial class PagingClient
    {
        internal PagingRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of PagingClient. </summary>
        internal PagingClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new PagingRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> A paging operation that must return result of the default &apos;value&apos; node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetNoItemNamePagesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.GetNoItemNamePagesAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.GetNoItemNamePagesNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that must return result of the default &apos;value&apos; node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetNoItemNamePages(CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.GetNoItemNamePages(cancellationToken);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.GetNoItemNamePagesNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that must ignore any kind of nextLink, and stop after page 1. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetNullNextLinkNamePagesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.GetNullNextLinkNamePagesAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, null, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.GetNullNextLinkNamePagesNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, null, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that must ignore any kind of nextLink, and stop after page 1. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetNullNextLinkNamePages(CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.GetNullNextLinkNamePages(cancellationToken);
                return Page.FromValues(response.Value.Values, null, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.GetNullNextLinkNamePagesNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, null, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that finishes on the first call without a nextlink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetSinglePagesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.GetSinglePagesAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.GetSinglePagesNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that finishes on the first call without a nextlink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetSinglePages(CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.GetSinglePages(cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.GetSinglePagesNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesAsync(string clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.GetMultiplePagesAsync(clientRequestId, maxresults, timeout, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.GetMultiplePagesNextPageAsync(clientRequestId, maxresults, timeout, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetMultiplePages(string clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.GetMultiplePages(clientRequestId, maxresults, timeout, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.GetMultiplePagesNextPage(clientRequestId, maxresults, timeout, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetOdataMultiplePagesAsync(string clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.GetOdataMultiplePagesAsync(clientRequestId, maxresults, timeout, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.GetOdataMultiplePagesNextPageAsync(clientRequestId, maxresults, timeout, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetOdataMultiplePages(string clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.GetOdataMultiplePages(clientRequestId, maxresults, timeout, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.GetOdataMultiplePagesNextPage(clientRequestId, maxresults, timeout, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="offset"> Offset of return value. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesWithOffsetAsync(string clientRequestId, int? maxresults, int offset, int? timeout, CancellationToken cancellationToken = default)
        {

            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.GetMultiplePagesWithOffsetAsync(clientRequestId, maxresults, offset, timeout, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.GetMultiplePagesWithOffsetNextPageAsync(clientRequestId, maxresults, timeout, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="offset"> Offset of return value. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetMultiplePagesWithOffset(string clientRequestId, int? maxresults, int offset, int? timeout, CancellationToken cancellationToken = default)
        {

            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.GetMultiplePagesWithOffset(clientRequestId, maxresults, offset, timeout, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.GetMultiplePagesWithOffsetNextPage(clientRequestId, maxresults, timeout, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesRetryFirstAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.GetMultiplePagesRetryFirstAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.GetMultiplePagesRetryFirstNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetMultiplePagesRetryFirst(CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.GetMultiplePagesRetryFirst(cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.GetMultiplePagesRetryFirstNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesRetrySecondAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.GetMultiplePagesRetrySecondAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.GetMultiplePagesRetrySecondNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetMultiplePagesRetrySecond(CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.GetMultiplePagesRetrySecond(cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.GetMultiplePagesRetrySecondNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that receives a 400 on the first call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetSinglePagesFailureAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.GetSinglePagesFailureAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.GetSinglePagesFailureNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that receives a 400 on the first call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetSinglePagesFailure(CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.GetSinglePagesFailure(cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.GetSinglePagesFailureNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that receives a 400 on the second call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesFailureAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.GetMultiplePagesFailureAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.GetMultiplePagesFailureNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that receives a 400 on the second call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetMultiplePagesFailure(CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.GetMultiplePagesFailure(cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.GetMultiplePagesFailureNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that receives an invalid nextLink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesFailureUriAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.GetMultiplePagesFailureUriAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.GetMultiplePagesFailureUriNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that receives an invalid nextLink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetMultiplePagesFailureUri(CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.GetMultiplePagesFailureUri(cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.GetMultiplePagesFailureUriNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesFragmentNextLinkAsync(string apiVersion, string tenant, CancellationToken cancellationToken = default)
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }

            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.GetMultiplePagesFragmentNextLinkAsync(apiVersion, tenant, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.NextFragmentAsync(apiVersion, tenant, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetMultiplePagesFragmentNextLink(string apiVersion, string tenant, CancellationToken cancellationToken = default)
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }

            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.GetMultiplePagesFragmentNextLink(apiVersion, tenant, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.NextFragment(apiVersion, tenant, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment with parameters grouped. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesFragmentWithGroupingNextLinkAsync(string apiVersion, string tenant, CancellationToken cancellationToken = default)
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }

            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.GetMultiplePagesFragmentWithGroupingNextLinkAsync(apiVersion, tenant, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.NextFragmentWithGroupingAsync(apiVersion, tenant, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment with parameters grouped. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetMultiplePagesFragmentWithGroupingNextLink(string apiVersion, string tenant, CancellationToken cancellationToken = default)
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }

            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.GetMultiplePagesFragmentWithGroupingNextLink(apiVersion, tenant, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.NextFragmentWithGrouping(apiVersion, tenant, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesLROAsync(string clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.GetMultiplePagesLROAsync(clientRequestId, maxresults, timeout, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.GetMultiplePagesLRONextPageAsync(clientRequestId, maxresults, timeout, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetMultiplePagesLRO(string clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.GetMultiplePagesLRO(clientRequestId, maxresults, timeout, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.GetMultiplePagesLRONextPage(clientRequestId, maxresults, timeout, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> NextFragmentAsync(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.NextFragmentAsync(apiVersion, tenant, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.NextFragmentAsync(apiVersion, tenant, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> NextFragment(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.NextFragment(apiVersion, tenant, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.NextFragment(apiVersion, tenant, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> NextFragmentWithGroupingAsync(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.NextFragmentWithGroupingAsync(apiVersion, tenant, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.NextFragmentWithGroupingAsync(apiVersion, tenant, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> NextFragmentWithGrouping(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.NextFragmentWithGrouping(apiVersion, tenant, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.NextFragmentWithGrouping(apiVersion, tenant, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
