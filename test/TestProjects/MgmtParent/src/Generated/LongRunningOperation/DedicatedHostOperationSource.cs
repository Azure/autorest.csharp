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

namespace MgmtParent
{
    internal class DedicatedHostOperationSource : IOperationSource<DedicatedHostResource>
    {
        private readonly ArmClient _client;

        internal DedicatedHostOperationSource(ArmClient client)
        {
            _client = client;
        }

        DedicatedHostResource IOperationSource<DedicatedHostResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
            var data = DedicatedHostData.DeserializeDedicatedHostData(document.RootElement);
            return new DedicatedHostResource(_client, data);
        }

        async ValueTask<DedicatedHostResource> IOperationSource<DedicatedHostResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
            var data = DedicatedHostData.DeserializeDedicatedHostData(document.RootElement);
            return new DedicatedHostResource(_client, data);
        }
    }
}
