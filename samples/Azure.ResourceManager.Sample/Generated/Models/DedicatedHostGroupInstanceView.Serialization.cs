// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class DedicatedHostGroupInstanceView
    {
        internal static DedicatedHostGroupInstanceView DeserializeDedicatedHostGroupInstanceView(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<DedicatedHostInstanceViewWithName>> hosts = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("hosts"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DedicatedHostInstanceViewWithName> array = new List<DedicatedHostInstanceViewWithName>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DedicatedHostInstanceViewWithName.DeserializeDedicatedHostInstanceViewWithName(item));
                    }
                    hosts = array;
                    continue;
                }
            }
            return new DedicatedHostGroupInstanceView(Optional.ToList(hosts));
        }
    }
}
