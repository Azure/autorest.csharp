// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace required_optional.Models
{
    public partial class ClassOptionalWrapper : IUtf8JsonSerializable, IModelJsonSerializable<ClassOptionalWrapper>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ClassOptionalWrapper>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ClassOptionalWrapper>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Value))
            {
                writer.WritePropertyName("value"u8);
                writer.WriteObjectValue(Value);
            }
            writer.WriteEndObject();
        }

        ClassOptionalWrapper IModelJsonSerializable<ClassOptionalWrapper>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeClassOptionalWrapper(document.RootElement, options);
        }

        BinaryData IModelSerializable<ClassOptionalWrapper>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        ClassOptionalWrapper IModelSerializable<ClassOptionalWrapper>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeClassOptionalWrapper(document.RootElement, options);
        }

        internal static ClassOptionalWrapper DeserializeClassOptionalWrapper(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<Product> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    value = Product.DeserializeProduct(property.Value);
                    continue;
                }
            }
            return new ClassOptionalWrapper(value.Value);
        }
    }
}
