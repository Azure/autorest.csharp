// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
{
    public partial class Fish
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("Fish");
            }
            else
            {
                writer.WriteStartObject();
            }
            writer.WriteString("fishtype", Fishtype);
            if (Species != null)
            {
                writer.WriteString("species", Species);
            }
            writer.WriteNumber("length", Length);
            if (_siblings != null)
            {
                writer.WriteStartArray("siblings");
                foreach (var item in _siblings)
                {
                    item?.Serialize(writer);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static Fish Deserialize(JsonElement element)
        {
            var result = new Fish();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("fishtype"))
                {
                    result.Fishtype = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("species"))
                {
                    result.Species = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("length"))
                {
                    result.Length = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("siblings"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Siblings.Add(BodyComplex.Models.V20160229.Fish.Deserialize(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
