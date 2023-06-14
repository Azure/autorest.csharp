// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class BooleanWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
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

        internal static BooleanWrapper DeserializeBooleanWrapper(JsonElement element)
        {
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
    }
}
