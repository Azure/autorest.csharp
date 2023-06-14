// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    internal class BlobRestoreStatusOperationSource : IOperationSource<BlobRestoreStatus>
    {
        BlobRestoreStatus IOperationSource<BlobRestoreStatus>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return BlobRestoreStatus.DeserializeBlobRestoreStatus(document.RootElement);
        }

        async ValueTask<BlobRestoreStatus> IOperationSource<BlobRestoreStatus>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return BlobRestoreStatus.DeserializeBlobRestoreStatus(document.RootElement);
        }
    }
}
