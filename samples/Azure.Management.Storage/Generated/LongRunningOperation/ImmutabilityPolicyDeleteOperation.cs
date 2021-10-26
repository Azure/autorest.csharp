// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Management.Storage;

namespace Azure.Management.Storage.Models
{
    /// <summary> Aborts an unlocked immutability policy. The response of delete has immutabilityPeriodSinceCreationInDays set to 0. ETag in If-Match is required for this operation. Deleting a locked immutability policy is not allowed, the only way is to delete the container after deleting all expired blobs inside the policy locked container. </summary>
    public partial class ImmutabilityPolicyDeleteOperation : Operation<ImmutabilityPolicyData>
    {
        private readonly OperationOrResponseInternals<ImmutabilityPolicyData> _operation;

        /// <summary> Initializes a new instance of ImmutabilityPolicyDeleteOperation for mocking. </summary>
        protected ImmutabilityPolicyDeleteOperation()
        {
        }

        internal ImmutabilityPolicyDeleteOperation(Response<ImmutabilityPolicyData> response)
        {
            _operation = new OperationOrResponseInternals<ImmutabilityPolicyData>(response);
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override ImmutabilityPolicyData Value => _operation.Value;

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
        public override ValueTask<Response<ImmutabilityPolicyData>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<ImmutabilityPolicyData>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
