// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace validation.Models
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
            writer.WritePropertyName("constStringAsEnum");
            writer.WriteStringValue(ConstStringAsEnum);
            writer.WriteEndObject();
        }

        internal static Product DeserializeProduct(JsonElement element)
        {
            Product result;
            IList<string> displayNames = default;
            int? capacity = default;
            string image = default;
            ChildProduct child = new ChildProduct();
            ConstantProduct constChild = new ConstantProduct();
            float constInt = default;
            string constString = default;
            string constStringAsEnum = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("display_names"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    displayNames = array;
                    continue;
                }
                if (property.NameEquals("capacity"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    capacity = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("image"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    image = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("child"))
                {
                    child = ChildProduct.DeserializeChildProduct(property.Value);
                    continue;
                }
                if (property.NameEquals("constChild"))
                {
                    constChild = ConstantProduct.DeserializeConstantProduct(property.Value);
                    continue;
                }
                if (property.NameEquals("constInt"))
                {
                    constInt = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("constString"))
                {
                    constString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("constStringAsEnum"))
                {
                    constStringAsEnum = property.Value.GetString();
                    continue;
                }
            }
            result = new Product(displayNames, capacity, image, child, constChild, constInt, constString, constStringAsEnum);
            return result;
        }
    }
}
