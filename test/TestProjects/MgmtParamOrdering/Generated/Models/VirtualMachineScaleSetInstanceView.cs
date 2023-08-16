// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtParamOrdering.Models
{
    /// <summary> The instance view of a virtual machine scale set. </summary>
    public partial class VirtualMachineScaleSetInstanceView
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtParamOrdering.Models.VirtualMachineScaleSetInstanceView
        ///
        /// </summary>
        internal VirtualMachineScaleSetInstanceView()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtParamOrdering.Models.VirtualMachineScaleSetInstanceView
        ///
        /// </summary>
        /// <param name="virtualMachine"> The instance view status summary for the virtual machine scale set. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetInstanceView(string virtualMachine, Dictionary<string, BinaryData> rawData)
        {
            VirtualMachine = virtualMachine;
            _rawData = rawData;
        }

        /// <summary> The instance view status summary for the virtual machine scale set. </summary>
        public string VirtualMachine { get; }
    }
}
