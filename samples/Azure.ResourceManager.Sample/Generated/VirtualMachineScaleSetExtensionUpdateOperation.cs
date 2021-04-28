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
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    public partial class VirtualMachineScaleSetExtensionUpdateOperation : ArmOperation<VirtualMachineScaleSetExtensionData>, IOperationSource<VirtualMachineScaleSetExtensionData>
    {
        private readonly OperationInternals<VirtualMachineScaleSetExtensionData> _operation;
        protected VirtualMachineScaleSetExtensionUpdateOperation()
        {
        }
        internal VirtualMachineScaleSetExtensionUpdateOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<VirtualMachineScaleSetExtensionData>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "VirtualMachineScaleSetExtensionUpdateOperation");
        }
        public override string Id => _operation.Id;
        public override VirtualMachineScaleSetExtensionData Value => _operation.Value;
        public override bool HasCompleted => _operation.HasCompleted;
        public override bool HasValue => _operation.HasValue;
        public override Response GetRawResponse() => _operation.GetRawResponse();
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);
        public override ValueTask<Response<VirtualMachineScaleSetExtensionData>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);
        public override ValueTask<Response<VirtualMachineScaleSetExtensionData>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
        VirtualMachineScaleSetExtensionData IOperationSource<VirtualMachineScaleSetExtensionData>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return VirtualMachineScaleSetExtensionData.DeserializeVirtualMachineScaleSetExtensionData(document.RootElement);
        }
        async ValueTask<VirtualMachineScaleSetExtensionData> IOperationSource<VirtualMachineScaleSetExtensionData>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return VirtualMachineScaleSetExtensionData.DeserializeVirtualMachineScaleSetExtensionData(document.RootElement);
        }
    }
}
