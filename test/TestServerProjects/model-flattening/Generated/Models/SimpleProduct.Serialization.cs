// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace model_flattening.Models
{
    public partial class SimpleProduct : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("base_product_id");
            writer.WriteStringValue(ProductId);
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("base_product_description");
                writer.WriteStringValue(Description);
            }
            writer.WritePropertyName("details");
            writer.WriteStartObject();
            if (Optional.IsDefined(MaxProductDisplayName))
            {
                writer.WritePropertyName("max_product_display_name");
                writer.WriteStringValue(MaxProductDisplayName);
            }
            if (Optional.IsDefined(Capacity))
            {
                writer.WritePropertyName("max_product_capacity");
                writer.WriteStringValue(Capacity.Value.ToString());
            }
            writer.WritePropertyName("max_product_image");
            writer.WriteStartObject();
            if (Optional.IsDefined(GenericValue))
            {
                writer.WritePropertyName("generic_value");
                writer.WriteStringValue(GenericValue);
            }
            if (Optional.IsDefined(OdataValue))
            {
                writer.WritePropertyName("@odata.value");
                writer.WriteStringValue(OdataValue);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static SimpleProduct DeserializeSimpleProduct(JsonElement element)
        {
            string baseProductId = default;
            Optional<string> baseProductDescription = default;
            Optional<string> maxProductDisplayName = default;
            Optional<SimpleProductPropertiesMaxProductCapacity> maxProductCapacity = default;
            Optional<string> genericValue = default;
            Optional<string> odataValue = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("base_product_id"))
                {
                    baseProductId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("base_product_description"))
                {
                    baseProductDescription = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("details"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("max_product_display_name"))
                        {
                            maxProductDisplayName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("max_product_capacity"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            maxProductCapacity = new SimpleProductPropertiesMaxProductCapacity(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("max_product_image"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            foreach (var property1 in property0.Value.EnumerateObject())
                            {
                                if (property1.NameEquals("generic_value"))
                                {
                                    genericValue = property1.Value.GetString();
                                    continue;
                                }
                                if (property1.NameEquals("@odata.value"))
                                {
                                    odataValue = property1.Value.GetString();
                                    continue;
                                }
                            }
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new SimpleProduct(baseProductId, baseProductDescription.Value, maxProductDisplayName.Value, Optional.ToNullable(maxProductCapacity), genericValue.Value, odataValue.Value);
        }
    }
}
