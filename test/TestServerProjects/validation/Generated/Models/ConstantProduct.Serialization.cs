// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace validation.Models
{
    public partial class ConstantProduct : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("constProperty"u8);
            writer.WriteStringValue(ConstProperty.ToString());
            writer.WritePropertyName("constProperty2"u8);
            writer.WriteStringValue(ConstProperty2.ToString());
            writer.WriteEndObject();
        }

        internal static ConstantProduct DeserializeConstantProduct(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ConstantProductConstProperty constProperty = default;
            ConstantProductConstProperty2 constProperty2 = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("constProperty"u8))
                {
                    constProperty = new ConstantProductConstProperty(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("constProperty2"u8))
                {
                    constProperty2 = new ConstantProductConstProperty2(property.Value.GetString());
                    continue;
                }
            }
            return new ConstantProduct(constProperty, constProperty2);
        }
    }
}
