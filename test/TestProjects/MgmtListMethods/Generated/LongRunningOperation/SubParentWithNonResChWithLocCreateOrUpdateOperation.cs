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
using MgmtListMethods;

namespace MgmtListMethods.Models
{
    /// <summary> Create or update. </summary>
    public partial class SubParentWithNonResChWithLocCreateOrUpdateOperation : Operation<SubParentWithNonResChWithLoc>
    {
        private readonly OperationOrResponseInternals<SubParentWithNonResChWithLoc> _operation;

        /// <summary> Initializes a new instance of SubParentWithNonResChWithLocCreateOrUpdateOperation for mocking. </summary>
        protected SubParentWithNonResChWithLocCreateOrUpdateOperation()
        {
        }

        internal SubParentWithNonResChWithLocCreateOrUpdateOperation(ArmResource operationsBase, Response<SubParentWithNonResChWithLocData> response)
        {
            _operation = new OperationOrResponseInternals<SubParentWithNonResChWithLoc>(Response.FromValue(new SubParentWithNonResChWithLoc(operationsBase, response.Value.Id, response.Value), response.GetRawResponse()));
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override SubParentWithNonResChWithLoc Value => _operation.Value;

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
        public override ValueTask<Response<SubParentWithNonResChWithLoc>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<SubParentWithNonResChWithLoc>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
