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

namespace Azure.ResourceManager.Sample
{
    /// <summary> Create or update a proximity placement group. </summary>
    public partial class ProximityPlacementGroupsCreateOrUpdateOperation : Operation<ProximityPlacementGroup>
    {
        private readonly OperationOrResponseInternals<ProximityPlacementGroup> _operation;

        /// <summary> Initializes a new instance of ProximityPlacementGroupsCreateOrUpdateOperation for mocking. </summary>
        protected ProximityPlacementGroupsCreateOrUpdateOperation()
        {
        }

        internal ProximityPlacementGroupsCreateOrUpdateOperation(OperationsBase operationsBase, Response<ProximityPlacementGroupData> response)
        {
            _operation = new OperationOrResponseInternals<ProximityPlacementGroup>(Response.FromValue(new ProximityPlacementGroup(operationsBase, response.Value), response.GetRawResponse()));
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override ProximityPlacementGroup Value => _operation.Value;

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
        public override ValueTask<Response<ProximityPlacementGroup>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<ProximityPlacementGroup>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
