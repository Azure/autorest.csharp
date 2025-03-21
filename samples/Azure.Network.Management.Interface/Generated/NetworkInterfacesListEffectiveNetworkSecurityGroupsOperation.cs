// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Network.Management.Interface.Models;

namespace Azure.Network.Management.Interface
{
    /// <summary> Gets all network security groups applied to a network interface. </summary>
    public partial class NetworkInterfacesListEffectiveNetworkSecurityGroupsOperation : Operation<EffectiveNetworkSecurityGroupListResult>, IOperationSource<EffectiveNetworkSecurityGroupListResult>
    {
        private readonly OperationInternal<EffectiveNetworkSecurityGroupListResult> _operation;

        /// <summary> Initializes a new instance of NetworkInterfacesListEffectiveNetworkSecurityGroupsOperation for mocking. </summary>
        protected NetworkInterfacesListEffectiveNetworkSecurityGroupsOperation()
        {
        }

        internal NetworkInterfacesListEffectiveNetworkSecurityGroupsOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            IOperation<EffectiveNetworkSecurityGroupListResult> nextLinkOperation = NextLinkOperationImplementation.Create(this, pipeline, request.Method, request.Uri.ToUri(), response, OperationFinalStateVia.Location);
            _operation = new OperationInternal<EffectiveNetworkSecurityGroupListResult>(nextLinkOperation, clientDiagnostics, response, "NetworkInterfacesListEffectiveNetworkSecurityGroupsOperation");
        }

        /// <inheritdoc />
#pragma warning disable CA1822
        public override string Id => throw new NotImplementedException();
#pragma warning restore CA1822

        /// <inheritdoc />
        public override EffectiveNetworkSecurityGroupListResult Value => _operation.Value;

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
        public override Response<EffectiveNetworkSecurityGroupListResult> WaitForCompletion(CancellationToken cancellationToken = default) => _operation.WaitForCompletion(cancellationToken);

        /// <inheritdoc />
        public override Response<EffectiveNetworkSecurityGroupListResult> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletion(pollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<EffectiveNetworkSecurityGroupListResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<EffectiveNetworkSecurityGroupListResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        EffectiveNetworkSecurityGroupListResult IOperationSource<EffectiveNetworkSecurityGroupListResult>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
            return EffectiveNetworkSecurityGroupListResult.DeserializeEffectiveNetworkSecurityGroupListResult(document.RootElement);
        }

        async ValueTask<EffectiveNetworkSecurityGroupListResult> IOperationSource<EffectiveNetworkSecurityGroupListResult>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
            return EffectiveNetworkSecurityGroupListResult.DeserializeEffectiveNetworkSecurityGroupListResult(document.RootElement);
        }
    }
}
