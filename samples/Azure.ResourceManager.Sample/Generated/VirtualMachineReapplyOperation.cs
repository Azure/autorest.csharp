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
    public partial class VirtualMachineReapplyOperation : ArmOperation<VirtualMachineData>, IOperationSource<VirtualMachineData>
    {
        private readonly ArmOperationHelpers<VirtualMachineData> _operation;
        protected VirtualMachineReapplyOperation()
        {
        }
        internal VirtualMachineReapplyOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new ArmOperationHelpers<VirtualMachineData>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "VirtualMachineReapplyOperation");
        }
        public override string Id => _operation.Id;
        public override VirtualMachineData Value => _operation.Value;
        public override bool HasCompleted => _operation.HasCompleted;
        public override bool HasValue => _operation.HasValue;
        public override Response GetRawResponse() => _operation.GetRawResponse();
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);
        public override ValueTask<Response<VirtualMachineData>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);
        public override ValueTask<Response<VirtualMachineData>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
        VirtualMachineData IOperationSource<VirtualMachineData>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return VirtualMachineData.DeserializeVirtualMachineData(document.RootElement);
        }
        async ValueTask<VirtualMachineData> IOperationSource<VirtualMachineData>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return VirtualMachineData.DeserializeVirtualMachineData(document.RootElement);
        }
    }
}
