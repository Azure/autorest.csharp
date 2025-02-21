// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using AzureSample.ResourceManager.Storage.Models;

namespace AzureSample.ResourceManager.Storage
{
    internal class BlobRestoreStatusOperationSource : IOperationSource<BlobRestoreStatus>
    {
        BlobRestoreStatus IOperationSource<BlobRestoreStatus>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
            return BlobRestoreStatus.DeserializeBlobRestoreStatus(document.RootElement);
        }

        async ValueTask<BlobRestoreStatus> IOperationSource<BlobRestoreStatus>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
            return BlobRestoreStatus.DeserializeBlobRestoreStatus(document.RootElement);
        }
    }
}
