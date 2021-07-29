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
    public partial class PageSizeIntegerModelsPutOperation : Operation<PageSizeIntegerModel>
    {
        private readonly OperationOrResponseInternals<PageSizeIntegerModel> _operation;

        /// <summary> Initializes a new instance of PageSizeIntegerModelsPutOperation for mocking. </summary>
        protected PageSizeIntegerModelsPutOperation()
        {
        }

        internal PageSizeIntegerModelsPutOperation(ResourceOperations operationsBase, Response<PageSizeIntegerModelData> response)
        {
            _operation = new OperationOrResponseInternals<PageSizeIntegerModel>(Response.FromValue(new PageSizeIntegerModel(operationsBase, response.Value), response.GetRawResponse()));
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override PageSizeIntegerModel Value => _operation.Value;

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
        public override ValueTask<Response<PageSizeIntegerModel>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<PageSizeIntegerModel>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
