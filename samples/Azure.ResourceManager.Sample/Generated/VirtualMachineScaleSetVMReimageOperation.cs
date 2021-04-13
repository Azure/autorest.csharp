// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    public partial class VirtualMachineScaleSetVMReimageOperation : ArmOperation<VirtualMachineScaleSetVMData>, IOperationSource<VirtualMachineScaleSetVMData>
    {
        private readonly ArmOperationHelpers<VirtualMachineScaleSetVMData> _operation;
        protected VirtualMachineScaleSetVMReimageOperation()
        {
        }
        internal VirtualMachineScaleSetVMReimageOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new ArmOperationHelpers<VirtualMachineScaleSetVMData>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "VirtualMachineScaleSetVMReimageOperation");
        }
        public override string Id => _operation.Id;
        public override VirtualMachineScaleSetVMData Value => _operation.Value;
        public override bool HasCompleted => _operation.HasCompleted;
        public override bool HasValue => _operation.HasValue;
        public override Response GetRawResponse() => _operation.GetRawResponse();
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);
        public override ValueTask<Response<VirtualMachineScaleSetVMData>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);
        public override ValueTask<Response<VirtualMachineScaleSetVMData>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
        VirtualMachineScaleSetVMData IOperationSource<VirtualMachineScaleSetVMData>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return VirtualMachineScaleSetVMData.DeserializeVirtualMachineScaleSetVMData(document.RootElement);
        }
        async ValueTask<VirtualMachineScaleSetVMData> IOperationSource<VirtualMachineScaleSetVMData>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return VirtualMachineScaleSetVMData.DeserializeVirtualMachineScaleSetVMData(document.RootElement);
        }
    }
}
