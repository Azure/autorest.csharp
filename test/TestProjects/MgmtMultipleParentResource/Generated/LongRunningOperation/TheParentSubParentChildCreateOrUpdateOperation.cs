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
using Azure.ResourceManager;
using MgmtMultipleParentResource;

namespace MgmtMultipleParentResource.Models
{
    /// <summary> The operation to create or update the VMSS VM run command. </summary>
    public partial class TheParentSubParentChildCreateOrUpdateOperation : Operation<TheParentSubParentChild>, IOperationSource<TheParentSubParentChild>
    {
        private readonly OperationInternals<TheParentSubParentChild> _operation;

        private readonly ArmClient _armClient;

        /// <summary> Initializes a new instance of TheParentSubParentChildCreateOrUpdateOperation for mocking. </summary>
        protected TheParentSubParentChildCreateOrUpdateOperation()
        {
        }

        internal TheParentSubParentChildCreateOrUpdateOperation(ArmClient armClient, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<TheParentSubParentChild>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "TheParentSubParentChildCreateOrUpdateOperation");
            _armClient = armClient;
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override TheParentSubParentChild Value => _operation.Value;

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
        public override ValueTask<Response<TheParentSubParentChild>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<TheParentSubParentChild>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        TheParentSubParentChild IOperationSource<TheParentSubParentChild>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = ChildBodyData.DeserializeChildBodyData(document.RootElement);
            return new TheParentSubParentChild(_armClient, data);
        }

        async ValueTask<TheParentSubParentChild> IOperationSource<TheParentSubParentChild>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = ChildBodyData.DeserializeChildBodyData(document.RootElement);
            return new TheParentSubParentChild(_armClient, data);
        }
    }
}
