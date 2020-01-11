// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using custom_baseUrl_paging.Models.V100;

namespace custom_baseUrl_paging
{
    internal partial class PagingOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of PagingOperations. </summary>
        public PagingOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "host")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateGetPagesPartialUrlFirstPageRequest(string accountName)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"http://{accountName}{host}"));
            request.Uri.AppendPath("/paging/customurl/partialnextlink", false);
            return message;
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL and expect to concat after host. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetPagesPartialUrlFirstPageAsync(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrl");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlFirstPageRequest(accountName);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.NextLink, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL and expect to concat after host. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Page<Product> GetPagesPartialUrlFirstPage(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrl");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlFirstPageRequest(accountName);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.NextLink, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetPagesPartialUrlNextPageRequest(string accountName, string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            if (Uri.IsWellFormedUriString(nextLinkUrl, UriKind.Absolute))
            {
                request.Uri.Reset(new Uri(nextLinkUrl));
            }
            else
            {
                request.Uri.Reset(new Uri($"http://{accountName}{host}{nextLinkUrl}"));
            }
            return message;
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL and expect to concat after host. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetPagesPartialUrlNextPageAsync(string accountName, string nextLinkUrl, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrl");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlNextPageRequest(accountName, nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.NextLink, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

            Task<Page<Product>> FirstPageFunc(int? pageSizeHint) => GetPagesPartialUrlFirstPageAsync(accountName, cancellationToken).AsTask();
            Task<Page<Product>> NextPageFunc(string continuationToken, int? pageSizeHint) => GetPagesPartialUrlNextPageAsync(accountName, continuationToken, cancellationToken).AsTask();
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        internal HttpMessage CreateGetPagesPartialUrlOperationFirstPageRequest(string accountName)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"http://{accountName}{host}"));
            request.Uri.AppendPath("/paging/customurl/partialnextlinkop", false);
            return message;
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL with next operation. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetPagesPartialUrlOperationFirstPageAsync(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrlOperation");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlOperationFirstPageRequest(accountName);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.NextLink, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL with next operation. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Page<Product> GetPagesPartialUrlOperationFirstPage(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrlOperation");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlOperationFirstPageRequest(accountName);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.NextLink, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetPagesPartialUrlOperationNextPageRequest(string accountName, string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            if (Uri.IsWellFormedUriString(nextLinkUrl, UriKind.Absolute))
            {
                request.Uri.Reset(new Uri(nextLinkUrl));
            }
            else
            {
                request.Uri.Reset(new Uri($"http://{accountName}{host}{nextLinkUrl}"));
            }
            return message;
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL with next operation. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetPagesPartialUrlOperationNextPageAsync(string accountName, string nextLinkUrl, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrlOperation");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlOperationNextPageRequest(accountName, nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.NextLink, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

            Task<Page<Product>> FirstPageFunc(int? pageSizeHint) => GetPagesPartialUrlOperationFirstPageAsync(accountName, cancellationToken).AsTask();
            Task<Page<Product>> NextPageFunc(string continuationToken, int? pageSizeHint) => GetPagesPartialUrlOperationNextPageAsync(accountName, continuationToken, cancellationToken).AsTask();
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        internal HttpMessage CreateGetPagesPartialUrlOperationNextFirstPageRequest(string accountName, string nextLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"http://{accountName}{host}"));
            request.Uri.AppendPath("/paging/customurl/", false);
            request.Uri.AppendPath(nextLink, true);
            return message;
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="nextLink"> Next link for the list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetPagesPartialUrlOperationNextFirstPageAsync(string accountName, string nextLink, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrlOperationNext");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlOperationNextFirstPageRequest(accountName, nextLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.NextLink, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="nextLink"> Next link for the list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Page<Product> GetPagesPartialUrlOperationNextFirstPage(string accountName, string nextLink, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrlOperationNext");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlOperationNextFirstPageRequest(accountName, nextLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.NextLink, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetPagesPartialUrlOperationNextNextPageRequest(string accountName, string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            if (Uri.IsWellFormedUriString(nextLinkUrl, UriKind.Absolute))
            {
                request.Uri.Reset(new Uri(nextLinkUrl));
            }
            else
            {
                request.Uri.Reset(new Uri($"http://{accountName}{host}{nextLinkUrl}"));
            }
            return message;
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetPagesPartialUrlOperationNextNextPageAsync(string accountName, string nextLinkUrl, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrlOperationNext");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlOperationNextNextPageRequest(accountName, nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.NextLink, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

            Task<Page<Product>> FirstPageFunc(int? pageSizeHint) => GetPagesPartialUrlOperationNextFirstPageAsync(accountName, nextLink, cancellationToken).AsTask();
            Task<Page<Product>> NextPageFunc(string continuationToken, int? pageSizeHint) => GetPagesPartialUrlOperationNextNextPageAsync(accountName, continuationToken, cancellationToken).AsTask();
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
