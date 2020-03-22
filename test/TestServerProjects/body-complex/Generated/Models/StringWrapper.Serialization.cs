// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
            if (Field != null)
            {
                writer.WritePropertyName("field");
                writer.WriteStringValue(Field);
            }
            if (Empty != null)
            {
                writer.WritePropertyName("empty");
                writer.WriteStringValue(Empty);
            }
            if (NullProperty != null)
            {
                writer.WritePropertyName("null");
                writer.WriteStringValue(NullProperty);
            }
            writer.WriteEndObject();
        }

        internal static StringWrapper DeserializeStringWrapper(JsonElement element)
        {
            string field = default;
            string empty = default;
            string @null = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    field = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("empty"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    empty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("null"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    @null = property.Value.GetString();
                    continue;
                }
            }
            return new StringWrapper(field, empty, @null);
        }
    }
}
