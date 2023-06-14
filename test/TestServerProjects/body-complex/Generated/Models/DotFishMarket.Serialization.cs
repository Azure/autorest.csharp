// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class DotFishMarket
    {
        internal static DotFishMarket DeserializeDotFishMarket(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<DotSalmon> sampleSalmon = default;
            Optional<IReadOnlyList<DotSalmon>> salmons = default;
            Optional<DotFish> sampleFish = default;
            Optional<IReadOnlyList<DotFish>> fishes = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sampleSalmon"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sampleSalmon = DotSalmon.DeserializeDotSalmon(property.Value);
                    continue;
                }
                if (property.NameEquals("salmons"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DotSalmon> array = new List<DotSalmon>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DotSalmon.DeserializeDotSalmon(item));
                    }
                    salmons = array;
                    continue;
                }
                if (property.NameEquals("sampleFish"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sampleFish = DotFish.DeserializeDotFish(property.Value);
                    continue;
                }
                if (property.NameEquals("fishes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DotFish> array = new List<DotFish>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DotFish.DeserializeDotFish(item));
                    }
                    fishes = array;
                    continue;
                }
            }
            return new DotFishMarket(sampleSalmon.Value, Optional.ToList(salmons), sampleFish.Value, Optional.ToList(fishes));
        }
    }
}
