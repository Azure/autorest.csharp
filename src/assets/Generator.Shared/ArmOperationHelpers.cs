// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

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
    internal class ArmOperationHelpers<T> : OperationHelpers<T>
    {
        public ArmOperationHelpers(
            IOperationSource<T> source,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            Request originalRequest,
            Response originalResponse,
            OperationFinalStateVia finalStateVia,
            string scopeName)
            : base(source, clientDiagnostics, pipeline, originalRequest, originalResponse, finalStateVia, scopeName)
        {
        }

        private readonly ArmOperationHelpers<T> _operation;
        private readonly Response<T> _valueResponse;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmOperation{TOperations}"/> class.
        /// </summary>
        /// <param name="response"> The non lro response to wrap. </param>
        protected ArmOperation(Response<T> response)
        {
            if (response is null)
                throw new ArgumentNullException(nameof(response));

            _valueResponse = response;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmOperation{T}"/> class.
        /// </summary>
        /// <param name="source"> The operation source to use. </param>
        /// <param name="clientDiagnostics">The client diagnostics to use. </param>
        /// <param name="pipeline"> The HttpPipeline to use. </param>
        /// <param name="request"> The original request. </param>
        /// <param name="response"> The original response. </param>
        /// <param name="scopeName"> The scope name to use. </param>
        internal ArmOperation(IOperationSource<T> source, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, string scopeName)
        {
            _operation = new ArmOperationHelpers<T>(source, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, scopeName);
        }

        private bool _doesWrapOperation => _valueResponse is null;

        /// <inheritdoc/>
        public override string Id => _operation?.Id;

        /// <inheritdoc/>
        public override TOperations Value => _doesWrapOperation ? _operation.Value : _valueResponse.Value;

        /// <inheritdoc/>
        public override bool HasCompleted => _doesWrapOperation ? _operation.HasCompleted : true;

        /// <inheritdoc/>
        public override bool HasValue => _doesWrapOperation ? _operation.HasValue : true;

        /// <inheritdoc/>
        public override Response GetRawResponse()
        {
            return _doesWrapOperation ? _operation.GetRawResponse() : _valueResponse.GetRawResponse();
        }

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            return _doesWrapOperation ? _operation.UpdateStatus(cancellationToken) : _valueResponse.GetRawResponse();
        }

        /// <inheritdoc/>
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            return _doesWrapOperation
                ? _operation.UpdateStatusAsync(cancellationToken)
                : new ValueTask<Response>(_valueResponse.GetRawResponse());
        }

        /// <inheritdoc/>
        public override async ValueTask<Response<T>> WaitForCompletionAsync(
            CancellationToken cancellationToken = default)
        {
            return await WaitForCompletionAsync(ArmOperationHelpers<T>.DefaultPollingInterval, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public override async ValueTask<Response<T>> WaitForCompletionAsync(
            TimeSpan pollingInterval,
            CancellationToken cancellationToken)
        {
            return _doesWrapOperation
                ? await _operation.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false)
                : _valueResponse;
        }

        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmOperation{TOperations}"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual Response<T> WaitForCompletion(CancellationToken cancellationToken = default)
        {
            return WaitForCompletion(ArmOperationHelpers<T>.DefaultPollingInterval.Seconds, cancellationToken);
        }

        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="pollingInterval"> The polling interval in seconds to check for status. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmOperation{TOperations}"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual Response<T> WaitForCompletion(int pollingInterval, CancellationToken cancellationToken = default)
        {
            while (true)
            {
                UpdateStatus(cancellationToken);
                if (HasCompleted)
                {
                    return Response.FromValue(Value, GetRawResponse()) as ArmResponse<T>;
                }

                Task.Delay(pollingInterval, cancellationToken).Wait(cancellationToken);
            }
        }
    }
}
