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
    public partial class RGChildResourceCreateOrUpdateOperation : Operation<RGChildResource>
    {
        private readonly OperationOrResponseInternals<RGChildResource> _operation;

        /// <summary> Initializes a new instance of RGChildResourceCreateOrUpdateOperation for mocking. </summary>
        protected RGChildResourceCreateOrUpdateOperation()
        {
        }

        internal RGChildResourceCreateOrUpdateOperation(ArmResource operationsBase, Response<RGChildResourceData> response)
        {
            _operation = new OperationOrResponseInternals<RGChildResource>(Response.FromValue(new RGChildResource(operationsBase, response.Value), response.GetRawResponse()));
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override RGChildResource Value => _operation.Value;

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
        public override ValueTask<Response<RGChildResource>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<RGChildResource>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
