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

namespace MgmtListMethods
{
    internal class TenantTestResourceOperationSource : IOperationSource<TenantTestResource>
    {
        private readonly ArmClient _client;

        internal TenantTestResourceOperationSource(ArmClient client)
        {
            _client = client;
        }

        TenantTestResource IOperationSource<TenantTestResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = TenantTestResourceData.DeserializeTenantTestResourceData(document.RootElement);
            return new TenantTestResource(_client, data);
        }

        async ValueTask<TenantTestResource> IOperationSource<TenantTestResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = TenantTestResourceData.DeserializeTenantTestResourceData(document.RootElement);
            return new TenantTestResource(_client, data);
        }
    }
}
