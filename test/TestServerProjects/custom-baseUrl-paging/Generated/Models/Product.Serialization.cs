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
            Optional<ProductProperties> properties = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    properties = ProductProperties.DeserializeProductProperties(property.Value);
                    continue;
                }
            }
            return new Product(properties.Value);
        }
    }
}
