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
    internal class OperationInternals
    {
        public static TimeSpan DefaultPollingInterval { get; private set; } = TimeSpan.FromSeconds(1);

        private readonly OperationInternal _operationInternal;

        public OperationInternals(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request originalRequest, Response originalResponse, OperationFinalStateVia finalStateVia, string scopeName)
        {
            var nextLinkOperation = NextLinkOperationImplementation.Create(pipeline, originalRequest.Method, originalRequest.Uri.ToUri(), originalResponse, finalStateVia);
            _operationInternal = new OperationInternal(clientDiagnostics, nextLinkOperation, originalResponse, scopeName);
            _operationInternal.DefaultPollingInterval = OperationInternals.DefaultPollingInterval;
        }

        public Response GetRawResponse() => _operationInternal.RawResponse;

        public ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default) => _operationInternal.WaitForCompletionResponseAsync(cancellationToken);

        public ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) => _operationInternal.WaitForCompletionResponseAsync(pollingInterval, cancellationToken);

        public ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operationInternal.UpdateStatusAsync(cancellationToken);

        public Response UpdateStatus(CancellationToken cancellationToken = default) => _operationInternal.UpdateStatus(cancellationToken);

#pragma warning disable CA1822
        //TODO: This is currently unused.
        public string Id => throw new NotImplementedException();
#pragma warning restore CA1822

        public bool HasCompleted => _operationInternal.HasCompleted;
    }
}
