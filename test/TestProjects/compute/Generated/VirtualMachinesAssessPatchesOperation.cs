// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using compute.Models;

namespace compute
{
    /// <summary> Assess patches on the VM. </summary>
    public partial class VirtualMachinesAssessPatchesOperation : Operation<VirtualMachineAssessPatchesResult>, IOperationSource<VirtualMachineAssessPatchesResult>
    {
        private readonly ArmOperationHelpers<VirtualMachineAssessPatchesResult> _operation;
        internal VirtualMachinesAssessPatchesOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new ArmOperationHelpers<VirtualMachineAssessPatchesResult>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "VirtualMachinesAssessPatchesOperation");
        }
        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override VirtualMachineAssessPatchesResult Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.GetRawResponse();

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<VirtualMachineAssessPatchesResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<VirtualMachineAssessPatchesResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        VirtualMachineAssessPatchesResult IOperationSource<VirtualMachineAssessPatchesResult>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return VirtualMachineAssessPatchesResult.DeserializeVirtualMachineAssessPatchesResult(document.RootElement);
        }

        async ValueTask<VirtualMachineAssessPatchesResult> IOperationSource<VirtualMachineAssessPatchesResult>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return VirtualMachineAssessPatchesResult.DeserializeVirtualMachineAssessPatchesResult(document.RootElement);
        }
    }
}
