// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace paging.Models
{
    public partial class ProductResultValue
    {
        internal static ProductResultValue DeserializeProductResultValue(JsonElement element)
        {
            Optional<IReadOnlyList<Product>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<Product> array = new List<Product>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Product.DeserializeProduct(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new ProductResultValue(Optional.ToList(value), nextLink.Value);
        }
    }
}
