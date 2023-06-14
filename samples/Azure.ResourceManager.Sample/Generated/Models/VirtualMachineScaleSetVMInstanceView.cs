// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The instance view of a virtual machine scale set VM.
    /// Serialized Name: VirtualMachineScaleSetVMInstanceView
    /// </summary>
    public partial class VirtualMachineScaleSetVMInstanceView
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetVMInstanceView. </summary>
        internal VirtualMachineScaleSetVMInstanceView()
        {
            Disks = new ChangeTrackingList<DiskInstanceView>();
            Extensions = new ChangeTrackingList<VirtualMachineExtensionInstanceView>();
            Statuses = new ChangeTrackingList<InstanceViewStatus>();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetVMInstanceView. </summary>
        /// <param name="platformUpdateDomain">
        /// The Update Domain count.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.platformUpdateDomain
        /// </param>
        /// <param name="platformFaultDomain">
        /// The Fault Domain count.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.platformFaultDomain
        /// </param>
        /// <param name="rdpThumbPrint">
        /// The Remote desktop certificate thumbprint.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.rdpThumbPrint
        /// </param>
        /// <param name="vmAgent">
        /// The VM Agent running on the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.vmAgent
        /// </param>
        /// <param name="maintenanceRedeployStatus">
        /// The Maintenance Operation status on the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.maintenanceRedeployStatus
        /// </param>
        /// <param name="disks">
        /// The disks information.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.disks
        /// </param>
        /// <param name="extensions">
        /// The extensions information.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.extensions
        /// </param>
        /// <param name="vmHealth">
        /// The health status for the VM.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.vmHealth
        /// </param>
        /// <param name="bootDiagnostics">
        /// Boot Diagnostics is a debugging feature which allows you to view Console Output and Screenshot to diagnose VM status. &lt;br&gt;&lt;br&gt; You can easily view the output of your console log. &lt;br&gt;&lt;br&gt; Azure also enables you to see a screenshot of the VM from the hypervisor.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.bootDiagnostics
        /// </param>
        /// <param name="statuses">
        /// The resource status information.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.statuses
        /// </param>
        /// <param name="assignedHost">
        /// Resource id of the dedicated host, on which the virtual machine is allocated through automatic placement, when the virtual machine is associated with a dedicated host group that has automatic placement enabled. &lt;br&gt;&lt;br&gt;Minimum api-version: 2020-06-01.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.assignedHost
        /// </param>
        /// <param name="placementGroupId">
        /// The placement group in which the VM is running. If the VM is deallocated it will not have a placementGroupId.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.placementGroupId
        /// </param>
        internal VirtualMachineScaleSetVMInstanceView(int? platformUpdateDomain, int? platformFaultDomain, string rdpThumbPrint, VirtualMachineAgentInstanceView vmAgent, MaintenanceRedeployStatus maintenanceRedeployStatus, IReadOnlyList<DiskInstanceView> disks, IReadOnlyList<VirtualMachineExtensionInstanceView> extensions, VirtualMachineHealthStatus vmHealth, BootDiagnosticsInstanceView bootDiagnostics, IReadOnlyList<InstanceViewStatus> statuses, string assignedHost, string placementGroupId)
        {
            PlatformUpdateDomain = platformUpdateDomain;
            PlatformFaultDomain = platformFaultDomain;
            RdpThumbPrint = rdpThumbPrint;
            VmAgent = vmAgent;
            MaintenanceRedeployStatus = maintenanceRedeployStatus;
            Disks = disks;
            Extensions = extensions;
            VmHealth = vmHealth;
            BootDiagnostics = bootDiagnostics;
            Statuses = statuses;
            AssignedHost = assignedHost;
            PlacementGroupId = placementGroupId;
        }

        /// <summary>
        /// The Update Domain count.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.platformUpdateDomain
        /// </summary>
        public int? PlatformUpdateDomain { get; }
        /// <summary>
        /// The Fault Domain count.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.platformFaultDomain
        /// </summary>
        public int? PlatformFaultDomain { get; }
        /// <summary>
        /// The Remote desktop certificate thumbprint.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.rdpThumbPrint
        /// </summary>
        public string RdpThumbPrint { get; }
        /// <summary>
        /// The VM Agent running on the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.vmAgent
        /// </summary>
        public VirtualMachineAgentInstanceView VmAgent { get; }
        /// <summary>
        /// The Maintenance Operation status on the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.maintenanceRedeployStatus
        /// </summary>
        public MaintenanceRedeployStatus MaintenanceRedeployStatus { get; }
        /// <summary>
        /// The disks information.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.disks
        /// </summary>
        public IReadOnlyList<DiskInstanceView> Disks { get; }
        /// <summary>
        /// The extensions information.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.extensions
        /// </summary>
        public IReadOnlyList<VirtualMachineExtensionInstanceView> Extensions { get; }
        /// <summary>
        /// The health status for the VM.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.vmHealth
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
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.bootDiagnostics
        /// </summary>
        public BootDiagnosticsInstanceView BootDiagnostics { get; }
        /// <summary>
        /// The resource status information.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.statuses
        /// </summary>
        public IReadOnlyList<InstanceViewStatus> Statuses { get; }
        /// <summary>
        /// Resource id of the dedicated host, on which the virtual machine is allocated through automatic placement, when the virtual machine is associated with a dedicated host group that has automatic placement enabled. &lt;br&gt;&lt;br&gt;Minimum api-version: 2020-06-01.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.assignedHost
        /// </summary>
        public string AssignedHost { get; }
        /// <summary>
        /// The placement group in which the VM is running. If the VM is deallocated it will not have a placementGroupId.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.placementGroupId
        /// </summary>
        public string PlacementGroupId { get; }
    }
}
