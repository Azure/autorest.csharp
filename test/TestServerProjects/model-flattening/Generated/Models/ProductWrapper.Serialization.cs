// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace model_flattening.Models
{
    public partial class ProductWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("property");
            writer.WriteStartObject();
            if (Value != null)
            {
                writer.WritePropertyName("value");
                writer.WriteStringValue(Value);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
        internal static ProductWrapper DeserializeProductWrapper(JsonElement element)
        {
            ProductWrapper result = new ProductWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("property"))
                {
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("value"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            result.Value = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
