// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class IndexerExecutionInfo : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Status != null)
            {
                writer.WritePropertyName("status");
                writer.WriteStringValue(Status.Value.ToSerialString());
            }
            if (LastResult != null)
            {
                writer.WritePropertyName("lastResult");
                writer.WriteObjectValue(LastResult);
            }
            if (ExecutionHistory != null)
            {
                writer.WritePropertyName("executionHistory");
                writer.WriteStartArray();
                foreach (var item in ExecutionHistory)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Limits != null)
            {
                writer.WritePropertyName("limits");
                writer.WriteObjectValue(Limits);
            }
            writer.WriteEndObject();
        }
        internal static IndexerExecutionInfo DeserializeIndexerExecutionInfo(JsonElement element)
        {
            IndexerExecutionInfo result = new IndexerExecutionInfo();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Status = property.Value.GetString().ToIndexerStatus();
                    continue;
                }
                if (property.NameEquals("lastResult"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.LastResult = IndexerExecutionResult.DeserializeIndexerExecutionResult(property.Value);
                    continue;
                }
                if (property.NameEquals("executionHistory"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ExecutionHistory = new List<IndexerExecutionResult>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.ExecutionHistory.Add(IndexerExecutionResult.DeserializeIndexerExecutionResult(item));
                    }
                    continue;
                }
                if (property.NameEquals("limits"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Limits = IndexerLimits.DeserializeIndexerLimits(property.Value);
                    continue;
                }
            }
            return result;
        }
    }
}
