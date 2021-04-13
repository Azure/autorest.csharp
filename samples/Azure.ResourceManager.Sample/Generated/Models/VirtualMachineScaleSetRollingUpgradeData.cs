// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing the VirtualMachineScaleSetRollingUpgrade data model. </summary>
    public partial class VirtualMachineScaleSetRollingUpgradeData : TrackedResource<TenantResourceIdentifier>
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetRollingUpgradeData. </summary>
        public VirtualMachineScaleSetRollingUpgradeData()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetRollingUpgradeData. </summary>
        /// <param name="policy"> The rolling upgrade policies applied for this upgrade. </param>
        /// <param name="runningStatus"> Information about the current running state of the overall upgrade. </param>
        /// <param name="progress"> Information about the number of virtual machine instances in each upgrade state. </param>
        /// <param name="error"> Error details for this upgrade, if there are any. </param>
        internal VirtualMachineScaleSetRollingUpgradeData(RollingUpgradePolicy policy, RollingUpgradeRunningStatus runningStatus, RollingUpgradeProgressInfo progress, ApiError error)
        {
            Policy = policy;
            RunningStatus = runningStatus;
            Progress = progress;
            Error = error;
        }

        /// <summary> ARM resource type. </summary>
        public static ResourceType ResourceType => "todo: find out resource type";

        /// <summary> The rolling upgrade policies applied for this upgrade. </summary>
        public RollingUpgradePolicy Policy { get; }
        /// <summary> Information about the current running state of the overall upgrade. </summary>
        public RollingUpgradeRunningStatus RunningStatus { get; }
        /// <summary> Information about the number of virtual machine instances in each upgrade state. </summary>
        public RollingUpgradeProgressInfo Progress { get; }
        /// <summary> Error details for this upgrade, if there are any. </summary>
        public ApiError Error { get; }
    }
}
