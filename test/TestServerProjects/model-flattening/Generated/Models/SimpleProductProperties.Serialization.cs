// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace model_flattening.Models
{
    public partial class SimpleProductProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("max_product_display_name");
            writer.WriteStringValue(MaxProductDisplayName);
            writer.WritePropertyName("max_product_capacity");
            writer.WriteStringValue(Capacity);
            if (MaxProductImage != null)
            {
                writer.WritePropertyName("max_product_image");
                writer.WriteObjectValue(MaxProductImage);
            }
            writer.WriteEndObject();
        }
        internal static SimpleProductProperties DeserializeSimpleProductProperties(JsonElement element)
        {
            SimpleProductProperties result = new SimpleProductProperties();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("max_product_display_name"))
                {
                    result.MaxProductDisplayName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("max_product_capacity"))
                {
                    result.Capacity = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("max_product_image"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.MaxProductImage = ProductUrl.DeserializeProductUrl(property.Value);
                    continue;
                }
            }
            return result;
        }
    }
}
