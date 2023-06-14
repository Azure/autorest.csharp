// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class StringWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
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

        internal static StringWrapper DeserializeStringWrapper(JsonElement element)
        {
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
