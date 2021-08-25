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
using MgmtContextualPath;

namespace MgmtContextualPath.Models
{
    /// <summary> Create or update an fake. </summary>
    public partial class FakeTupleResourceCreateOrUpdateOperation : Operation<FakeTupleResource>
    {
        private readonly OperationOrResponseInternals<FakeTupleResource> _operation;

        /// <summary> Initializes a new instance of FakeTupleResourceCreateOrUpdateOperation for mocking. </summary>
        protected FakeTupleResourceCreateOrUpdateOperation()
        {
        }

        internal FakeTupleResourceCreateOrUpdateOperation(ArmResource operationsBase, Response<FakeTupleResourceData> response)
        {
            _operation = new OperationOrResponseInternals<FakeTupleResource>(Response.FromValue(new FakeTupleResource(operationsBase, response.Value), response.GetRawResponse()));
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override FakeTupleResource Value => _operation.Value;

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
        public override ValueTask<Response<FakeTupleResource>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<FakeTupleResource>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
