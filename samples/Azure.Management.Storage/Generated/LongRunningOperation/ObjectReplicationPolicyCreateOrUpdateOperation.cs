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
using Azure.ResourceManager.Core;

namespace Azure.Management.Storage.Models
{
    /// <summary> Create or update the object replication policy of the storage account. </summary>
    public partial class ObjectReplicationPolicyCreateOrUpdateOperation : Operation<ObjectReplicationPolicy>
    {
        private readonly OperationOrResponseInternals<ObjectReplicationPolicy> _operation;

        /// <summary> Initializes a new instance of ObjectReplicationPolicyCreateOrUpdateOperation for mocking. </summary>
        protected ObjectReplicationPolicyCreateOrUpdateOperation()
        {
        }

        internal ObjectReplicationPolicyCreateOrUpdateOperation(ArmResource operationsBase, Response<ObjectReplicationPolicyData> response)
        {
            _operation = new OperationOrResponseInternals<ObjectReplicationPolicy>(Response.FromValue(new ObjectReplicationPolicy(operationsBase, response.Value.Id, response.Value), response.GetRawResponse()));
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override ObjectReplicationPolicy Value => _operation.Value;

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
        public override ValueTask<Response<ObjectReplicationPolicy>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<ObjectReplicationPolicy>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
