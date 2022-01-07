// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using MgmtExpandResourceTypes;

namespace MgmtExpandResourceTypes.Models
{
    /// <summary> Updates a record set within a DNS zone. </summary>
    public partial class RecordSetUpdateOperation : Operation<RecordSetData>
    {
        private readonly OperationOrResponseInternals<RecordSetData> _operation;

        /// <summary> Initializes a new instance of RecordSetUpdateOperation for mocking. </summary>
        protected RecordSetUpdateOperation()
        {
        }

        internal RecordSetUpdateOperation(Response<RecordSetData> response)
        {
            _operation = new OperationOrResponseInternals<RecordSetData>(response);
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override RecordSetData Value => _operation.Value;

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
        public override ValueTask<Response<RecordSetData>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<RecordSetData>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
