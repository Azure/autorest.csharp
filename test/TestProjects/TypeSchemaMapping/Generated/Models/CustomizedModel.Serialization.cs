// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using NamespaceForEnums;

namespace CustomNamespace
{
    internal partial class CustomizedModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (CustomizedStringProperty != null)
            {
                writer.WritePropertyName("ModelProperty");
                writer.WriteStringValue(CustomizedStringProperty);
            }
            writer.WritePropertyName("Fruit");
            writer.WriteStringValue(CustomizedFancyField.ToSerialString());
            writer.WritePropertyName("DaysOfWeek");
            writer.WriteStringValue(DaysOfWeek.ToString());
            writer.WriteEndObject();
        }

        internal static CustomizedModel DeserializeCustomizedModel(JsonElement element)
        {
            CustomizedModel result;
            string modelProperty = default;
            CustomFruitEnum fruit = default;
            CustomDaysOfWeek daysOfWeek = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ModelProperty"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    modelProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Fruit"))
                {
                    fruit = property.Value.GetString().ToCustomFruitEnum();
                    continue;
                }
                if (property.NameEquals("DaysOfWeek"))
                {
                    daysOfWeek = new CustomDaysOfWeek(property.Value.GetString());
                    continue;
                }
            }
            result = new CustomizedModel(modelProperty, fruit, daysOfWeek);
            return result;
        }
    }
}
