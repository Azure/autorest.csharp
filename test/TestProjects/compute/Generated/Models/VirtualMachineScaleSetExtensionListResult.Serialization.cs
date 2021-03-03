// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace compute.Models
{
    public partial class VirtualMachineScaleSetExtensionListResult
    {
        internal static VirtualMachineScaleSetExtensionListResult DeserializeVirtualMachineScaleSetExtensionListResult(JsonElement element)
        {
            IReadOnlyList<VirtualMachineScaleSetExtension> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    List<VirtualMachineScaleSetExtension> array = new List<VirtualMachineScaleSetExtension>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineScaleSetExtension.DeserializeVirtualMachineScaleSetExtension(item));
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
            return new VirtualMachineScaleSetExtensionListResult(value, nextLink.Value);
        }
    }
}
