// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using NamespaceForEnums;

namespace CustomNamespace
{
    internal partial struct RenamedModelStruct : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("ModelProperty");
            writer.WriteStartObject();
            if (Optional.IsDefined(CustomizedFlattenedStringProperty))
            {
                writer.WritePropertyName("ModelProperty");
                writer.WriteStringValue(CustomizedFlattenedStringProperty);
            }
            if (Optional.IsDefined(Fruit))
            {
                writer.WritePropertyName("Fruit");
                writer.WriteStringValue(Fruit.Value.ToSerialString());
            }
            if (Optional.IsDefined(DaysOfWeek))
            {
                writer.WritePropertyName("DaysOfWeek");
                writer.WriteStringValue(DaysOfWeek.Value.ToString());
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static RenamedModelStruct DeserializeRenamedModelStruct(JsonElement element)
        {
            Optional<string> modelProperty = default;
            Optional<CustomFruitEnum> fruit = default;
            Optional<CustomDaysOfWeek> daysOfWeek = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ModelProperty"))
                {
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("ModelProperty"))
                        {
                            modelProperty = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("Fruit"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            fruit = property0.Value.GetString().ToCustomFruitEnum();
                            continue;
                        }
                        if (property0.NameEquals("DaysOfWeek"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            daysOfWeek = new CustomDaysOfWeek(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new RenamedModelStruct(modelProperty.Value, Optional.ToNullable(fruit), Optional.ToNullable(daysOfWeek));
        }
    }
}
