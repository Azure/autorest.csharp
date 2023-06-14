// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace AppConfiguration.Models
{
    public partial class Label
    {
        internal static Label DeserializeLabel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
            }
            return new Label(name.Value);
        }
    }
}
