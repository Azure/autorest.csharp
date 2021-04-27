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
    internal class OperationOrResponseInternals<T>
    {
        private readonly OperationInternals<T>? _operation;
        private readonly Response<T>? _valueResponse;

        public OperationOrResponseInternals(
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            Request originalRequest,
            Response originalResponse,
            OperationFinalStateVia finalStateVia,
            string scopeName)
            : this(null, clientDiagnostics, pipeline, originalRequest, originalResponse, finalStateVia, scopeName)
        {
        }

        public OperationOrResponseInternals(
            IOperationSource<T>? source,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            Request originalRequest,
            Response originalResponse,
            OperationFinalStateVia finalStateVia,
            string scopeName)
        {
            _operation = new OperationInternals<T>(source, clientDiagnostics, pipeline, originalRequest, originalResponse, finalStateVia, scopeName);
        }

        public OperationOrResponseInternals(Response<T> response)
        {
            if (response is null)
                throw new ArgumentNullException(nameof(response));

            _valueResponse = response;
        }

        private bool _doesWrapOperation => _valueResponse is null;

        public T Value => _doesWrapOperation ? _operation!.Value : _valueResponse!.Value;

        public bool HasCompleted => _doesWrapOperation ? _operation!.HasCompleted : true;

        public bool HasValue => _doesWrapOperation ? _operation!.HasValue : true;

        public Response GetRawResponse()
        {
            return _doesWrapOperation ? _operation!.GetRawResponse() : _valueResponse!.GetRawResponse();
        }

        public Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            return _doesWrapOperation ? _operation!.UpdateStatus(cancellationToken) : _valueResponse!.GetRawResponse();
        }

        public ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            return _doesWrapOperation
                ? _operation!.UpdateStatusAsync(cancellationToken)
                : new ValueTask<Response>(_valueResponse!.GetRawResponse());
        }

        public async ValueTask<Response<T>> WaitForCompletionAsync(
            CancellationToken cancellationToken = default)
        {
            return await WaitForCompletionAsync(OperationInternals<T>.DefaultPollingInterval, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<Response<T>> WaitForCompletionAsync(
            TimeSpan pollingInterval,
            CancellationToken cancellationToken)
        {
            return _doesWrapOperation
                ? await _operation!.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false)
                : _valueResponse!;
        }
    }
}
