// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using custom_baseUrl_paging.Models;

namespace custom_baseUrl_paging
{
    public partial class PagingClient
    {
        private PagingRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of PagingClient. </summary>
        internal PagingClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "host")
        {
            restClient = new PagingRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL and expect to concat after host. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetPagesPartialUrlAsync(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await restClient.GetPagesPartialUrlAsync(accountName, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await restClient.GetPagesPartialUrlNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL and expect to concat after host. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetPagesPartialUrl(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = restClient.GetPagesPartialUrl(accountName, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = restClient.GetPagesPartialUrlNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL with next operation. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetPagesPartialUrlOperationAsync(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await restClient.GetPagesPartialUrlOperationAsync(accountName, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await restClient.GetPagesPartialUrlOperationNextAsync(accountName, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL with next operation. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetPagesPartialUrlOperation(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = restClient.GetPagesPartialUrlOperation(accountName, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = restClient.GetPagesPartialUrlOperationNext(accountName, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="nextLink"> Next link for the list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetPagesPartialUrlOperationNextAsync(string accountName, string nextLink, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await restClient.GetPagesPartialUrlOperationNextAsync(accountName, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await restClient.GetPagesPartialUrlOperationNextAsync(accountName, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="nextLink"> Next link for the list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetPagesPartialUrlOperationNext(string accountName, string nextLink, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = restClient.GetPagesPartialUrlOperationNext(accountName, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = restClient.GetPagesPartialUrlOperationNext(accountName, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
