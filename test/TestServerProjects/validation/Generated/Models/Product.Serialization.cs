// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace validation.Models.V100
{
    public partial class ProductSerializer
    {
        internal static void Serialize(Product model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.DisplayNames != null)
            {
                writer.WritePropertyName("display_names");
                writer.WriteStartArray();
                foreach (var item in model.DisplayNames)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (model.Capacity != null)
            {
                writer.WritePropertyName("capacity");
                writer.WriteNumberValue(model.Capacity.Value);
            }
            if (model.Image != null)
            {
                writer.WritePropertyName("image");
                writer.WriteStringValue(model.Image);
            }
            writer.WritePropertyName("child");
            ChildProductSerializer.Serialize(model.Child, writer);
            writer.WritePropertyName("constChild");
            ConstantProductSerializer.Serialize(model.ConstChild, writer);
            writer.WritePropertyName("constInt");
            writer.WriteNumberValue(model.ConstInt);
            writer.WritePropertyName("constString");
            writer.WriteStringValue(model.ConstString);
            writer.WritePropertyName("constStringAsEnum");
            writer.WriteStringValue(model.ConstStringAsEnum);
            writer.WriteEndObject();
        }
        internal static Product Deserialize(JsonElement element)
        {
            var result = new Product();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("display_names"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.DisplayNames = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.DisplayNames.Add(item.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("capacity"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Capacity = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("image"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Image = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("child"))
                {
                    result.Child = ChildProductSerializer.Deserialize(property.Value);
                    continue;
                }
                if (property.NameEquals("constChild"))
                {
                    result.ConstChild = ConstantProductSerializer.Deserialize(property.Value);
                    continue;
                }
                if (property.NameEquals("constInt"))
                {
                    result.ConstInt = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("constString"))
                {
                    result.ConstString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("constStringAsEnum"))
                {
                    result.ConstStringAsEnum = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
