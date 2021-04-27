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
    internal class OperationOrResponseInternalsBase
    {
        public OperationOrResponseInternalsBase(OperationInternals operationInternals)
        {
            if (operationInternals is null)
                throw new ArgumentNullException(nameof(operationInternals));

            Operation = operationInternals;
        }

        public OperationOrResponseInternalsBase(Response response)
        {
            if (response is null)
                throw new ArgumentNullException(nameof(response));

            VoidResponse = response;
        }

        protected OperationInternals? Operation { get; }

        protected Response? VoidResponse { get; }

        protected bool DoesWrapOperation => VoidResponse is null;

        public bool HasCompleted => DoesWrapOperation ? Operation!.HasCompleted : true;

        public Response GetRawResponse()
        {
            return DoesWrapOperation ? Operation!.GetRawResponse() : VoidResponse!;
        }

        public Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            return DoesWrapOperation ? Operation!.UpdateStatus(cancellationToken) : VoidResponse!;
        }

        public ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            return DoesWrapOperation
                ? Operation!.UpdateStatusAsync(cancellationToken)
                : new ValueTask<Response>(VoidResponse!);
        }

        public async ValueTask<Response> WaitForCompletionResponseAsync(
            CancellationToken cancellationToken = default)
        {
            return await WaitForCompletionResponseAsync(OperationInternals.DefaultPollingInterval, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<Response> WaitForCompletionResponseAsync(
            TimeSpan pollingInterval,
            CancellationToken cancellationToken)
        {
            return DoesWrapOperation
                ? await Operation!.WaitForCompletionResponseAsync(pollingInterval, cancellationToken).ConfigureAwait(false)
                : VoidResponse!;
        }
    }
}
