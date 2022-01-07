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
using MgmtParamOrdering;

namespace MgmtParamOrdering.Models
{
    /// <summary> Create or update a dedicated host . </summary>
    public partial class DedicatedHostCreateOrUpdateOperation : Operation<DedicatedHost>, IOperationSource<DedicatedHost>
    {
        private readonly OperationInternals<DedicatedHost> _operation;

        private readonly ArmResource _operationBase;

        /// <summary> Initializes a new instance of DedicatedHostCreateOrUpdateOperation for mocking. </summary>
        protected DedicatedHostCreateOrUpdateOperation()
        {
        }

        internal DedicatedHostCreateOrUpdateOperation(ArmResource operationsBase, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<DedicatedHost>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "DedicatedHostCreateOrUpdateOperation");
            _operationBase = operationsBase;
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override DedicatedHost Value => _operation.Value;

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
        public override ValueTask<Response<DedicatedHost>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<DedicatedHost>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        DedicatedHost IOperationSource<DedicatedHost>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = DedicatedHostData.DeserializeDedicatedHostData(document.RootElement);
            return new DedicatedHost(_operationBase, data.Id, data);
        }

        async ValueTask<DedicatedHost> IOperationSource<DedicatedHost>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = DedicatedHostData.DeserializeDedicatedHostData(document.RootElement);
            return new DedicatedHost(_operationBase, data.Id, data);
        }
    }
}
