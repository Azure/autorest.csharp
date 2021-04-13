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
    public partial class VirtualMachineScaleSetRollingUpgradeStartExtensionUpgradeOperation : ArmOperation<VirtualMachineScaleSetRollingUpgradeData>, IOperationSource<VirtualMachineScaleSetRollingUpgradeData>
    {
        private readonly ArmOperationHelpers<VirtualMachineScaleSetRollingUpgradeData> _operation;
        protected VirtualMachineScaleSetRollingUpgradeStartExtensionUpgradeOperation()
        {
        }
        internal VirtualMachineScaleSetRollingUpgradeStartExtensionUpgradeOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new ArmOperationHelpers<VirtualMachineScaleSetRollingUpgradeData>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "VirtualMachineScaleSetRollingUpgradeStartExtensionUpgradeOperation");
        }
        public override string Id => _operation.Id;
        public override VirtualMachineScaleSetRollingUpgradeData Value => _operation.Value;
        public override bool HasCompleted => _operation.HasCompleted;
        public override bool HasValue => _operation.HasValue;
        public override Response GetRawResponse() => _operation.GetRawResponse();
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);
        public override ValueTask<Response<VirtualMachineScaleSetRollingUpgradeData>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);
        public override ValueTask<Response<VirtualMachineScaleSetRollingUpgradeData>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
        VirtualMachineScaleSetRollingUpgradeData IOperationSource<VirtualMachineScaleSetRollingUpgradeData>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return VirtualMachineScaleSetRollingUpgradeData.DeserializeVirtualMachineScaleSetRollingUpgradeData(document.RootElement);
        }
        async ValueTask<VirtualMachineScaleSetRollingUpgradeData> IOperationSource<VirtualMachineScaleSetRollingUpgradeData>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return VirtualMachineScaleSetRollingUpgradeData.DeserializeVirtualMachineScaleSetRollingUpgradeData(document.RootElement);
        }
    }
}
