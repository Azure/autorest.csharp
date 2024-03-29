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

namespace MgmtDiscriminator
{
    internal class DeliveryRuleOperationSource : IOperationSource<DeliveryRuleResource>
    {
        private readonly ArmClient _client;

        internal DeliveryRuleOperationSource(ArmClient client)
        {
            _client = client;
        }

        DeliveryRuleResource IOperationSource<DeliveryRuleResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = DeliveryRuleData.DeserializeDeliveryRuleData(document.RootElement);
            return new DeliveryRuleResource(_client, data);
        }

        async ValueTask<DeliveryRuleResource> IOperationSource<DeliveryRuleResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = DeliveryRuleData.DeserializeDeliveryRuleData(document.RootElement);
            return new DeliveryRuleResource(_client, data);
        }
    }
}
