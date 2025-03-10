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
    /// <summary> Creates or updates a Tap configuration in the specified NetworkInterface. </summary>
    public partial class NetworkInterfaceTapConfigurationsCreateOrUpdateOperation : Operation<NetworkInterfaceTapConfiguration>, IOperationSource<NetworkInterfaceTapConfiguration>
    {
        private readonly OperationInternal<NetworkInterfaceTapConfiguration> _operation;

        /// <summary> Initializes a new instance of NetworkInterfaceTapConfigurationsCreateOrUpdateOperation for mocking. </summary>
        protected NetworkInterfaceTapConfigurationsCreateOrUpdateOperation()
        {
        }

        internal NetworkInterfaceTapConfigurationsCreateOrUpdateOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            IOperation<NetworkInterfaceTapConfiguration> nextLinkOperation = NextLinkOperationImplementation.Create(this, pipeline, request.Method, request.Uri.ToUri(), response, OperationFinalStateVia.AzureAsyncOperation);
            _operation = new OperationInternal<NetworkInterfaceTapConfiguration>(nextLinkOperation, clientDiagnostics, response, "NetworkInterfaceTapConfigurationsCreateOrUpdateOperation");
        }

        /// <inheritdoc />
#pragma warning disable CA1822
        public override string Id => throw new NotImplementedException();
#pragma warning restore CA1822

        /// <inheritdoc />
        public override NetworkInterfaceTapConfiguration Value => _operation.Value;

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
        public override Response<NetworkInterfaceTapConfiguration> WaitForCompletion(CancellationToken cancellationToken = default) => _operation.WaitForCompletion(cancellationToken);

        /// <inheritdoc />
        public override Response<NetworkInterfaceTapConfiguration> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletion(pollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<NetworkInterfaceTapConfiguration>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<NetworkInterfaceTapConfiguration>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        NetworkInterfaceTapConfiguration IOperationSource<NetworkInterfaceTapConfiguration>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
            return NetworkInterfaceTapConfiguration.DeserializeNetworkInterfaceTapConfiguration(document.RootElement);
        }

        async ValueTask<NetworkInterfaceTapConfiguration> IOperationSource<NetworkInterfaceTapConfiguration>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
            return NetworkInterfaceTapConfiguration.DeserializeNetworkInterfaceTapConfiguration(document.RootElement);
        }
    }
}
