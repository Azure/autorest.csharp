// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Management.Storage;
using Azure.ResourceManager.Core;

namespace Azure.Management.Storage.Models
{
    /// <summary> Synchronously creates or updates an encryption scope under the specified storage account. If an encryption scope is already created and a subsequent request is issued with different properties, the encryption scope properties will be updated per the specified request. </summary>
    public partial class EncryptionScopePutOperation : Operation<EncryptionScope>
    {
        private readonly OperationOrResponseInternals<EncryptionScope> _operation;

        /// <summary> Initializes a new instance of EncryptionScopePutOperation for mocking. </summary>
        protected EncryptionScopePutOperation()
        {
        }

        internal EncryptionScopePutOperation(ArmResource operationsBase, Response<EncryptionScopeData> response)
        {
            _operation = new OperationOrResponseInternals<EncryptionScope>(Response.FromValue(new EncryptionScope(operationsBase, response.Value.Id, response.Value), response.GetRawResponse()));
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override EncryptionScope Value => _operation.Value;

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
        public override ValueTask<Response<EncryptionScope>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<EncryptionScope>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
