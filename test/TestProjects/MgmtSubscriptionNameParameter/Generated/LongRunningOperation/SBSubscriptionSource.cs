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

namespace MgmtSubscriptionNameParameter
{
    internal class SBSubscriptionSource : IOperationSource<SBSubscription>
    {
        private readonly ArmClient _client;

        internal SBSubscriptionSource(ArmClient client)
        {
            _client = client;
        }

        SBSubscription IOperationSource<SBSubscription>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = SBSubscriptionData.DeserializeSBSubscriptionData(document.RootElement);
            return new SBSubscription(_client, data);
        }

        async ValueTask<SBSubscription> IOperationSource<SBSubscription>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = SBSubscriptionData.DeserializeSBSubscriptionData(document.RootElement);
            return new SBSubscription(_client, data);
        }
    }
}
