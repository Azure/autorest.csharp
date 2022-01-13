// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using MgmtNonStringPathVariable;

namespace MgmtNonStringPathVariable.Models
{
    /// <summary> Create or update an fake. </summary>
    public partial class FakeCreateOrUpdateOperation : Operation<Fake>, IOperationSource<Fake>
    {
        private readonly OperationInternals<Fake> _operation;

        private readonly ArmResource _operationBase;

        /// <summary> Initializes a new instance of FakeCreateOrUpdateOperation for mocking. </summary>
        protected FakeCreateOrUpdateOperation()
        {
        }

        internal FakeCreateOrUpdateOperation(ArmResource operationsBase, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<Fake>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "FakeCreateOrUpdateOperation");
            _operationBase = operationsBase;
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override Fake Value => _operation.Value;

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
        public override ValueTask<Response<Fake>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<Fake>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        Fake IOperationSource<Fake>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = FakeData.DeserializeFakeData(document.RootElement);
            return new Fake(_operationBase, data);
        }

        async ValueTask<Fake> IOperationSource<Fake>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = FakeData.DeserializeFakeData(document.RootElement);
            return new Fake(_operationBase, data);
        }
    }
}
