// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class LowLevelFuncOperation<T> : Operation<T>, IOperationStatePoller<T> where T : notnull
    {
        private readonly Func<Response, T> _resultSelector;
        private readonly OperationImplementation<T> _operationImplementation;
        private readonly IOperationStatePoller _operationStatePoller;

        internal LowLevelFuncOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, OperationFinalStateVia finalStateVia, string scopeName, Func<Response, T> resultSelector)
        {
            _resultSelector = resultSelector;
            _operationStatePoller = NextLinkOperationImplementation.Create(pipeline, request.Method, request.Uri.ToUri(), response, finalStateVia);
            _operationImplementation = new OperationImplementation<T>(clientDiagnostics, this, response, scopeName);
        }

#pragma warning disable CA1822
        //TODO: This is currently unused.
        /// <inheritdoc />
        public override string Id => throw new NotImplementedException();
#pragma warning restore CA1822

        /// <inheritdoc />
        public override T Value => _operationImplementation.Value;

        /// <inheritdoc />
        public override bool HasCompleted => _operationImplementation.HasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _operationImplementation.HasValue;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operationImplementation.RawResponse;
        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operationImplementation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operationImplementation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operationImplementation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operationImplementation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        async ValueTask<OperationState<T>> IOperationStatePoller<T>.PollOperationStateAsync(bool async, CancellationToken cancellationToken)
        {
            var state = await _operationStatePoller.PollOperationStateAsync(async, cancellationToken).ConfigureAwait(false);
            if (state.HasSucceeded)
            {
                return OperationState<T>.Success(state.RawResponse, _resultSelector(state.RawResponse));
            }

            if (state.HasCompleted)
            {
                return OperationState<T>.Failure(state.RawResponse, state.OperationFailedException);
            }

            return OperationState<T>.Pending(state.RawResponse);
        }
    }
}
