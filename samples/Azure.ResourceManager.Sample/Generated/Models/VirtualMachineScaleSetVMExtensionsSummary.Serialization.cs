// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineScaleSetVMExtensionsSummary
    {
        internal static VirtualMachineScaleSetVMExtensionsSummary DeserializeVirtualMachineScaleSetVMExtensionsSummary(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<IReadOnlyList<VirtualMachineStatusCodeCount>> statusesSummary = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("statusesSummary"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
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
            return new VirtualMachineScaleSetVMExtensionsSummary(name.Value, Optional.ToList(statusesSummary));
        }
    }
}
