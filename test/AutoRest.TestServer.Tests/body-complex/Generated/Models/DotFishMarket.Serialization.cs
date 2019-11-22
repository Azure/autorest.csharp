// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class DotFishMarket
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("DotFishMarket");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (SampleSalmon != null)
            {
                SampleSalmon?.Serialize(writer, true);
            }
            if (_salmons != null)
            {
                writer.WriteStartArray("salmons");
                foreach (var item in _salmons)
                {
                    item?.Serialize(writer, true);
                }
                writer.WriteEndArray();
            }
            if (SampleFish != null)
            {
                SampleFish?.Serialize(writer, true);
            }
            if (_fishes != null)
            {
                writer.WriteStartArray("fishes");
                foreach (var item in _fishes)
                {
                    item?.Serialize(writer, true);
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
                    result.SampleSalmon = body_complex.Models.V20160229.DotSalmon.Deserialize(property.Value);
                    continue;
                }
                if (property.NameEquals("salmons"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Salmons.Add(body_complex.Models.V20160229.DotSalmon.Deserialize(item));
                    }
                    continue;
                }
                if (property.NameEquals("sampleFish"))
                {
                    result.SampleFish = body_complex.Models.V20160229.DotFish.Deserialize(property.Value);
                    continue;
                }
                if (property.NameEquals("fishes"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Fishes.Add(body_complex.Models.V20160229.DotFish.Deserialize(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
