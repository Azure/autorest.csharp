// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class VirtualMachineScaleSetListSkusResult
    {
        internal static VirtualMachineScaleSetListSkusResult DeserializeVirtualMachineScaleSetListSkusResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<VirtualMachineScaleSetSku> vmssSkus = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("VmssSkus"u8))
                {
                    List<VirtualMachineScaleSetSku> array = new List<VirtualMachineScaleSetSku>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineScaleSetSku.DeserializeVirtualMachineScaleSetSku(item));
                    }
                    vmssSkus = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new VirtualMachineScaleSetListSkusResult(vmssSkus, nextLink.Value);
        }
    }
}
