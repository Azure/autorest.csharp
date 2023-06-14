// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using MgmtScopeResource.Models;

namespace MgmtScopeResource
{
    internal class WhatIfOperationResultOperationSource : IOperationSource<WhatIfOperationResult>
    {
        WhatIfOperationResult IOperationSource<WhatIfOperationResult>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return WhatIfOperationResult.DeserializeWhatIfOperationResult(document.RootElement);
        }

        async ValueTask<WhatIfOperationResult> IOperationSource<WhatIfOperationResult>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return WhatIfOperationResult.DeserializeWhatIfOperationResult(document.RootElement);
        }
    }
}
