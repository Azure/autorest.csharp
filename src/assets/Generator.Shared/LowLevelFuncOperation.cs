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
    internal class LowLevelFuncOperation<T> : Operation<T>, IOperationSource<T> where T : notnull
    {
        private readonly OperationInternals<T> _operation;
        private readonly Func<Response, T> _resultSelector;

        internal LowLevelFuncOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, OperationFinalStateVia finalStateVia, string scopeName, Func<Response, T> resultSelector)
        {
            _operation = new OperationInternals<T>(this, clientDiagnostics, pipeline, request, response, finalStateVia, scopeName);
            _resultSelector = resultSelector;
        }

        internal LowLevelFuncOperation(OperationInternals op, Func<Response, T> resultSelector)
        {
            _operation = new OperationInternals<T>(this, op);
            _resultSelector = resultSelector;
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override T Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.GetRawResponse();

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        T IOperationSource<T>.CreateResult(Response response, CancellationToken cancellationToken) => _resultSelector(response);

        ValueTask<T> IOperationSource<T>.CreateResultAsync(Response response, CancellationToken cancellationToken) => new ValueTask<T>(_resultSelector(response));

        public static implicit operator LowLevelFuncOperation<T>(LowLevelFuncOperation<BinaryData> operation)
        {
            return new LowLevelFuncOperation<T>((OperationInternals)(operation._operation), r => (T)(object)r);
        }
    }
}
