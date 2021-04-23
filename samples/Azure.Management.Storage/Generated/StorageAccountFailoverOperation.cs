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
using Azure.ResourceManager.Core;

namespace Azure.Management.Storage
{
    public partial class StorageAccountFailoverOperation : ArmOperation<StorageAccountData>, IOperationSource<StorageAccountData>
    {
        private readonly ArmOperationHelpers<StorageAccountData> _operation;
        protected StorageAccountFailoverOperation()
        {
        }
        internal StorageAccountFailoverOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new ArmOperationHelpers<StorageAccountData>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "StorageAccountFailoverOperation");
        }
        public override string Id => _operation.Id;
        public override StorageAccountData Value => _operation.Value;
        public override bool HasCompleted => _operation.HasCompleted;
        public override bool HasValue => _operation.HasValue;
        public override Response GetRawResponse() => _operation.GetRawResponse();
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);
        public override ValueTask<Response<StorageAccountData>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);
        public override ValueTask<Response<StorageAccountData>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
        StorageAccountData IOperationSource<StorageAccountData>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return StorageAccountData.DeserializeStorageAccountData(document.RootElement);
        }
        async ValueTask<StorageAccountData> IOperationSource<StorageAccountData>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return StorageAccountData.DeserializeStorageAccountData(document.RootElement);
        }
    }
}
