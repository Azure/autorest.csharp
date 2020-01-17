// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class DocumentKeyPhrases : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);
            writer.WritePropertyName("keyPhrases");
            writer.WriteStartArray();
            foreach (var item in KeyPhrases)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            if (Statistics != null)
            {
                writer.WritePropertyName("statistics");
                writer.WriteObjectValue(Statistics);
            }
            writer.WriteEndObject();
        }
        internal static DocumentKeyPhrases DeserializeDocumentKeyPhrases(JsonElement element)
        {
            DocumentKeyPhrases result = new DocumentKeyPhrases();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    result.Id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("keyPhrases"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.KeyPhrases.Add(item.GetString());
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
