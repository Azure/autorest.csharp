// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;

namespace MgmtResourceName.Models
{
    internal partial class DisplayResourceListResult
    {
        internal static DisplayResourceListResult DeserializeDisplayResourceListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<DisplayResourceData> value = default;
            string nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DisplayResourceData> array = new List<DisplayResourceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DisplayResourceData.DeserializeDisplayResourceData(item));
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
            return new DisplayResourceListResult(value ?? new ChangeTrackingList<DisplayResourceData>(), nextLink);
        }
    }
}
