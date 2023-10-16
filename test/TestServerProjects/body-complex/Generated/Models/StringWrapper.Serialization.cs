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
    public partial class StringWrapper : IUtf8JsonSerializable, IModelJsonSerializable<StringWrapper>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<StringWrapper>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<StringWrapper>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Field))
            {
                writer.WritePropertyName("field"u8);
                writer.WriteStringValue(Field);
            }
            if (Optional.IsDefined(Empty))
            {
                writer.WritePropertyName("empty"u8);
                writer.WriteStringValue(Empty);
            }
            if (Optional.IsDefined(NullProperty))
            {
                writer.WritePropertyName("null"u8);
                writer.WriteStringValue(NullProperty);
            }
            writer.WriteEndObject();
        }

        StringWrapper IModelJsonSerializable<StringWrapper>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeStringWrapper(doc.RootElement, options);
        }

        BinaryData IModelSerializable<StringWrapper>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        StringWrapper IModelSerializable<StringWrapper>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeStringWrapper(document.RootElement, options);
        }

        internal static StringWrapper DeserializeStringWrapper(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> field = default;
            Optional<string> empty = default;
            Optional<string> @null = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"u8))
                {
                    field = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("empty"u8))
                {
                    empty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("null"u8))
                {
                    @null = property.Value.GetString();
                    continue;
                }
            }
            return new StringWrapper(field.Value, empty.Value, @null.Value);
        }
    }
}
