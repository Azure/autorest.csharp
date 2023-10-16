// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Storage.Models
{
    internal partial class KeyPolicy : IUtf8JsonSerializable, IModelJsonSerializable<KeyPolicy>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<KeyPolicy>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<KeyPolicy>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("keyExpirationPeriodInDays"u8);
            writer.WriteNumberValue(KeyExpirationPeriodInDays);
            writer.WriteEndObject();
        }

        KeyPolicy IModelJsonSerializable<KeyPolicy>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeKeyPolicy(doc.RootElement, options);
        }

        BinaryData IModelSerializable<KeyPolicy>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        KeyPolicy IModelSerializable<KeyPolicy>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeKeyPolicy(document.RootElement, options);
        }

        internal static KeyPolicy DeserializeKeyPolicy(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int keyExpirationPeriodInDays = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("keyExpirationPeriodInDays"u8))
                {
                    keyExpirationPeriodInDays = property.Value.GetInt32();
                    continue;
                }
            }
            return new KeyPolicy(keyExpirationPeriodInDays);
        }
    }
}
