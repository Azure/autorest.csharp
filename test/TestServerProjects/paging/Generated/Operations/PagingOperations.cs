// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using paging.Models.V100;

namespace paging
{
    internal partial class PagingOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of PagingOperations. </summary>
        public PagingOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateGetNoItemNamePagesFirstPageRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/paging/noitemname", false);
            return message;
        }
        /// <summary> A paging operation that must return result of the default &apos;value&apos; node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetNoItemNamePagesFirstPageAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetNoItemNamePages");
            scope.Start();
            try
            {
                using var message = CreateGetNoItemNamePagesFirstPageRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = ProductResultValue.DeserializeProductResultValue(document.RootElement);
                            return Page.FromValues(value.Value, value.NextLink, message.Response);
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
        /// <summary> A paging operation that must return result of the default &apos;value&apos; node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Page<Product> GetNoItemNamePagesFirstPage(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetNoItemNamePages");
            scope.Start();
            try
            {
                using var message = CreateGetNoItemNamePagesFirstPageRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = ProductResultValue.DeserializeProductResultValue(document.RootElement);
                            return Page.FromValues(value.Value, value.NextLink, message.Response);
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
        internal HttpMessage CreateGetNoItemNamePagesNextPageRequest(string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
            return message;
        }
        /// <summary> A paging operation that must return result of the default &apos;value&apos; node. </summary>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetNoItemNamePagesNextPageAsync(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetNoItemNamePages");
            scope.Start();
            try
            {
                using var message = CreateGetNoItemNamePagesNextPageRequest(nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = ProductResultValue.DeserializeProductResultValue(document.RootElement);
                            return Page.FromValues(value.Value, value.NextLink, message.Response);
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
        /// <summary> A paging operation that must return result of the default &apos;value&apos; node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetNoItemNamePagesAsync(CancellationToken cancellationToken = default)
        {

            Task<Page<Product>> FirstPageFunc(int? pageSizeHint) => GetNoItemNamePagesFirstPageAsync(cancellationToken).AsTask();
            Task<Page<Product>> NextPageFunc(string continuationToken, int? pageSizeHint) => GetNoItemNamePagesNextPageAsync(continuationToken, cancellationToken).AsTask();
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        internal HttpMessage CreateGetNullNextLinkNamePagesRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/paging/nullnextlink", false);
            return message;
        }
        /// <summary> A paging operation that must ignore any kind of nextLink, and stop after page 1. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetNullNextLinkNamePagesAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetNullNextLinkNamePages");
            scope.Start();
            try
            {
                using var message = CreateGetNullNextLinkNamePagesRequest();
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
        /// <summary> A paging operation that must ignore any kind of nextLink, and stop after page 1. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetNullNextLinkNamePages(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetNullNextLinkNamePages");
            scope.Start();
            try
            {
                using var message = CreateGetNullNextLinkNamePagesRequest();
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
        internal HttpMessage CreateGetSinglePagesFirstPageRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/paging/single", false);
            return message;
        }
        /// <summary> A paging operation that finishes on the first call without a nextlink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetSinglePagesFirstPageAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetSinglePages");
            scope.Start();
            try
            {
                using var message = CreateGetSinglePagesFirstPageRequest();
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
        /// <summary> A paging operation that finishes on the first call without a nextlink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Page<Product> GetSinglePagesFirstPage(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetSinglePages");
            scope.Start();
            try
            {
                using var message = CreateGetSinglePagesFirstPageRequest();
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
        internal HttpMessage CreateGetSinglePagesNextPageRequest(string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
            return message;
        }
        /// <summary> A paging operation that finishes on the first call without a nextlink. </summary>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetSinglePagesNextPageAsync(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetSinglePages");
            scope.Start();
            try
            {
                using var message = CreateGetSinglePagesNextPageRequest(nextLinkUrl);
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
        /// <summary> A paging operation that finishes on the first call without a nextlink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetSinglePagesAsync(CancellationToken cancellationToken = default)
        {

            Task<Page<Product>> FirstPageFunc(int? pageSizeHint) => GetSinglePagesFirstPageAsync(cancellationToken).AsTask();
            Task<Page<Product>> NextPageFunc(string continuationToken, int? pageSizeHint) => GetSinglePagesNextPageAsync(continuationToken, cancellationToken).AsTask();
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        internal HttpMessage CreateGetMultiplePagesFirstPageRequest(string? clientRequestId, int? maxresults, int? timeout)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/paging/multiple", false);
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
            return message;
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetMultiplePagesFirstPageAsync(string? clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePages");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFirstPageRequest(clientRequestId, maxresults, timeout);
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
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Page<Product> GetMultiplePagesFirstPage(string? clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePages");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFirstPageRequest(clientRequestId, maxresults, timeout);
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
        internal HttpMessage CreateGetMultiplePagesNextPageRequest(string? clientRequestId, int? maxresults, int? timeout, string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
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
            return message;
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetMultiplePagesNextPageAsync(string? clientRequestId, int? maxresults, int? timeout, string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePages");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesNextPageRequest(clientRequestId, maxresults, timeout, nextLinkUrl);
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
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesAsync(string? clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            Task<Page<Product>> FirstPageFunc(int? pageSizeHint) => GetMultiplePagesFirstPageAsync(clientRequestId, maxresults, timeout, cancellationToken).AsTask();
            Task<Page<Product>> NextPageFunc(string continuationToken, int? pageSizeHint) => GetMultiplePagesNextPageAsync(clientRequestId, maxresults, timeout, continuationToken, cancellationToken).AsTask();
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        internal HttpMessage CreateGetOdataMultiplePagesFirstPageRequest(string? clientRequestId, int? maxresults, int? timeout)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/paging/multiple/odata", false);
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
            return message;
        }
        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetOdataMultiplePagesFirstPageAsync(string? clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetOdataMultiplePages");
            scope.Start();
            try
            {
                using var message = CreateGetOdataMultiplePagesFirstPageRequest(clientRequestId, maxresults, timeout);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.OdataNextLink, message.Response);
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
        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Page<Product> GetOdataMultiplePagesFirstPage(string? clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetOdataMultiplePages");
            scope.Start();
            try
            {
                using var message = CreateGetOdataMultiplePagesFirstPageRequest(clientRequestId, maxresults, timeout);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.OdataNextLink, message.Response);
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
        internal HttpMessage CreateGetOdataMultiplePagesNextPageRequest(string? clientRequestId, int? maxresults, int? timeout, string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
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
            return message;
        }
        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetOdataMultiplePagesNextPageAsync(string? clientRequestId, int? maxresults, int? timeout, string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetOdataMultiplePages");
            scope.Start();
            try
            {
                using var message = CreateGetOdataMultiplePagesNextPageRequest(clientRequestId, maxresults, timeout, nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.OdataNextLink, message.Response);
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
        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetOdataMultiplePagesAsync(string? clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            Task<Page<Product>> FirstPageFunc(int? pageSizeHint) => GetOdataMultiplePagesFirstPageAsync(clientRequestId, maxresults, timeout, cancellationToken).AsTask();
            Task<Page<Product>> NextPageFunc(string continuationToken, int? pageSizeHint) => GetOdataMultiplePagesNextPageAsync(clientRequestId, maxresults, timeout, continuationToken, cancellationToken).AsTask();
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        internal HttpMessage CreateGetMultiplePagesWithOffsetFirstPageRequest(string? clientRequestId, int? maxresults, int offset, int? timeout)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/paging/multiple/withpath/", false);
            request.Uri.AppendPath(offset, true);
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
            return message;
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="offset"> Offset of return value. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetMultiplePagesWithOffsetFirstPageAsync(string? clientRequestId, int? maxresults, int offset, int? timeout, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesWithOffset");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesWithOffsetFirstPageRequest(clientRequestId, maxresults, offset, timeout);
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
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="offset"> Offset of return value. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Page<Product> GetMultiplePagesWithOffsetFirstPage(string? clientRequestId, int? maxresults, int offset, int? timeout, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesWithOffset");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesWithOffsetFirstPageRequest(clientRequestId, maxresults, offset, timeout);
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
        internal HttpMessage CreateGetMultiplePagesWithOffsetNextPageRequest(string? clientRequestId, int? maxresults, int? timeout, string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
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
            return message;
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetMultiplePagesWithOffsetNextPageAsync(string? clientRequestId, int? maxresults, int? timeout, string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesWithOffset");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesWithOffsetNextPageRequest(clientRequestId, maxresults, timeout, nextLinkUrl);
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
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="offset"> Offset of return value. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesWithOffsetAsync(string? clientRequestId, int? maxresults, int offset, int? timeout, CancellationToken cancellationToken = default)
        {

            Task<Page<Product>> FirstPageFunc(int? pageSizeHint) => GetMultiplePagesWithOffsetFirstPageAsync(clientRequestId, maxresults, offset, timeout, cancellationToken).AsTask();
            Task<Page<Product>> NextPageFunc(string continuationToken, int? pageSizeHint) => GetMultiplePagesWithOffsetNextPageAsync(clientRequestId, maxresults, timeout, continuationToken, cancellationToken).AsTask();
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        internal HttpMessage CreateGetMultiplePagesRetryFirstFirstPageRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/paging/multiple/retryfirst", false);
            return message;
        }
        /// <summary> A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetMultiplePagesRetryFirstFirstPageAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesRetryFirst");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesRetryFirstFirstPageRequest();
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
        /// <summary> A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Page<Product> GetMultiplePagesRetryFirstFirstPage(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesRetryFirst");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesRetryFirstFirstPageRequest();
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
        internal HttpMessage CreateGetMultiplePagesRetryFirstNextPageRequest(string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
            return message;
        }
        /// <summary> A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages. </summary>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetMultiplePagesRetryFirstNextPageAsync(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesRetryFirst");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesRetryFirstNextPageRequest(nextLinkUrl);
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
        /// <summary> A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesRetryFirstAsync(CancellationToken cancellationToken = default)
        {

            Task<Page<Product>> FirstPageFunc(int? pageSizeHint) => GetMultiplePagesRetryFirstFirstPageAsync(cancellationToken).AsTask();
            Task<Page<Product>> NextPageFunc(string continuationToken, int? pageSizeHint) => GetMultiplePagesRetryFirstNextPageAsync(continuationToken, cancellationToken).AsTask();
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        internal HttpMessage CreateGetMultiplePagesRetrySecondFirstPageRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/paging/multiple/retrysecond", false);
            return message;
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetMultiplePagesRetrySecondFirstPageAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesRetrySecond");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesRetrySecondFirstPageRequest();
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
        /// <summary> A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Page<Product> GetMultiplePagesRetrySecondFirstPage(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesRetrySecond");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesRetrySecondFirstPageRequest();
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
        internal HttpMessage CreateGetMultiplePagesRetrySecondNextPageRequest(string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
            return message;
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually. </summary>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetMultiplePagesRetrySecondNextPageAsync(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesRetrySecond");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesRetrySecondNextPageRequest(nextLinkUrl);
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
        /// <summary> A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesRetrySecondAsync(CancellationToken cancellationToken = default)
        {

            Task<Page<Product>> FirstPageFunc(int? pageSizeHint) => GetMultiplePagesRetrySecondFirstPageAsync(cancellationToken).AsTask();
            Task<Page<Product>> NextPageFunc(string continuationToken, int? pageSizeHint) => GetMultiplePagesRetrySecondNextPageAsync(continuationToken, cancellationToken).AsTask();
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        internal HttpMessage CreateGetSinglePagesFailureFirstPageRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/paging/single/failure", false);
            return message;
        }
        /// <summary> A paging operation that receives a 400 on the first call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetSinglePagesFailureFirstPageAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetSinglePagesFailure");
            scope.Start();
            try
            {
                using var message = CreateGetSinglePagesFailureFirstPageRequest();
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
        /// <summary> A paging operation that receives a 400 on the first call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Page<Product> GetSinglePagesFailureFirstPage(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetSinglePagesFailure");
            scope.Start();
            try
            {
                using var message = CreateGetSinglePagesFailureFirstPageRequest();
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
        internal HttpMessage CreateGetSinglePagesFailureNextPageRequest(string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
            return message;
        }
        /// <summary> A paging operation that receives a 400 on the first call. </summary>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetSinglePagesFailureNextPageAsync(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetSinglePagesFailure");
            scope.Start();
            try
            {
                using var message = CreateGetSinglePagesFailureNextPageRequest(nextLinkUrl);
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
        /// <summary> A paging operation that receives a 400 on the first call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetSinglePagesFailureAsync(CancellationToken cancellationToken = default)
        {

            Task<Page<Product>> FirstPageFunc(int? pageSizeHint) => GetSinglePagesFailureFirstPageAsync(cancellationToken).AsTask();
            Task<Page<Product>> NextPageFunc(string continuationToken, int? pageSizeHint) => GetSinglePagesFailureNextPageAsync(continuationToken, cancellationToken).AsTask();
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        internal HttpMessage CreateGetMultiplePagesFailureFirstPageRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/paging/multiple/failure", false);
            return message;
        }
        /// <summary> A paging operation that receives a 400 on the second call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetMultiplePagesFailureFirstPageAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFailure");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFailureFirstPageRequest();
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
        /// <summary> A paging operation that receives a 400 on the second call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Page<Product> GetMultiplePagesFailureFirstPage(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFailure");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFailureFirstPageRequest();
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
        internal HttpMessage CreateGetMultiplePagesFailureNextPageRequest(string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
            return message;
        }
        /// <summary> A paging operation that receives a 400 on the second call. </summary>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetMultiplePagesFailureNextPageAsync(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFailure");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFailureNextPageRequest(nextLinkUrl);
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
        /// <summary> A paging operation that receives a 400 on the second call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesFailureAsync(CancellationToken cancellationToken = default)
        {

            Task<Page<Product>> FirstPageFunc(int? pageSizeHint) => GetMultiplePagesFailureFirstPageAsync(cancellationToken).AsTask();
            Task<Page<Product>> NextPageFunc(string continuationToken, int? pageSizeHint) => GetMultiplePagesFailureNextPageAsync(continuationToken, cancellationToken).AsTask();
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        internal HttpMessage CreateGetMultiplePagesFailureUriFirstPageRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/paging/multiple/failureuri", false);
            return message;
        }
        /// <summary> A paging operation that receives an invalid nextLink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetMultiplePagesFailureUriFirstPageAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFailureUri");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFailureUriFirstPageRequest();
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
        /// <summary> A paging operation that receives an invalid nextLink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Page<Product> GetMultiplePagesFailureUriFirstPage(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFailureUri");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFailureUriFirstPageRequest();
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
        internal HttpMessage CreateGetMultiplePagesFailureUriNextPageRequest(string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
            return message;
        }
        /// <summary> A paging operation that receives an invalid nextLink. </summary>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetMultiplePagesFailureUriNextPageAsync(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFailureUri");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFailureUriNextPageRequest(nextLinkUrl);
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
        /// <summary> A paging operation that receives an invalid nextLink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesFailureUriAsync(CancellationToken cancellationToken = default)
        {

            Task<Page<Product>> FirstPageFunc(int? pageSizeHint) => GetMultiplePagesFailureUriFirstPageAsync(cancellationToken).AsTask();
            Task<Page<Product>> NextPageFunc(string continuationToken, int? pageSizeHint) => GetMultiplePagesFailureUriNextPageAsync(continuationToken, cancellationToken).AsTask();
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        internal HttpMessage CreateGetMultiplePagesFragmentNextLinkFirstPageRequest(string apiVersion, string tenant)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/paging/multiple/fragment/", false);
            request.Uri.AppendPath(tenant, true);
            request.Uri.AppendQuery("api_version", apiVersion, true);
            return message;
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetMultiplePagesFragmentNextLinkFirstPageAsync(string apiVersion, string tenant, CancellationToken cancellationToken = default)
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFragmentNextLink");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFragmentNextLinkFirstPageRequest(apiVersion, tenant);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.OdataNextLink, message.Response);
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
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Page<Product> GetMultiplePagesFragmentNextLinkFirstPage(string apiVersion, string tenant, CancellationToken cancellationToken = default)
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFragmentNextLink");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFragmentNextLinkFirstPageRequest(apiVersion, tenant);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.OdataNextLink, message.Response);
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
        internal HttpMessage CreateGetMultiplePagesFragmentNextLinkNextPageRequest(string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
            return message;
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetMultiplePagesFragmentNextLinkNextPageAsync(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFragmentNextLink");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFragmentNextLinkNextPageRequest(nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.OdataNextLink, message.Response);
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

            Task<Page<Product>> FirstPageFunc(int? pageSizeHint) => GetMultiplePagesFragmentNextLinkFirstPageAsync(apiVersion, tenant, cancellationToken).AsTask();
            Task<Page<Product>> NextPageFunc(string continuationToken, int? pageSizeHint) => GetMultiplePagesFragmentNextLinkNextPageAsync(continuationToken, cancellationToken).AsTask();
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        internal HttpMessage CreateGetMultiplePagesFragmentWithGroupingNextLinkFirstPageRequest(string apiVersion, string tenant)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/paging/multiple/fragmentwithgrouping/", false);
            request.Uri.AppendPath(tenant, true);
            request.Uri.AppendQuery("api_version", apiVersion, true);
            return message;
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment with parameters grouped. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetMultiplePagesFragmentWithGroupingNextLinkFirstPageAsync(string apiVersion, string tenant, CancellationToken cancellationToken = default)
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFragmentWithGroupingNextLink");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFragmentWithGroupingNextLinkFirstPageRequest(apiVersion, tenant);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.OdataNextLink, message.Response);
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
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment with parameters grouped. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Page<Product> GetMultiplePagesFragmentWithGroupingNextLinkFirstPage(string apiVersion, string tenant, CancellationToken cancellationToken = default)
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFragmentWithGroupingNextLink");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFragmentWithGroupingNextLinkFirstPageRequest(apiVersion, tenant);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.OdataNextLink, message.Response);
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
        internal HttpMessage CreateGetMultiplePagesFragmentWithGroupingNextLinkNextPageRequest(string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
            return message;
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment with parameters grouped. </summary>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetMultiplePagesFragmentWithGroupingNextLinkNextPageAsync(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFragmentWithGroupingNextLink");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFragmentWithGroupingNextLinkNextPageRequest(nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.OdataNextLink, message.Response);
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

            Task<Page<Product>> FirstPageFunc(int? pageSizeHint) => GetMultiplePagesFragmentWithGroupingNextLinkFirstPageAsync(apiVersion, tenant, cancellationToken).AsTask();
            Task<Page<Product>> NextPageFunc(string continuationToken, int? pageSizeHint) => GetMultiplePagesFragmentWithGroupingNextLinkNextPageAsync(continuationToken, cancellationToken).AsTask();
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        internal HttpMessage CreateGetMultiplePagesLROFirstPageRequest(string? clientRequestId, int? maxresults, int? timeout)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/paging/multiple/lro", false);
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
            return message;
        }
        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetMultiplePagesLROFirstPageAsync(string? clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesLRO");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesLROFirstPageRequest(clientRequestId, maxresults, timeout);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Page<Product> GetMultiplePagesLROFirstPage(string? clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesLRO");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesLROFirstPageRequest(clientRequestId, maxresults, timeout);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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
        internal HttpMessage CreateGetMultiplePagesLRONextPageRequest(string? clientRequestId, int? maxresults, int? timeout, string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri(nextLinkUrl));
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
            return message;
        }
        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> GetMultiplePagesLRONextPageAsync(string? clientRequestId, int? maxresults, int? timeout, string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesLRO");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesLRONextPageRequest(clientRequestId, maxresults, timeout, nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesLROAsync(string? clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            Task<Page<Product>> FirstPageFunc(int? pageSizeHint) => GetMultiplePagesLROFirstPageAsync(clientRequestId, maxresults, timeout, cancellationToken).AsTask();
            Task<Page<Product>> NextPageFunc(string continuationToken, int? pageSizeHint) => GetMultiplePagesLRONextPageAsync(clientRequestId, maxresults, timeout, continuationToken, cancellationToken).AsTask();
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        internal HttpMessage CreateNextFragmentFirstPageRequest(string apiVersion, string tenant, string nextLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/paging/multiple/fragment/", false);
            request.Uri.AppendPath(tenant, true);
            request.Uri.AppendPath("/", false);
            request.Uri.AppendPath(nextLink, true);
            request.Uri.AppendQuery("api_version", apiVersion, true);
            return message;
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> NextFragmentFirstPageAsync(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
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

            using var scope = clientDiagnostics.CreateScope("PagingOperations.NextFragment");
            scope.Start();
            try
            {
                using var message = CreateNextFragmentFirstPageRequest(apiVersion, tenant, nextLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.OdataNextLink, message.Response);
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
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Page<Product> NextFragmentFirstPage(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
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

            using var scope = clientDiagnostics.CreateScope("PagingOperations.NextFragment");
            scope.Start();
            try
            {
                using var message = CreateNextFragmentFirstPageRequest(apiVersion, tenant, nextLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.OdataNextLink, message.Response);
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
        internal HttpMessage CreateNextFragmentNextPageRequest(string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
            return message;
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> NextFragmentNextPageAsync(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.NextFragment");
            scope.Start();
            try
            {
                using var message = CreateNextFragmentNextPageRequest(nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.OdataNextLink, message.Response);
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

            Task<Page<Product>> FirstPageFunc(int? pageSizeHint) => NextFragmentFirstPageAsync(apiVersion, tenant, nextLink, cancellationToken).AsTask();
            Task<Page<Product>> NextPageFunc(string continuationToken, int? pageSizeHint) => NextFragmentNextPageAsync(continuationToken, cancellationToken).AsTask();
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        internal HttpMessage CreateNextFragmentWithGroupingFirstPageRequest(string apiVersion, string tenant, string nextLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/paging/multiple/fragmentwithgrouping/", false);
            request.Uri.AppendPath(tenant, true);
            request.Uri.AppendPath("/", false);
            request.Uri.AppendPath(nextLink, true);
            request.Uri.AppendQuery("api_version", apiVersion, true);
            return message;
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> NextFragmentWithGroupingFirstPageAsync(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
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

            using var scope = clientDiagnostics.CreateScope("PagingOperations.NextFragmentWithGrouping");
            scope.Start();
            try
            {
                using var message = CreateNextFragmentWithGroupingFirstPageRequest(apiVersion, tenant, nextLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.OdataNextLink, message.Response);
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
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Page<Product> NextFragmentWithGroupingFirstPage(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
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

            using var scope = clientDiagnostics.CreateScope("PagingOperations.NextFragmentWithGrouping");
            scope.Start();
            try
            {
                using var message = CreateNextFragmentWithGroupingFirstPageRequest(apiVersion, tenant, nextLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.OdataNextLink, message.Response);
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
        internal HttpMessage CreateNextFragmentWithGroupingNextPageRequest(string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
            return message;
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Page<Product>> NextFragmentWithGroupingNextPageAsync(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.NextFragmentWithGrouping");
            scope.Start();
            try
            {
                using var message = CreateNextFragmentWithGroupingNextPageRequest(nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                            return Page.FromValues(value.Values, value.OdataNextLink, message.Response);
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

            Task<Page<Product>> FirstPageFunc(int? pageSizeHint) => NextFragmentWithGroupingFirstPageAsync(apiVersion, tenant, nextLink, cancellationToken).AsTask();
            Task<Page<Product>> NextPageFunc(string continuationToken, int? pageSizeHint) => NextFragmentWithGroupingNextPageAsync(continuationToken, cancellationToken).AsTask();
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
