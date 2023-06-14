// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The health status of the VM.
    /// Serialized Name: VirtualMachineHealthStatus
    /// </summary>
    internal partial class VirtualMachineHealthStatus
    {
        /// <summary> Initializes a new instance of VirtualMachineHealthStatus. </summary>
        internal VirtualMachineHealthStatus()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineHealthStatus. </summary>
        /// <param name="status">
        /// The health status information for the VM.
        /// Serialized Name: VirtualMachineHealthStatus.status
        /// </param>
        internal VirtualMachineHealthStatus(InstanceViewStatus status)
        {
            Status = status;
        }

        /// <summary>
        /// The health status information for the VM.
        /// Serialized Name: VirtualMachineHealthStatus.status
        /// </summary>
        public InstanceViewStatus Status { get; }
    }
}
