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
    internal partial class CustomizedModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IUtf8JsonSerializable)this).Write(writer, new SerializableOptions());

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(PropertyRenamedAndTypeChanged))
            {
                writer.WritePropertyName("ModelProperty"u8);
                writer.WriteNumberValue(PropertyRenamedAndTypeChanged.Value);
            }
            if (Optional.IsDefined(_field))
            {
                writer.WritePropertyName("PropertyToField"u8);
                writer.WriteStringValue(_field);
            }
            writer.WritePropertyName("Fruit"u8);
            writer.WriteStringValue(CustomizedFancyField.ToSerialString());
            writer.WritePropertyName("DaysOfWeek"u8);
            writer.WriteStringValue(DaysOfWeek.ToString());
            writer.WriteEndObject();
        }

        internal static CustomizedModel DeserializeCustomizedModel(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> modelProperty = default;
            Optional<string> propertyToField = default;
            CustomFruitEnum fruit = default;
            CustomDaysOfWeek daysOfWeek = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ModelProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    modelProperty = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("PropertyToField"u8))
                {
                    propertyToField = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Fruit"u8))
                {
                    fruit = property.Value.GetString().ToCustomFruitEnum();
                    continue;
                }
                if (property.NameEquals("DaysOfWeek"u8))
                {
                    daysOfWeek = new CustomDaysOfWeek(property.Value.GetString());
                    continue;
                }
            }
            return new CustomizedModel(Optional.ToNullable(modelProperty), propertyToField.Value, fruit, daysOfWeek);
        }
    }
}
