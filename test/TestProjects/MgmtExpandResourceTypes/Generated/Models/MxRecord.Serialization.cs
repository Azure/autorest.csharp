// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtExpandResourceTypes.Models
{
    public partial class MxRecord : IUtf8JsonSerializable, IModelJsonSerializable<MxRecord>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<MxRecord>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<MxRecord>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Preference))
            {
                writer.WritePropertyName("preference"u8);
                writer.WriteNumberValue(Preference.Value);
            }
            if (Optional.IsDefined(Exchange))
            {
                writer.WritePropertyName("exchange"u8);
                writer.WriteStringValue(Exchange);
            }
            writer.WriteEndObject();
        }

        MxRecord IModelJsonSerializable<MxRecord>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeMxRecord(doc.RootElement, options);
        }

        BinaryData IModelSerializable<MxRecord>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        MxRecord IModelSerializable<MxRecord>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeMxRecord(document.RootElement, options);
        }

        internal static MxRecord DeserializeMxRecord(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> preference = default;
            Optional<string> exchange = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("preference"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    preference = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("exchange"u8))
                {
                    exchange = property.Value.GetString();
                    continue;
                }
            }
            return new MxRecord(Optional.ToNullable(preference), exchange.Value);
        }
    }
}
