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

namespace AzureSample.ResourceManager.Sample
{
    internal class ImageOperationSource : IOperationSource<ImageResource>
    {
        private readonly ArmClient _client;

        internal ImageOperationSource(ArmClient client)
        {
            _client = client;
        }

        ImageResource IOperationSource<ImageResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<ImageData>(response.Content, ModelReaderWriterOptions.Json, AzureSampleResourceManagerSampleContext.Default);
            return new ImageResource(_client, data);
        }

        async ValueTask<ImageResource> IOperationSource<ImageResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            var data = ModelReaderWriter.Read<ImageData>(response.Content, ModelReaderWriterOptions.Json, AzureSampleResourceManagerSampleContext.Default);
            return await Task.FromResult(new ImageResource(_client, data)).ConfigureAwait(false);
        }
    }
}
