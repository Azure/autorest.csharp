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

namespace _Azure.ResourceManager.Resources
{
    internal class NestedProxyResourceOperationSource : IOperationSource<NestedProxyResource>
    {
        private readonly ArmClient _client;

        internal NestedProxyResourceOperationSource(ArmClient client)
        {
            _client = client;
        }

        NestedProxyResource IOperationSource<NestedProxyResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
            var data = NestedProxyResourceData.DeserializeNestedProxyResourceData(document.RootElement);
            return new NestedProxyResource(_client, data);
        }

        async ValueTask<NestedProxyResource> IOperationSource<NestedProxyResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
            var data = NestedProxyResourceData.DeserializeNestedProxyResourceData(document.RootElement);
            return new NestedProxyResource(_client, data);
        }
    }
}
