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
    /// <summary>
    /// This implements the ARM scenarios for LROs. It is highly recommended to read the ARM spec prior to modifying this code:
    /// https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/Addendum.md#asynchronous-operations
    /// Other reference documents include:
    /// https://github.com/Azure/autorest/blob/master/docs/extensions/readme.md#x-ms-long-running-operation
    /// https://github.com/Azure/adx-documentation-pr/blob/master/sdks/LRO/LRO_AzureSDK.md
    /// </summary>
    /// <typeparam name="T">The final result of the LRO.</typeparam>
#pragma warning disable SA1649 // File name should match first type name
    internal class OperationInternals<T>: IOperation<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly IOperationSource<T> _source;
        private readonly OperationInternal<T> _operationInternal;
        private readonly IOperation _nextLinkOperation;

        public OperationInternals(
            IOperationSource<T> source,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            Request originalRequest,
            Response originalResponse,
            OperationFinalStateVia finalStateVia,
            string scopeName)
        {
            _source = source;
            _nextLinkOperation = NextLinkOperationImplementation.Create(pipeline, originalRequest.Method, originalRequest.Uri.ToUri(), originalResponse, finalStateVia);
            _operationInternal = new OperationInternal<T>(clientDiagnostics, this, originalResponse, scopeName);
            _operationInternal.DefaultPollingInterval = OperationInternals.DefaultPollingInterval;
        }

        public ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
            => _operationInternal.WaitForCompletionAsync(cancellationToken);

        public ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
            => _operationInternal.WaitForCompletionAsync(pollingInterval, cancellationToken);

        public Response GetRawResponse() => _operationInternal.RawResponse;

        public ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default) => _operationInternal.WaitForCompletionResponseAsync(cancellationToken);

        public ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) => _operationInternal.WaitForCompletionResponseAsync(pollingInterval, cancellationToken);

        public ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operationInternal.UpdateStatusAsync(cancellationToken);

        public Response UpdateStatus(CancellationToken cancellationToken = default) => _operationInternal.UpdateStatus(cancellationToken);

#pragma warning disable CA1822
        //TODO: This is currently unused.
        public string Id => throw new NotImplementedException();
#pragma warning restore CA1822

        public T Value => _operationInternal.Value;
        public bool HasValue => _operationInternal.HasValue;
        public bool HasCompleted => _operationInternal.HasCompleted;

        // Temporary, remove after OperationOrResponseInternals<T> is removed
        public OperationInternal<T> Internal => _operationInternal;

        async ValueTask<OperationState<T>> IOperation<T>.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            var state = await _nextLinkOperation.UpdateStateAsync(async, cancellationToken).ConfigureAwait(false);
            if (state.HasSucceeded)
            {
                var value = async
                    ? await _source.CreateResultAsync(state.RawResponse, cancellationToken).ConfigureAwait(false)
                    : _source.CreateResult(state.RawResponse, cancellationToken);

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
