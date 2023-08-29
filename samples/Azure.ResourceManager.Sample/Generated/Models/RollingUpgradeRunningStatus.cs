// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Information about the current running state of the overall upgrade.
    /// Serialized Name: RollingUpgradeRunningStatus
    /// </summary>
    public partial class RollingUpgradeRunningStatus
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="RollingUpgradeRunningStatus"/>. </summary>
        internal RollingUpgradeRunningStatus()
        {
        }

        /// <summary> Initializes a new instance of <see cref="RollingUpgradeRunningStatus"/>. </summary>
        /// <param name="code">
        /// Code indicating the current status of the upgrade.
        /// Serialized Name: RollingUpgradeRunningStatus.code
        /// </param>
        /// <param name="startOn">
        /// Start time of the upgrade.
        /// Serialized Name: RollingUpgradeRunningStatus.startTime
        /// </param>
        /// <param name="lastAction">
        /// The last action performed on the rolling upgrade.
        /// Serialized Name: RollingUpgradeRunningStatus.lastAction
        /// </param>
        /// <param name="lastActionOn">
        /// Last action time of the upgrade.
        /// Serialized Name: RollingUpgradeRunningStatus.lastActionTime
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal RollingUpgradeRunningStatus(RollingUpgradeStatusCode? code, DateTimeOffset? startOn, RollingUpgradeActionType? lastAction, DateTimeOffset? lastActionOn, Dictionary<string, BinaryData> rawData)
        {
            Code = code;
            StartOn = startOn;
            LastAction = lastAction;
            LastActionOn = lastActionOn;
            _rawData = rawData;
        }

        /// <summary>
        /// Code indicating the current status of the upgrade.
        /// Serialized Name: RollingUpgradeRunningStatus.code
        /// </summary>
        public RollingUpgradeStatusCode? Code { get; }
        /// <summary>
        /// Start time of the upgrade.
        /// Serialized Name: RollingUpgradeRunningStatus.startTime
        /// </summary>
        public DateTimeOffset? StartOn { get; }
        /// <summary>
        /// The last action performed on the rolling upgrade.
        /// Serialized Name: RollingUpgradeRunningStatus.lastAction
        /// </summary>
        public RollingUpgradeActionType? LastAction { get; }
        /// <summary>
        /// Last action time of the upgrade.
        /// Serialized Name: RollingUpgradeRunningStatus.lastActionTime
        /// </summary>
        public DateTimeOffset? LastActionOn { get; }
    }
}
