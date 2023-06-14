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
    internal class FirewallPolicyOperationSource : IOperationSource<FirewallPolicyResource>
    {
        private readonly ArmClient _client;

        internal FirewallPolicyOperationSource(ArmClient client)
        {
            _client = client;
        }

        FirewallPolicyResource IOperationSource<FirewallPolicyResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = FirewallPolicyData.DeserializeFirewallPolicyData(document.RootElement);
            return new FirewallPolicyResource(_client, data);
        }

        async ValueTask<FirewallPolicyResource> IOperationSource<FirewallPolicyResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = FirewallPolicyData.DeserializeFirewallPolicyData(document.RootElement);
            return new FirewallPolicyResource(_client, data);
        }
    }
}
