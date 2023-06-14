// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Network.Management.Interface.Models;

namespace Azure.Network.Management.Interface
{
    /// <summary> Gets all route tables applied to a network interface. </summary>
    public partial class NetworkInterfacesGetEffectiveRouteTableOperation : Operation<EffectiveRouteListResult>, IOperationSource<EffectiveRouteListResult>
    {
        private readonly OperationInternal<EffectiveRouteListResult> _operation;

        /// <summary> Initializes a new instance of NetworkInterfacesGetEffectiveRouteTableOperation for mocking. </summary>
        protected NetworkInterfacesGetEffectiveRouteTableOperation()
        {
        }

        internal NetworkInterfacesGetEffectiveRouteTableOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            IOperation<EffectiveRouteListResult> nextLinkOperation = NextLinkOperationImplementation.Create(this, pipeline, request.Method, request.Uri.ToUri(), response, OperationFinalStateVia.Location);
            _operation = new OperationInternal<EffectiveRouteListResult>(nextLinkOperation, clientDiagnostics, response, "NetworkInterfacesGetEffectiveRouteTableOperation");
        }

        /// <inheritdoc />
#pragma warning disable CA1822
        public override string Id => throw new NotImplementedException();
#pragma warning restore CA1822

        /// <inheritdoc />
        public override EffectiveRouteListResult Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.RawResponse;

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override Response<EffectiveRouteListResult> WaitForCompletion(CancellationToken cancellationToken = default) => _operation.WaitForCompletion(cancellationToken);

        /// <inheritdoc />
        public override Response<EffectiveRouteListResult> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletion(pollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<EffectiveRouteListResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<EffectiveRouteListResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        EffectiveRouteListResult IOperationSource<EffectiveRouteListResult>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return EffectiveRouteListResult.DeserializeEffectiveRouteListResult(document.RootElement);
        }

        async ValueTask<EffectiveRouteListResult> IOperationSource<EffectiveRouteListResult>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return EffectiveRouteListResult.DeserializeEffectiveRouteListResult(document.RootElement);
        }
    }
}
