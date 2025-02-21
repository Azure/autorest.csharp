// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using MgmtTypeSpec.Models;

namespace MgmtTypeSpec
{
    internal class OperationStatusResultOperationSource : IOperationSource<OperationStatusResult>
    {
        OperationStatusResult IOperationSource<OperationStatusResult>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
            return OperationStatusResult.DeserializeOperationStatusResult(document.RootElement);
        }

        async ValueTask<OperationStatusResult> IOperationSource<OperationStatusResult>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
            return OperationStatusResult.DeserializeOperationStatusResult(document.RootElement);
        }
    }
}
