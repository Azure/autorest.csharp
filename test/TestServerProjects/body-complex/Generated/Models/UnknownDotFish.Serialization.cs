// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    internal partial class UnknownDotFish
    {
        internal static UnknownDotFish DeserializeUnknownDotFish(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string fishType = "Unknown";
            Optional<string> species = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("fish.type"u8))
                {
                    fishType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("species"u8))
                {
                    species = property.Value.GetString();
                    continue;
                }
            }
            return new UnknownDotFish(fishType, species.Value);
        }
    }
}
