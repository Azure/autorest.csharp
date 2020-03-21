// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace custom_baseUrl_paging.Models
{
    public partial class Product
    {
        internal static Product DeserializeProduct(JsonElement element)
        {
            Product result;
            ProductProperties properties = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    properties = ProductProperties.DeserializeProductProperties(property.Value);
                    continue;
                }
            }
            result = new Product(properties);
            return result;
        }
    }
}
