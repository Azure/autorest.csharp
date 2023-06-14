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
using lro.Models;

namespace lro
{
    /// <summary> Long running put request, service returns a 200 with ProvisioningState=’Creating’. Poll the endpoint indicated in the Azure-AsyncOperation header for operation status. </summary>
    public partial class LrosaDsPutAsyncRelativeRetry400Operation : Operation<Product>, IOperationSource<Product>
    {
        private readonly OperationInternal<Product> _operation;

        /// <summary> Initializes a new instance of LrosaDsPutAsyncRelativeRetry400Operation for mocking. </summary>
        protected LrosaDsPutAsyncRelativeRetry400Operation()
        {
        }

        internal LrosaDsPutAsyncRelativeRetry400Operation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            IOperation<Product> nextLinkOperation = NextLinkOperationImplementation.Create(this, pipeline, request.Method, request.Uri.ToUri(), response, OperationFinalStateVia.Location);
            _operation = new OperationInternal<Product>(nextLinkOperation, clientDiagnostics, response, "LrosaDsPutAsyncRelativeRetry400Operation");
        }

        /// <inheritdoc />
#pragma warning disable CA1822
        public override string Id => throw new NotImplementedException();
#pragma warning restore CA1822

        /// <inheritdoc />
        public override Product Value => _operation.Value;

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
        public override Response<Product> WaitForCompletion(CancellationToken cancellationToken = default) => _operation.WaitForCompletion(cancellationToken);

        /// <inheritdoc />
        public override Response<Product> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletion(pollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<Product>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<Product>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        Product IOperationSource<Product>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return Product.DeserializeProduct(document.RootElement);
        }

        async ValueTask<Product> IOperationSource<Product>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return Product.DeserializeProduct(document.RootElement);
        }
    }
}
