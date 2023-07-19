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
    public partial class BooleanWrapper : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(FieldTrue))
            {
                writer.WritePropertyName("field_true"u8);
                writer.WriteBooleanValue(FieldTrue.Value);
            }
            if (Optional.IsDefined(FieldFalse))
            {
                writer.WritePropertyName("field_false"u8);
                writer.WriteBooleanValue(FieldFalse.Value);
            }
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeBooleanWrapper(doc.RootElement, options);
        }

        internal static BooleanWrapper DeserializeBooleanWrapper(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> fieldTrue = default;
            Optional<bool> fieldFalse = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field_true"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    fieldTrue = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("field_false"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    fieldFalse = property.Value.GetBoolean();
                    continue;
                }
            }
            return new BooleanWrapper(Optional.ToNullable(fieldTrue), Optional.ToNullable(fieldFalse));
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeBooleanWrapper(doc.RootElement, options);
        }
    }
}
