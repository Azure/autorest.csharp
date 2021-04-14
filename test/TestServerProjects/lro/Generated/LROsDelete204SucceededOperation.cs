// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace lro
{
    /// <summary> Long running delete succeeds and returns right away. </summary>
    public partial class LROsDelete204SucceededOperation : Operation<Response>, IOperationSource<Response>
    {
        private readonly OperationHelpers<Response> _operation;

        /// <summary> Initializes a new instance of LROsDelete204SucceededOperation for mocking. </summary>
        protected LROsDelete204SucceededOperation()
        {
        }

        internal LROsDelete204SucceededOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationHelpers<Response>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "LROsDelete204SucceededOperation");
        }
        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override Response Value => _operation.Value;

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
        public override ValueTask<Response<Response>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<Response>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        Response IOperationSource<Response>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            return response;
        }

        async ValueTask<Response> IOperationSource<Response>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            return await new ValueTask<Response>(response).ConfigureAwait(false);
        }
    }
}
