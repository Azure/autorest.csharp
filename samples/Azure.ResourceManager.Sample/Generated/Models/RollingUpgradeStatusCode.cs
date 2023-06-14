// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Code indicating the current status of the upgrade.
    /// Serialized Name: RollingUpgradeStatusCode
    /// </summary>
    public enum RollingUpgradeStatusCode
    {
        /// <summary>
        /// RollingForward
        /// Serialized Name: RollingUpgradeStatusCode.RollingForward
        /// </summary>
        RollingForward,
        /// <summary>
        /// Cancelled
        /// Serialized Name: RollingUpgradeStatusCode.Cancelled
        /// </summary>
        Cancelled,
        /// <summary>
        /// Completed
        /// Serialized Name: RollingUpgradeStatusCode.Completed
        /// </summary>
        Completed,
        /// <summary>
        /// Faulted
        /// Serialized Name: RollingUpgradeStatusCode.Faulted
        /// </summary>
        Faulted
    }
}
