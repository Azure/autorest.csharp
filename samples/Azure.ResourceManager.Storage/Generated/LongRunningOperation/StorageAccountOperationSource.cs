// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Storage
{
    internal class StorageAccountOperationSource : IOperationSource<StorageAccountResource>
    {
        private readonly ArmClient _client;

        internal StorageAccountOperationSource(ArmClient client)
        {
            _client = client;
        }

        StorageAccountResource IOperationSource<StorageAccountResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = StorageAccountData.DeserializeStorageAccountData(document.RootElement);
            return new StorageAccountResource(_client, data);
        }

        async ValueTask<StorageAccountResource> IOperationSource<StorageAccountResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = StorageAccountData.DeserializeStorageAccountData(document.RootElement);
            return new StorageAccountResource(_client, data);
        }
    }
}
