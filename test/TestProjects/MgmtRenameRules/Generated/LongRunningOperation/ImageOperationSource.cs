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

namespace MgmtRenameRules
{
    internal class ImageOperationSource : IOperationSource<Image>
    {
        private readonly ArmClient _client;

        internal ImageOperationSource(ArmClient client)
        {
            _client = client;
        }

        Image IOperationSource<Image>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            try
            {
                using var document = JsonDocument.Parse(response.ContentStream);
                var data = ImageData.DeserializeImageData(document.RootElement);
                return new Image(_client, data);
            }
            finally
            {
                response.ContentStream.Position = 0;
            }
        }

        async ValueTask<Image> IOperationSource<Image>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            try
            {
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                var data = ImageData.DeserializeImageData(document.RootElement);
                return new Image(_client, data);
            }
            finally
            {
                response.ContentStream.Position = 0;
            }
        }
    }
}
