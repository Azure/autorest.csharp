// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class DocumentLanguage : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);
            writer.WritePropertyName("detectedLanguages");
            writer.WriteStartArray();
            foreach (var item in DetectedLanguages)
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
        internal static DocumentLanguage DeserializeDocumentLanguage(JsonElement element)
        {
            DocumentLanguage result = new DocumentLanguage();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    result.Id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("detectedLanguages"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.DetectedLanguages.Add(DetectedLanguage.DeserializeDetectedLanguage(item));
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
