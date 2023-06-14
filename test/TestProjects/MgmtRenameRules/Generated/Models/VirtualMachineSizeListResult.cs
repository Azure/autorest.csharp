// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The List Virtual Machine operation response.
    /// Serialized Name: VirtualMachineSizeListResult
    /// </summary>
    internal partial class VirtualMachineSizeListResult
    {
        /// <summary> Initializes a new instance of VirtualMachineSizeListResult. </summary>
        internal VirtualMachineSizeListResult()
        {
            Value = new ChangeTrackingList<VirtualMachineSize>();
        }

        /// <summary> Initializes a new instance of VirtualMachineSizeListResult. </summary>
        /// <param name="value">
        /// The list of virtual machine sizes.
        /// Serialized Name: VirtualMachineSizeListResult.value
        /// </param>
        internal VirtualMachineSizeListResult(IReadOnlyList<VirtualMachineSize> value)
        {
            Value = value;
        }

        /// <summary>
        /// The list of virtual machine sizes.
        /// Serialized Name: VirtualMachineSizeListResult.value
        /// </summary>
        public IReadOnlyList<VirtualMachineSize> Value { get; }
    }
}
