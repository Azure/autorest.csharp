// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class VirtualMachineScaleSetListResult
    {
        internal static VirtualMachineScaleSetListResult DeserializeVirtualMachineScaleSetListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<VirtualMachineScaleSetData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<VirtualMachineScaleSetData> array = new List<VirtualMachineScaleSetData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineScaleSetData.DeserializeVirtualMachineScaleSetData(item));
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
            return new VirtualMachineScaleSetListResult(value, nextLink.Value);
        }
    }
}
