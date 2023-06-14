// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace xms_error_responses.Models
{
    public partial class Pet
    {
        internal static Pet DeserializePet(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<string> aniType = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("aniType"u8))
                {
                    aniType = property.Value.GetString();
                    continue;
                }
            }
            return new Pet(aniType.Value, name.Value);
        }
    }
}
