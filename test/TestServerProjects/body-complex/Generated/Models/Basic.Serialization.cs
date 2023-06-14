// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class Basic : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
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

        internal static Basic DeserializeBasic(JsonElement element)
        {
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
