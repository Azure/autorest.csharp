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
        internal HttpMessage CreateGetNoItemNamePagesRequest()
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
        public async ValueTask<Response<ProductResultValue>> GetNoItemNamePagesAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetNoItemNamePages");
            scope.Start();
            try
            {
                using var message = CreateGetNoItemNamePagesRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = ProductResultValue.DeserializeProductResultValue(document.RootElement);
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
        /// <summary> A paging operation that must return result of the default &apos;value&apos; node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResultValue> GetNoItemNamePages(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetNoItemNamePages");
            scope.Start();
            try
            {
                using var message = CreateGetNoItemNamePagesRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = ProductResultValue.DeserializeProductResultValue(document.RootElement);
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
        internal HttpMessage CreateGetNoItemNamePagesPageRequest(string? nextLinkUrl)
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
        public async ValueTask<Response<ProductResultValue>> GetNoItemNamePagesNextPage(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetNoItemNamePages");
            scope.Start();
            try
            {
                using var message = CreateGetNoItemNamePagesPageRequest(nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = ProductResultValue.DeserializeProductResultValue(document.RootElement);
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
        internal HttpMessage CreateGetNullNextLinkNamePagesPageRequest(string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
            return message;
        }
        /// <summary> A paging operation that must ignore any kind of nextLink, and stop after page 1. </summary>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetNullNextLinkNamePagesNextPage(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetNullNextLinkNamePages");
            scope.Start();
            try
            {
                using var message = CreateGetNullNextLinkNamePagesPageRequest(nextLinkUrl);
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
        internal HttpMessage CreateGetSinglePagesRequest()
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
        public async ValueTask<Response<ProductResult>> GetSinglePagesAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetSinglePages");
            scope.Start();
            try
            {
                using var message = CreateGetSinglePagesRequest();
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
        /// <summary> A paging operation that finishes on the first call without a nextlink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetSinglePages(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetSinglePages");
            scope.Start();
            try
            {
                using var message = CreateGetSinglePagesRequest();
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
        internal HttpMessage CreateGetSinglePagesPageRequest(string? nextLinkUrl)
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
        public async ValueTask<Response<ProductResult>> GetSinglePagesNextPage(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetSinglePages");
            scope.Start();
            try
            {
                using var message = CreateGetSinglePagesPageRequest(nextLinkUrl);
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
        internal HttpMessage CreateGetMultiplePagesRequest(string? clientRequestId, int? maxresults, int? timeout)
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
        public async ValueTask<Response<ProductResult>> GetMultiplePagesAsync(string? clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePages");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesRequest(clientRequestId, maxresults, timeout);
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
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePages(string? clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePages");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesRequest(clientRequestId, maxresults, timeout);
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
        internal HttpMessage CreateGetMultiplePagesPageRequest(string? clientRequestId, int? maxresults, int? timeout, string? nextLinkUrl)
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
        public async ValueTask<Response<ProductResult>> GetMultiplePagesNextPage(string? clientRequestId, int? maxresults, int? timeout, string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePages");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesPageRequest(clientRequestId, maxresults, timeout, nextLinkUrl);
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
        internal HttpMessage CreateGetOdataMultiplePagesRequest(string? clientRequestId, int? maxresults, int? timeout)
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
        public async ValueTask<Response<OdataProductResult>> GetOdataMultiplePagesAsync(string? clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetOdataMultiplePages");
            scope.Start();
            try
            {
                using var message = CreateGetOdataMultiplePagesRequest(clientRequestId, maxresults, timeout);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
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
        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<OdataProductResult> GetOdataMultiplePages(string? clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetOdataMultiplePages");
            scope.Start();
            try
            {
                using var message = CreateGetOdataMultiplePagesRequest(clientRequestId, maxresults, timeout);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
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
        internal HttpMessage CreateGetOdataMultiplePagesPageRequest(string? clientRequestId, int? maxresults, int? timeout, string? nextLinkUrl)
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
        public async ValueTask<Response<OdataProductResult>> GetOdataMultiplePagesNextPage(string? clientRequestId, int? maxresults, int? timeout, string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetOdataMultiplePages");
            scope.Start();
            try
            {
                using var message = CreateGetOdataMultiplePagesPageRequest(clientRequestId, maxresults, timeout, nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
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
        internal HttpMessage CreateGetMultiplePagesWithOffsetRequest(string? clientRequestId, int? maxresults, int offset, int? timeout)
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
        public async ValueTask<Response<ProductResult>> GetMultiplePagesWithOffsetAsync(string? clientRequestId, int? maxresults, int offset, int? timeout, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesWithOffset");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesWithOffsetRequest(clientRequestId, maxresults, offset, timeout);
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
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="offset"> Offset of return value. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesWithOffset(string? clientRequestId, int? maxresults, int offset, int? timeout, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesWithOffset");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesWithOffsetRequest(clientRequestId, maxresults, offset, timeout);
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
        internal HttpMessage CreateGetMultiplePagesWithOffsetPageRequest(string? clientRequestId, int? maxresults, int offset, int? timeout, string? nextLinkUrl)
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
        /// <param name="offset"> Offset of return value. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetMultiplePagesWithOffsetNextPage(string? clientRequestId, int? maxresults, int offset, int? timeout, string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesWithOffset");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesWithOffsetPageRequest(clientRequestId, maxresults, offset, timeout, nextLinkUrl);
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
        internal HttpMessage CreateGetMultiplePagesRetryFirstRequest()
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
        public async ValueTask<Response<ProductResult>> GetMultiplePagesRetryFirstAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesRetryFirst");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesRetryFirstRequest();
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
        /// <summary> A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesRetryFirst(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesRetryFirst");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesRetryFirstRequest();
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
        internal HttpMessage CreateGetMultiplePagesRetryFirstPageRequest(string? nextLinkUrl)
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
        public async ValueTask<Response<ProductResult>> GetMultiplePagesRetryFirstNextPage(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesRetryFirst");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesRetryFirstPageRequest(nextLinkUrl);
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
        internal HttpMessage CreateGetMultiplePagesRetrySecondRequest()
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
        public async ValueTask<Response<ProductResult>> GetMultiplePagesRetrySecondAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesRetrySecond");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesRetrySecondRequest();
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
        /// <summary> A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesRetrySecond(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesRetrySecond");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesRetrySecondRequest();
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
        internal HttpMessage CreateGetMultiplePagesRetrySecondPageRequest(string? nextLinkUrl)
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
        public async ValueTask<Response<ProductResult>> GetMultiplePagesRetrySecondNextPage(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesRetrySecond");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesRetrySecondPageRequest(nextLinkUrl);
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
        internal HttpMessage CreateGetSinglePagesFailureRequest()
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
        public async ValueTask<Response<ProductResult>> GetSinglePagesFailureAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetSinglePagesFailure");
            scope.Start();
            try
            {
                using var message = CreateGetSinglePagesFailureRequest();
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
        /// <summary> A paging operation that receives a 400 on the first call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetSinglePagesFailure(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetSinglePagesFailure");
            scope.Start();
            try
            {
                using var message = CreateGetSinglePagesFailureRequest();
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
        internal HttpMessage CreateGetSinglePagesFailurePageRequest(string? nextLinkUrl)
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
        public async ValueTask<Response<ProductResult>> GetSinglePagesFailureNextPage(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetSinglePagesFailure");
            scope.Start();
            try
            {
                using var message = CreateGetSinglePagesFailurePageRequest(nextLinkUrl);
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
        internal HttpMessage CreateGetMultiplePagesFailureRequest()
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
        public async ValueTask<Response<ProductResult>> GetMultiplePagesFailureAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFailure");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFailureRequest();
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
        /// <summary> A paging operation that receives a 400 on the second call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesFailure(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFailure");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFailureRequest();
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
        internal HttpMessage CreateGetMultiplePagesFailurePageRequest(string? nextLinkUrl)
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
        public async ValueTask<Response<ProductResult>> GetMultiplePagesFailureNextPage(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFailure");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFailurePageRequest(nextLinkUrl);
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
        internal HttpMessage CreateGetMultiplePagesFailureUriRequest()
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
        public async ValueTask<Response<ProductResult>> GetMultiplePagesFailureUriAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFailureUri");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFailureUriRequest();
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
        /// <summary> A paging operation that receives an invalid nextLink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesFailureUri(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFailureUri");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFailureUriRequest();
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
        internal HttpMessage CreateGetMultiplePagesFailureUriPageRequest(string? nextLinkUrl)
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
        public async ValueTask<Response<ProductResult>> GetMultiplePagesFailureUriNextPage(string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFailureUri");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFailureUriPageRequest(nextLinkUrl);
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
        internal HttpMessage CreateGetMultiplePagesFragmentNextLinkRequest(string apiVersion, string tenant)
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
        public async ValueTask<Response<OdataProductResult>> GetMultiplePagesFragmentNextLinkAsync(string apiVersion, string tenant, CancellationToken cancellationToken = default)
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
                using var message = CreateGetMultiplePagesFragmentNextLinkRequest(apiVersion, tenant);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
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
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<OdataProductResult> GetMultiplePagesFragmentNextLink(string apiVersion, string tenant, CancellationToken cancellationToken = default)
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
                using var message = CreateGetMultiplePagesFragmentNextLinkRequest(apiVersion, tenant);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
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
        internal HttpMessage CreateGetMultiplePagesFragmentNextLinkPageRequest(string apiVersion, string tenant, string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
            request.Uri.AppendQuery("api_version", apiVersion, true);
            return message;
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<OdataProductResult>> GetMultiplePagesFragmentNextLinkNextPage(string apiVersion, string tenant, string nextLinkUrl, CancellationToken cancellationToken = default)
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
                using var message = CreateGetMultiplePagesFragmentNextLinkPageRequest(apiVersion, tenant, nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
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
        internal HttpMessage CreateGetMultiplePagesFragmentWithGroupingNextLinkRequest(string apiVersion, string tenant)
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
        public async ValueTask<Response<OdataProductResult>> GetMultiplePagesFragmentWithGroupingNextLinkAsync(string apiVersion, string tenant, CancellationToken cancellationToken = default)
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
                using var message = CreateGetMultiplePagesFragmentWithGroupingNextLinkRequest(apiVersion, tenant);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
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
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment with parameters grouped. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<OdataProductResult> GetMultiplePagesFragmentWithGroupingNextLink(string apiVersion, string tenant, CancellationToken cancellationToken = default)
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
                using var message = CreateGetMultiplePagesFragmentWithGroupingNextLinkRequest(apiVersion, tenant);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
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
        internal HttpMessage CreateGetMultiplePagesFragmentWithGroupingNextLinkPageRequest(string apiVersion, string tenant, string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
            request.Uri.AppendQuery("api_version", apiVersion, true);
            return message;
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment with parameters grouped. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<OdataProductResult>> GetMultiplePagesFragmentWithGroupingNextLinkNextPage(string apiVersion, string tenant, string nextLinkUrl, CancellationToken cancellationToken = default)
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
                using var message = CreateGetMultiplePagesFragmentWithGroupingNextLinkPageRequest(apiVersion, tenant, nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
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
        internal HttpMessage CreateGetMultiplePagesLRORequest(string? clientRequestId, int? maxresults, int? timeout)
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
        public async ValueTask<Response<ProductResult>> GetMultiplePagesLROAsync(string? clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesLRO");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesLRORequest(clientRequestId, maxresults, timeout);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> MISSING·PARAMETER-DESCRIPTION. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesLRO(string? clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesLRO");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesLRORequest(clientRequestId, maxresults, timeout);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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
        internal HttpMessage CreateGetMultiplePagesLROPageRequest(string? clientRequestId, int? maxresults, int? timeout, string? nextLinkUrl)
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
        public async ValueTask<Response<ProductResult>> GetMultiplePagesLRONextPage(string? clientRequestId, int? maxresults, int? timeout, string nextLinkUrl, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesLRO");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesLROPageRequest(clientRequestId, maxresults, timeout, nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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
        internal HttpMessage CreateNextFragmentRequest(string apiVersion, string tenant, string nextLink)
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
        public async ValueTask<Response<OdataProductResult>> NextFragmentAsync(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
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
                using var message = CreateNextFragmentRequest(apiVersion, tenant, nextLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
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
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<OdataProductResult> NextFragment(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
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
                using var message = CreateNextFragmentRequest(apiVersion, tenant, nextLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
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
        internal HttpMessage CreateNextFragmentPageRequest(string apiVersion, string tenant, string nextLink, string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
            request.Uri.AppendQuery("api_version", apiVersion, true);
            return message;
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<OdataProductResult>> NextFragmentNextPage(string apiVersion, string tenant, string nextLink, string nextLinkUrl, CancellationToken cancellationToken = default)
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
                using var message = CreateNextFragmentPageRequest(apiVersion, tenant, nextLink, nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
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
        internal HttpMessage CreateNextFragmentWithGroupingRequest(string apiVersion, string tenant, string nextLink)
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
        public async ValueTask<Response<OdataProductResult>> NextFragmentWithGroupingAsync(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
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
                using var message = CreateNextFragmentWithGroupingRequest(apiVersion, tenant, nextLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
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
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<OdataProductResult> NextFragmentWithGrouping(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
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
                using var message = CreateNextFragmentWithGroupingRequest(apiVersion, tenant, nextLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
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
        internal HttpMessage CreateNextFragmentWithGroupingPageRequest(string apiVersion, string tenant, string nextLink, string? nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri(nextLinkUrl));
            request.Uri.AppendQuery("api_version", apiVersion, true);
            return message;
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<OdataProductResult>> NextFragmentWithGroupingNextPage(string apiVersion, string tenant, string nextLink, string nextLinkUrl, CancellationToken cancellationToken = default)
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
                using var message = CreateNextFragmentWithGroupingPageRequest(apiVersion, tenant, nextLink, nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
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
    }
}
