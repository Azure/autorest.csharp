// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtOperations;

namespace MgmtOperations.Models
{
    internal partial class AvailabilitySetChildListResult
    {
        internal static AvailabilitySetChildListResult DeserializeAvailabilitySetChildListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<AvailabilitySetChildData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<AvailabilitySetChildData> array = new List<AvailabilitySetChildData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AvailabilitySetChildData.DeserializeAvailabilitySetChildData(item));
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
            return new AvailabilitySetChildListResult(value, nextLink.Value);
        }
    }
}
