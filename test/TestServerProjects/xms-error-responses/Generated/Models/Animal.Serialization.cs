// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace xms_error_responses.Models
{
    public partial class Animal
    {
        internal static Animal DeserializeAnimal(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> aniType = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("aniType"u8))
                {
                    aniType = property.Value.GetString();
                    continue;
                }
            }
            return new Animal(aniType.Value);
        }
    }
}
