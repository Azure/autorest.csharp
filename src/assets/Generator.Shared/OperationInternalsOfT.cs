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
    internal class OperationInternals<T>: IOperationStatePoller<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly IOperationSource<T> _source;
        private readonly OperationImplementation<T> operationImplementation;
        private readonly IOperationStatePoller operationStatePoller;

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
            operationStatePoller = NextLinkOperationImplementation.Create(pipeline, originalRequest.Method, originalRequest.Uri.ToUri(), originalResponse, finalStateVia);
            operationImplementation = new OperationImplementation<T>(clientDiagnostics, this, originalResponse, scopeName);
            operationImplementation.DefaultPollingInterval = OperationInternals.DefaultPollingInterval;
        }

        public ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
            => operationImplementation.WaitForCompletionAsync(cancellationToken);

        public ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
            => operationImplementation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        public Response GetRawResponse() => operationImplementation.RawResponse;

        public ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default) => operationImplementation.WaitForCompletionResponseAsync(cancellationToken);

        public ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) => operationImplementation.WaitForCompletionResponseAsync(pollingInterval, cancellationToken);

        public ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => operationImplementation.UpdateStatusAsync(cancellationToken);

        public Response UpdateStatus(CancellationToken cancellationToken = default) => operationImplementation.UpdateStatus(cancellationToken);

#pragma warning disable CA1822
        //TODO: This is currently unused.
        public string Id => throw new NotImplementedException();
#pragma warning restore CA1822

        public T Value => operationImplementation.Value;
        public bool HasValue => operationImplementation.HasValue;
        public bool HasCompleted => operationImplementation.HasCompleted;

        // Temporary, remove after OperationOrResponseInternals<T> is removed
        public OperationImplementation<T> Internal => operationImplementation;

        async ValueTask<OperationState<T>> IOperationStatePoller<T>.PollOperationStateAsync(bool async, CancellationToken cancellationToken)
        {
            var state = await operationStatePoller.PollOperationStateAsync(async, cancellationToken).ConfigureAwait(false);
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
