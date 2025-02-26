// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
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
            var data = ModelReaderWriter.Read<SingletonTrackedResourceData>(new BinaryData(response.ContentStream));
            return new SingletonTrackedResource(_client, data);
        }

        async ValueTask<SingletonTrackedResource> IOperationSource<SingletonTrackedResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<SingletonTrackedResourceData>(new BinaryData(response.ContentStream));
            return await Task.FromResult(new SingletonTrackedResource(_client, data)).ConfigureAwait(false);
        }
    }
}
