// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtRenameRules;

namespace MgmtRenameRules.Models
{
    internal partial class VirtualMachineScaleSetListResult
    {
        internal static VirtualMachineScaleSetListResult DeserializeVirtualMachineScaleSetListResult(JsonElement element)
        {
            IReadOnlyList<VirtualMachineScaleSetResourceData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    List<VirtualMachineScaleSetResourceData> array = new List<VirtualMachineScaleSetResourceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineScaleSetResourceData.DeserializeVirtualMachineScaleSetResourceData(item));
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
            return new VirtualMachineScaleSetListResult(value, nextLink.Value);
        }
    }
}
