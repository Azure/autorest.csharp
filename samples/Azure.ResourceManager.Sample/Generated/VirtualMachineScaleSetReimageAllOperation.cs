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
    public partial class VirtualMachineScaleSetReimageAllOperation : ArmOperation<VirtualMachineScaleSetData>, IOperationSource<VirtualMachineScaleSetData>
    {
        private readonly ArmOperationHelpers<VirtualMachineScaleSetData> _operation;
        protected VirtualMachineScaleSetReimageAllOperation()
        {
        }
        internal VirtualMachineScaleSetReimageAllOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new ArmOperationHelpers<VirtualMachineScaleSetData>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "VirtualMachineScaleSetReimageAllOperation");
        }
        public override string Id => _operation.Id;
        public override VirtualMachineScaleSetData Value => _operation.Value;
        public override bool HasCompleted => _operation.HasCompleted;
        public override bool HasValue => _operation.HasValue;
        public override Response GetRawResponse() => _operation.GetRawResponse();
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);
        public override ValueTask<Response<VirtualMachineScaleSetData>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);
        public override ValueTask<Response<VirtualMachineScaleSetData>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
        VirtualMachineScaleSetData IOperationSource<VirtualMachineScaleSetData>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return VirtualMachineScaleSetData.DeserializeVirtualMachineScaleSetData(document.RootElement);
        }
        async ValueTask<VirtualMachineScaleSetData> IOperationSource<VirtualMachineScaleSetData>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return VirtualMachineScaleSetData.DeserializeVirtualMachineScaleSetData(document.RootElement);
        }
    }
}
