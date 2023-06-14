// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtLRO;

namespace MgmtLRO.Models
{
    internal partial class BarListResult
    {
        internal static BarListResult DeserializeBarListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<BarData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<BarData> array = new List<BarData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(BarData.DeserializeBarData(item));
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
            return new BarListResult(value, nextLink.Value);
        }
    }
}
