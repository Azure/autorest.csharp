// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class DocumentKeyPhrases : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            writer.WritePropertyName("keyPhrases"u8);
            writer.WriteStartArray();
            foreach (var item in KeyPhrases)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("warnings"u8);
            writer.WriteStartArray();
            foreach (var item in Warnings)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(Statistics))
            {
                writer.WritePropertyName("statistics"u8);
                writer.WriteObjectValue(Statistics);
            }
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeDocumentKeyPhrases(doc.RootElement, options);
        }

        internal static DocumentKeyPhrases DeserializeDocumentKeyPhrases(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            IReadOnlyList<string> keyPhrases = default;
            IReadOnlyList<TextAnalyticsWarning> warnings = default;
            Optional<DocumentStatistics> statistics = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("keyPhrases"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    keyPhrases = array;
                    continue;
                }
                if (property.NameEquals("warnings"u8))
                {
                    List<TextAnalyticsWarning> array = new List<TextAnalyticsWarning>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TextAnalyticsWarning.DeserializeTextAnalyticsWarning(item));
                    }
                    warnings = array;
                    continue;
                }
                if (property.NameEquals("statistics"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    statistics = DocumentStatistics.DeserializeDocumentStatistics(property.Value);
                    continue;
                }
            }
            return new DocumentKeyPhrases(id, keyPhrases, warnings, statistics.Value);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDocumentKeyPhrases(doc.RootElement, options);
        }
    }
}
