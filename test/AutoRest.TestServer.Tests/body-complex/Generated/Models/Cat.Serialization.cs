// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class Cat
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("cat");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (Color != null)
            {
                writer.WriteString("color", Color);
            }
            if (Hates != null)
            {
                writer.WriteStartArray("hates");
                foreach (var item in Hates)
                {
                    item?.Serialize(writer, true);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static Cat Deserialize(JsonElement element)
        {
            var result = new Cat();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("color"))
                {
                    result.Color = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("hates"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Hates.Add(Dog.Deserialize(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
