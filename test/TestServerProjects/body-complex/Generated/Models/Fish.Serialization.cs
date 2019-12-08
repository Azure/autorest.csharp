// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class Fish
    {
        internal void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("fishtype");
            writer.WriteStringValue(Fishtype);
            if (Species != null)
            {
                writer.WritePropertyName("species");
                writer.WriteStringValue(Species);
            }
            writer.WritePropertyName("length");
            writer.WriteNumberValue(Length);
            if (Siblings != null)
            {
                writer.WriteStartArray("siblings");
                foreach (var item in Siblings)
                {
                    writer.WritePropertyName("siblings");
                    item.Serialize(writer);
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
                        result.Siblings.Add(Fish.Deserialize(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
