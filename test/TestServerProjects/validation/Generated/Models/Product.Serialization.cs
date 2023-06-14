// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
                writer.WritePropertyName("display_names"u8);
                writer.WriteStartArray();
                foreach (var item in DisplayNames)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Capacity))
            {
                writer.WritePropertyName("capacity"u8);
                writer.WriteNumberValue(Capacity.Value);
            }
            if (Optional.IsDefined(Image))
            {
                writer.WritePropertyName("image"u8);
                writer.WriteStringValue(Image);
            }
            writer.WritePropertyName("child"u8);
            writer.WriteObjectValue(Child);
            writer.WritePropertyName("constChild"u8);
            writer.WriteObjectValue(ConstChild);
            writer.WritePropertyName("constInt"u8);
            writer.WriteNumberValue(ConstInt.ToSerialInt32());
            writer.WritePropertyName("constString"u8);
            writer.WriteStringValue(ConstString.ToString());
            if (Optional.IsDefined(ConstStringAsEnum))
            {
                writer.WritePropertyName("constStringAsEnum"u8);
                writer.WriteStringValue(ConstStringAsEnum.Value.ToString());
            }
            writer.WriteEndObject();
        }

        internal static Product DeserializeProduct(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<string>> displayNames = default;
            Optional<int> capacity = default;
            Optional<string> image = default;
            ChildProduct child = default;
            ConstantProduct constChild = default;
            ProductConstInt constInt = default;
            ProductConstString constString = default;
            Optional<EnumConst> constStringAsEnum = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("display_names"u8))
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
                if (property.NameEquals("capacity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    capacity = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("image"u8))
                {
                    image = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("child"u8))
                {
                    child = ChildProduct.DeserializeChildProduct(property.Value);
                    continue;
                }
                if (property.NameEquals("constChild"u8))
                {
                    constChild = ConstantProduct.DeserializeConstantProduct(property.Value);
                    continue;
                }
                if (property.NameEquals("constInt"u8))
                {
                    constInt = new ProductConstInt(property.Value.GetInt32());
                    continue;
                }
                if (property.NameEquals("constString"u8))
                {
                    constString = new ProductConstString(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("constStringAsEnum"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    constStringAsEnum = new EnumConst(property.Value.GetString());
                    continue;
                }
            }
            return new Product(Optional.ToList(displayNames), Optional.ToNullable(capacity), image.Value, child, constChild, constInt, constString, Optional.ToNullable(constStringAsEnum));
        }
    }
}
