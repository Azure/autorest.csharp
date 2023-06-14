// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Information about the current running state of the overall upgrade.
    /// Serialized Name: UpgradeOperationHistoryStatus
    /// </summary>
    public partial class UpgradeOperationHistoryStatus
    {
        /// <summary> Initializes a new instance of UpgradeOperationHistoryStatus. </summary>
        internal UpgradeOperationHistoryStatus()
        {
        }

        /// <summary> Initializes a new instance of UpgradeOperationHistoryStatus. </summary>
        /// <param name="code">
        /// Code indicating the current status of the upgrade.
        /// Serialized Name: UpgradeOperationHistoryStatus.code
        /// </param>
        /// <param name="startOn">
        /// Start time of the upgrade.
        /// Serialized Name: UpgradeOperationHistoryStatus.startTime
        /// </param>
        /// <param name="endOn">
        /// End time of the upgrade.
        /// Serialized Name: UpgradeOperationHistoryStatus.endTime
        /// </param>
        internal UpgradeOperationHistoryStatus(UpgradeState? code, DateTimeOffset? startOn, DateTimeOffset? endOn)
        {
            Code = code;
            StartOn = startOn;
            EndOn = endOn;
        }

        /// <summary>
        /// Code indicating the current status of the upgrade.
        /// Serialized Name: UpgradeOperationHistoryStatus.code
        /// </summary>
        public UpgradeState? Code { get; }
        /// <summary>
        /// Start time of the upgrade.
        /// Serialized Name: UpgradeOperationHistoryStatus.startTime
        /// </summary>
        public DateTimeOffset? StartOn { get; }
        /// <summary>
        /// End time of the upgrade.
        /// Serialized Name: UpgradeOperationHistoryStatus.endTime
        /// </summary>
        public DateTimeOffset? EndOn { get; }
    }
}
