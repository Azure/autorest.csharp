// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class DedicatedHostGroupListResult
    {
        internal static DedicatedHostGroupListResult DeserializeDedicatedHostGroupListResult(JsonElement element)
        {
            IReadOnlyList<DedicatedHostGroupResourceData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    List<DedicatedHostGroupResourceData> array = new List<DedicatedHostGroupResourceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DedicatedHostGroupResourceData.DeserializeDedicatedHostGroupResourceData(item));
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
            return new DedicatedHostGroupListResult(value, nextLink.Value);
        }
    }
}
