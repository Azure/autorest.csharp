// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace ModelWithConverterUsage.Models
{
    public partial class Product : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IUtf8JsonSerializable)this).Write(writer, new SerializableOptions());

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ConstProperty))
            {
                writer.WritePropertyName("Const_Property"u8);
                writer.WriteStringValue(ConstProperty);
            }
            writer.WriteEndObject();
        }

        internal static Product DeserializeProduct(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> constProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Const_Property"u8))
                {
                    constProperty = property.Value.GetString();
                    continue;
                }
            }
            return new Product(constProperty.Value);
        }
    }
}
