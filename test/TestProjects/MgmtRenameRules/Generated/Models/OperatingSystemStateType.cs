// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The OS State.
    /// Serialized Name: OperatingSystemStateTypes
    /// </summary>
    public enum OperatingSystemStateType
    {
        /// <summary>
        /// Generalized image. Needs to be provisioned during deployment time.
        /// Serialized Name: OperatingSystemStateTypes.Generalized
        /// </summary>
        Generalized,
        /// <summary>
        /// Specialized image. Contains already provisioned OS Disk.
        /// Serialized Name: OperatingSystemStateTypes.Specialized
        /// </summary>
        Specialized
    }
}
