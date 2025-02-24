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

namespace _Azure.ResourceManager.Resources
{
    internal class SingletonTrackedResourceOperationSource : IOperationSource<SingletonTrackedResource>
    {
        private readonly ArmClient _client;

        internal SingletonTrackedResourceOperationSource(ArmClient client)
        {
            _client = client;
        }

        SingletonTrackedResource IOperationSource<SingletonTrackedResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = SingletonTrackedResourceData.DeserializeSingletonTrackedResourceData(document.RootElement);
            return new SingletonTrackedResource(_client, data);
        }

        async ValueTask<SingletonTrackedResource> IOperationSource<SingletonTrackedResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = SingletonTrackedResourceData.DeserializeSingletonTrackedResourceData(document.RootElement);
            return new SingletonTrackedResource(_client, data);
        }
    }
}
