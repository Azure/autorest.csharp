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
    /// <summary> The operation to create or update the run command. </summary>
    public partial class AnotherParentCreateOrUpdateOperation : Operation<AnotherParent>, IOperationSource<AnotherParent>
    {
        private readonly OperationInternals<AnotherParent> _operation;

        private readonly ArmResource _operationBase;

        /// <summary> Initializes a new instance of AnotherParentCreateOrUpdateOperation for mocking. </summary>
        protected AnotherParentCreateOrUpdateOperation()
        {
        }

        internal AnotherParentCreateOrUpdateOperation(ArmResource operationsBase, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<AnotherParent>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "AnotherParentCreateOrUpdateOperation");
            _operationBase = operationsBase;
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override AnotherParent Value => _operation.Value;

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
        public override ValueTask<Response<AnotherParent>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<AnotherParent>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        AnotherParent IOperationSource<AnotherParent>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = AnotherParentData.DeserializeAnotherParentData(document.RootElement);
            return new AnotherParent(_operationBase, data.Id, data);
        }

        async ValueTask<AnotherParent> IOperationSource<AnotherParent>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = AnotherParentData.DeserializeAnotherParentData(document.RootElement);
            return new AnotherParent(_operationBase, data.Id, data);
        }
    }
}
