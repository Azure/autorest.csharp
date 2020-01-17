// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class Cat : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Color != null)
            {
                writer.WritePropertyName("color");
                writer.WriteStringValue(Color);
            }
            if (Hates != null)
            {
                writer.WritePropertyName("hates");
                writer.WriteStartArray();
                foreach (var item in Hates)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
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
        internal static Cat DeserializeCat(JsonElement element)
        {
            Cat result = new Cat();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("color"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Color = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("hates"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Hates = new List<Dog>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Hates.Add(Dog.DeserializeDog(item));
                    }
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Id = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Name = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
