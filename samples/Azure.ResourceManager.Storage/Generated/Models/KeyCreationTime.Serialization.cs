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
    public partial class KeyCreationTime : IUtf8JsonSerializable, IModelJsonSerializable<KeyCreationTime>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<KeyCreationTime>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<KeyCreationTime>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Key1))
            {
                writer.WritePropertyName("key1"u8);
                writer.WriteStringValue(Key1.Value, "O");
            }
            if (Optional.IsDefined(Key2))
            {
                writer.WritePropertyName("key2"u8);
                writer.WriteStringValue(Key2.Value, "O");
            }
            writer.WriteEndObject();
        }

        KeyCreationTime IModelJsonSerializable<KeyCreationTime>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeKeyCreationTime(doc.RootElement, options);
        }

        BinaryData IModelSerializable<KeyCreationTime>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        KeyCreationTime IModelSerializable<KeyCreationTime>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeKeyCreationTime(document.RootElement, options);
        }

        internal static KeyCreationTime DeserializeKeyCreationTime(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<DateTimeOffset> key1 = default;
            Optional<DateTimeOffset> key2 = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("key1"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    key1 = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("key2"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    key2 = property.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new KeyCreationTime(Optional.ToNullable(key1), Optional.ToNullable(key2));
        }
    }
}
