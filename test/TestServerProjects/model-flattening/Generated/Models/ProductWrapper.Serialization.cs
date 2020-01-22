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
            if (Property != null)
            {
                writer.WritePropertyName("property");
                writer.WriteObjectValue(Property);
            }
            writer.WriteEndObject();
        }
        internal static ProductWrapper DeserializeProductWrapper(JsonElement element)
        {
            ProductWrapper result = new ProductWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("property"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Property = WrappedProduct.DeserializeWrappedProduct(property.Value);
                    continue;
                }
            }
            return result;
        }
    }
}
