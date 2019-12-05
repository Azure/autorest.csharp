// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class DotFish
    {
        public void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("fish.type");
            writer.WriteStringValue(FishType);
            if (Species != null)
            {
                writer.WritePropertyName("species");
                writer.WriteStringValue(Species);
            }
            writer.WriteEndObject();
        }
        public static DotFish Deserialize(JsonElement element)
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
