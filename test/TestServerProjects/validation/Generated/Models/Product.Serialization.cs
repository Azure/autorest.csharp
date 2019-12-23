// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace validation.Models.V100
{
    public partial class Product : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (DisplayNames != null)
            {
                writer.WritePropertyName("display_names");
                writer.WriteStartArray();
                foreach (var item in DisplayNames)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Capacity != null)
            {
                writer.WritePropertyName("capacity");
                writer.WriteNumberValue(Capacity.Value);
            }
            if (Image != null)
            {
                writer.WritePropertyName("image");
                writer.WriteStringValue(Image);
            }
            writer.WritePropertyName("child");
            writer.WriteObjectValue(Child);
            writer.WritePropertyName("constChild");
            writer.WriteObjectValue(ConstChild);
            writer.WritePropertyName("constInt");
            writer.WriteNumberValue(ConstInt);
            writer.WritePropertyName("constString");
            writer.WriteStringValue(ConstString);
            if (ConstStringAsEnum != null)
            {
                writer.WritePropertyName("constStringAsEnum");
                writer.WriteStringValue(ConstStringAsEnum);
            }
            writer.WriteEndObject();
        }
        internal static Product DeserializeProduct(JsonElement element)
        {
            Product result = new Product();
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
                    result.Child = ChildProduct.DeserializeChildProduct(property.Value);
                    continue;
                }
                if (property.NameEquals("constChild"))
                {
                    result.ConstChild = ConstantProduct.DeserializeConstantProduct(property.Value);
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
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ConstStringAsEnum = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
