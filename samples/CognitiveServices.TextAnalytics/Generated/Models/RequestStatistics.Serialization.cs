// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class RequestStatistics : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("documentsCount"u8);
            writer.WriteNumberValue(DocumentsCount);
            writer.WritePropertyName("validDocumentsCount"u8);
            writer.WriteNumberValue(ValidDocumentsCount);
            writer.WritePropertyName("erroneousDocumentsCount"u8);
            writer.WriteNumberValue(ErroneousDocumentsCount);
            writer.WritePropertyName("transactionsCount"u8);
            writer.WriteNumberValue(TransactionsCount);
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeRequestStatistics(doc.RootElement, options);
        }

        internal static RequestStatistics DeserializeRequestStatistics(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int documentsCount = default;
            int validDocumentsCount = default;
            int erroneousDocumentsCount = default;
            long transactionsCount = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("documentsCount"u8))
                {
                    documentsCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("validDocumentsCount"u8))
                {
                    validDocumentsCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("erroneousDocumentsCount"u8))
                {
                    erroneousDocumentsCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("transactionsCount"u8))
                {
                    transactionsCount = property.Value.GetInt64();
                    continue;
                }
            }
            return new RequestStatistics(documentsCount, validDocumentsCount, erroneousDocumentsCount, transactionsCount);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeRequestStatistics(doc.RootElement, options);
        }
    }
}
