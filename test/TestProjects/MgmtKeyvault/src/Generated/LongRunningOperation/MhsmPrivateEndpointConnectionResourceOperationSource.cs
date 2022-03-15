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

namespace MgmtKeyvault
{
    internal class MhsmPrivateEndpointConnectionResourceOperationSource : IOperationSource<MhsmPrivateEndpointConnectionResource>
    {
        private readonly ArmClient _client;

        internal MhsmPrivateEndpointConnectionResourceOperationSource(ArmClient client)
        {
            _client = client;
        }

        MhsmPrivateEndpointConnectionResource IOperationSource<MhsmPrivateEndpointConnectionResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = MhsmPrivateEndpointConnectionResourceData.DeserializeMhsmPrivateEndpointConnectionResourceData(document.RootElement);
            return new MhsmPrivateEndpointConnectionResource(_client, data);
        }

        async ValueTask<MhsmPrivateEndpointConnectionResource> IOperationSource<MhsmPrivateEndpointConnectionResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = MhsmPrivateEndpointConnectionResourceData.DeserializeMhsmPrivateEndpointConnectionResourceData(document.RootElement);
            return new MhsmPrivateEndpointConnectionResource(_client, data);
        }
    }
}
