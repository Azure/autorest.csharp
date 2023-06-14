// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace body_dictionary.Models
{
    public partial class Widget : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Integer))
            {
                writer.WritePropertyName("integer"u8);
                writer.WriteNumberValue(Integer.Value);
            }
            if (Optional.IsDefined(String))
            {
                writer.WritePropertyName("string"u8);
                writer.WriteStringValue(String);
            }
            writer.WriteEndObject();
        }

        internal static Widget DeserializeWidget(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> integer = default;
            Optional<string> @string = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("integer"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    integer = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("string"u8))
                {
                    @string = property.Value.GetString();
                    continue;
                }
            }
            return new Widget(Optional.ToNullable(integer), @string.Value);
        }
    }
}
