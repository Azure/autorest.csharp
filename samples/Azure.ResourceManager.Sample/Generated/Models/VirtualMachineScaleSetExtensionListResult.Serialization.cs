// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class VirtualMachineScaleSetExtensionListResult
    {
        internal static VirtualMachineScaleSetExtensionListResult DeserializeVirtualMachineScaleSetExtensionListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<VirtualMachineScaleSetExtensionData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<VirtualMachineScaleSetExtensionData> array = new List<VirtualMachineScaleSetExtensionData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineScaleSetExtensionData.DeserializeVirtualMachineScaleSetExtensionData(item));
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
            return new VirtualMachineScaleSetExtensionListResult(value, nextLink.Value);
        }
    }
}
