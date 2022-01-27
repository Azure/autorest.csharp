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
using MgmtKeyvault;

namespace MgmtKeyvault.Models
{
    /// <summary> Create or update a key vault in the specified subscription. </summary>
    public partial class VaultCreateOrUpdateOperation : Operation<Vault>, IOperationSource<Vault>
    {
        private readonly OperationInternals<Vault> _operation;

        private readonly ArmClient _armClient;

        /// <summary> Initializes a new instance of VaultCreateOrUpdateOperation for mocking. </summary>
        protected VaultCreateOrUpdateOperation()
        {
        }

        internal VaultCreateOrUpdateOperation(ArmClient armClient, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<Vault>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "VaultCreateOrUpdateOperation");
            _armClient = armClient;
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override Vault Value => _operation.Value;

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
        public override ValueTask<Response<Vault>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<Vault>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        Vault IOperationSource<Vault>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = VaultData.DeserializeVaultData(document.RootElement);
            return new Vault(_armClient, data);
        }

        async ValueTask<Vault> IOperationSource<Vault>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = VaultData.DeserializeVaultData(document.RootElement);
            return new Vault(_armClient, data);
        }
    }
}
