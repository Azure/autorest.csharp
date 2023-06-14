// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineScaleSetSku
    {
        internal static VirtualMachineScaleSetSku DeserializeVirtualMachineScaleSetSku(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ResourceType> resourceType = default;
            Optional<SampleSku> sku = default;
            Optional<VirtualMachineScaleSetSkuCapacity> capacity = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("resourceType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    resourceType = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("sku"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sku = SampleSku.DeserializeSampleSku(property.Value);
                    continue;
                }
                if (property.NameEquals("capacity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    capacity = VirtualMachineScaleSetSkuCapacity.DeserializeVirtualMachineScaleSetSkuCapacity(property.Value);
                    continue;
                }
            }
            return new VirtualMachineScaleSetSku(Optional.ToNullable(resourceType), sku.Value, capacity.Value);
        }
    }
}
