// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtHierarchicalNonResource.Models
{
    public partial class ResourceRange
    {
        internal static ResourceRange DeserializeResourceRange(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> min = default;
            Optional<int> max = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("min"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    min = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("max"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    max = property.Value.GetInt32();
                    continue;
                }
            }
            return new ResourceRange(Optional.ToNullable(min), Optional.ToNullable(max));
        }
    }
}
