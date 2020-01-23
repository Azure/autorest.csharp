// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class IndexerLimits : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (MaxRunTime != null)
            {
                writer.WritePropertyName("maxRunTime");
                writer.WriteStringValue(MaxRunTime.Value, "P");
            }
            if (MaxDocumentExtractionSize != null)
            {
                writer.WritePropertyName("maxDocumentExtractionSize");
                writer.WriteNumberValue(MaxDocumentExtractionSize.Value);
            }
            if (MaxDocumentContentCharactersToExtract != null)
            {
                writer.WritePropertyName("maxDocumentContentCharactersToExtract");
                writer.WriteNumberValue(MaxDocumentContentCharactersToExtract.Value);
            }
            writer.WriteEndObject();
        }
        internal static IndexerLimits DeserializeIndexerLimits(JsonElement element)
        {
            IndexerLimits result = new IndexerLimits();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("maxRunTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.MaxRunTime = property.Value.GetTimeSpan("P");
                    continue;
                }
                if (property.NameEquals("maxDocumentExtractionSize"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.MaxDocumentExtractionSize = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("maxDocumentContentCharactersToExtract"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.MaxDocumentContentCharactersToExtract = property.Value.GetInt64();
                    continue;
                }
            }
            return result;
        }
    }
}
