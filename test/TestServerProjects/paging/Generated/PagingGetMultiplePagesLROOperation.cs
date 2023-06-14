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
    /// <summary> A long-running paging operation that includes a nextLink that has 10 pages. </summary>
    public partial class PagingGetMultiplePagesLROOperation : Operation<AsyncPageable<Product>>, IOperationSource<AsyncPageable<Product>>
    {
        private readonly OperationInternal<AsyncPageable<Product>> _operation;
        private readonly Func<int?, string, HttpMessage> _nextPageFunc;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Initializes a new instance of PagingGetMultiplePagesLROOperation for mocking. </summary>
        protected PagingGetMultiplePagesLROOperation()
        {
        }

        internal PagingGetMultiplePagesLROOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, Func<int?, string, HttpMessage> nextPageFunc)
        {
            IOperation<AsyncPageable<Product>> nextLinkOperation = NextLinkOperationImplementation.Create(this, pipeline, request.Method, request.Uri.ToUri(), response, OperationFinalStateVia.Location);
            _operation = new OperationInternal<AsyncPageable<Product>>(nextLinkOperation, clientDiagnostics, response, "PagingGetMultiplePagesLROOperation");
            _nextPageFunc = nextPageFunc;
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <inheritdoc />
#pragma warning disable CA1822
        public override string Id => throw new NotImplementedException();
#pragma warning restore CA1822

        /// <inheritdoc />
        public override AsyncPageable<Product> Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.RawResponse;

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override Response<AsyncPageable<Product>> WaitForCompletion(CancellationToken cancellationToken = default) => _operation.WaitForCompletion(cancellationToken);

        /// <inheritdoc />
        public override Response<AsyncPageable<Product>> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletion(pollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<AsyncPageable<Product>>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<AsyncPageable<Product>>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        AsyncPageable<Product> IOperationSource<AsyncPageable<Product>>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            return PageableHelpers.CreateAsyncPageable(response, _nextPageFunc, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingGetMultiplePagesLROOperation", "values", "nextLink", cancellationToken);
        }

        ValueTask<AsyncPageable<Product>> IOperationSource<AsyncPageable<Product>>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            return new ValueTask<AsyncPageable<Product>>(PageableHelpers.CreateAsyncPageable(response, _nextPageFunc, Product.DeserializeProduct, _clientDiagnostics, _pipeline, "PagingGetMultiplePagesLROOperation", "values", "nextLink", cancellationToken));
        }
    }
}
