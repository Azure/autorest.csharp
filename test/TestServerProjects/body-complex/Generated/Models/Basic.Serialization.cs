// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace body_complex.Models
{
    public partial class Basic : IUtf8JsonSerializable, IModelJsonSerializable<Basic>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<Basic>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<Basic>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Id))
            {
                if (Id != null)
                {
                    writer.WritePropertyName("id"u8);
                    writer.WriteNumberValue(Id.Value);
                }
                else
                {
                    writer.WriteNull("id");
                }
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Color))
            {
                writer.WritePropertyName("color"u8);
                writer.WriteStringValue(Color.Value.ToString());
            }
            writer.WriteEndObject();
        }

        Basic IModelJsonSerializable<Basic>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeBasic(doc.RootElement, options);
        }

        BinaryData IModelSerializable<Basic>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        Basic IModelSerializable<Basic>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeBasic(document.RootElement, options);
        }

        internal static Basic DeserializeBasic(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int?> id = default;
            Optional<string> name = default;
            Optional<CMYKColors> color = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        id = null;
                        continue;
                    }
                    id = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("color"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    color = new CMYKColors(property.Value.GetString());
                    continue;
                }
            }
            return new Basic(Optional.ToNullable(id), name.Value, Optional.ToNullable(color));
        }
    }
}
