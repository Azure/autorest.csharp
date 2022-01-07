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
using MgmtMultipleParentResource;

namespace MgmtMultipleParentResource.Models
{
    /// <summary> The operation to create or update the VMSS VM run command. </summary>
    public partial class ChildCreateOrUpdateOperation : Operation<ParentSubParentChild>, IOperationSource<ParentSubParentChild>
    {
        private readonly OperationInternals<ParentSubParentChild> _operation;

        private readonly ArmResource _operationBase;

        /// <summary> Initializes a new instance of ChildCreateOrUpdateOperation for mocking. </summary>
        protected ChildCreateOrUpdateOperation()
        {
        }

        internal ChildCreateOrUpdateOperation(ArmResource operationsBase, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<ParentSubParentChild>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "ChildCreateOrUpdateOperation");
            _operationBase = operationsBase;
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override ParentSubParentChild Value => _operation.Value;

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
        public override ValueTask<Response<ParentSubParentChild>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<ParentSubParentChild>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        ParentSubParentChild IOperationSource<ParentSubParentChild>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = ChildBodyData.DeserializeChildBodyData(document.RootElement);
            return new ParentSubParentChild(_operationBase, data.Id, data);
        }

        async ValueTask<ParentSubParentChild> IOperationSource<ParentSubParentChild>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = ChildBodyData.DeserializeChildBodyData(document.RootElement);
            return new ParentSubParentChild(_operationBase, data.Id, data);
        }
    }
}
