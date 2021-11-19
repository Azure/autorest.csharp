// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class LowLevelFuncOperation<T> : Operation<T> where T : notnull
    {
        private readonly OperationInternal<T> _operation;

        internal LowLevelFuncOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, OperationFinalStateVia finalStateVia, string scopeName, Func<Response, T> resultSelector)
        {
            var nextLinkOperation = NextLinkOperation.Create(pipeline, request.Method, request.Uri.ToUri(), response, finalStateVia);
            _operation = new OperationInternal<T>(clientDiagnostics, new SelectorOperation<T>(nextLinkOperation, resultSelector), response, scopeName);
        }

#pragma warning disable CA1822
        //TODO: This is currently unused.
        /// <inheritdoc />
        public override string Id => throw new NotImplementedException();
#pragma warning restore CA1822

        /// <inheritdoc />
        public override T Value => _operation.Value;

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
        public override ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
