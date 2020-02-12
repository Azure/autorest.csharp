// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class SentimentResponse : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("documents");
            writer.WriteStartArray();
            foreach (var item in Documents)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("errors");
            writer.WriteStartArray();
            foreach (var item0 in Errors)
            {
                writer.WriteObjectValue(item0);
            }
            writer.WriteEndArray();
            if (Statistics != null)
            {
                writer.WritePropertyName("statistics");
                writer.WriteObjectValue(Statistics);
            }
            writer.WritePropertyName("modelVersion");
            writer.WriteStringValue(ModelVersion);
            writer.WriteEndObject();
        }
        internal static SentimentResponse DeserializeSentimentResponse(JsonElement element)
        {
            SentimentResponse result = new SentimentResponse();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("documents"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Documents.Add(DocumentSentiment.DeserializeDocumentSentiment(item));
                    }
                    continue;
                }
                if (property.NameEquals("errors"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Errors.Add(DocumentError.DeserializeDocumentError(item));
                    }
                    continue;
                }
                if (property.NameEquals("statistics"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Statistics = RequestStatistics.DeserializeRequestStatistics(property.Value);
                    continue;
                }
                if (property.NameEquals("modelVersion"))
                {
                    result.ModelVersion = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
