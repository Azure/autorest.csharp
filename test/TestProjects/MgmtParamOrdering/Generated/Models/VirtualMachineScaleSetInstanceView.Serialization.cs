// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtParamOrdering.Models
{
    public partial class VirtualMachineScaleSetInstanceView
    {
        internal static VirtualMachineScaleSetInstanceView DeserializeVirtualMachineScaleSetInstanceView(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> virtualMachine = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("virtualMachine"u8))
                {
                    virtualMachine = property.Value.GetString();
                    continue;
                }
            }
            return new VirtualMachineScaleSetInstanceView(virtualMachine.Value);
        }
    }
}
