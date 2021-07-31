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
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> You can provide the template and parameters directly in the request or link to JSON files. </summary>
    public partial class DeploymentsCreateOrUpdateAtScopeOperation : Operation<DeploymentExtended>, IOperationSource<DeploymentExtended>
    {
        private readonly OperationInternals<DeploymentExtended> _operation;

        private readonly ResourceOperations _operationBase;

        /// <summary> Initializes a new instance of DeploymentsCreateOrUpdateAtScopeOperation for mocking. </summary>
        protected DeploymentsCreateOrUpdateAtScopeOperation()
        {
        }

        internal DeploymentsCreateOrUpdateAtScopeOperation(ResourceOperations operationsBase, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<DeploymentExtended>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "DeploymentsCreateOrUpdateAtScopeOperation");
            _operationBase = operationsBase;
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override DeploymentExtended Value => _operation.Value;

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
        public override ValueTask<Response<DeploymentExtended>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<DeploymentExtended>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        DeploymentExtended IOperationSource<DeploymentExtended>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return new DeploymentExtended(_operationBase, DeploymentExtendedData.DeserializeDeploymentExtendedData(document.RootElement));
        }

        async ValueTask<DeploymentExtended> IOperationSource<DeploymentExtended>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return new DeploymentExtended(_operationBase, DeploymentExtendedData.DeserializeDeploymentExtendedData(document.RootElement));
        }
    }
}
