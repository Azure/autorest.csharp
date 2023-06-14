// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace MgmtListMethods
{
    internal class TenantTestOperationSource : IOperationSource<TenantTestResource>
    {
        private readonly ArmClient _client;

        internal TenantTestOperationSource(ArmClient client)
        {
            _client = client;
        }

        TenantTestResource IOperationSource<TenantTestResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = TenantTestData.DeserializeTenantTestData(document.RootElement);
            return new TenantTestResource(_client, data);
        }

        async ValueTask<TenantTestResource> IOperationSource<TenantTestResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = TenantTestData.DeserializeTenantTestData(document.RootElement);
            return new TenantTestResource(_client, data);
        }
    }
}
