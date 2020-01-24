// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using AnotherCustomNamespace;
using Azure.Core;
using TypeSchemaMapping.Models;

namespace CustomNamespace
{
    internal partial class CustomizedModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (ModelProperty != null)
            {
                writer.WritePropertyName("ModelProperty");
                writer.WriteStringValue(ModelProperty);
            }
            writer.WritePropertyName("Fruit");
            writer.WriteStringValue(Fruit.ToString());
            writer.WritePropertyName("DaysOfWeek");
            writer.WriteStringValue(DaysOfWeek.ToString());
            writer.WriteEndObject();
        }
        internal static CustomizedModel DeserializeCustomizedModel(JsonElement element)
        {
            CustomizedModel result = new CustomizedModel();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ModelProperty"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ModelProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Fruit"))
                {
                    result.Fruit = new CustomFruitEnum(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("DaysOfWeek"))
                {
                    result.DaysOfWeek = new DaysOfWeek(property.Value.GetString());
                    continue;
                }
            }
            return result;
        }
    }
}
