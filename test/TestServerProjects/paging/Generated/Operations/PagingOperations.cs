// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using paging.Models;

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
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paging/noitemname", false);
            request.Uri = uri;
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
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
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paging/nullnextlink", false);
            request.Uri = uri;
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
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
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paging/single", false);
            request.Uri = uri;
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetMultiplePagesRequest(string clientRequestId, int? maxresults, int? timeout)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
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
            return message;
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetMultiplePagesAsync(string clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePages(string clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetOdataMultiplePagesRequest(string clientRequestId, int? maxresults, int? timeout)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
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
            return message;
        }
        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<OdataProductResult>> GetOdataMultiplePagesAsync(string clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<OdataProductResult> GetOdataMultiplePages(string clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetMultiplePagesWithOffsetRequest(string clientRequestId, int? maxresults, int offset, int? timeout)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
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
            return message;
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="offset"> Offset of return value. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetMultiplePagesWithOffsetAsync(string clientRequestId, int? maxresults, int offset, int? timeout, CancellationToken cancellationToken = default)
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="offset"> Offset of return value. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesWithOffset(string clientRequestId, int? maxresults, int offset, int? timeout, CancellationToken cancellationToken = default)
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
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
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paging/multiple/retryfirst", false);
            request.Uri = uri;
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
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
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paging/multiple/retrysecond", false);
            request.Uri = uri;
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
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
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paging/single/failure", false);
            request.Uri = uri;
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
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
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paging/multiple/failure", false);
            request.Uri = uri;
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
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
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paging/multiple/failureuri", false);
            request.Uri = uri;
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
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
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paging/multiple/fragment/", false);
            uri.AppendPath(tenant, true);
            uri.AppendQuery("api_version", apiVersion, true);
            request.Uri = uri;
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
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
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paging/multiple/fragmentwithgrouping/", false);
            uri.AppendPath(tenant, true);
            uri.AppendQuery("api_version", apiVersion, true);
            request.Uri = uri;
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetMultiplePagesLRORequest(string clientRequestId, int? maxresults, int? timeout)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
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
            return message;
        }
        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetMultiplePagesLROAsync(string clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesLRO(string clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
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
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paging/multiple/fragment/", false);
            uri.AppendPath(tenant, true);
            uri.AppendPath("/", false);
            uri.AppendPath(nextLink, false);
            uri.AppendQuery("api_version", apiVersion, true);
            request.Uri = uri;
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
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
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/paging/multiple/fragmentwithgrouping/", false);
            uri.AppendPath(tenant, true);
            uri.AppendPath("/", false);
            uri.AppendPath(nextLink, false);
            uri.AppendQuery("api_version", apiVersion, true);
            request.Uri = uri;
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetNoItemNamePagesNextPageRequest(string nextLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(nextLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> A paging operation that must return result of the default &apos;value&apos; node. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResultValue>> GetNoItemNamePagesNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetNoItemNamePages");
            scope.Start();
            try
            {
                using var message = CreateGetNoItemNamePagesNextPageRequest(nextLink);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A paging operation that must return result of the default &apos;value&apos; node. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResultValue> GetNoItemNamePagesNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetNoItemNamePages");
            scope.Start();
            try
            {
                using var message = CreateGetNoItemNamePagesNextPageRequest(nextLink);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetNullNextLinkNamePagesNextPageRequest(string nextLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(nextLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> A paging operation that must ignore any kind of nextLink, and stop after page 1. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetNullNextLinkNamePagesNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetNullNextLinkNamePages");
            scope.Start();
            try
            {
                using var message = CreateGetNullNextLinkNamePagesNextPageRequest(nextLink);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A paging operation that must ignore any kind of nextLink, and stop after page 1. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetNullNextLinkNamePagesNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetNullNextLinkNamePages");
            scope.Start();
            try
            {
                using var message = CreateGetNullNextLinkNamePagesNextPageRequest(nextLink);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetSinglePagesNextPageRequest(string nextLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(nextLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> A paging operation that finishes on the first call without a nextlink. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetSinglePagesNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetSinglePages");
            scope.Start();
            try
            {
                using var message = CreateGetSinglePagesNextPageRequest(nextLink);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A paging operation that finishes on the first call without a nextlink. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetSinglePagesNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetSinglePages");
            scope.Start();
            try
            {
                using var message = CreateGetSinglePagesNextPageRequest(nextLink);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetMultiplePagesNextPageRequest(string clientRequestId, int? maxresults, int? timeout, string nextLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(nextLink, false);
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
            return message;
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetMultiplePagesNextPageAsync(string clientRequestId, int? maxresults, int? timeout, string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePages");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesNextPageRequest(clientRequestId, maxresults, timeout, nextLink);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesNextPage(string clientRequestId, int? maxresults, int? timeout, string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePages");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesNextPageRequest(clientRequestId, maxresults, timeout, nextLink);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetOdataMultiplePagesNextPageRequest(string clientRequestId, int? maxresults, int? timeout, string nextLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(nextLink, false);
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
            return message;
        }
        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<OdataProductResult>> GetOdataMultiplePagesNextPageAsync(string clientRequestId, int? maxresults, int? timeout, string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetOdataMultiplePages");
            scope.Start();
            try
            {
                using var message = CreateGetOdataMultiplePagesNextPageRequest(clientRequestId, maxresults, timeout, nextLink);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<OdataProductResult> GetOdataMultiplePagesNextPage(string clientRequestId, int? maxresults, int? timeout, string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetOdataMultiplePages");
            scope.Start();
            try
            {
                using var message = CreateGetOdataMultiplePagesNextPageRequest(clientRequestId, maxresults, timeout, nextLink);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetMultiplePagesWithOffsetNextPageRequest(string clientRequestId, int? maxresults, int? timeout, string nextLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(nextLink, false);
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
            return message;
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetMultiplePagesWithOffsetNextPageAsync(string clientRequestId, int? maxresults, int? timeout, string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesWithOffset");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesWithOffsetNextPageRequest(clientRequestId, maxresults, timeout, nextLink);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesWithOffsetNextPage(string clientRequestId, int? maxresults, int? timeout, string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesWithOffset");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesWithOffsetNextPageRequest(clientRequestId, maxresults, timeout, nextLink);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetMultiplePagesRetryFirstNextPageRequest(string nextLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(nextLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetMultiplePagesRetryFirstNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesRetryFirst");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesRetryFirstNextPageRequest(nextLink);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesRetryFirstNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesRetryFirst");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesRetryFirstNextPageRequest(nextLink);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetMultiplePagesRetrySecondNextPageRequest(string nextLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(nextLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetMultiplePagesRetrySecondNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesRetrySecond");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesRetrySecondNextPageRequest(nextLink);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesRetrySecondNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesRetrySecond");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesRetrySecondNextPageRequest(nextLink);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetSinglePagesFailureNextPageRequest(string nextLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(nextLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> A paging operation that receives a 400 on the first call. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetSinglePagesFailureNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetSinglePagesFailure");
            scope.Start();
            try
            {
                using var message = CreateGetSinglePagesFailureNextPageRequest(nextLink);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A paging operation that receives a 400 on the first call. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetSinglePagesFailureNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetSinglePagesFailure");
            scope.Start();
            try
            {
                using var message = CreateGetSinglePagesFailureNextPageRequest(nextLink);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetMultiplePagesFailureNextPageRequest(string nextLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(nextLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> A paging operation that receives a 400 on the second call. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetMultiplePagesFailureNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFailure");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFailureNextPageRequest(nextLink);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A paging operation that receives a 400 on the second call. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesFailureNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFailure");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFailureNextPageRequest(nextLink);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetMultiplePagesFailureUriNextPageRequest(string nextLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(nextLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> A paging operation that receives an invalid nextLink. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetMultiplePagesFailureUriNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFailureUri");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFailureUriNextPageRequest(nextLink);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A paging operation that receives an invalid nextLink. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesFailureUriNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesFailureUri");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesFailureUriNextPageRequest(nextLink);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetMultiplePagesLRONextPageRequest(string clientRequestId, int? maxresults, int? timeout, string nextLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(nextLink, false);
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
            return message;
        }
        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ProductResult>> GetMultiplePagesLRONextPageAsync(string clientRequestId, int? maxresults, int? timeout, string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesLRO");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesLRONextPageRequest(clientRequestId, maxresults, timeout, nextLink);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesLRONextPage(string clientRequestId, int? maxresults, int? timeout, string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("PagingOperations.GetMultiplePagesLRO");
            scope.Start();
            try
            {
                using var message = CreateGetMultiplePagesLRONextPageRequest(clientRequestId, maxresults, timeout, nextLink);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
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
        public AsyncPageable<Product> GetNoItemNamePagesPageableAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetNoItemNamePagesAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await GetNoItemNamePagesNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that must return result of the default &apos;value&apos; node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetNoItemNamePagesPageable(CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetNoItemNamePages(cancellationToken);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = GetNoItemNamePagesNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that must ignore any kind of nextLink, and stop after page 1. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetNullNextLinkNamePagesPageableAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetNullNextLinkNamePagesAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, null, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await GetNullNextLinkNamePagesNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, null, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that must ignore any kind of nextLink, and stop after page 1. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetNullNextLinkNamePagesPageable(CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetNullNextLinkNamePages(cancellationToken);
                return Page.FromValues(response.Value.Values, null, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = GetNullNextLinkNamePagesNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, null, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that finishes on the first call without a nextlink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetSinglePagesPageableAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetSinglePagesAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await GetSinglePagesNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that finishes on the first call without a nextlink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetSinglePagesPageable(CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetSinglePages(cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = GetSinglePagesNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesPageableAsync(string clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetMultiplePagesAsync(clientRequestId, maxresults, timeout, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await GetMultiplePagesNextPageAsync(clientRequestId, maxresults, timeout, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetMultiplePagesPageable(string clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetMultiplePages(clientRequestId, maxresults, timeout, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = GetMultiplePagesNextPage(clientRequestId, maxresults, timeout, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetOdataMultiplePagesPageableAsync(string clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetOdataMultiplePagesAsync(clientRequestId, maxresults, timeout, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await GetOdataMultiplePagesNextPageAsync(clientRequestId, maxresults, timeout, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetOdataMultiplePagesPageable(string clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetOdataMultiplePages(clientRequestId, maxresults, timeout, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = GetOdataMultiplePagesNextPage(clientRequestId, maxresults, timeout, nextLink, cancellationToken);
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
        public AsyncPageable<Product> GetMultiplePagesWithOffsetPageableAsync(string clientRequestId, int? maxresults, int offset, int? timeout, CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetMultiplePagesWithOffsetAsync(clientRequestId, maxresults, offset, timeout, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await GetMultiplePagesWithOffsetNextPageAsync(clientRequestId, maxresults, timeout, nextLink, cancellationToken).ConfigureAwait(false);
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
        public Pageable<Product> GetMultiplePagesWithOffsetPageable(string clientRequestId, int? maxresults, int offset, int? timeout, CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetMultiplePagesWithOffset(clientRequestId, maxresults, offset, timeout, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = GetMultiplePagesWithOffsetNextPage(clientRequestId, maxresults, timeout, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesRetryFirstPageableAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetMultiplePagesRetryFirstAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await GetMultiplePagesRetryFirstNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetMultiplePagesRetryFirstPageable(CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetMultiplePagesRetryFirst(cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = GetMultiplePagesRetryFirstNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesRetrySecondPageableAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetMultiplePagesRetrySecondAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await GetMultiplePagesRetrySecondNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetMultiplePagesRetrySecondPageable(CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetMultiplePagesRetrySecond(cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = GetMultiplePagesRetrySecondNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that receives a 400 on the first call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetSinglePagesFailurePageableAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetSinglePagesFailureAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await GetSinglePagesFailureNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that receives a 400 on the first call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetSinglePagesFailurePageable(CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetSinglePagesFailure(cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = GetSinglePagesFailureNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that receives a 400 on the second call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesFailurePageableAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetMultiplePagesFailureAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await GetMultiplePagesFailureNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that receives a 400 on the second call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetMultiplePagesFailurePageable(CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetMultiplePagesFailure(cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = GetMultiplePagesFailureNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that receives an invalid nextLink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesFailureUriPageableAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetMultiplePagesFailureUriAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await GetMultiplePagesFailureUriNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that receives an invalid nextLink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetMultiplePagesFailureUriPageable(CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetMultiplePagesFailureUri(cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = GetMultiplePagesFailureUriNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesFragmentNextLinkPageableAsync(string apiVersion, string tenant, CancellationToken cancellationToken = default)
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
                var response = await GetMultiplePagesFragmentNextLinkAsync(apiVersion, tenant, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await NextFragmentAsync(apiVersion, tenant, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetMultiplePagesFragmentNextLinkPageable(string apiVersion, string tenant, CancellationToken cancellationToken = default)
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
                var response = GetMultiplePagesFragmentNextLink(apiVersion, tenant, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = NextFragment(apiVersion, tenant, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment with parameters grouped. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesFragmentWithGroupingNextLinkPageableAsync(string apiVersion, string tenant, CancellationToken cancellationToken = default)
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
                var response = await GetMultiplePagesFragmentWithGroupingNextLinkAsync(apiVersion, tenant, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await NextFragmentWithGroupingAsync(apiVersion, tenant, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment with parameters grouped. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetMultiplePagesFragmentWithGroupingNextLinkPageable(string apiVersion, string tenant, CancellationToken cancellationToken = default)
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
                var response = GetMultiplePagesFragmentWithGroupingNextLink(apiVersion, tenant, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = NextFragmentWithGrouping(apiVersion, tenant, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> GetMultiplePagesLROPageableAsync(string clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {
            async Task<Page<Product>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetMultiplePagesLROAsync(clientRequestId, maxresults, timeout, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await GetMultiplePagesLRONextPageAsync(clientRequestId, maxresults, timeout, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> GetMultiplePagesLROPageable(string clientRequestId, int? maxresults, int? timeout, CancellationToken cancellationToken = default)
        {
            Page<Product> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetMultiplePagesLRO(clientRequestId, maxresults, timeout, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = GetMultiplePagesLRONextPage(clientRequestId, maxresults, timeout, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> NextFragmentPageableAsync(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
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
                var response = await NextFragmentAsync(apiVersion, tenant, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await NextFragmentAsync(apiVersion, tenant, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> NextFragmentPageable(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
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
                var response = NextFragment(apiVersion, tenant, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = NextFragment(apiVersion, tenant, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Product> NextFragmentWithGroupingPageableAsync(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
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
                var response = await NextFragmentWithGroupingAsync(apiVersion, tenant, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            async Task<Page<Product>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await NextFragmentWithGroupingAsync(apiVersion, tenant, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> A paging operation that doesn&apos;t return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Product> NextFragmentWithGroupingPageable(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
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
                var response = NextFragmentWithGrouping(apiVersion, tenant, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            Page<Product> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = NextFragmentWithGrouping(apiVersion, tenant, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Values, response.Value.OdataNextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
