// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineInstanceView
    {
        internal static VirtualMachineInstanceView DeserializeVirtualMachineInstanceView(JsonElement element)
        {
            Optional<int> platformUpdateDomain = default;
            Optional<int> platformFaultDomain = default;
            Optional<string> computerName = default;
            Optional<string> osName = default;
            Optional<string> osVersion = default;
            Optional<HyperVGeneration> hyperVGeneration = default;
            Optional<string> rdpThumbPrint = default;
            Optional<VirtualMachineAgentInstanceView> vmAgent = default;
            Optional<MaintenanceRedeployStatus> maintenanceRedeployStatus = default;
            Optional<IReadOnlyList<DiskInstanceView>> disks = default;
            Optional<IReadOnlyList<VirtualMachineExtensionInstanceView>> extensions = default;
            Optional<VirtualMachineHealthStatus> vmHealth = default;
            Optional<BootDiagnosticsInstanceView> bootDiagnostics = default;
            Optional<string> assignedHost = default;
            Optional<IReadOnlyList<InstanceViewStatus>> statuses = default;
            Optional<VirtualMachinePatchStatus> patchStatus = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("platformUpdateDomain"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    platformUpdateDomain = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("platformFaultDomain"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    platformFaultDomain = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("computerName"))
                {
                    computerName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("osName"))
                {
                    osName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("osVersion"))
                {
                    osVersion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("hyperVGeneration"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    hyperVGeneration = new HyperVGeneration(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("rdpThumbPrint"))
                {
                    rdpThumbPrint = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("vmAgent"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    vmAgent = VirtualMachineAgentInstanceView.DeserializeVirtualMachineAgentInstanceView(property.Value);
                    continue;
                }
                if (property.NameEquals("maintenanceRedeployStatus"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    maintenanceRedeployStatus = MaintenanceRedeployStatus.DeserializeMaintenanceRedeployStatus(property.Value);
                    continue;
                }
                if (property.NameEquals("disks"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<DiskInstanceView> array = new List<DiskInstanceView>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DiskInstanceView.DeserializeDiskInstanceView(item));
                    }
                    disks = array;
                    continue;
                }
                if (property.NameEquals("extensions"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<VirtualMachineExtensionInstanceView> array = new List<VirtualMachineExtensionInstanceView>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineExtensionInstanceView.DeserializeVirtualMachineExtensionInstanceView(item));
                    }
                    extensions = array;
                    continue;
                }
                if (property.NameEquals("vmHealth"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    vmHealth = VirtualMachineHealthStatus.DeserializeVirtualMachineHealthStatus(property.Value);
                    continue;
                }
                if (property.NameEquals("bootDiagnostics"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    bootDiagnostics = BootDiagnosticsInstanceView.DeserializeBootDiagnosticsInstanceView(property.Value);
                    continue;
                }
                if (property.NameEquals("assignedHost"))
                {
                    assignedHost = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("statuses"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
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
                if (property.NameEquals("patchStatus"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    patchStatus = VirtualMachinePatchStatus.DeserializeVirtualMachinePatchStatus(property.Value);
                    continue;
                }
            }
            return new VirtualMachineInstanceView(Optional.ToNullable(platformUpdateDomain), Optional.ToNullable(platformFaultDomain), computerName.Value, osName.Value, osVersion.Value, Optional.ToNullable(hyperVGeneration), rdpThumbPrint.Value, vmAgent.Value, maintenanceRedeployStatus.Value, Optional.ToList(disks), Optional.ToList(extensions), vmHealth.Value, bootDiagnostics.Value, assignedHost.Value, Optional.ToList(statuses), patchStatus.Value);
        }
    }
}
