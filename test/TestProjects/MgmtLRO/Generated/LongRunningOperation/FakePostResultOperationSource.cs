// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using MgmtLRO.Models;

namespace MgmtLRO
{
    internal class FakePostResultOperationSource : IOperationSource<FakePostResult>
    {
        FakePostResult IOperationSource<FakePostResult>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return FakePostResult.DeserializeFakePostResult(document.RootElement);
        }

        async ValueTask<FakePostResult> IOperationSource<FakePostResult>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return FakePostResult.DeserializeFakePostResult(document.RootElement);
        }
    }
}
