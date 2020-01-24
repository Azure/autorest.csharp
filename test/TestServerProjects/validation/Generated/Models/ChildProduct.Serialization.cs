// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace validation.Models
{
    public partial class ChildProduct : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("constProperty");
            writer.WriteStringValue(ConstProperty);
            if (Count != null)
            {
                writer.WritePropertyName("count");
                writer.WriteNumberValue(Count.Value);
            }
            writer.WriteEndObject();
        }
        internal static ChildProduct DeserializeChildProduct(JsonElement element)
        {
            ChildProduct result = new ChildProduct();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("constProperty"))
                {
                    result.ConstProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("count"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Count = property.Value.GetInt32();
                    continue;
                }
            }
            return result;
        }
    }
}
