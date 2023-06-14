// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtHierarchicalNonResource.Models
{
    internal partial class Disallowed
    {
        internal static Disallowed DeserializeDisallowed(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<string>> diskTypes = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("diskTypes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    diskTypes = array;
                    continue;
                }
            }
            return new Disallowed(Optional.ToList(diskTypes));
        }
    }
}
