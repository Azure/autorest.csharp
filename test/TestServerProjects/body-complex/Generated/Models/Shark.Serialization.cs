// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace body_complex.Models.V20160229
{
    public partial class SharkSerializer
    {
        internal static void Serialize(Shark model, Utf8JsonWriter writer)
        {
            switch (model)
            {
                case Cookiecuttershark cookiecuttershark:
                    CookiecuttersharkSerializer.Serialize(cookiecuttershark, writer);
                    return;
                case Goblinshark goblinshark:
                    GoblinsharkSerializer.Serialize(goblinshark, writer);
                    return;
                case Sawshark sawshark:
                    SawsharkSerializer.Serialize(sawshark, writer);
                    return;
            }
            writer.WriteStartObject();
            if (model.Age != null)
            {
                writer.WritePropertyName("age");
                writer.WriteNumberValue(model.Age.Value);
            }
            writer.WritePropertyName("birthday");
            writer.WriteStringValue(model.Birthday, "S");
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
                writer.WritePropertyName("siblings");
                writer.WriteStartArray();
                foreach (var item in model.Siblings)
                {
                    FishSerializer.Serialize(item, writer);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static Shark Deserialize(JsonElement element)
        {
            if (element.TryGetProperty("fishtype", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "cookiecuttershark": return CookiecuttersharkSerializer.Deserialize(element);
                    case "goblin": return GoblinsharkSerializer.Deserialize(element);
                    case "sawshark": return SawsharkSerializer.Deserialize(element);
                }
            }
            var result = new Shark();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("age"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Age = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("birthday"))
                {
                    result.Birthday = property.Value.GetDateTimeOffset("S");
                    continue;
                }
                if (property.NameEquals("fishtype"))
                {
                    result.Fishtype = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("species"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
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
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Siblings = new List<Fish>();
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
