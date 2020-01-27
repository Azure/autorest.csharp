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
            writer.WritePropertyName("constProperty");
            writer.WriteStringValue(ConstProperty);
            writer.WritePropertyName("constProperty2");
            writer.WriteStringValue(ConstProperty2);
            writer.WriteEndObject();
        }
        internal static ConstantProduct DeserializeConstantProduct(JsonElement element)
        {
            ConstantProduct result = new ConstantProduct();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("constProperty"))
                {
                    result.ConstProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("constProperty2"))
                {
                    result.ConstProperty2 = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
