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
using Azure.ResourceManager;
using MgmtRenameRules;

namespace MgmtRenameRules.Models
{
    /// <summary> The operation to create or update an extension. </summary>
    public partial class VirtualMachineScaleSetExtensionCreateOrUpdateOperation : Operation<VirtualMachineScaleSetExtension>, IOperationSource<VirtualMachineScaleSetExtension>
    {
        private readonly OperationInternals<VirtualMachineScaleSetExtension> _operation;

        private readonly ArmClient _armClient;

        /// <summary> Initializes a new instance of VirtualMachineScaleSetExtensionCreateOrUpdateOperation for mocking. </summary>
        protected VirtualMachineScaleSetExtensionCreateOrUpdateOperation()
        {
        }

        internal VirtualMachineScaleSetExtensionCreateOrUpdateOperation(ArmClient armClient, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<VirtualMachineScaleSetExtension>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "VirtualMachineScaleSetExtensionCreateOrUpdateOperation");
            _armClient = armClient;
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
            return new VirtualMachineScaleSetExtension(_armClient, data);
        }

        async ValueTask<VirtualMachineScaleSetExtension> IOperationSource<VirtualMachineScaleSetExtension>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = VirtualMachineScaleSetExtensionData.DeserializeVirtualMachineScaleSetExtensionData(document.RootElement);
            return new VirtualMachineScaleSetExtension(_armClient, data);
        }
    }
}
