// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample
{
    internal partial class VirtualMachineSizeListResult
    {
        internal static VirtualMachineSizeListResult DeserializeVirtualMachineSizeListResult(JsonElement element)
        {
            Optional<IReadOnlyList<VirtualMachineSizeData>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<VirtualMachineSizeData> array = new List<VirtualMachineSizeData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineSizeData.DeserializeVirtualMachineSizeData(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new VirtualMachineSizeListResult(Optional.ToList(value));
        }
    }
}
