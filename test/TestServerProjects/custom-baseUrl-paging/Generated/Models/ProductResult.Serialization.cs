// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace custom_baseUrl_paging.Models
{
    public partial class ProductResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Values != null)
            {
                writer.WritePropertyName("values");
                writer.WriteStartArray();
                foreach (var item in Values)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (NextLink != null)
            {
                writer.WritePropertyName("nextLink");
                writer.WriteStringValue(NextLink);
            }
            writer.WriteEndObject();
        }
        internal static ProductResult DeserializeProductResult(JsonElement element)
        {
            ProductResult result = new ProductResult();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("values"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Values = new List<Product>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Values.Add(Product.DeserializeProduct(item));
                    }
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.NextLink = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
