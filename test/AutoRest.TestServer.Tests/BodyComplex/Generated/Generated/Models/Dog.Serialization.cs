// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
{
    public partial class Dog
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("dog");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (Food != null)
            {
                writer.WriteString("food", Food);
            }
            writer.WriteEndObject();
        }
        internal static Dog Deserialize(JsonElement element)
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
