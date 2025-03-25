// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace _Azure.ResourceManager.Resources
{
    internal class TopLevelTrackedResourceOperationSource : IOperationSource<TopLevelTrackedResource>
    {
        private readonly ArmClient _client;

        internal TopLevelTrackedResourceOperationSource(ArmClient client)
        {
            _client = client;
        }

        TopLevelTrackedResource IOperationSource<TopLevelTrackedResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<TopLevelTrackedResourceData>(response.Content);
            return new TopLevelTrackedResource(_client, data);
        }

        async ValueTask<TopLevelTrackedResource> IOperationSource<TopLevelTrackedResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<TopLevelTrackedResourceData>(response.Content);
            return await Task.FromResult(new TopLevelTrackedResource(_client, data)).ConfigureAwait(false);
        }
    }
}
