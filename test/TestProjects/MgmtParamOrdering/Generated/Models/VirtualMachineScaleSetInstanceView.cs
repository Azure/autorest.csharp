// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtParamOrdering.Models
{
    /// <summary> The instance view of a virtual machine scale set. </summary>
    public partial class VirtualMachineScaleSetInstanceView
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetInstanceView. </summary>
        internal VirtualMachineScaleSetInstanceView()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetInstanceView. </summary>
        /// <param name="virtualMachine"> The instance view status summary for the virtual machine scale set. </param>
        internal VirtualMachineScaleSetInstanceView(string virtualMachine)
        {
            VirtualMachine = virtualMachine;
        }

        /// <summary> The instance view status summary for the virtual machine scale set. </summary>
        public string VirtualMachine { get; }
    }
}
