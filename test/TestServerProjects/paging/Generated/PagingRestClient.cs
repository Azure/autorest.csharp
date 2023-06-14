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
    internal partial class PagingRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of PagingRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public PagingRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateGetNoItemNamePagesRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/noitemname", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that must return result of the default 'value' node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ProductResultValue>> GetNoItemNamePagesAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNoItemNamePagesRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResultValue value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResultValue.DeserializeProductResultValue(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that must return result of the default 'value' node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResultValue> GetNoItemNamePages(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNoItemNamePagesRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResultValue value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResultValue.DeserializeProductResultValue(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetNullNextLinkNamePagesRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/nullnextlink", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that must ignore any kind of nextLink, and stop after page 1. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ProductResult>> GetNullNextLinkNamePagesAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNullNextLinkNamePagesRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that must ignore any kind of nextLink, and stop after page 1. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetNullNextLinkNamePages(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetNullNextLinkNamePagesRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetSinglePagesRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/single", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that finishes on the first call without a nextlink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ProductResult>> GetSinglePagesAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSinglePagesRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that finishes on the first call without a nextlink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetSinglePages(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSinglePagesRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateFirstResponseEmptyRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/firstResponseEmpty/1", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation whose first response's items list is empty, but still returns a next link. Second (and final) call, will give you an items list of 1. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ProductResultValue>> FirstResponseEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateFirstResponseEmptyRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResultValue value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResultValue.DeserializeProductResultValue(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation whose first response's items list is empty, but still returns a next link. Second (and final) call, will give you an items list of 1. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResultValue> FirstResponseEmpty(CancellationToken cancellationToken = default)
        {
            using var message = CreateFirstResponseEmptyRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResultValue value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResultValue.DeserializeProductResultValue(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMultiplePagesRequest(string clientRequestId, PagingGetMultiplePagesOptions pagingGetMultiplePagesOptions)
        {
            var message = _pipeline.CreateMessage();
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
            if (pagingGetMultiplePagesOptions?.Maxresults != null)
            {
                request.Headers.Add("maxresults", pagingGetMultiplePagesOptions.Maxresults.Value);
            }
            if (pagingGetMultiplePagesOptions?.Timeout != null)
            {
                request.Headers.Add("timeout", pagingGetMultiplePagesOptions.Timeout.Value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="pagingGetMultiplePagesOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ProductResult>> GetMultiplePagesAsync(string clientRequestId = null, PagingGetMultiplePagesOptions pagingGetMultiplePagesOptions = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetMultiplePagesRequest(clientRequestId, pagingGetMultiplePagesOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="pagingGetMultiplePagesOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePages(string clientRequestId = null, PagingGetMultiplePagesOptions pagingGetMultiplePagesOptions = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetMultiplePagesRequest(clientRequestId, pagingGetMultiplePagesOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetWithQueryParamsRequest(int requiredQueryParameter)
        {
            var message = _pipeline.CreateMessage();
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

        /// <summary> A paging operation that includes a next operation. It has a different query parameter from it's next operation nextOperationWithQueryParams. Returns a ProductResult. </summary>
        /// <param name="requiredQueryParameter"> A required integer query parameter. Put in value '100' to pass test. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ProductResult>> GetWithQueryParamsAsync(int requiredQueryParameter, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetWithQueryParamsRequest(requiredQueryParameter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that includes a next operation. It has a different query parameter from it's next operation nextOperationWithQueryParams. Returns a ProductResult. </summary>
        /// <param name="requiredQueryParameter"> A required integer query parameter. Put in value '100' to pass test. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetWithQueryParams(int requiredQueryParameter, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetWithQueryParamsRequest(requiredQueryParameter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDuplicateParamsRequest(string filter)
        {
            var message = _pipeline.CreateMessage();
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

        /// <summary> Define `filter` as a query param for all calls. However, the returned next link will also include the `filter` as part of it. Make sure you don't end up duplicating the `filter` param in the url sent. </summary>
        /// <param name="filter"> OData filter options. Pass in 'foo'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ProductResult>> DuplicateParamsAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateDuplicateParamsRequest(filter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Define `filter` as a query param for all calls. However, the returned next link will also include the `filter` as part of it. Make sure you don't end up duplicating the `filter` param in the url sent. </summary>
        /// <param name="filter"> OData filter options. Pass in 'foo'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> DuplicateParams(string filter = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateDuplicateParamsRequest(filter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateNextOperationWithQueryParamsRequest()
        {
            var message = _pipeline.CreateMessage();
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

        /// <summary> Next operation for getWithQueryParams. Pass in next=True to pass test. Returns a ProductResult. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ProductResult>> NextOperationWithQueryParamsAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateNextOperationWithQueryParamsRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Next operation for getWithQueryParams. Pass in next=True to pass test. Returns a ProductResult. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> NextOperationWithQueryParams(CancellationToken cancellationToken = default)
        {
            using var message = CreateNextOperationWithQueryParamsRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetOdataMultiplePagesRequest(string clientRequestId, PagingGetOdataMultiplePagesOptions pagingGetOdataMultiplePagesOptions)
        {
            var message = _pipeline.CreateMessage();
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
            if (pagingGetOdataMultiplePagesOptions?.Maxresults != null)
            {
                request.Headers.Add("maxresults", pagingGetOdataMultiplePagesOptions.Maxresults.Value);
            }
            if (pagingGetOdataMultiplePagesOptions?.Timeout != null)
            {
                request.Headers.Add("timeout", pagingGetOdataMultiplePagesOptions.Timeout.Value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="pagingGetOdataMultiplePagesOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<OdataProductResult>> GetOdataMultiplePagesAsync(string clientRequestId = null, PagingGetOdataMultiplePagesOptions pagingGetOdataMultiplePagesOptions = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetOdataMultiplePagesRequest(clientRequestId, pagingGetOdataMultiplePagesOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        OdataProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="pagingGetOdataMultiplePagesOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<OdataProductResult> GetOdataMultiplePages(string clientRequestId = null, PagingGetOdataMultiplePagesOptions pagingGetOdataMultiplePagesOptions = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetOdataMultiplePagesRequest(clientRequestId, pagingGetOdataMultiplePagesOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        OdataProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMultiplePagesWithOffsetRequest(PagingGetMultiplePagesWithOffsetOptions pagingGetMultiplePagesWithOffsetOptions, string clientRequestId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/withpath/", false);
            uri.AppendPath(pagingGetMultiplePagesWithOffsetOptions.Offset, true);
            request.Uri = uri;
            if (clientRequestId != null)
            {
                request.Headers.Add("client-request-id", clientRequestId);
            }
            if (pagingGetMultiplePagesWithOffsetOptions?.Maxresults != null)
            {
                request.Headers.Add("maxresults", pagingGetMultiplePagesWithOffsetOptions.Maxresults.Value);
            }
            if (pagingGetMultiplePagesWithOffsetOptions?.Timeout != null)
            {
                request.Headers.Add("timeout", pagingGetMultiplePagesWithOffsetOptions.Timeout.Value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="pagingGetMultiplePagesWithOffsetOptions"> Parameter group. </param>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pagingGetMultiplePagesWithOffsetOptions"/> is null. </exception>
        public async Task<Response<ProductResult>> GetMultiplePagesWithOffsetAsync(PagingGetMultiplePagesWithOffsetOptions pagingGetMultiplePagesWithOffsetOptions, string clientRequestId = null, CancellationToken cancellationToken = default)
        {
            if (pagingGetMultiplePagesWithOffsetOptions == null)
            {
                throw new ArgumentNullException(nameof(pagingGetMultiplePagesWithOffsetOptions));
            }

            using var message = CreateGetMultiplePagesWithOffsetRequest(pagingGetMultiplePagesWithOffsetOptions, clientRequestId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="pagingGetMultiplePagesWithOffsetOptions"> Parameter group. </param>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pagingGetMultiplePagesWithOffsetOptions"/> is null. </exception>
        public Response<ProductResult> GetMultiplePagesWithOffset(PagingGetMultiplePagesWithOffsetOptions pagingGetMultiplePagesWithOffsetOptions, string clientRequestId = null, CancellationToken cancellationToken = default)
        {
            if (pagingGetMultiplePagesWithOffsetOptions == null)
            {
                throw new ArgumentNullException(nameof(pagingGetMultiplePagesWithOffsetOptions));
            }

            using var message = CreateGetMultiplePagesWithOffsetRequest(pagingGetMultiplePagesWithOffsetOptions, clientRequestId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMultiplePagesRetryFirstRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/retryfirst", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ProductResult>> GetMultiplePagesRetryFirstAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetMultiplePagesRetryFirstRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesRetryFirst(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetMultiplePagesRetryFirstRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMultiplePagesRetrySecondRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/retrysecond", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ProductResult>> GetMultiplePagesRetrySecondAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetMultiplePagesRetrySecondRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesRetrySecond(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetMultiplePagesRetrySecondRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetSinglePagesFailureRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/single/failure", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that receives a 400 on the first call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ProductResult>> GetSinglePagesFailureAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSinglePagesFailureRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that receives a 400 on the first call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetSinglePagesFailure(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSinglePagesFailureRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMultiplePagesFailureRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/failure", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that receives a 400 on the second call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ProductResult>> GetMultiplePagesFailureAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetMultiplePagesFailureRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that receives a 400 on the second call. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesFailure(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetMultiplePagesFailureRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMultiplePagesFailureUriRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/failureuri", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that receives an invalid nextLink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ProductResult>> GetMultiplePagesFailureUriAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetMultiplePagesFailureUriRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that receives an invalid nextLink. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResult> GetMultiplePagesFailureUri(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetMultiplePagesFailureUriRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMultiplePagesFragmentNextLinkRequest(string apiVersion, string tenant)
        {
            var message = _pipeline.CreateMessage();
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

        /// <summary> A paging operation that doesn't return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> or <paramref name="tenant"/> is null. </exception>
        public async Task<Response<OdataProductResult>> GetMultiplePagesFragmentNextLinkAsync(string apiVersion, string tenant, CancellationToken cancellationToken = default)
        {
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }

            using var message = CreateGetMultiplePagesFragmentNextLinkRequest(apiVersion, tenant);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        OdataProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that doesn't return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> or <paramref name="tenant"/> is null. </exception>
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

            using var message = CreateGetMultiplePagesFragmentNextLinkRequest(apiVersion, tenant);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        OdataProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMultiplePagesFragmentWithGroupingNextLinkRequest(CustomParameterGroup customParameterGroup)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/fragmentwithgrouping/", false);
            uri.AppendPath(customParameterGroup.Tenant, true);
            uri.AppendQuery("api_version", customParameterGroup.ApiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that doesn't return a full URL, just a fragment with parameters grouped. </summary>
        /// <param name="customParameterGroup"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="customParameterGroup"/> is null. </exception>
        public async Task<Response<OdataProductResult>> GetMultiplePagesFragmentWithGroupingNextLinkAsync(CustomParameterGroup customParameterGroup, CancellationToken cancellationToken = default)
        {
            if (customParameterGroup == null)
            {
                throw new ArgumentNullException(nameof(customParameterGroup));
            }

            using var message = CreateGetMultiplePagesFragmentWithGroupingNextLinkRequest(customParameterGroup);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        OdataProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that doesn't return a full URL, just a fragment with parameters grouped. </summary>
        /// <param name="customParameterGroup"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="customParameterGroup"/> is null. </exception>
        public Response<OdataProductResult> GetMultiplePagesFragmentWithGroupingNextLink(CustomParameterGroup customParameterGroup, CancellationToken cancellationToken = default)
        {
            if (customParameterGroup == null)
            {
                throw new ArgumentNullException(nameof(customParameterGroup));
            }

            using var message = CreateGetMultiplePagesFragmentWithGroupingNextLinkRequest(customParameterGroup);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        OdataProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMultiplePagesLRORequest(string clientRequestId, PagingGetMultiplePagesLroOptions pagingGetMultiplePagesLroOptions)
        {
            var message = _pipeline.CreateMessage();
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
            if (pagingGetMultiplePagesLroOptions?.Maxresults != null)
            {
                request.Headers.Add("maxresults", pagingGetMultiplePagesLroOptions.Maxresults.Value);
            }
            if (pagingGetMultiplePagesLroOptions?.Timeout != null)
            {
                request.Headers.Add("timeout", pagingGetMultiplePagesLroOptions.Timeout.Value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="pagingGetMultiplePagesLroOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> GetMultiplePagesLROAsync(string clientRequestId = null, PagingGetMultiplePagesLroOptions pagingGetMultiplePagesLroOptions = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetMultiplePagesLRORequest(clientRequestId, pagingGetMultiplePagesLroOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="pagingGetMultiplePagesLroOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetMultiplePagesLRO(string clientRequestId = null, PagingGetMultiplePagesLroOptions pagingGetMultiplePagesLroOptions = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetMultiplePagesLRORequest(clientRequestId, pagingGetMultiplePagesLroOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateNextFragmentRequest(string apiVersion, string tenant, string nextLink)
        {
            var message = _pipeline.CreateMessage();
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

        /// <summary> A paging operation that doesn't return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/>, <paramref name="tenant"/> or <paramref name="nextLink"/> is null. </exception>
        public async Task<Response<OdataProductResult>> NextFragmentAsync(string apiVersion, string tenant, string nextLink, CancellationToken cancellationToken = default)
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

            using var message = CreateNextFragmentRequest(apiVersion, tenant, nextLink);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        OdataProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that doesn't return a full URL, just a fragment. </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/>, <paramref name="tenant"/> or <paramref name="nextLink"/> is null. </exception>
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

            using var message = CreateNextFragmentRequest(apiVersion, tenant, nextLink);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        OdataProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateNextFragmentWithGroupingRequest(string nextLink, CustomParameterGroup customParameterGroup)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/multiple/fragmentwithgrouping/", false);
            uri.AppendPath(customParameterGroup.Tenant, true);
            uri.AppendPath("/", false);
            uri.AppendRawNextLink(nextLink, false);
            uri.AppendQuery("api_version", customParameterGroup.ApiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that doesn't return a full URL, just a fragment. </summary>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="customParameterGroup"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="customParameterGroup"/> is null. </exception>
        public async Task<Response<OdataProductResult>> NextFragmentWithGroupingAsync(string nextLink, CustomParameterGroup customParameterGroup, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }
            if (customParameterGroup == null)
            {
                throw new ArgumentNullException(nameof(customParameterGroup));
            }

            using var message = CreateNextFragmentWithGroupingRequest(nextLink, customParameterGroup);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        OdataProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that doesn't return a full URL, just a fragment. </summary>
        /// <param name="nextLink"> Next link for list operation. </param>
        /// <param name="customParameterGroup"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="customParameterGroup"/> is null. </exception>
        public Response<OdataProductResult> NextFragmentWithGrouping(string nextLink, CustomParameterGroup customParameterGroup, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }
            if (customParameterGroup == null)
            {
                throw new ArgumentNullException(nameof(customParameterGroup));
            }

            using var message = CreateNextFragmentWithGroupingRequest(nextLink, customParameterGroup);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        OdataProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetPagingModelWithItemNameWithXMSClientNameRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/paging/itemNameWithXMSClientName", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that returns a paging model whose item name is is overriden by x-ms-client-name 'indexes'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ProductResultValueWithXMSClientName>> GetPagingModelWithItemNameWithXMSClientNameAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetPagingModelWithItemNameWithXMSClientNameRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResultValueWithXMSClientName value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResultValueWithXMSClientName.DeserializeProductResultValueWithXMSClientName(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that returns a paging model whose item name is is overriden by x-ms-client-name 'indexes'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProductResultValueWithXMSClientName> GetPagingModelWithItemNameWithXMSClientName(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetPagingModelWithItemNameWithXMSClientNameRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResultValueWithXMSClientName value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResultValueWithXMSClientName.DeserializeProductResultValueWithXMSClientName(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetNoItemNamePagesNextPageRequest(string nextLink)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that must return result of the default 'value' node. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<Response<ProductResultValue>> GetNoItemNamePagesNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetNoItemNamePagesNextPageRequest(nextLink);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResultValue value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResultValue.DeserializeProductResultValue(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that must return result of the default 'value' node. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public Response<ProductResultValue> GetNoItemNamePagesNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetNoItemNamePagesNextPageRequest(nextLink);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResultValue value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResultValue.DeserializeProductResultValue(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetSinglePagesNextPageRequest(string nextLink)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that finishes on the first call without a nextlink. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<Response<ProductResult>> GetSinglePagesNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetSinglePagesNextPageRequest(nextLink);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that finishes on the first call without a nextlink. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public Response<ProductResult> GetSinglePagesNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetSinglePagesNextPageRequest(nextLink);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateFirstResponseEmptyNextPageRequest(string nextLink)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation whose first response's items list is empty, but still returns a next link. Second (and final) call, will give you an items list of 1. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<Response<ProductResultValue>> FirstResponseEmptyNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateFirstResponseEmptyNextPageRequest(nextLink);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResultValue value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResultValue.DeserializeProductResultValue(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation whose first response's items list is empty, but still returns a next link. Second (and final) call, will give you an items list of 1. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public Response<ProductResultValue> FirstResponseEmptyNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateFirstResponseEmptyNextPageRequest(nextLink);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResultValue value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResultValue.DeserializeProductResultValue(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMultiplePagesNextPageRequest(string nextLink, string clientRequestId, PagingGetMultiplePagesOptions pagingGetMultiplePagesOptions)
        {
            var message = _pipeline.CreateMessage();
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
            if (pagingGetMultiplePagesOptions?.Maxresults != null)
            {
                request.Headers.Add("maxresults", pagingGetMultiplePagesOptions.Maxresults.Value);
            }
            if (pagingGetMultiplePagesOptions?.Timeout != null)
            {
                request.Headers.Add("timeout", pagingGetMultiplePagesOptions.Timeout.Value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="pagingGetMultiplePagesOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<Response<ProductResult>> GetMultiplePagesNextPageAsync(string nextLink, string clientRequestId = null, PagingGetMultiplePagesOptions pagingGetMultiplePagesOptions = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetMultiplePagesNextPageRequest(nextLink, clientRequestId, pagingGetMultiplePagesOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="pagingGetMultiplePagesOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public Response<ProductResult> GetMultiplePagesNextPage(string nextLink, string clientRequestId = null, PagingGetMultiplePagesOptions pagingGetMultiplePagesOptions = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetMultiplePagesNextPageRequest(nextLink, clientRequestId, pagingGetMultiplePagesOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDuplicateParamsNextPageRequest(string nextLink, string filter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Define `filter` as a query param for all calls. However, the returned next link will also include the `filter` as part of it. Make sure you don't end up duplicating the `filter` param in the url sent. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="filter"> OData filter options. Pass in 'foo'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<Response<ProductResult>> DuplicateParamsNextPageAsync(string nextLink, string filter = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateDuplicateParamsNextPageRequest(nextLink, filter);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Define `filter` as a query param for all calls. However, the returned next link will also include the `filter` as part of it. Make sure you don't end up duplicating the `filter` param in the url sent. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="filter"> OData filter options. Pass in 'foo'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public Response<ProductResult> DuplicateParamsNextPage(string nextLink, string filter = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateDuplicateParamsNextPageRequest(nextLink, filter);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetOdataMultiplePagesNextPageRequest(string nextLink, string clientRequestId, PagingGetOdataMultiplePagesOptions pagingGetOdataMultiplePagesOptions)
        {
            var message = _pipeline.CreateMessage();
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
            if (pagingGetOdataMultiplePagesOptions?.Maxresults != null)
            {
                request.Headers.Add("maxresults", pagingGetOdataMultiplePagesOptions.Maxresults.Value);
            }
            if (pagingGetOdataMultiplePagesOptions?.Timeout != null)
            {
                request.Headers.Add("timeout", pagingGetOdataMultiplePagesOptions.Timeout.Value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="pagingGetOdataMultiplePagesOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<Response<OdataProductResult>> GetOdataMultiplePagesNextPageAsync(string nextLink, string clientRequestId = null, PagingGetOdataMultiplePagesOptions pagingGetOdataMultiplePagesOptions = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetOdataMultiplePagesNextPageRequest(nextLink, clientRequestId, pagingGetOdataMultiplePagesOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        OdataProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that includes a nextLink in odata format that has 10 pages. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="pagingGetOdataMultiplePagesOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public Response<OdataProductResult> GetOdataMultiplePagesNextPage(string nextLink, string clientRequestId = null, PagingGetOdataMultiplePagesOptions pagingGetOdataMultiplePagesOptions = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetOdataMultiplePagesNextPageRequest(nextLink, clientRequestId, pagingGetOdataMultiplePagesOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        OdataProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = OdataProductResult.DeserializeOdataProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMultiplePagesWithOffsetNextPageRequest(string nextLink, PagingGetMultiplePagesWithOffsetOptions pagingGetMultiplePagesWithOffsetOptions, string clientRequestId)
        {
            var message = _pipeline.CreateMessage();
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
            if (pagingGetMultiplePagesWithOffsetOptions?.Maxresults != null)
            {
                request.Headers.Add("maxresults", pagingGetMultiplePagesWithOffsetOptions.Maxresults.Value);
            }
            if (pagingGetMultiplePagesWithOffsetOptions?.Timeout != null)
            {
                request.Headers.Add("timeout", pagingGetMultiplePagesWithOffsetOptions.Timeout.Value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="pagingGetMultiplePagesWithOffsetOptions"> Parameter group. </param>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="pagingGetMultiplePagesWithOffsetOptions"/> is null. </exception>
        public async Task<Response<ProductResult>> GetMultiplePagesWithOffsetNextPageAsync(string nextLink, PagingGetMultiplePagesWithOffsetOptions pagingGetMultiplePagesWithOffsetOptions, string clientRequestId = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }
            if (pagingGetMultiplePagesWithOffsetOptions == null)
            {
                throw new ArgumentNullException(nameof(pagingGetMultiplePagesWithOffsetOptions));
            }

            using var message = CreateGetMultiplePagesWithOffsetNextPageRequest(nextLink, pagingGetMultiplePagesWithOffsetOptions, clientRequestId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="pagingGetMultiplePagesWithOffsetOptions"> Parameter group. </param>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="pagingGetMultiplePagesWithOffsetOptions"/> is null. </exception>
        public Response<ProductResult> GetMultiplePagesWithOffsetNextPage(string nextLink, PagingGetMultiplePagesWithOffsetOptions pagingGetMultiplePagesWithOffsetOptions, string clientRequestId = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }
            if (pagingGetMultiplePagesWithOffsetOptions == null)
            {
                throw new ArgumentNullException(nameof(pagingGetMultiplePagesWithOffsetOptions));
            }

            using var message = CreateGetMultiplePagesWithOffsetNextPageRequest(nextLink, pagingGetMultiplePagesWithOffsetOptions, clientRequestId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMultiplePagesRetryFirstNextPageRequest(string nextLink)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<Response<ProductResult>> GetMultiplePagesRetryFirstNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetMultiplePagesRetryFirstNextPageRequest(nextLink);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that fails on the first call with 500 and then retries and then get a response including a nextLink that has 10 pages. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public Response<ProductResult> GetMultiplePagesRetryFirstNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetMultiplePagesRetryFirstNextPageRequest(nextLink);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMultiplePagesRetrySecondNextPageRequest(string nextLink)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<Response<ProductResult>> GetMultiplePagesRetrySecondNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetMultiplePagesRetrySecondNextPageRequest(nextLink);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that includes a nextLink that has 10 pages, of which the 2nd call fails first with 500. The client should retry and finish all 10 pages eventually. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public Response<ProductResult> GetMultiplePagesRetrySecondNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetMultiplePagesRetrySecondNextPageRequest(nextLink);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetSinglePagesFailureNextPageRequest(string nextLink)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that receives a 400 on the first call. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<Response<ProductResult>> GetSinglePagesFailureNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetSinglePagesFailureNextPageRequest(nextLink);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that receives a 400 on the first call. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public Response<ProductResult> GetSinglePagesFailureNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetSinglePagesFailureNextPageRequest(nextLink);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMultiplePagesFailureNextPageRequest(string nextLink)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that receives a 400 on the second call. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<Response<ProductResult>> GetMultiplePagesFailureNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetMultiplePagesFailureNextPageRequest(nextLink);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that receives a 400 on the second call. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public Response<ProductResult> GetMultiplePagesFailureNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetMultiplePagesFailureNextPageRequest(nextLink);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMultiplePagesFailureUriNextPageRequest(string nextLink)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that receives an invalid nextLink. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<Response<ProductResult>> GetMultiplePagesFailureUriNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetMultiplePagesFailureUriNextPageRequest(nextLink);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that receives an invalid nextLink. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public Response<ProductResult> GetMultiplePagesFailureUriNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetMultiplePagesFailureUriNextPageRequest(nextLink);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResult.DeserializeProductResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetMultiplePagesLRONextPageRequest(string nextLink, string clientRequestId, PagingGetMultiplePagesLroOptions pagingGetMultiplePagesLroOptions)
        {
            var message = _pipeline.CreateMessage();
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
            if (pagingGetMultiplePagesLroOptions?.Maxresults != null)
            {
                request.Headers.Add("maxresults", pagingGetMultiplePagesLroOptions.Maxresults.Value);
            }
            if (pagingGetMultiplePagesLroOptions?.Timeout != null)
            {
                request.Headers.Add("timeout", pagingGetMultiplePagesLroOptions.Timeout.Value);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="pagingGetMultiplePagesLroOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<Response> GetMultiplePagesLRONextPageAsync(string nextLink, string clientRequestId = null, PagingGetMultiplePagesLroOptions pagingGetMultiplePagesLroOptions = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetMultiplePagesLRONextPageRequest(nextLink, clientRequestId, pagingGetMultiplePagesLroOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="clientRequestId"> The String to use. </param>
        /// <param name="pagingGetMultiplePagesLroOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public Response GetMultiplePagesLRONextPage(string nextLink, string clientRequestId = null, PagingGetMultiplePagesLroOptions pagingGetMultiplePagesLroOptions = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetMultiplePagesLRONextPageRequest(nextLink, clientRequestId, pagingGetMultiplePagesLroOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetPagingModelWithItemNameWithXMSClientNameNextPageRequest(string nextLink)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A paging operation that returns a paging model whose item name is is overriden by x-ms-client-name 'indexes'. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<Response<ProductResultValueWithXMSClientName>> GetPagingModelWithItemNameWithXMSClientNameNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetPagingModelWithItemNameWithXMSClientNameNextPageRequest(nextLink);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResultValueWithXMSClientName value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProductResultValueWithXMSClientName.DeserializeProductResultValueWithXMSClientName(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A paging operation that returns a paging model whose item name is is overriden by x-ms-client-name 'indexes'. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public Response<ProductResultValueWithXMSClientName> GetPagingModelWithItemNameWithXMSClientNameNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetPagingModelWithItemNameWithXMSClientNameNextPageRequest(nextLink);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProductResultValueWithXMSClientName value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProductResultValueWithXMSClientName.DeserializeProductResultValueWithXMSClientName(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
