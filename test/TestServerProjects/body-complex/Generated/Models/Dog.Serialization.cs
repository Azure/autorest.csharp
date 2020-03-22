// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class Dog : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Food != null)
            {
                writer.WritePropertyName("food");
                writer.WriteStringValue(Food);
            }
            if (Id != null)
            {
                writer.WritePropertyName("id");
                writer.WriteNumberValue(Id.Value);
            }
            if (Name != null)
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            writer.WriteEndObject();
        }

        internal static Dog DeserializeDog(JsonElement element)
        {
            string food = default;
            int? id = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("food"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    food = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    id = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    name = property.Value.GetString();
                    continue;
                }
            }
            return new Dog(food, id, name);
        }
    }
}
