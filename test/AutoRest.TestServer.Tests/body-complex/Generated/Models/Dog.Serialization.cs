// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class Dog
    {
        public void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Food != null)
            {
                writer.WritePropertyName("food");
                writer.WriteStringValue(Food);
            }
            writer.WriteEndObject();
        }
        public static Dog Deserialize(JsonElement element)
        {
            var result = new Dog();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("food"))
                {
                    result.Food = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
