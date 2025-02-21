// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using MgmtAcronymMapping.Models;

namespace MgmtAcronymMapping
{
    internal class LogAnalyticsOperationSource : IOperationSource<LogAnalytics>
    {
        LogAnalytics IOperationSource<LogAnalytics>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 });
            return LogAnalytics.DeserializeLogAnalytics(document.RootElement);
        }

        async ValueTask<LogAnalytics> IOperationSource<LogAnalytics>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }, cancellationToken).ConfigureAwait(false);
            return LogAnalytics.DeserializeLogAnalytics(document.RootElement);
        }
    }
}
