// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using MgmtOperations;

namespace MgmtOperations.Models
{
    internal partial class AvailabilitySetListResult
    {
        internal static AvailabilitySetListResult DeserializeAvailabilitySetListResult(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<AvailabilitySetData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<AvailabilitySetData> array = new List<AvailabilitySetData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AvailabilitySetData.DeserializeAvailabilitySetData(item));
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
            return new AvailabilitySetListResult(value, nextLink.Value);
        }
    }
}
