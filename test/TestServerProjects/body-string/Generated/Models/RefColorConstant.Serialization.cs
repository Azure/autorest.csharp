// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace body_string.Models
{
    public partial class RefColorConstant : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("ColorConstant"u8);
            writer.WriteStringValue(ColorConstant.ToString());
            if (Optional.IsDefined(Field1))
            {
                writer.WritePropertyName("field1"u8);
                writer.WriteStringValue(Field1);
            }
            writer.WriteEndObject();
        }

        internal static RefColorConstant DeserializeRefColorConstant(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ColorConstant colorConstant = default;
            Optional<string> field1 = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ColorConstant"u8))
                {
                    colorConstant = new ColorConstant(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("field1"u8))
                {
                    field1 = property.Value.GetString();
                    continue;
                }
            }
            return new RefColorConstant(colorConstant, field1.Value);
        }
    }
}
