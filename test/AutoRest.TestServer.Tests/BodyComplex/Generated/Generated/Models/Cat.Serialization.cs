// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
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
            if (_hates != null)
            {
                writer.WriteStartArray("hates");
                foreach (var item in _hates)
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
                        result.Hates.Add(BodyComplex.Models.V20160229.Dog.Deserialize(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
