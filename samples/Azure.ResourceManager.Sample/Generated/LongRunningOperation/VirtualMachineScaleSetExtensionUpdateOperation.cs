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
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> The operation to update an extension. </summary>
    public partial class VirtualMachineScaleSetExtensionUpdateOperation : Operation<VirtualMachineScaleSetExtension>, IOperationSource<VirtualMachineScaleSetExtension>
    {
        private readonly OperationInternals<VirtualMachineScaleSetExtension> _operation;

        private readonly ArmResource _operationBase;

        /// <summary> Initializes a new instance of VirtualMachineScaleSetExtensionUpdateOperation for mocking. </summary>
        protected VirtualMachineScaleSetExtensionUpdateOperation()
        {
        }

        internal VirtualMachineScaleSetExtensionUpdateOperation(ArmResource operationsBase, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<VirtualMachineScaleSetExtension>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "VirtualMachineScaleSetExtensionUpdateOperation");
            _operationBase = operationsBase;
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override VirtualMachineScaleSetExtension Value => _operation.Value;

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
        public override ValueTask<Response<VirtualMachineScaleSetExtension>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<VirtualMachineScaleSetExtension>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        VirtualMachineScaleSetExtension IOperationSource<VirtualMachineScaleSetExtension>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = VirtualMachineScaleSetExtensionData.DeserializeVirtualMachineScaleSetExtensionData(document.RootElement);
            return new VirtualMachineScaleSetExtension(_operationBase, new ResourceIdentifier(data.Id), data);
        }

        async ValueTask<VirtualMachineScaleSetExtension> IOperationSource<VirtualMachineScaleSetExtension>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = VirtualMachineScaleSetExtensionData.DeserializeVirtualMachineScaleSetExtensionData(document.RootElement);
            return new VirtualMachineScaleSetExtension(_operationBase, new ResourceIdentifier(data.Id), data);
        }
    }
}
