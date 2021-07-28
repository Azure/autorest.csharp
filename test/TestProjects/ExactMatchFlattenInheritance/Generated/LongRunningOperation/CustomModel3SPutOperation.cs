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
using ExactMatchFlattenInheritance;

namespace ExactMatchFlattenInheritance.Models
{
    /// <summary> Create or update an CustomModel3. </summary>
    public partial class CustomModel3SPutOperation : Operation<CustomModel3>
    {
        private readonly OperationOrResponseInternals<CustomModel3> _operation;

        /// <summary> Initializes a new instance of CustomModel3SPutOperation for mocking. </summary>
        protected CustomModel3SPutOperation()
        {
        }

        internal CustomModel3SPutOperation(ResourceOperations operationsBase, Response<CustomModel3Data> response)
        {
            _operation = new OperationOrResponseInternals<CustomModel3>(Response.FromValue(new CustomModel3(operationsBase, response.Value), response.GetRawResponse()));
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override CustomModel3 Value => _operation.Value;

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
        public override ValueTask<Response<CustomModel3>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<CustomModel3>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
