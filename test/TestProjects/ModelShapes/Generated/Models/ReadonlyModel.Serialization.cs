// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace ModelShapes.Models
{
    public partial class ReadonlyModel
    {
        internal static ReadonlyModel DeserializeReadonlyModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
            }
            return new ReadonlyModel(name.Value);
        }
    }
}
