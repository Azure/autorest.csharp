// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using MgmtRenameRules.Models;

namespace MgmtRenameRules
{
    internal class LogAnalyticsOperationSource : IOperationSource<LogAnalytics>
    {
        LogAnalytics IOperationSource<LogAnalytics>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return LogAnalytics.DeserializeLogAnalytics(document.RootElement);
        }

        async ValueTask<LogAnalytics> IOperationSource<LogAnalytics>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return LogAnalytics.DeserializeLogAnalytics(document.RootElement);
        }
    }
}
