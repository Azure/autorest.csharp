// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models.V20160229
{
    public partial class DotFishSerializer
    {
        internal static void Serialize(DotFish model, Utf8JsonWriter writer)
        {
            switch (model)
            {
                case DotSalmon dotSalmon:
                    DotSalmonSerializer.Serialize(dotSalmon, writer);
                    return;
            }
            writer.WriteStartObject();
            writer.WritePropertyName("fish.type");
            writer.WriteStringValue(model.FishType);
            if (model.Species != null)
            {
                writer.WritePropertyName("species");
                writer.WriteStringValue(model.Species);
            }

            writer.WriteEndObject();
        }
        internal static DotFish Deserialize(JsonElement element)
        {
            if (element.TryGetProperty("fish.type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "DotSalmon": return DotSalmonSerializer.Deserialize(element);
                }
            }
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
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Species = property.Value.GetString();
                    continue;
                }

            }
            return result;
        }
    }
}
