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
    public partial class ResGrpParentWithAncestorWithNonResChWithLocCreateOrUpdateOperation : Operation<ResGrpParentWithAncestorWithNonResChWithLoc>
    {
        private readonly OperationOrResponseInternals<ResGrpParentWithAncestorWithNonResChWithLoc> _operation;

        /// <summary> Initializes a new instance of ResGrpParentWithAncestorWithNonResChWithLocCreateOrUpdateOperation for mocking. </summary>
        protected ResGrpParentWithAncestorWithNonResChWithLocCreateOrUpdateOperation()
        {
        }

        internal ResGrpParentWithAncestorWithNonResChWithLocCreateOrUpdateOperation(ArmResource operationsBase, Response<ResGrpParentWithAncestorWithNonResChWithLocData> response)
        {
            _operation = new OperationOrResponseInternals<ResGrpParentWithAncestorWithNonResChWithLoc>(Response.FromValue(new ResGrpParentWithAncestorWithNonResChWithLoc(operationsBase, response.Value), response.GetRawResponse()));
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override ResGrpParentWithAncestorWithNonResChWithLoc Value => _operation.Value;

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
        public override ValueTask<Response<ResGrpParentWithAncestorWithNonResChWithLoc>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<ResGrpParentWithAncestorWithNonResChWithLoc>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
