// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Information about the number of virtual machine instances in each upgrade state.
    /// Serialized Name: RollingUpgradeProgressInfo
    /// </summary>
    public partial class RollingUpgradeProgressInfo
    {
        /// <summary> Initializes a new instance of RollingUpgradeProgressInfo. </summary>
        internal RollingUpgradeProgressInfo()
        {
        }

        /// <summary> Initializes a new instance of RollingUpgradeProgressInfo. </summary>
        /// <param name="successfulInstanceCount">
        /// The number of instances that have been successfully upgraded.
        /// Serialized Name: RollingUpgradeProgressInfo.successfulInstanceCount
        /// </param>
        /// <param name="failedInstanceCount">
        /// The number of instances that have failed to be upgraded successfully.
        /// Serialized Name: RollingUpgradeProgressInfo.failedInstanceCount
        /// </param>
        /// <param name="inProgressInstanceCount">
        /// The number of instances that are currently being upgraded.
        /// Serialized Name: RollingUpgradeProgressInfo.inProgressInstanceCount
        /// </param>
        /// <param name="pendingInstanceCount">
        /// The number of instances that have not yet begun to be upgraded.
        /// Serialized Name: RollingUpgradeProgressInfo.pendingInstanceCount
        /// </param>
        internal RollingUpgradeProgressInfo(int? successfulInstanceCount, int? failedInstanceCount, int? inProgressInstanceCount, int? pendingInstanceCount)
        {
            SuccessfulInstanceCount = successfulInstanceCount;
            FailedInstanceCount = failedInstanceCount;
            InProgressInstanceCount = inProgressInstanceCount;
            PendingInstanceCount = pendingInstanceCount;
        }

        /// <summary>
        /// The number of instances that have been successfully upgraded.
        /// Serialized Name: RollingUpgradeProgressInfo.successfulInstanceCount
        /// </summary>
        public int? SuccessfulInstanceCount { get; }
        /// <summary>
        /// The number of instances that have failed to be upgraded successfully.
        /// Serialized Name: RollingUpgradeProgressInfo.failedInstanceCount
        /// </summary>
        public int? FailedInstanceCount { get; }
        /// <summary>
        /// The number of instances that are currently being upgraded.
        /// Serialized Name: RollingUpgradeProgressInfo.inProgressInstanceCount
        /// </summary>
        public int? InProgressInstanceCount { get; }
        /// <summary>
        /// The number of instances that have not yet begun to be upgraded.
        /// Serialized Name: RollingUpgradeProgressInfo.pendingInstanceCount
        /// </summary>
        public int? PendingInstanceCount { get; }
    }
}
