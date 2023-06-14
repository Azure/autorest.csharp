// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace MgmtMockAndSample
{
    internal class MgmtMockAndSamplePrivateEndpointConnectionOperationSource : IOperationSource<MgmtMockAndSamplePrivateEndpointConnectionResource>
    {
        private readonly ArmClient _client;

        internal MgmtMockAndSamplePrivateEndpointConnectionOperationSource(ArmClient client)
        {
            _client = client;
        }

        MgmtMockAndSamplePrivateEndpointConnectionResource IOperationSource<MgmtMockAndSamplePrivateEndpointConnectionResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = MgmtMockAndSamplePrivateEndpointConnectionData.DeserializeMgmtMockAndSamplePrivateEndpointConnectionData(document.RootElement);
            return new MgmtMockAndSamplePrivateEndpointConnectionResource(_client, data);
        }

        async ValueTask<MgmtMockAndSamplePrivateEndpointConnectionResource> IOperationSource<MgmtMockAndSamplePrivateEndpointConnectionResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = MgmtMockAndSamplePrivateEndpointConnectionData.DeserializeMgmtMockAndSamplePrivateEndpointConnectionData(document.RootElement);
            return new MgmtMockAndSamplePrivateEndpointConnectionResource(_client, data);
        }
    }
}
