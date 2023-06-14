// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtRenameRules.Models;

namespace MgmtRenameRules
{
    /// <summary>
    /// A class representing the VirtualMachineScaleSetRollingUpgrade data model.
    /// The status of the latest virtual machine scale set rolling upgrade.
    /// Serialized Name: RollingUpgradeStatusInfo
    /// </summary>
    public partial class VirtualMachineScaleSetRollingUpgradeData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetRollingUpgradeData. </summary>
        /// <param name="location"> The location. </param>
        public VirtualMachineScaleSetRollingUpgradeData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetRollingUpgradeData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="policy">
        /// The rolling upgrade policies applied for this upgrade.
        /// Serialized Name: RollingUpgradeStatusInfo.properties.policy
        /// </param>
        /// <param name="runningStatus">
        /// Information about the current running state of the overall upgrade.
        /// Serialized Name: RollingUpgradeStatusInfo.properties.runningStatus
        /// </param>
        /// <param name="progress">
        /// Information about the number of virtual machine instances in each upgrade state.
        /// Serialized Name: RollingUpgradeStatusInfo.properties.progress
        /// </param>
        /// <param name="error">
        /// Error details for this upgrade, if there are any.
        /// Serialized Name: RollingUpgradeStatusInfo.properties.error
        /// </param>
        internal VirtualMachineScaleSetRollingUpgradeData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, RollingUpgradePolicy policy, RollingUpgradeRunningStatus runningStatus, RollingUpgradeProgressInfo progress, ApiError error) : base(id, name, resourceType, systemData, tags, location)
        {
            Policy = policy;
            RunningStatus = runningStatus;
            Progress = progress;
            Error = error;
        }

        /// <summary>
        /// The rolling upgrade policies applied for this upgrade.
        /// Serialized Name: RollingUpgradeStatusInfo.properties.policy
        /// </summary>
        public RollingUpgradePolicy Policy { get; }
        /// <summary>
        /// Information about the current running state of the overall upgrade.
        /// Serialized Name: RollingUpgradeStatusInfo.properties.runningStatus
        /// </summary>
        public RollingUpgradeRunningStatus RunningStatus { get; }
        /// <summary>
        /// Information about the number of virtual machine instances in each upgrade state.
        /// Serialized Name: RollingUpgradeStatusInfo.properties.progress
        /// </summary>
        public RollingUpgradeProgressInfo Progress { get; }
        /// <summary>
        /// Error details for this upgrade, if there are any.
        /// Serialized Name: RollingUpgradeStatusInfo.properties.error
        /// </summary>
        public ApiError Error { get; }
    }
}
