// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class DedicatedHostListResult
    {
        internal static DedicatedHostListResult DeserializeDedicatedHostListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<DedicatedHostData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<DedicatedHostData> array = new List<DedicatedHostData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DedicatedHostData.DeserializeDedicatedHostData(item));
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
            return new DedicatedHostListResult(value, nextLink.Value);
        }
    }
}
