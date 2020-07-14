// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace body_array.Models
{
    public partial class Product : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Integer))
            {
                writer.WritePropertyName("integer");
                writer.WriteNumberValue(Integer.Value);
            }
            if (Optional.IsDefined(String))
            {
                writer.WritePropertyName("string");
                writer.WriteStringValue(String);
            }
            writer.WriteEndObject();
        }

        internal static Product DeserializeProduct(JsonElement element)
        {
            Optional<int> integer = default;
            Optional<string> @string = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("integer"))
                {
                    integer = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("string"))
                {
                    @string = property.Value.GetString();
                    continue;
                }
            }
            return new Product(Optional.ToNullable(integer), @string.Value);
        }
    }
}
