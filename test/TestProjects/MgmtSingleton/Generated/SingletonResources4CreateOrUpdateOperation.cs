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

namespace MgmtSingleton
{
    public partial class SingletonResources4CreateOrUpdateOperation : Operation<SingletonResource4>
    {
        private readonly OperationOrResponseInternals<SingletonResource4> _operation;

        /// <summary> Initializes a new instance of SingletonResources4CreateOrUpdateOperation for mocking. </summary>
        protected SingletonResources4CreateOrUpdateOperation()
        {
        }

        internal SingletonResources4CreateOrUpdateOperation(ResourceOperationsBase operationsBase, Response<SingletonResource4Data> response)
        {
            _operation = new OperationOrResponseInternals<SingletonResource4>(Response.FromValue(new SingletonResource4(operationsBase, response.Value), response.GetRawResponse()));
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override SingletonResource4 Value => _operation.Value;

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
        public override ValueTask<Response<SingletonResource4>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<SingletonResource4>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
