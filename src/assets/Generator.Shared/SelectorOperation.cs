// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal class SelectorOperation<T> : IOperation<T>
    {
        private readonly IOperation _operation;
        private readonly Func<Response, T> _selector;

        public SelectorOperation(IOperation operation, Func<Response, T> selector)
        {
            _operation = operation;
            _selector = selector;
        }

        public async ValueTask<OperationState<T>> UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            var state = await _operation.UpdateStateAsync(async, cancellationToken).ConfigureAwait(false);
            if (state.HasSucceeded)
            {
                return OperationState<T>.Success(state.RawResponse, _selector(state.RawResponse));
            }

            if (state.HasCompleted)
            {
                return OperationState<T>.Failure(state.RawResponse, state.OperationFailedException);
            }

            return OperationState<T>.Pending(state.RawResponse);
        }
    }
}
