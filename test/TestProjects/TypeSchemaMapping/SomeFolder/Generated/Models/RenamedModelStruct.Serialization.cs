// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using NamespaceForEnums;

namespace CustomNamespace
{
    internal partial struct RenamedModelStruct : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IUtf8JsonSerializable)this).Write(writer, new SerializableOptions());

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("ModelProperty"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(CustomizedFlattenedStringProperty))
            {
                writer.WritePropertyName("ModelProperty"u8);
                writer.WriteStringValue(CustomizedFlattenedStringProperty);
            }
            if (Optional.IsDefined(PropertyToField))
            {
                writer.WritePropertyName("PropertyToField"u8);
                writer.WriteStringValue(PropertyToField);
            }
            if (Optional.IsDefined(Fruit))
            {
                writer.WritePropertyName("Fruit"u8);
                writer.WriteStringValue(Fruit.Value.ToSerialString());
            }
            if (Optional.IsDefined(DaysOfWeek))
            {
                writer.WritePropertyName("DaysOfWeek"u8);
                writer.WriteStringValue(DaysOfWeek.Value.ToString());
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static RenamedModelStruct DeserializeRenamedModelStruct(JsonElement element, SerializableOptions options = default)
        {
            Optional<string> modelProperty = default;
            Optional<string> propertyToField = default;
            Optional<CustomFruitEnum> fruit = default;
            Optional<CustomDaysOfWeek> daysOfWeek = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ModelProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("ModelProperty"u8))
                        {
                            modelProperty = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("PropertyToField"u8))
                        {
                            propertyToField = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("Fruit"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            fruit = property0.Value.GetString().ToCustomFruitEnum();
                            continue;
                        }
                        if (property0.NameEquals("DaysOfWeek"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            daysOfWeek = new CustomDaysOfWeek(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new RenamedModelStruct(modelProperty.Value, propertyToField.Value, Optional.ToNullable(fruit), Optional.ToNullable(daysOfWeek));
        }
    }
}
