// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class DocumentLinkedEntities : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);
            writer.WritePropertyName("entities");
            writer.WriteStartArray();
            foreach (var item in Entities)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (Statistics != null)
            {
                writer.WritePropertyName("statistics");
                writer.WriteObjectValue(Statistics);
            }
            writer.WriteEndObject();
        }
        internal static DocumentLinkedEntities DeserializeDocumentLinkedEntities(JsonElement element)
        {
            DocumentLinkedEntities result = new DocumentLinkedEntities();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    result.Id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("entities"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Entities.Add(LinkedEntity.DeserializeLinkedEntity(item));
                    }
                    continue;
                }
                if (property.NameEquals("statistics"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Statistics = DocumentStatistics.DeserializeDocumentStatistics(property.Value);
                    continue;
                }
            }
            return result;
        }
    }
}
