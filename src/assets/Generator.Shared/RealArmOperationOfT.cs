// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
#pragma warning disable SA1649 // File name should match first type name
    internal sealed class RealArmOperation<T> : ArmOperation<T>, IOperation<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly IOperationSource<T> _operationSource;
        private readonly OperationInternal<T> _operation;
        private readonly IOperation _nextLinkOperation;

#pragma warning disable CA1822
        public override string Id => throw new NotImplementedException();
#pragma warning restore CA1822
        public override bool HasCompleted => _operation.HasCompleted;
        public override T Value => _operation.Value;
        public override bool HasValue => _operation.HasValue;

        internal RealArmOperation(IOperationSource<T> operationSource, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, OperationFinalStateVia finalStateVia, string scopeName)
        {
            _operationSource = operationSource;
            _nextLinkOperation = NextLinkOperationImplementation.Create(pipeline, request.Method, request.Uri.ToUri(), response, finalStateVia);
            _operation = new OperationInternal<T>(clientDiagnostics, this, response, scopeName);
        }

        public override Response GetRawResponse()
            => _operation.RawResponse;

        public override Response UpdateStatus(CancellationToken cancellationToken = default)
            => _operation.UpdateStatus(cancellationToken);

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
            => _operation.UpdateStatusAsync(cancellationToken);

        async ValueTask<OperationState<T>> IOperation<T>.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            var state = await _nextLinkOperation.UpdateStateAsync(async, cancellationToken).ConfigureAwait(false);
            if (state.HasSucceeded)
            {
                var value = async
                    ? await _operationSource.CreateResultAsync(state.RawResponse, cancellationToken).ConfigureAwait(false)
                    : _operationSource.CreateResult(state.RawResponse, cancellationToken);

                return OperationState<T>.Success(state.RawResponse, value);
            }

            if (state.HasCompleted)
            {
                return OperationState<T>.Failure(state.RawResponse, state.OperationFailedException);
            }

            return OperationState<T>.Pending(state.RawResponse);
        }
    }
}
