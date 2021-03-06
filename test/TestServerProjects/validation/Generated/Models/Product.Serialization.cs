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
            if (Optional.IsCollectionDefined(DisplayNames))
            {
                writer.WritePropertyName("display_names");
                writer.WriteStartArray();
                foreach (var item in DisplayNames)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Capacity))
            {
                writer.WritePropertyName("capacity");
                writer.WriteNumberValue(Capacity.Value);
            }
            if (Optional.IsDefined(Image))
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
            if (Optional.IsDefined(ConstStringAsEnum))
            {
                writer.WritePropertyName("constStringAsEnum");
                writer.WriteStringValue(ConstStringAsEnum);
            }
            writer.WriteEndObject();
        }

        internal static Product DeserializeProduct(JsonElement element)
        {
            Optional<IList<string>> displayNames = default;
            Optional<int> capacity = default;
            Optional<string> image = default;
            ChildProduct child = default;
            ConstantProduct constChild = default;
            int constInt = default;
            string constString = default;
            Optional<string> constStringAsEnum = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("display_names"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
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
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    capacity = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("image"))
                {
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
                    constInt = property.Value.GetInt32();
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
            return new Product(Optional.ToList(displayNames), Optional.ToNullable(capacity), image.Value, child, constChild, constInt, constString, constStringAsEnum.Value);
        }
    }
}
