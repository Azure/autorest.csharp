// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace model_flattening.Models
{
    public partial class SimpleProduct : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Details != null)
            {
                writer.WritePropertyName("details");
                writer.WriteObjectValue(Details);
            }
            writer.WritePropertyName("base_product_id");
            writer.WriteStringValue(ProductId);
            if (Description != null)
            {
                writer.WritePropertyName("base_product_description");
                writer.WriteStringValue(Description);
            }
            writer.WriteEndObject();
        }
        internal static SimpleProduct DeserializeSimpleProduct(JsonElement element)
        {
            SimpleProduct result = new SimpleProduct();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("details"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Details = SimpleProductProperties.DeserializeSimpleProductProperties(property.Value);
                    continue;
                }
                if (property.NameEquals("base_product_id"))
                {
                    result.ProductId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("base_product_description"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Description = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
