// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing the VirtualMachineScaleSetRollingUpgrade data model. </summary>
    public partial class VirtualMachineScaleSetRollingUpgradeData : TrackedResource
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetRollingUpgradeData. </summary>
        /// <param name="location"> The location. </param>
        public VirtualMachineScaleSetRollingUpgradeData(Location location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetRollingUpgradeData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="policy"> The rolling upgrade policies applied for this upgrade. </param>
        /// <param name="runningStatus"> Information about the current running state of the overall upgrade. </param>
        /// <param name="progress"> Information about the number of virtual machine instances in each upgrade state. </param>
        /// <param name="error"> Error details for this upgrade, if there are any. </param>
        internal VirtualMachineScaleSetRollingUpgradeData(ResourceIdentifier id, string name, ResourceType type, IDictionary<string, string> tags, Location location, RollingUpgradePolicy policy, RollingUpgradeRunningStatus runningStatus, RollingUpgradeProgressInfo progress, ApiError error) : base(id, name, type, tags, location)
        {
            Policy = policy;
            RunningStatus = runningStatus;
            Progress = progress;
            Error = error;
        }

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
