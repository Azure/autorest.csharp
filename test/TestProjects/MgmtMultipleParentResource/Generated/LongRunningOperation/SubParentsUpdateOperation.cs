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
    /// <summary> The operation to update the VMSS VM run command. </summary>
    public partial class SubParentsUpdateOperation : Operation<SubParent>, IOperationSource<SubParent>
    {
        private readonly OperationInternals<SubParent> _operation;

        private readonly ResourceOperations _operationBase;

        /// <summary> Initializes a new instance of SubParentsUpdateOperation for mocking. </summary>
        protected SubParentsUpdateOperation()
        {
        }

        internal SubParentsUpdateOperation(ResourceOperations operationsBase, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<SubParent>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "SubParentsUpdateOperation");
            _operationBase = operationsBase;
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override SubParent Value => _operation.Value;

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
        public override ValueTask<Response<SubParent>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<SubParent>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        SubParent IOperationSource<SubParent>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return new SubParent(_operationBase, SubParentData.DeserializeSubParentData(document.RootElement));
        }

        async ValueTask<SubParent> IOperationSource<SubParent>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return new SubParent(_operationBase, SubParentData.DeserializeSubParentData(document.RootElement));
        }
    }
}
