// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using SupersetFlattenInheritance;

namespace SupersetFlattenInheritance.Models
{
    public partial class TrackedResourceModel1CreateOrUpdateOperation : Operation<TrackedResourceModel1>
    {
        private readonly OperationOrResponseInternals<TrackedResourceModel1> _operation;

        /// <summary> Initializes a new instance of TrackedResourceModel1CreateOrUpdateOperation for mocking. </summary>
        protected TrackedResourceModel1CreateOrUpdateOperation()
        {
        }

        internal TrackedResourceModel1CreateOrUpdateOperation(ArmClient armClient, Response<TrackedResourceModel1Data> response)
        {
            _operation = new OperationOrResponseInternals<TrackedResourceModel1>(Response.FromValue(new TrackedResourceModel1(armClient, response.Value), response.GetRawResponse()));
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override TrackedResourceModel1 Value => _operation.Value;

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
        public override ValueTask<Response<TrackedResourceModel1>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<TrackedResourceModel1>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
