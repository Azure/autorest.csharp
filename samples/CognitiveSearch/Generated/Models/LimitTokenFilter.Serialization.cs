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
    public partial class LimitTokenFilter : IUtf8JsonSerializable, IModelJsonSerializable<LimitTokenFilter>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<LimitTokenFilter>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<LimitTokenFilter>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(MaxTokenCount))
            {
                writer.WritePropertyName("maxTokenCount"u8);
                writer.WriteNumberValue(MaxTokenCount.Value);
            }
            if (Optional.IsDefined(ConsumeAllTokens))
            {
                writer.WritePropertyName("consumeAllTokens"u8);
                writer.WriteBooleanValue(ConsumeAllTokens.Value);
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        LimitTokenFilter IModelJsonSerializable<LimitTokenFilter>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeLimitTokenFilter(document.RootElement, options);
        }

        BinaryData IModelSerializable<LimitTokenFilter>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        LimitTokenFilter IModelSerializable<LimitTokenFilter>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeLimitTokenFilter(document.RootElement, options);
        }

        internal static LimitTokenFilter DeserializeLimitTokenFilter(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> maxTokenCount = default;
            Optional<bool> consumeAllTokens = default;
            string odataType = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("maxTokenCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxTokenCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("consumeAllTokens"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    consumeAllTokens = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
            }
            return new LimitTokenFilter(odataType, name, Optional.ToNullable(maxTokenCount), Optional.ToNullable(consumeAllTokens));
        }
    }
}
