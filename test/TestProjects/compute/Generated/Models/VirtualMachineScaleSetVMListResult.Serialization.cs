// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace compute.Models
{
    public partial class VirtualMachineScaleSetVMListResult
    {
        internal static VirtualMachineScaleSetVMListResult DeserializeVirtualMachineScaleSetVMListResult(JsonElement element)
        {
            IReadOnlyList<VirtualMachineScaleSetVM> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    List<VirtualMachineScaleSetVM> array = new List<VirtualMachineScaleSetVM>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineScaleSetVM.DeserializeVirtualMachineScaleSetVM(item));
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
            return new VirtualMachineScaleSetVMListResult(value, nextLink.Value);
        }
    }
}
