// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtExpandResourceTypes;

namespace MgmtExpandResourceTypes.Models
{
    internal partial class ZoneListResult
    {
        internal static ZoneListResult DeserializeZoneListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<ZoneData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ZoneData> array = new List<ZoneData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ZoneData.DeserializeZoneData(item));
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
            return new ZoneListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
