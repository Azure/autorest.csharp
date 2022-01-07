// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Core;
using MgmtParamOrdering;

namespace MgmtParamOrdering.Models
{
    /// <summary> Create or update container. </summary>
    public partial class EnvironmentContainerCreateOrUpdateOperation : Operation<EnvironmentContainerResource>
    {
        private readonly OperationOrResponseInternals<EnvironmentContainerResource> _operation;

        /// <summary> Initializes a new instance of EnvironmentContainerCreateOrUpdateOperation for mocking. </summary>
        protected EnvironmentContainerCreateOrUpdateOperation()
        {
        }

        internal EnvironmentContainerCreateOrUpdateOperation(ArmResource operationsBase, Response<EnvironmentContainerResourceData> response)
        {
            _operation = new OperationOrResponseInternals<EnvironmentContainerResource>(Response.FromValue(new EnvironmentContainerResource(operationsBase, response.Value.Id, response.Value), response.GetRawResponse()));
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override EnvironmentContainerResource Value => _operation.Value;

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
        public override ValueTask<Response<EnvironmentContainerResource>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<EnvironmentContainerResource>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
