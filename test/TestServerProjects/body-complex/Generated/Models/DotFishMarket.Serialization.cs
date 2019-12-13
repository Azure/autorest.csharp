// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class DotFishMarketSerializer
    {
        internal static void Serialize(DotFishMarket model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.SampleSalmon != null)
            {
                writer.WritePropertyName("sampleSalmon");
                DotSalmonSerializer.Serialize(model.SampleSalmon, writer);
            }
            if (model.Salmons != null)
            {
                writer.WriteStartArray("salmons");
                foreach (var item in model.Salmons)
                {
                    DotSalmonSerializer.Serialize(item, writer);
                }
                writer.WriteEndArray();
            }
            if (model.SampleFish != null)
            {
                writer.WritePropertyName("sampleFish");
                DotFishSerializer.Serialize(model.SampleFish, writer);
            }
            if (model.Fishes != null)
            {
                writer.WriteStartArray("fishes");
                foreach (var item in model.Fishes)
                {
                    DotFishSerializer.Serialize(item, writer);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static DotFishMarket Deserialize(JsonElement element)
        {
            var result = new DotFishMarket();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sampleSalmon"))
                {
                    result.SampleSalmon = DotSalmonSerializer.Deserialize(property.Value);
                    continue;
                }
                if (property.NameEquals("salmons"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Salmons.Add(DotSalmonSerializer.Deserialize(item));
                    }
                    continue;
                }
                if (property.NameEquals("sampleFish"))
                {
                    result.SampleFish = DotFishSerializer.Deserialize(property.Value);
                    continue;
                }
                if (property.NameEquals("fishes"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Fishes.Add(DotFishSerializer.Deserialize(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
