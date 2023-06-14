// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The last action performed on the rolling upgrade.
    /// Serialized Name: RollingUpgradeActionType
    /// </summary>
    public enum RollingUpgradeActionType
    {
        /// <summary>
        /// Start
        /// Serialized Name: RollingUpgradeActionType.Start
        /// </summary>
        Start,
        /// <summary>
        /// Cancel
        /// Serialized Name: RollingUpgradeActionType.Cancel
        /// </summary>
        Cancel
    }
}
