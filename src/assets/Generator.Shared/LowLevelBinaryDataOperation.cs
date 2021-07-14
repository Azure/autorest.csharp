// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// The common operation type used by all low level client methods. The result of the operation is the `Response.Content` property of the final state.
    /// </summary>
    internal class LowLevelBinaryDataOperation : Operation<BinaryData>, IOperationSource<BinaryData>
    {
        private readonly OperationInternals<BinaryData> _operation;

        internal LowLevelBinaryDataOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, OperationFinalStateVia finalStateVia, string scopeName)
        {
            _operation = new OperationInternals<BinaryData>(this, clientDiagnostics, pipeline, request, response, finalStateVia, scopeName);
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override BinaryData Value => _operation.Value;

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
        public override ValueTask<Response<BinaryData>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<BinaryData>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        BinaryData IOperationSource<BinaryData>.CreateResult(Response response, CancellationToken cancellationToken) => response.Content;

        ValueTask<BinaryData> IOperationSource<BinaryData>.CreateResultAsync(Response response, CancellationToken cancellationToken) => new ValueTask<BinaryData>(response.Content);
    }
}
