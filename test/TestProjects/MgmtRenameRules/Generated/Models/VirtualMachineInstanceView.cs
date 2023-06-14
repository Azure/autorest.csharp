// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The instance view of a virtual machine.
    /// Serialized Name: VirtualMachineInstanceView
    /// </summary>
    public partial class VirtualMachineInstanceView
    {
        /// <summary> Initializes a new instance of VirtualMachineInstanceView. </summary>
        internal VirtualMachineInstanceView()
        {
            Disks = new ChangeTrackingList<DiskInstanceView>();
            Statuses = new ChangeTrackingList<InstanceViewStatus>();
        }

        /// <summary> Initializes a new instance of VirtualMachineInstanceView. </summary>
        /// <param name="platformUpdateDomain">
        /// Specifies the update domain of the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.platformUpdateDomain
        /// </param>
        /// <param name="platformFaultDomain">
        /// Specifies the fault domain of the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.platformFaultDomain
        /// </param>
        /// <param name="computerName">
        /// The computer name assigned to the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.computerName
        /// </param>
        /// <param name="osName">
        /// The Operating System running on the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.osName
        /// </param>
        /// <param name="osVersion">
        /// The version of Operating System running on the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.osVersion
        /// </param>
        /// <param name="hyperVGeneration">
        /// Specifies the HyperVGeneration Type associated with a resource
        /// Serialized Name: VirtualMachineInstanceView.hyperVGeneration
        /// </param>
        /// <param name="rdpThumbPrint">
        /// The Remote desktop certificate thumbprint.
        /// Serialized Name: VirtualMachineInstanceView.rdpThumbPrint
        /// </param>
        /// <param name="vmAgent">
        /// The VM Agent running on the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.vmAgent
        /// </param>
        /// <param name="maintenanceRedeployStatus">
        /// The Maintenance Operation status on the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.maintenanceRedeployStatus
        /// </param>
        /// <param name="disks">
        /// The virtual machine disk information.
        /// Serialized Name: VirtualMachineInstanceView.disks
        /// </param>
        /// <param name="vmHealth">
        /// The health status for the VM.
        /// Serialized Name: VirtualMachineInstanceView.vmHealth
        /// </param>
        /// <param name="bootDiagnostics">
        /// Boot Diagnostics is a debugging feature which allows you to view Console Output and Screenshot to diagnose VM status. &lt;br&gt;&lt;br&gt; You can easily view the output of your console log. &lt;br&gt;&lt;br&gt; Azure also enables you to see a screenshot of the VM from the hypervisor.
        /// Serialized Name: VirtualMachineInstanceView.bootDiagnostics
        /// </param>
        /// <param name="assignedHost">
        /// Resource id of the dedicated host, on which the virtual machine is allocated through automatic placement, when the virtual machine is associated with a dedicated host group that has automatic placement enabled. &lt;br&gt;&lt;br&gt;Minimum api-version: 2020-06-01.
        /// Serialized Name: VirtualMachineInstanceView.assignedHost
        /// </param>
        /// <param name="statuses">
        /// The resource status information.
        /// Serialized Name: VirtualMachineInstanceView.statuses
        /// </param>
        /// <param name="patchStatus">
        /// The status of virtual machine patch operations.
        /// Serialized Name: VirtualMachineInstanceView.patchStatus
        /// </param>
        internal VirtualMachineInstanceView(int? platformUpdateDomain, int? platformFaultDomain, string computerName, string osName, string osVersion, HyperVGenerationType? hyperVGeneration, string rdpThumbPrint, VirtualMachineAgentInstanceView vmAgent, MaintenanceRedeployStatus maintenanceRedeployStatus, IReadOnlyList<DiskInstanceView> disks, VirtualMachineHealthStatus vmHealth, BootDiagnosticsInstanceView bootDiagnostics, string assignedHost, IReadOnlyList<InstanceViewStatus> statuses, VirtualMachinePatchStatus patchStatus)
        {
            PlatformUpdateDomain = platformUpdateDomain;
            PlatformFaultDomain = platformFaultDomain;
            ComputerName = computerName;
            OSName = osName;
            OSVersion = osVersion;
            HyperVGeneration = hyperVGeneration;
            RdpThumbPrint = rdpThumbPrint;
            VmAgent = vmAgent;
            MaintenanceRedeployStatus = maintenanceRedeployStatus;
            Disks = disks;
            VmHealth = vmHealth;
            BootDiagnostics = bootDiagnostics;
            AssignedHost = assignedHost;
            Statuses = statuses;
            PatchStatus = patchStatus;
        }

        /// <summary>
        /// Specifies the update domain of the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.platformUpdateDomain
        /// </summary>
        public int? PlatformUpdateDomain { get; }
        /// <summary>
        /// Specifies the fault domain of the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.platformFaultDomain
        /// </summary>
        public int? PlatformFaultDomain { get; }
        /// <summary>
        /// The computer name assigned to the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.computerName
        /// </summary>
        public string ComputerName { get; }
        /// <summary>
        /// The Operating System running on the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.osName
        /// </summary>
        public string OSName { get; }
        /// <summary>
        /// The version of Operating System running on the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.osVersion
        /// </summary>
        public string OSVersion { get; }
        /// <summary>
        /// Specifies the HyperVGeneration Type associated with a resource
        /// Serialized Name: VirtualMachineInstanceView.hyperVGeneration
        /// </summary>
        public HyperVGenerationType? HyperVGeneration { get; }
        /// <summary>
        /// The Remote desktop certificate thumbprint.
        /// Serialized Name: VirtualMachineInstanceView.rdpThumbPrint
        /// </summary>
        public string RdpThumbPrint { get; }
        /// <summary>
        /// The VM Agent running on the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.vmAgent
        /// </summary>
        public VirtualMachineAgentInstanceView VmAgent { get; }
        /// <summary>
        /// The Maintenance Operation status on the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.maintenanceRedeployStatus
        /// </summary>
        public MaintenanceRedeployStatus MaintenanceRedeployStatus { get; }
        /// <summary>
        /// The virtual machine disk information.
        /// Serialized Name: VirtualMachineInstanceView.disks
        /// </summary>
        public IReadOnlyList<DiskInstanceView> Disks { get; }
        /// <summary>
        /// The health status for the VM.
        /// Serialized Name: VirtualMachineInstanceView.vmHealth
        /// </summary>
        internal VirtualMachineHealthStatus VmHealth { get; }
        /// <summary>
        /// The health status information for the VM.
        /// Serialized Name: VirtualMachineHealthStatus.status
        /// </summary>
        public InstanceViewStatus VmHealthStatus
        {
            get => VmHealth?.Status;
        }

        /// <summary>
        /// Boot Diagnostics is a debugging feature which allows you to view Console Output and Screenshot to diagnose VM status. &lt;br&gt;&lt;br&gt; You can easily view the output of your console log. &lt;br&gt;&lt;br&gt; Azure also enables you to see a screenshot of the VM from the hypervisor.
        /// Serialized Name: VirtualMachineInstanceView.bootDiagnostics
        /// </summary>
        public BootDiagnosticsInstanceView BootDiagnostics { get; }
        /// <summary>
        /// Resource id of the dedicated host, on which the virtual machine is allocated through automatic placement, when the virtual machine is associated with a dedicated host group that has automatic placement enabled. &lt;br&gt;&lt;br&gt;Minimum api-version: 2020-06-01.
        /// Serialized Name: VirtualMachineInstanceView.assignedHost
        /// </summary>
        public string AssignedHost { get; }
        /// <summary>
        /// The resource status information.
        /// Serialized Name: VirtualMachineInstanceView.statuses
        /// </summary>
        public IReadOnlyList<InstanceViewStatus> Statuses { get; }
        /// <summary>
        /// The status of virtual machine patch operations.
        /// Serialized Name: VirtualMachineInstanceView.patchStatus
        /// </summary>
        public VirtualMachinePatchStatus PatchStatus { get; }
    }
}
