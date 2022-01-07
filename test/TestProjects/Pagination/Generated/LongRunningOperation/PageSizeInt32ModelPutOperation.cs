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
using Pagination;

namespace Pagination.Models
{
    public partial class PageSizeInt32ModelPutOperation : Operation<PageSizeInt32Model>
    {
        private readonly OperationOrResponseInternals<PageSizeInt32Model> _operation;

        /// <summary> Initializes a new instance of PageSizeInt32ModelPutOperation for mocking. </summary>
        protected PageSizeInt32ModelPutOperation()
        {
        }

        internal PageSizeInt32ModelPutOperation(ArmResource operationsBase, Response<PageSizeInt32ModelData> response)
        {
            _operation = new OperationOrResponseInternals<PageSizeInt32Model>(Response.FromValue(new PageSizeInt32Model(operationsBase, new ResourceIdentifier(response.Value.Id), response.Value), response.GetRawResponse()));
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override PageSizeInt32Model Value => _operation.Value;

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
        public override ValueTask<Response<PageSizeInt32Model>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<PageSizeInt32Model>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
