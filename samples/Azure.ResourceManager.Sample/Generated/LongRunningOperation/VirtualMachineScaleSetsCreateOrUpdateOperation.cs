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
    /// <summary> Create or update a VM scale set. </summary>
    public partial class VirtualMachineScaleSetsCreateOrUpdateOperation : Operation<VirtualMachineScaleSet>, IOperationSource<VirtualMachineScaleSet>
    {
        private readonly OperationInternals<VirtualMachineScaleSet> _operation;

        private readonly ResourceOperations _operationBase;

        /// <summary> Initializes a new instance of VirtualMachineScaleSetsCreateOrUpdateOperation for mocking. </summary>
        protected VirtualMachineScaleSetsCreateOrUpdateOperation()
        {
        }

        internal VirtualMachineScaleSetsCreateOrUpdateOperation(ResourceOperations operationsBase, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<VirtualMachineScaleSet>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "VirtualMachineScaleSetsCreateOrUpdateOperation");
            _operationBase = operationsBase;
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override VirtualMachineScaleSet Value => _operation.Value;

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
        public override ValueTask<Response<VirtualMachineScaleSet>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<VirtualMachineScaleSet>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        VirtualMachineScaleSet IOperationSource<VirtualMachineScaleSet>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return new VirtualMachineScaleSet(_operationBase, VirtualMachineScaleSetData.DeserializeVirtualMachineScaleSetData(document.RootElement));
        }

        async ValueTask<VirtualMachineScaleSet> IOperationSource<VirtualMachineScaleSet>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return new VirtualMachineScaleSet(_operationBase, VirtualMachineScaleSetData.DeserializeVirtualMachineScaleSetData(document.RootElement));
        }
    }
}
