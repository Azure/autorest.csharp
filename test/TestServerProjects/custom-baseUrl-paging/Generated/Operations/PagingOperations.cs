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
        internal HttpMessage CreateGetPagesPartialUrlRequest(string accountName)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("http://", false);
            uri.AppendRaw(accountName, false);
            uri.AppendRaw(host, false);
            uri.AppendPath("/paging/customurl/partialnextlink", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL and expect to concat after host. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetPagesPartialUrlAsync(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrl");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlRequest(accountName);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
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
        public Response<ProductResult> GetPagesPartialUrl(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrl");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlRequest(accountName);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
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
        internal HttpMessage CreateGetPagesPartialUrlNextPageRequest(string nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(nextLinkUrl, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL and expect to concat after host. </summary>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetPagesPartialUrlNextPageAsync(string nextLinkUrl, CancellationToken cancellationToken = default)
        {
            if (nextLinkUrl == null)
            {
                throw new ArgumentNullException(nameof(nextLinkUrl));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrl");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlNextPageRequest(nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
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
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetPagesPartialUrlNextPage(string nextLinkUrl, CancellationToken cancellationToken = default)
        {
            if (nextLinkUrl == null)
            {
                throw new ArgumentNullException(nameof(nextLinkUrl));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrl");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlNextPageRequest(nextLinkUrl);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
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
        internal HttpMessage CreateGetPagesPartialUrlOperationRequest(string accountName)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("http://", false);
            uri.AppendRaw(accountName, false);
            uri.AppendRaw(host, false);
            uri.AppendPath("/paging/customurl/partialnextlinkop", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL with next operation. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetPagesPartialUrlOperationAsync(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrlOperation");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlOperationRequest(accountName);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
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
        public Response<ProductResult> GetPagesPartialUrlOperation(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrlOperation");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlOperationRequest(accountName);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
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
        internal HttpMessage CreateGetPagesPartialUrlOperationNextPageRequest(string nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(nextLinkUrl, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL with next operation. </summary>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetPagesPartialUrlOperationNextPageAsync(string nextLinkUrl, CancellationToken cancellationToken = default)
        {
            if (nextLinkUrl == null)
            {
                throw new ArgumentNullException(nameof(nextLinkUrl));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrlOperation");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlOperationNextPageRequest(nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
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
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetPagesPartialUrlOperationNextPage(string nextLinkUrl, CancellationToken cancellationToken = default)
        {
            if (nextLinkUrl == null)
            {
                throw new ArgumentNullException(nameof(nextLinkUrl));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrlOperation");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlOperationNextPageRequest(nextLinkUrl);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
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
        internal HttpMessage CreateGetPagesPartialUrlOperationNextRequest(string accountName, string nextLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("http://", false);
            uri.AppendRaw(accountName, false);
            uri.AppendRaw(host, false);
            uri.AppendPath("/paging/customurl/", false);
            uri.AppendPath(nextLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="nextLink"> Next link for the list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetPagesPartialUrlOperationNextAsync(string accountName, string nextLink, CancellationToken cancellationToken = default)
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
                using var message = CreateGetPagesPartialUrlOperationNextRequest(accountName, nextLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
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
        public Response<ProductResult> GetPagesPartialUrlOperationNext(string accountName, string nextLink, CancellationToken cancellationToken = default)
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
                using var message = CreateGetPagesPartialUrlOperationNextRequest(accountName, nextLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
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
        internal HttpMessage CreateGetPagesPartialUrlOperationNextNextPageRequest(string nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(nextLinkUrl, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL. </summary>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetPagesPartialUrlOperationNextNextPageAsync(string nextLinkUrl, CancellationToken cancellationToken = default)
        {
            if (nextLinkUrl == null)
            {
                throw new ArgumentNullException(nameof(nextLinkUrl));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrlOperationNext");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlOperationNextNextPageRequest(nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
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
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetPagesPartialUrlOperationNextNextPage(string nextLinkUrl, CancellationToken cancellationToken = default)
        {
            if (nextLinkUrl == null)
            {
                throw new ArgumentNullException(nameof(nextLinkUrl));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetPagesPartialUrlOperationNext");
            scope.Start();
            try
            {
                using var message = CreateGetPagesPartialUrlOperationNextNextPageRequest(nextLinkUrl);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = ProductResult.DeserializeProductResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
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
        /// <summary> A paging operation that combines custom url, paging and partial URL and expect to concat after host. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetPagesPartialUrlPageableAsync(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetPagesPartialUrlAsync(accountName, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLinkUrl, int? pageSizeHint)
            {
                var response = await GetPagesPartialUrlNextPageAsync(nextLinkUrl, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL and expect to concat after host. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetPagesPartialUrlPageable(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetPagesPartialUrl(accountName, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLinkUrl, int? pageSizeHint)
            {
                var response = GetPagesPartialUrlNextPage(nextLinkUrl, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageResponseEnumerator.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL with next operation. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetPagesPartialUrlOperationPageableAsync(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetPagesPartialUrlOperationAsync(accountName, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLinkUrl, int? pageSizeHint)
            {
                var response = await GetPagesPartialUrlOperationNextPageAsync(nextLinkUrl, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL with next operation. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetPagesPartialUrlOperationPageable(string accountName, CancellationToken cancellationToken = default)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetPagesPartialUrlOperation(accountName, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLinkUrl, int? pageSizeHint)
            {
                var response = GetPagesPartialUrlOperationNextPage(nextLinkUrl, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageResponseEnumerator.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="nextLink"> Next link for the list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetPagesPartialUrlOperationNextPageableAsync(string accountName, string nextLink, CancellationToken cancellationToken = default)
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
                var response = await GetPagesPartialUrlOperationNextAsync(accountName, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLinkUrl, int? pageSizeHint)
            {
                var response = await GetPagesPartialUrlOperationNextNextPageAsync(nextLinkUrl, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that combines custom url, paging and partial URL. </summary>
        /// <param name="accountName"> Account Name. </param>
        /// <param name="nextLink"> Next link for the list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetPagesPartialUrlOperationNextPageable(string accountName, string nextLink, CancellationToken cancellationToken = default)
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
                var response = GetPagesPartialUrlOperationNext(accountName, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLinkUrl, int? pageSizeHint)
            {
                var response = GetPagesPartialUrlOperationNextNextPage(nextLinkUrl, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageResponseEnumerator.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
