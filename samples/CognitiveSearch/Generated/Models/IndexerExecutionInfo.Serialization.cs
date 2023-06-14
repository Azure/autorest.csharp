// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class IndexerExecutionInfo
    {
        internal static IndexerExecutionInfo DeserializeIndexerExecutionInfo(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IndexerStatus status = default;
            Optional<IndexerExecutionResult> lastResult = default;
            IReadOnlyList<IndexerExecutionResult> executionHistory = default;
            IndexerLimits limits = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetString().ToIndexerStatus();
                    continue;
                }
                if (property.NameEquals("lastResult"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastResult = IndexerExecutionResult.DeserializeIndexerExecutionResult(property.Value);
                    continue;
                }
                if (property.NameEquals("executionHistory"u8))
                {
                    List<IndexerExecutionResult> array = new List<IndexerExecutionResult>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(IndexerExecutionResult.DeserializeIndexerExecutionResult(item));
                    }
                    executionHistory = array;
                    continue;
                }
                if (property.NameEquals("limits"u8))
                {
                    limits = IndexerLimits.DeserializeIndexerLimits(property.Value);
                    continue;
                }
            }
            return new IndexerExecutionInfo(status, lastResult.Value, executionHistory, limits);
        }
    }
}
