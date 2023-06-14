// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace MgmtNonStringPathVariable
{
    internal class BarOperationSource : IOperationSource<BarResource>
    {
        private readonly ArmClient _client;

        internal BarOperationSource(ArmClient client)
        {
            _client = client;
        }

        BarResource IOperationSource<BarResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = BarData.DeserializeBarData(document.RootElement);
            return new BarResource(_client, data);
        }

        async ValueTask<BarResource> IOperationSource<BarResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = BarData.DeserializeBarData(document.RootElement);
            return new BarResource(_client, data);
        }
    }
}
