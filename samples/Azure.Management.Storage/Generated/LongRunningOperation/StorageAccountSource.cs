// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.Management.Storage
{
    internal class StorageAccountSource : IOperationSource<StorageAccount>
    {
        private readonly ArmClient _client;

        internal StorageAccountSource(ArmClient client)
        {
            _client = client;
        }

        StorageAccount IOperationSource<StorageAccount>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = StorageAccountData.DeserializeStorageAccountData(document.RootElement);
            return new StorageAccount(_client, data);
        }

        async ValueTask<StorageAccount> IOperationSource<StorageAccount>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = StorageAccountData.DeserializeStorageAccountData(document.RootElement);
            return new StorageAccount(_client, data);
        }
    }
}
