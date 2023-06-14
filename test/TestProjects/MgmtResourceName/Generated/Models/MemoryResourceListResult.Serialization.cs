// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtResourceName;

namespace MgmtResourceName.Models
{
    internal partial class MemoryResourceListResult
    {
        internal static MemoryResourceListResult DeserializeMemoryResourceListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<MemoryData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<MemoryData> array = new List<MemoryData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(MemoryData.DeserializeMemoryData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new MemoryResourceListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
