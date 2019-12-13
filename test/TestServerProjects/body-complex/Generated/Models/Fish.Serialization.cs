// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class FishSerializer
    {
        internal static void Serialize(Fish model, Utf8JsonWriter writer)
        {
            switch (model)
            {
                case Salmon salmon:
                    SalmonSerializer.Serialize(salmon, writer);
                    return;
                case Shark shark:
                    SharkSerializer.Serialize(shark, writer);
                    return;
            }
            writer.WriteStartObject();
            writer.WritePropertyName("fishtype");
            writer.WriteStringValue(model.Fishtype);
            if (model.Species != null)
            {
                writer.WritePropertyName("species");
                writer.WriteStringValue(model.Species);
            }
            writer.WritePropertyName("length");
            writer.WriteNumberValue(model.Length);
            if (model.Siblings != null)
            {
                writer.WriteStartArray("siblings");
                foreach (var item in model.Siblings)
                {
                    FishSerializer.Serialize(item, writer);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static Fish Deserialize(JsonElement element)
        {
            if (element.TryGetProperty("fishtype", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "salmon": return SalmonSerializer.Deserialize(element);
                    case "shark": return SharkSerializer.Deserialize(element);
                }
            }
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
                    result.Length = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("siblings"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Siblings.Add(FishSerializer.Deserialize(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
