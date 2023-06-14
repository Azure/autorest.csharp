// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class VirtualMachineScaleSetVMListResult
    {
        internal static VirtualMachineScaleSetVMListResult DeserializeVirtualMachineScaleSetVMListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<VirtualMachineScaleSetVMData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<VirtualMachineScaleSetVMData> array = new List<VirtualMachineScaleSetVMData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineScaleSetVMData.DeserializeVirtualMachineScaleSetVMData(item));
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
            return new VirtualMachineScaleSetVMListResult(value, nextLink.Value);
        }
    }
}
