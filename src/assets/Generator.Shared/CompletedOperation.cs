// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal class CompletedOperation : IOperation
    {
        private readonly OperationState _operationState;

        public CompletedOperation(OperationState operationState)
        {
            _operationState = operationState;
        }

        public ValueTask<OperationState> UpdateStateAsync(bool async, CancellationToken cancellationToken) => new(_operationState);
    }
}
