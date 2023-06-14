// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineScaleSetInstanceView
    {
        internal static VirtualMachineScaleSetInstanceView DeserializeVirtualMachineScaleSetInstanceView(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<VirtualMachineScaleSetInstanceViewStatusesSummary> virtualMachine = default;
            Optional<IReadOnlyList<VirtualMachineScaleSetVMExtensionsSummary>> extensions = default;
            Optional<IReadOnlyList<InstanceViewStatus>> statuses = default;
            Optional<IReadOnlyList<OrchestrationServiceSummary>> orchestrationServices = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("virtualMachine"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    virtualMachine = VirtualMachineScaleSetInstanceViewStatusesSummary.DeserializeVirtualMachineScaleSetInstanceViewStatusesSummary(property.Value);
                    continue;
                }
                if (property.NameEquals("extensions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VirtualMachineScaleSetVMExtensionsSummary> array = new List<VirtualMachineScaleSetVMExtensionsSummary>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineScaleSetVMExtensionsSummary.DeserializeVirtualMachineScaleSetVMExtensionsSummary(item));
                    }
                    extensions = array;
                    continue;
                }
                if (property.NameEquals("statuses"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InstanceViewStatus> array = new List<InstanceViewStatus>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InstanceViewStatus.DeserializeInstanceViewStatus(item));
                    }
                    statuses = array;
                    continue;
                }
                if (property.NameEquals("orchestrationServices"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<OrchestrationServiceSummary> array = new List<OrchestrationServiceSummary>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(OrchestrationServiceSummary.DeserializeOrchestrationServiceSummary(item));
                    }
                    orchestrationServices = array;
                    continue;
                }
            }
            return new VirtualMachineScaleSetInstanceView(virtualMachine.Value, Optional.ToList(extensions), Optional.ToList(statuses), Optional.ToList(orchestrationServices));
        }
    }
}
