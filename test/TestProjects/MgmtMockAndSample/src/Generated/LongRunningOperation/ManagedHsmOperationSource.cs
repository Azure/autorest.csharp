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
    internal class ManagedHsmOperationSource : IOperationSource<ManagedHsmResource>
    {
        private readonly ArmClient _client;

        internal ManagedHsmOperationSource(ArmClient client)
        {
            _client = client;
        }

        ManagedHsmResource IOperationSource<ManagedHsmResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = ManagedHsmData.DeserializeManagedHsmData(document.RootElement);
            return new ManagedHsmResource(_client, data);
        }

        async ValueTask<ManagedHsmResource> IOperationSource<ManagedHsmResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = ManagedHsmData.DeserializeManagedHsmData(document.RootElement);
            return new ManagedHsmResource(_client, data);
        }
    }
}
