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

namespace MgmtAcronymMapping
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
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = ImageData.DeserializeImageData(document.RootElement);
            return new ImageResource(_client, data);
        }

        async ValueTask<ImageResource> IOperationSource<ImageResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = ImageData.DeserializeImageData(document.RootElement);
            return new ImageResource(_client, data);
        }
    }
}