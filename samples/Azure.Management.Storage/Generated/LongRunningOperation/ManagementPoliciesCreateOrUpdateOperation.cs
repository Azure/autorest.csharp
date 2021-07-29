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
    /// <summary> Sets the managementpolicy to the specified storage account. </summary>
    public partial class ManagementPoliciesCreateOrUpdateOperation : Operation<ManagementPolicy>
    {
        private readonly OperationOrResponseInternals<ManagementPolicy> _operation;

        /// <summary> Initializes a new instance of ManagementPoliciesCreateOrUpdateOperation for mocking. </summary>
        protected ManagementPoliciesCreateOrUpdateOperation()
        {
        }

        internal ManagementPoliciesCreateOrUpdateOperation(ResourceOperations operationsBase, Response<ManagementPolicyData> response)
        {
            _operation = new OperationOrResponseInternals<ManagementPolicy>(Response.FromValue(new ManagementPolicy(operationsBase, response.Value), response.GetRawResponse()));
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override ManagementPolicy Value => _operation.Value;

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
        public override ValueTask<Response<ManagementPolicy>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<ManagementPolicy>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
