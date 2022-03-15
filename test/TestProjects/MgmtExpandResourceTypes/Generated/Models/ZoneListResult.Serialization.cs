// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
            Optional<IReadOnlyList<ZoneResourceData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<ZoneResourceData> array = new List<ZoneResourceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ZoneResourceData.DeserializeZoneResourceData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new ZoneListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
