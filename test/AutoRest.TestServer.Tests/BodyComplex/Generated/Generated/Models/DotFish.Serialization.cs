// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
{
    public partial class DotFish
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("DotFish");
            }
            else
            {
                writer.WriteStartObject();
            }
            writer.WriteString("fish.type", FishType);
            if (Species != null)
            {
                writer.WriteString("species", Species);
            }
            writer.WriteEndObject();
        }
        internal static DotFish Deserialize(JsonElement element)
        {
            var result = new DotFish();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("fish.type"))
                {
                    result.FishType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("species"))
                {
                    result.Species = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
