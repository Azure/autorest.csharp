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
    public partial class FloatWrapper : IUtf8JsonSerializable, IModelJsonSerializable<FloatWrapper>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<FloatWrapper>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<FloatWrapper>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Field1))
            {
                writer.WritePropertyName("field1"u8);
                writer.WriteNumberValue(Field1.Value);
            }
            if (Optional.IsDefined(Field2))
            {
                writer.WritePropertyName("field2"u8);
                writer.WriteNumberValue(Field2.Value);
            }
            writer.WriteEndObject();
        }

        FloatWrapper IModelJsonSerializable<FloatWrapper>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFloatWrapper(document.RootElement, options);
        }

        BinaryData IModelSerializable<FloatWrapper>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        FloatWrapper IModelSerializable<FloatWrapper>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeFloatWrapper(document.RootElement, options);
        }

        internal static FloatWrapper DeserializeFloatWrapper(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<float> field1 = default;
            Optional<float> field2 = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field1"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    field1 = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("field2"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    field2 = property.Value.GetSingle();
                    continue;
                }
            }
            return new FloatWrapper(Optional.ToNullable(field1), Optional.ToNullable(field2));
        }
    }
}
