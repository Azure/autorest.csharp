// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class VirtualMachineScaleSetInstanceViewStatusesSummary
    {
        internal static VirtualMachineScaleSetInstanceViewStatusesSummary DeserializeVirtualMachineScaleSetInstanceViewStatusesSummary(JsonElement element)
        {
            Optional<IReadOnlyList<VirtualMachineStatusCodeCount>> statusesSummary = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("statusesSummary"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<VirtualMachineStatusCodeCount> array = new List<VirtualMachineStatusCodeCount>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineStatusCodeCount.DeserializeVirtualMachineStatusCodeCount(item));
                    }
                    statusesSummary = array;
                    continue;
                }
            }
            return new VirtualMachineScaleSetInstanceViewStatusesSummary(Optional.ToList(statusesSummary));
        }
    }
}
