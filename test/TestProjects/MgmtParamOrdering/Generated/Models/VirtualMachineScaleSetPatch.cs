// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtParamOrdering.Models
{
    /// <summary> Describes a Virtual Machine Scale Set. </summary>
    public partial class VirtualMachineScaleSetPatch : UpdateResource
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetPatch. </summary>
        public VirtualMachineScaleSetPatch()
        {
        }

        /// <summary> The virtual machine scale set sku. </summary>
        public MgmtParamOrderingSku Sku { get; set; }
    }
}
