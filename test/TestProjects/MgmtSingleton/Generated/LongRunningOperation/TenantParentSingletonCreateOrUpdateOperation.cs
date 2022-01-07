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
using MgmtSingleton;

namespace MgmtSingleton.Models
{
    public partial class TenantParentSingletonCreateOrUpdateOperation : Operation<TenantParentSingleton>
    {
        private readonly OperationOrResponseInternals<TenantParentSingleton> _operation;

        /// <summary> Initializes a new instance of TenantParentSingletonCreateOrUpdateOperation for mocking. </summary>
        protected TenantParentSingletonCreateOrUpdateOperation()
        {
        }

        internal TenantParentSingletonCreateOrUpdateOperation(ArmResource operationsBase, Response<TenantParentSingletonData> response)
        {
            _operation = new OperationOrResponseInternals<TenantParentSingleton>(Response.FromValue(new TenantParentSingleton(operationsBase, response.Value.Id, response.Value), response.GetRawResponse()));
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override TenantParentSingleton Value => _operation.Value;

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
        public override ValueTask<Response<TenantParentSingleton>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<TenantParentSingleton>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
