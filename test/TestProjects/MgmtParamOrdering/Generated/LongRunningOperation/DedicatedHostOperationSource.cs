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

namespace MgmtParamOrdering
{
    internal class DedicatedHostOperationSource : IOperationSource<DedicatedHost>
    {
        private readonly ArmClient _client;

        internal DedicatedHostOperationSource(ArmClient client)
        {
            _client = client;
        }

        DedicatedHost IOperationSource<DedicatedHost>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            try
            {
                using var document = JsonDocument.Parse(response.ContentStream);
                var data = DedicatedHostData.DeserializeDedicatedHostData(document.RootElement);
                return new DedicatedHost(_client, data);
            }
            finally
            {
                response.ContentStream.Position = 0;
            }
        }

        async ValueTask<DedicatedHost> IOperationSource<DedicatedHost>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            try
            {
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                var data = DedicatedHostData.DeserializeDedicatedHostData(document.RootElement);
                return new DedicatedHost(_client, data);
            }
            finally
            {
                response.ContentStream.Position = 0;
            }
        }
    }
}
