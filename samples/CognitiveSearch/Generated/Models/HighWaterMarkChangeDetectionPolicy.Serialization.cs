// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveSearch.Models
{
    public partial class HighWaterMarkChangeDetectionPolicy : IUtf8JsonSerializable, IModelJsonSerializable<HighWaterMarkChangeDetectionPolicy>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<HighWaterMarkChangeDetectionPolicy>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<HighWaterMarkChangeDetectionPolicy>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("highWaterMarkColumnName"u8);
            writer.WriteStringValue(HighWaterMarkColumnName);
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WriteEndObject();
        }

        HighWaterMarkChangeDetectionPolicy IModelJsonSerializable<HighWaterMarkChangeDetectionPolicy>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeHighWaterMarkChangeDetectionPolicy(document.RootElement, options);
        }

        BinaryData IModelSerializable<HighWaterMarkChangeDetectionPolicy>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        HighWaterMarkChangeDetectionPolicy IModelSerializable<HighWaterMarkChangeDetectionPolicy>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeHighWaterMarkChangeDetectionPolicy(document.RootElement, options);
        }

        internal static HighWaterMarkChangeDetectionPolicy DeserializeHighWaterMarkChangeDetectionPolicy(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string highWaterMarkColumnName = default;
            string odataType = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("highWaterMarkColumnName"u8))
                {
                    highWaterMarkColumnName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
            }
            return new HighWaterMarkChangeDetectionPolicy(odataType, highWaterMarkColumnName);
        }
    }
}
