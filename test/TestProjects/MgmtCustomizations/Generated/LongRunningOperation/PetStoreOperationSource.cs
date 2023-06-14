// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace MgmtCustomizations
{
    internal class PetStoreOperationSource : IOperationSource<PetStoreResource>
    {
        private readonly ArmClient _client;

        internal PetStoreOperationSource(ArmClient client)
        {
            _client = client;
        }

        PetStoreResource IOperationSource<PetStoreResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = PetStoreData.DeserializePetStoreData(document.RootElement);
            return new PetStoreResource(_client, data);
        }

        async ValueTask<PetStoreResource> IOperationSource<PetStoreResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = PetStoreData.DeserializePetStoreData(document.RootElement);
            return new PetStoreResource(_client, data);
        }
    }
}
