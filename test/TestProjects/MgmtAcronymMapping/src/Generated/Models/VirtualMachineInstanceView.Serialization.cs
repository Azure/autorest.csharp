// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;

namespace MgmtAcronymMapping.Models
{
    public partial class VirtualMachineInstanceView
    {
        internal static VirtualMachineInstanceView DeserializeVirtualMachineInstanceView(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? platformUpdateDomain = default;
            int? platformFaultDomain = default;
            string computerName = default;
            string osName = default;
            string osVersion = default;
            HyperVGenerationType? hyperVGeneration = default;
            string rdpThumbPrint = default;
            VirtualMachineAgentInstanceView vmAgent = default;
            MaintenanceRedeployStatus maintenanceRedeployStatus = default;
            IReadOnlyList<DiskInstanceView> disks = default;
            VirtualMachineHealthStatus vmHealth = default;
            BootDiagnosticsInstanceView bootDiagnostics = default;
            string assignedHost = default;
            IReadOnlyList<InstanceViewStatus> statuses = default;
            VirtualMachinePatchStatus patchStatus = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("platformUpdateDomain"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    platformUpdateDomain = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("platformFaultDomain"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    platformFaultDomain = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("computerName"u8))
                {
                    computerName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("osName"u8))
                {
                    osName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("osVersion"u8))
                {
                    osVersion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("hyperVGeneration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hyperVGeneration = new HyperVGenerationType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("rdpThumbPrint"u8))
                {
                    rdpThumbPrint = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("vmAgent"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    vmAgent = VirtualMachineAgentInstanceView.DeserializeVirtualMachineAgentInstanceView(property.Value);
                    continue;
                }
                if (property.NameEquals("maintenanceRedeployStatus"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maintenanceRedeployStatus = MaintenanceRedeployStatus.DeserializeMaintenanceRedeployStatus(property.Value);
                    continue;
                }
                if (property.NameEquals("disks"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
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
                if (property.NameEquals("vmHealth"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    vmHealth = VirtualMachineHealthStatus.DeserializeVirtualMachineHealthStatus(property.Value);
                    continue;
                }
                if (property.NameEquals("bootDiagnostics"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    bootDiagnostics = BootDiagnosticsInstanceView.DeserializeBootDiagnosticsInstanceView(property.Value);
                    continue;
                }
                if (property.NameEquals("assignedHost"u8))
                {
                    assignedHost = property.Value.GetString();
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
                if (property.NameEquals("patchStatus"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    patchStatus = VirtualMachinePatchStatus.DeserializeVirtualMachinePatchStatus(property.Value);
                    continue;
                }
            }
            return new VirtualMachineInstanceView(
                platformUpdateDomain,
                platformFaultDomain,
                computerName,
                osName,
                osVersion,
                hyperVGeneration,
                rdpThumbPrint,
                vmAgent,
                maintenanceRedeployStatus,
                disks ?? new ChangeTrackingList<DiskInstanceView>(),
                vmHealth,
                bootDiagnostics,
                assignedHost,
                statuses ?? new ChangeTrackingList<InstanceViewStatus>(),
                patchStatus);
        }
    }
}
